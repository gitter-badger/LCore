using System;
using System.Collections.Generic;
// ReSharper disable once RedundantUsingDirective
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Threading;

using LCore.Extensions;
// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace LCore.Web
    {
    /// <summary>
    /// FileProcessor is used to process byte data from a multi-part form and save it to the disk.
    /// </summary>
    public class FileProcessor : IDisposable
        {
        #region Class Vars

        /// <summary>
        /// Default folder to where the files are to be uploaded.
        /// </summary>
        private string _CurrentFilePath;

        /// <summary>
        /// Form post id is used in finding field separators in the multi-part form post
        /// </summary>
        private string _FormPostID = "";
        /// <summary>
        /// Used to find the start of a file
        /// </summary>
        private string _FieldSeparator = "";

        /// <summary>
        /// Used to note what buffer index we are on in the collection
        /// </summary>
        private long _CurrentBufferIndex;

        /// <summary>
        /// Used to flag each byte process if we have already found the start of a file or not
        /// </summary>
        private bool _StartFound;

        /// <summary>
        /// Used to flag each byte process if we have already found the end of a file.
        /// </summary>
        private bool _EndFound;

        /// <summary>
        /// Default file name
        /// </summary>
        private string _CurrentFileName = $"{Guid.NewGuid()}.bin";
        private string FullPath => L.File.CombinePaths(this._CurrentFilePath, this._CurrentFileName);

        /// <summary>
        /// FileStream object that is left open while a file is beting written to.  Each file will open and 
        /// close its filestream automatically
        /// </summary>
        private FileStream _FileStream;

        /// <summary>
        /// The following fields are used in the byte searching of buffer datas
        /// </summary>
        private long _StartIndexBufferID = -1;
        private int _StartLocationInBufferID = -1;

        private long _EndIndexBufferID = -1;
        private int _EndLocationInBufferID = -1;


        /// <summary>
        /// Dictionary array used to store byte chunks.
        /// Should store a max of 2 items.  2 history chunks are kept.
        /// </summary>
        private Dictionary<long, byte[]> _BufferHistory = new Dictionary<long, byte[]>();

        /// <summary>
        /// Object to hold all the finished filenames.
        /// </summary>
        private List<string> _FinishedFiles = new List<string>();

        // ReSharper disable once NotAccessedField.Local
        private Timer _Timer;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor with the path of where the files should be uploaded.
        /// </summary>
        public FileProcessor(string UploadLocation)
            {
            // This is the path where the files will be uploaded too.
            this._CurrentFilePath = UploadLocation;
            //	if (!File.Exists(_fullPath))
            //		{
            //		_fileStream = File.Create(_fullPath);
            //		}
            }

        #endregion

        #region Properties

        /// <summary>
        /// Property used to get the finished files.
        /// </summary>
        public List<string> FinishedFiles => this._FinishedFiles;

        #endregion

        #region Methods

        /// <summary>
        /// Method that is used to process the buffer.  
        /// </summary>
        /// <param name="BufferData">Byte data to scan</param>
        /// <param name="AddToBufferHistory">If true, it will add it to the buffer history. If false, it will not.</param>
        public void ProcessBuffer(ref byte[] BufferData, bool AddToBufferHistory)
            {
            int ByteLocation = -1;

            // If the start has not been found, search for it.
            if (!this._StartFound)
                {
                // Search for start location
                ByteLocation = this.GetStartBytePosition(ref BufferData);
                if (ByteLocation != -1)
                    {
                    // Set the start position to this current index
                    this._StartIndexBufferID = this._CurrentBufferIndex + 1;
                    // Set the start location in the index
                    this._StartLocationInBufferID = ByteLocation;

                    this._StartFound = true;

                    }
                }

            // If the start was found, we can start to store the data into a file.
            if (this._StartFound)
                {
                // Save this data to a file
                // Have to find the end point.  Makes sure the end is not in the same buffer

                int StartLocation = 0;
                if (ByteLocation != -1)
                    {
                    StartLocation = ByteLocation;
                    }

                // Write the data from the start point to the end point to the file.

                int WriteBytes = BufferData.Length - StartLocation;
                int TempEndByte = this.GetEndBytePosition(ref BufferData);
                if (TempEndByte != -1)
                    {
                    WriteBytes = TempEndByte - StartLocation;
                    // not that the end was found.
                    this._EndFound = true;
                    // Set the current index the file was found
                    this._EndIndexBufferID = this._CurrentBufferIndex + 1;
                    // Set the current byte location for the associated index the file was found
                    this._EndLocationInBufferID = TempEndByte;
                    }

                // Make sure we have something to write.
                if (WriteBytes > 0)
                    {
                    if (this._FileStream == null)
                        {
                        // create a new file stream to be used.
                        this._FileStream = new FileStream(L.File.CombinePaths(this._CurrentFilePath, this._CurrentFileName), FileMode.OpenOrCreate);

                        // this will create a time to live for the file so it will automatically be removed
                        const int FileTimeToLive = 3600;


                        // if the form were not to handle the file and remove it, this is an automatic removal of the file
                        // the timer object will execute in x number of seconds
                        this._Timer = new Timer(DeleteFile, this._CurrentFilePath + this._CurrentFileName, FileTimeToLive * 1000, 0);

                        }
                    // Write the datat to the file and flush it.
                    this._FileStream.Write(BufferData, StartLocation, WriteBytes);
                    this._FileStream.Flush();
                    }
                }

            // If the end was found, then we need to close the stream now that we are done with it.
            // We will also re-process this buffer to make sure the start of another file 
            // is not located within it.
            if (this._EndFound)
                {
                this.CloseStreams();
                this._StartFound = false;
                this._EndFound = false;

                // Research the current buffer for a new start location.  
                this.ProcessBuffer(ref BufferData, false);
                }

            // Add to buffer history
            if (AddToBufferHistory)
                {
                // Add to history object.
                this._BufferHistory.Add(this._CurrentBufferIndex, BufferData);
                this._CurrentBufferIndex++;
                // Cleanup old buffer references
                this.RemoveOldBufferData();
                }
            }

        /// <summary>
        /// Method used to clean up the internal buffer array.  
        /// Older elements are not needed, only a history of one is needed.
        /// </summary>
        private void RemoveOldBufferData()
            {
            for (long BufferIndex = this._CurrentBufferIndex; BufferIndex >= 0; BufferIndex--)
                {
                if (BufferIndex > this._CurrentBufferIndex - 3)
                    {
                    // Dont touch. preserving the last 2 items.
                    }
                else
                    {
                    if (this._BufferHistory.ContainsKey(BufferIndex))
                        {
                        this._BufferHistory.Remove(BufferIndex);
                        }
                    else
                        {
                        // no more previous buffers. 
                        BufferIndex = 0;
                        }
                    }
                }
            GC.Collect();
            }

        /// <summary>
        /// Close the stream, and reset the filename.
        /// </summary>
        public void CloseStreams()
            {
            if (this._FileStream != null)
                {
                this._FileStream.Dispose();
                this._FileStream.Close();
                this._FileStream = null;

                // add the file name to the finished list.
                this._FinishedFiles.Add(L.File.CombinePaths(this._CurrentFilePath, this._CurrentFileName));

                // Reset the filename.
                this._CurrentFileName = $"{Guid.NewGuid()}.bin";
                }
            }

        /// <summary>
        /// Method should be ran on the bytes that are returned on GetPreloadedEntityBody().
        /// </summary>
        /// <param name="BufferData"></param>
        public void GetFieldSeparators(ref byte[] BufferData)
            {
            try
                {
                this._FormPostID = Encoding.UTF8.GetString(BufferData).Sub(29, 13);
                this._FieldSeparator = $"-----------------------------{this._FormPostID}";
                }
            // ReSharper disable once UnusedVariable
            catch (Exception Ex)
                {
#if DEBUG
                Debug.WriteLine($"Error in GetFieldSeperators(): {Ex.Message}");
#endif
                }
            }

        /// <summary>
        /// Method used for searching buffer data, and if needed previous buffer data.
        /// </summary>
        /// <param name="BufferData">current buffer data need to be processed.</param>
        /// <returns>Returns byte location of data to start</returns>
        private int GetStartBytePosition(ref byte[] BufferData)
            {

            int ByteOffset = 0;
            // Check to see if the current bufferIndex is the same as any previous index found.
            // If it is, offset the searching by the previous location
            if (this._StartIndexBufferID == this._CurrentBufferIndex + 1)
                {
                ByteOffset = this._StartLocationInBufferID;
                }

            // Check to see if the end index was found before this start index.  That way we keep moving ahead
            if (this._EndIndexBufferID == this._CurrentBufferIndex + 1)
                {
                ByteOffset = this._EndLocationInBufferID;
                }


            byte[] SearchString = Encoding.UTF8.GetBytes("Content-Type: ");
            int TempContentTypeStart = FindBytePattern(ref BufferData, ref SearchString, ByteOffset);

            if (TempContentTypeStart != -1)
                {
                // Found content type start location
                // Next search for \r\n\r\n at this substring

                SearchString = Encoding.UTF8.GetBytes("\r\n\r\n");
                int TempSearchStringLocation = FindBytePattern(ref BufferData, ref SearchString, TempContentTypeStart);

                if (TempSearchStringLocation != -1)
                    {
                    // Found this.  Can get start of data here
                    // Add 4 to it. That is the number of positions before it gets to the start of the data
                    int ByteStart = TempSearchStringLocation + 4;
                    return ByteStart;
                    }
                }
            else if (ByteOffset - SearchString.Length > 0)
                {

                return -1;
                }

            else
                {
                // Did not find it. Add this and previous buffer together to see if it exists.
                // Check to see if the buffer index is at the start. 
                if (this._CurrentBufferIndex > 0)
                    {
                    // Get the previous buffer
                    byte[] PreviousBuffer = this._BufferHistory[this._CurrentBufferIndex - 1];
                    byte[] MergedBytes = MergeArrays(ref PreviousBuffer, ref BufferData);
                    // Get the byte array for the text
                    byte[] SearchString2 = Encoding.UTF8.GetBytes("Content-Type: ");
                    // Search the bytes for the searchString
                    TempContentTypeStart = FindBytePattern(ref MergedBytes, ref SearchString2, PreviousBuffer.Length - SearchString2.Length);

                    //tempContentTypeStart = combinedUTF8Data.IndexOf("Content-Type: ");
                    if (TempContentTypeStart != -1)
                        {
                        // Found content type start location
                        // Next search for \r\n\r\n at this substring

                        SearchString2 = Encoding.UTF8.GetBytes("Content-Type: ");
                        // because we are searching part of the previous buffer, we only need to go back the length of the search 
                        // array.  Any further, and our normal if statement would have picked it up when it first was processed.
                        int TempSearchStringLocation = FindBytePattern(ref MergedBytes, ref SearchString2, PreviousBuffer.Length - SearchString2.Length);

                        if (TempSearchStringLocation != -1)
                            {
                            // Found this.  Can get start of data here
                            // It is possible for some of this to be located in the previous buffer.
                            // Find out where the excape chars are located.
                            if (TempSearchStringLocation > PreviousBuffer.Length)
                                {
                                // Located in the second object.  
                                // If we used the previous buffer, we should not have to worry about going out of
                                // range unless the buffer was set to some really low number.  So not going to check for
                                // out of range issues.
                                int CurrentBufferByteLocation = TempSearchStringLocation - PreviousBuffer.Length;
                                return CurrentBufferByteLocation;
                                }
                            // Located in the first object.  The only reason this could happen is if
                            // the escape chars ended right at the end of the buffer.  This would mean
                            // that that the next buffer would start data at offset 0
                            return 0;
                            }
                        }
                    }
                }
            // indicate not found.
            return -1;
            }

        /// <summary>
        /// Method used for searching buffer data for end byte location, and if needed previous buffer data.
        /// </summary>
        /// <param name="BufferData">current buffer data needing to be processed.</param>
        /// <returns>Returns byte location of data to start</returns>
        private int GetEndBytePosition(ref byte[] BufferData)
            {

            int ByteOffset = 0;
            // Check to see if the current bufferIndex is the same as any previous index found.
            // If it is, offset the searching by the previous location.  This will allow us to find the next leading
            // Stop location so we do not return a byte offset that may have happened before the start index.
            if (this._StartIndexBufferID == this._CurrentBufferIndex + 1)
                {
                ByteOffset = this._StartLocationInBufferID;
                }

            // First see if we can find it in the current buffer batch.
            byte[] SearchString = Encoding.UTF8.GetBytes(this._FieldSeparator);
            int TempFieldSeparator = FindBytePattern(ref BufferData, ref SearchString, ByteOffset);

            if (TempFieldSeparator != -1)
                {
                // Found field ending. Depending on where the field separator is located on this, we may have to move back into
                // the previous buffer to return its offset.
                if (TempFieldSeparator - 2 < 0)
                    {
                    }
                else
                    {
                    return TempFieldSeparator - 2;
                    }
                }
            else if (ByteOffset - SearchString.Length > 0)
                {

                return -1;
                }
            else
                {
                // Did not find it. Add this and previous buffer together to see if it exists.
                // Check to see if the buffer index is at the start. 
                if (this._CurrentBufferIndex > 0)
                    {

                    // Get the previous buffer
                    byte[] PreviousBuffer = this._BufferHistory[this._CurrentBufferIndex - 1];
                    byte[] MergedBytes = MergeArrays(ref PreviousBuffer, ref BufferData);
                    // Get the byte array for the text
                    byte[] SearchString2 = Encoding.UTF8.GetBytes(this._FieldSeparator);
                    // Search the bytes for the searchString
                    TempFieldSeparator = FindBytePattern(ref MergedBytes, ref SearchString2, PreviousBuffer.Length - SearchString2.Length + ByteOffset);

                    if (TempFieldSeparator != -1)
                        {
                        // Found content type start location
                        // Next search for \r\n\r\n at this substring

                        SearchString2 = Encoding.UTF8.GetBytes("\r\n\r\n");
                        int TempSearchStringLocation = FindBytePattern(ref MergedBytes, ref SearchString2, TempFieldSeparator);

                        if (TempSearchStringLocation != -1)
                            {
                            // Found this.  Can get start of data here
                            // It is possible for some of this to be located in the previous buffer.
                            // Find out where the excape chars are located.
                            if (TempSearchStringLocation > PreviousBuffer.Length)
                                {
                                // Located in the second object.  
                                // If we used the previous buffer, we should not have to worry about going out of
                                // range unless the buffer was set to some really low number.  So not going to check for
                                // out of range issues.
                                int CurrentBufferByteLocation = TempSearchStringLocation - PreviousBuffer.Length;
                                return CurrentBufferByteLocation;
                                }
                            // Located in the first object.  The only reason this could happen is if
                            // the escape chars ended right at the end of the buffer.  This would mean
                            // that that the next buffer would start data at offset 0
                            return -1;
                            }
                        }
                    }
                }
            // indicate not found.
            return -1;
            }

        /// <summary>
        /// Method created to search for byte array patterns inside a byte array.
        /// </summary>
        /// <param name="ContainerBytes">byte array to search</param>
        /// <param name="SearchBytes">byte array with pattern to search with</param>
        /// <param name="StartAtIndex">byte offset to start searching at a specified location</param>
        /// <returns>-1 if not found or index of starting location of pattern</returns>
        private static int FindBytePattern(ref byte[] ContainerBytes, ref byte[] SearchBytes, int StartAtIndex)
            {
            const int ReturnValue = -1;
            for (int ByteIndex = StartAtIndex; ByteIndex < ContainerBytes.Length; ByteIndex++)
                {

                // Make sure the searchBytes length does not exceed the containerbytes
                if (ByteIndex + SearchBytes.Length > ContainerBytes.Length)
                    {
                    return -1;
                    }

                // First the first reference of the bytes to search
                if (ContainerBytes[ByteIndex] == SearchBytes[0])
                    {
                    bool Found = true;
                    int TempStartIndex = ByteIndex;
                    for (int SearchBytesIndex = 1; SearchBytesIndex < SearchBytes.Length; SearchBytesIndex++)
                        {
                        // Set next index
                        TempStartIndex++;
                        if (SearchBytes[SearchBytesIndex] != ContainerBytes[TempStartIndex])
                            {
                            Found = false;
                            // break out of the loop and continue searching.
                            break;
                            }
                        }
                    if (Found)
                        {
                        // Indicates that the byte array has been found. Return this index.
                        return ByteIndex;
                        }
                    }
                }
            return ReturnValue;
            }

        /// <summary>
        /// Used to merge two byte arrays into one.  
        /// </summary>
        /// <param name="ArrayOne">First byte array to go to the start of the new array</param>
        /// <param name="ArrayTwo">Second byte array to go to right after the first array that was passed</param>
        /// <returns>new byte array of all the new bytes</returns>
        private static byte[] MergeArrays(ref byte[] ArrayOne, ref byte[] ArrayTwo)
            {
            var NewArray = new byte[ArrayOne.Length + ArrayTwo.Length];
            ArrayOne.CopyTo(NewArray, 0);
            ArrayTwo.CopyTo(NewArray, ArrayOne.Length);

            return NewArray;
            }

        /// <summary>
        /// This is used as part of the clean up procedures. the Timer object will execute this function.
        /// </summary>
        /// <param name="FilePath"></param>
        private static void DeleteFile(object FilePath)
            {
            // File may have already been removed from the main application.
            try
                {
                if (File.Exists((string)FilePath))
                    {
                    File.Delete((string)FilePath);
                    }
                }
            catch { }
            }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Clean up method.
        /// </summary>
        public void Dispose()
            {
            // Clear the buffer history
            this._BufferHistory.Clear();
            GC.Collect();
            }

        #endregion
        }
    }