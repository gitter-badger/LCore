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
        public const int DefaultTries = 5;
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
            int Tries = 0;

            var Client = new WebClientTimeOut();
            System.IO.MemoryStream BodyStream = null;

            if (Data != null)
                {

                foreach (var Item in Data)
                    {
                    try
                        {
                        if (Item.Type == DataItem.DataStorageType.Body)
                            {
                            if (BodyStream == null)
                                {
                                BodyStream = new System.IO.MemoryStream();
                                }

                            byte[] Bytes = Item.Value.ToByteArray();
                            BodyStream.Write(Bytes, 0, Bytes.Length);


                            Client.Headers[$"{Http_Header_Prefix}{Item.Name}_Length"] = Bytes.Length.ToString();
                            }
                        else if (Item.Type == DataItem.DataStorageType.Header)
                            {
                            Client.Headers[Http_Header_Prefix + Item.Name] = Item.Value.CleanCrlf();
                            }
                        else
                            {
                            throw new Exception($"Unsupported type: \'{Item.Type}\'");
                            }
                        }
                    catch (Exception Ex)
                        {
                        throw new Exception($"Could not add header \'{Item.Name}\' with Value \'{Item.Value}\'", Ex);
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
                catch (Exception Ex)
                    {
                    FailReason = Ex;

                    Tries++;
                    Thread.Sleep(TryFailWait);
                    }
                }
            while (Tries < DefaultTries);

            throw new Exception(Url, FailReason);
            }

        public class DataItem
            {
            public enum DataStorageType { Header, Body }

            public string Name;
            public string Value;
            public readonly DataStorageType Type = DataStorageType.Header;
            }
        public class ResponseData
            {
            public string Value;
            public byte[] BinaryValue;
            }
        }
    }