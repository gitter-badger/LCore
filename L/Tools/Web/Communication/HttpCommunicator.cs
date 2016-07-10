using System;

using LCore.Extensions;
using System.Collections.Generic;
using System.Threading;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable NotAccessedField.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnassignedField.Global
#pragma warning disable 1591

namespace LCore.Web
    {
    //NOTE: when adding functions here, make sure all variable types used are serializable. 
    //Add each new type to the Tests project constant Tests.SERIALIZABLETYPES

    public class HttpCommunicator
        {
        public const int Tries = 5;
        public const int TryFailWait = 100;
        public const int RequestTimeOut = 20000; // 20 seconds


        public const string Http_Header_Prefix = "Header_";
        protected string BaseUrl;
        public HttpCommunicator(string BaseUrl)
            {
            this.BaseUrl = BaseUrl;
            }

        public ResponseData GetUrlResponse(string Url, List<DataItem> Data = null)
            {
            int tries = 0;

            var Client = new WebClientTimeOut();
            System.IO.MemoryStream BodyStream = null;

            if (Data != null)
                {

                foreach (var t in Data)
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


                            Client.Headers[$"{Http_Header_Prefix}{t.Name}_Length"] = bytes.Length.ToString();
                            }
                        else if (t.Type == DataItem.DataStorageType.Header)
                            {
                            Client.Headers[Http_Header_Prefix + t.Name] = t.Value.CleanCrlf();
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

                        OutBytes = Client.UploadData(Url, RequestBytes);
                        Out = OutBytes.ByteArrayToString();
                        }
                    else
                        {
                        OutBytes = Client.DownloadData(Url);
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

            throw new Exception(Url, FailReason);
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