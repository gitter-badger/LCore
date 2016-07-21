﻿using System.Collections;
using System.Collections.Generic;
using System.Web;

using LCore.Extensions;
using System.IO;
using LCore.Interfaces;

namespace LMVC.Extensions
    {
    [ExtensionProvider]
    public static class ResponseExt
        {
        public static void WriteCSV(this HttpResponseBase Response, IEnumerable<string> CSVData, string FileName)
            {
            Response.WriteCSV(CSVData.JoinLines(), FileName);
            }
        public static void WriteCSV(this HttpResponseBase Response, string CSVData, string FileName)
            {
            if (FileName == null)
                FileName = "data";

            if (FileName.ToLower().EndsWith(".csv"))
                FileName = FileName.Substring(FileName.Length - ".csv".Length);

            Response.Clear();
            Response.AddHeader("Content-Disposition", $"attachment; filename={FileName}.csv");
            Response.ContentType = "text/csv";
            Response.Write(CSVData);
            Response.End();
            }
        public static void WriteCSV(this HttpResponseBase Response, StringWriter Str, string FileName)
            {
            if (FileName == null)
                FileName = "data";

            if (FileName.ToLower().EndsWith(".csv"))
                FileName = FileName.Substring(FileName.Length - ".csv".Length);

            Response.Clear();
            Response.AddHeader("Content-Disposition", $"attachment; filename={FileName}.csv");
            Response.ContentType = "text/csv";
            Response.Write(Str);
            Response.End();
            }

        public static void WriteFile(this HttpResponseBase Response, string FilePath)
            {
            string FileName = Path.GetFileName(FilePath);

            if (!File.Exists(FilePath))
                return;

            Response.Clear();
            Response.AddHeader("Content-Disposition", $"attachment; filename={FileName}");
            Response.AddHeader("Content-Length", new FileInfo(FilePath).Length.ToString());
            Response.WriteFile(FilePath);
            Response.End();
            }

        public static void WritePDF(this HttpResponseBase Response, byte[] PDFBytes, string FileName)
            {
            if (FileName == null)
                FileName = "data";

            if (FileName.ToLower().EndsWith(".pdf"))
                FileName = FileName.Substring(FileName.Length - ".pdf".Length);

            Response.Clear();
            Response.AddHeader("Content-Disposition", $"attachment; filename={FileName}.pdf");
            Response.AddHeader("Content-Length", PDFBytes.Length.ToString());

            Response.ContentType = "application/pdf";
            Response.BinaryWrite(PDFBytes);
            Response.End();
            }
        }
    }