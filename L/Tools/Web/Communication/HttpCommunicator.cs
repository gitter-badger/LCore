using System;

using LCore.Extensions;
using System.Collections.Generic;
using System.Threading;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable NotAccessedField.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnassignedField.Global

namespace LCore.Web
    {
    //NOTE: when adding functions here, make sure all variable types used are serializable. 
    //Add each new type to the Tests project constant Tests.SERIALIZABLETYPES

    public class HttpCommunicator
        {
        public const int Tries = 5;
        public const int TryFailWait = 100;
        public const int RequestTimeOut = 20000; // 20 seconds


        public const string HTTP_Header_Prefix = "Header_";
        protected string BaseURL;
        public HttpCommunicator(string BaseURL)
            {
            this.BaseURL = BaseURL;
            }

        public ResponseData GetURLResponse(string URL, List<DataItem> Data = null)
            {
            int tries = 0;

            WebClientTimeOut Client = new WebClientTimeOut();
            System.IO.MemoryStream BodyStream = null;

            if (Data != null)
                {

                foreach (DataItem t in Data)
                    {
                    try
                        {
                        if (t.Type == DataItem.DataStorageType.Body)
                            {
                            if (BodyStream == null)
                                {
                                BodyStream = new System.IO.MemoryStream();
                                }

                            byte[] bytes = t.Value.ToByteArray();
                            BodyStream.Write(bytes, 0, bytes.Length);


                            Client.Headers[$"{HTTP_Header_Prefix}{t.Name}_Length"] = bytes.Length.ToString();
                            }
                        else if (t.Type == DataItem.DataStorageType.Header)
                            {
                            Client.Headers[HTTP_Header_Prefix + t.Name] = t.Value.CleanCRLF();
                            }
                        else
                            {
                            throw new Exception($"Unsupported type: \'{t.Type}\'");
                            }
                        }
                    catch (Exception e)
                        {
                        throw new Exception($"Could not add header \'{t.Name}\' with Value \'{t.Value}\'", e);
                        }
                    }
                }

            Exception FailReason;
            do
                {
                try
                    {
                    string Out;
                    byte[] OutBytes;
                    if (BodyStream != null)
                        {
                        byte[] RequestBytes = BodyStream.ToArray();

                        OutBytes = Client.UploadData(URL, RequestBytes);
                        Out = OutBytes.ByteArrayToString();
                        }
                    else
                        {
                        OutBytes = Client.DownloadData(URL);
                        Out = OutBytes.ByteArrayToString();
                        }

                    return new ResponseData { BinaryValue = OutBytes, Value = Out };
                    }
                catch (Exception e)
                    {
                    FailReason = e;

                    tries++;
                    Thread.Sleep(TryFailWait);
                    }
                }
            while (tries < Tries);

            throw new Exception(URL, FailReason);
            }

        public class DataItem
            {
            public enum DataStorageType { Header, Body }

            public string Name;
            public string Value;
            public DataStorageType Type = DataStorageType.Header;
            }
        public class ResponseData
            {
            public string Value;
            public byte[] BinaryValue;
            }
        }
    }