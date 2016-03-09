using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using LCore;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Singularity.Models;
using Singularity.Routes;
using Singularity.Controllers;
using Singularity.Context;
using System.IO;

namespace Singularity.Extensions
    {
    public static class ResponseExt
        {
        public static void WriteCSV(this HttpResponseBase Response, String[] CSVData, String FileName)
            {
            Response.WriteCSV(CSVData.JoinLines(), FileName);
            }
        public static void WriteCSV(this HttpResponseBase Response, String CSVData, String FileName)
            {
            if (FileName == null)
                FileName = "data";

            if (FileName.ToLower().EndsWith(".csv"))
                FileName = FileName.Substring(FileName.Length - ".csv".Length);

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ".csv");
            Response.ContentType = "text/csv";
            Response.Write(CSVData);
            Response.End();
            }
        public static void WriteCSV(this HttpResponseBase Response, StringWriter sw, String FileName)
            {
            if (FileName == null)
                FileName = "data";

            if (FileName.ToLower().EndsWith(".csv"))
                FileName = FileName.Substring(FileName.Length - ".csv".Length);

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ".csv");
            Response.ContentType = "text/csv";
            Response.Write(sw);
            Response.End();
            }

        public static void WriteFile(this HttpResponseBase Response, String FilePath)
            {
            String FileName = Path.GetFileName(FilePath);

            if (!File.Exists(FilePath))
                return;

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + "");
            Response.AddHeader("Content-Length", new FileInfo(FilePath).Length.ToString());
            Response.WriteFile(FilePath);
            Response.End();
            }

        public static void WritePDF(this HttpResponseBase Response, Byte[] PDF_Bytes, String FileName)
            {
            if (FileName == null)
                FileName = "data";

            if (FileName.ToLower().EndsWith(".pdf"))
                FileName = FileName.Substring(FileName.Length - ".pdf".Length);

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ".pdf");
            Response.AddHeader("Content-Length", PDF_Bytes.Length.ToString());

            Response.ContentType = "application/pdf";
            Response.BinaryWrite(PDF_Bytes);
            Response.End();
            }
        }
    }