using System;
using LCore;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Threading;

namespace LCore
    {
    //NOTE: when adding functions here, make sure all variable types used are serializable. 
    //Add each new type to the Tests project constant Tests.SERIALIZABLETYPES

    public class HttpCommunicator
        {
        public const int Tries = 5;
        public const int TryFailWait = 100;
        public const int RequestTimeOut = 20000; // 20 seconds


        public const String HTTP_Header_Prefix = "Header_";
        protected String BaseURL;
        public HttpCommunicator(String BaseURL)
            {
            this.BaseURL = BaseURL;
            }
        public ResponseData GetURLResponse(String URL)
            {
            return GetURLResponse(URL, null);
            }
        public ResponseData GetURLResponse(String URL, List<DataItem> Data)
            {
            int tries = 0;

            WebClientTimeOut Client = new WebClientTimeOut();
            System.IO.MemoryStream BodyStream = null;

            int BodyPosition = 0;
            if (Data != null)
                {

                for (int i = 0; i < Data.Count; i++)
                    {
                    try
                        {
                        if (Data[i].Type == DataItem.DataStorageType.Body)
                            {
                            if (BodyStream == null)
                                {
                                BodyStream = new System.IO.MemoryStream();
                                }

                            Byte[] bytes = Data[i].Value.ToByteArray();
                            BodyStream.Write(bytes, 0, bytes.Length);
                            BodyPosition += bytes.Length;


                            Client.Headers[HTTP_Header_Prefix + Data[i].Name + "_Length"] = bytes.Length.ToString();
                            }
                        else if (Data[i].Type == DataItem.DataStorageType.Header)
                            {
                            Client.Headers[HTTP_Header_Prefix + Data[i].Name] = Data[i].Value.ReplaceLineEnders(StringExt.CRLFReplace);
                            }
                        else
                            {
                            throw new Exception("Unsupported type: '" + Data[i].Type + "'");
                            }
                        }
                    catch (Exception e)
                        {
                        throw new Exception("Could not add header '" + Data[i].Name + "' with Value '" + Data[i].Value + "'", e);
                        }
                    }
                }

            Exception FailReason = null;
            do
                {
                try
                    {
                    String Out = "";
                    Byte[] OutBytes = null;
                    if (BodyStream != null)
                        {
                        Byte[] RequestBytes = BodyStream.ToArray();

                        OutBytes = Client.UploadData(URL, RequestBytes);
                        Out = OutBytes.ByteArrayToString();
                        }
                    else
                        {
                        OutBytes = Client.DownloadData(URL);
                        Out = OutBytes.ByteArrayToString();
                        }

                    return new ResponseData() { BinaryValue = OutBytes, Value = Out };
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

            public String Name;
            public String Value;
            public DataStorageType Type = DataStorageType.Header;
            }
        public class ResponseData
            {
            public String Value;
            public Byte[] BinaryValue;
            }
        }
    }