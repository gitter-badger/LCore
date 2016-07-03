using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Singularity.Controllers
    {
    public static class StatusMessages
        {
        public const string StatusMessage_Success = "StatusMessage_Success";
        public const string StatusMessage_Error = "StatusMessage_Error";
        public const string StatusMessage_Warning = "StatusMessage_Warning";
        public const string StatusMessage_Information = "StatusMessage_Information";

        public static List<string> GetStatusMessages_Success(this ControllerBase c)
            {
            var Out = c.TempData[StatusMessage_Success];

            var List = Out as List<string>;
            return List ?? new List<string>();
            }
        public static List<string> GetStatusMessages_Error(this ControllerBase c)
            {
            var Out = c.TempData[StatusMessage_Error];

            var List = Out as List<string>;
            return List ?? new List<string>();
            }
        public static List<string> GetStatusMessages_Warning(this ControllerBase c)
            {
            var Out = c.TempData[StatusMessage_Warning];

            var List = Out as List<string>;
            return List ?? new List<string>();
            }
        public static List<string> GetStatusMessages_Information(this ControllerBase c)
            {
            var Out = c.TempData[StatusMessage_Information];

            var @out = Out as List<string>;
            return @out ?? new List<string>();
            }

        public static void AddStatusMessages_Success(this ControllerBase c, string Message)
            {
            if (c.TempData.Peek(StatusMessage_Success) == null)
                c.TempData.Add(StatusMessage_Success, new List<string>());

            ((List<string>)c.TempData.Peek(StatusMessage_Success)).Add(Message);
            }
        public static void AddStatusMessages_Error(this ControllerBase c, string Message)
            {
            if (c.TempData.Peek(StatusMessage_Error) == null)
                c.TempData.Add(StatusMessage_Error, new List<string>());

            ((List<string>)c.TempData.Peek(StatusMessage_Error)).Add(Message);
            }
        public static void AddStatusMessages_Warning(this ControllerBase c, string Message)
            {
            if (c.TempData.Peek(StatusMessage_Warning) == null)
                c.TempData.Add(StatusMessage_Warning, new List<string>());

            ((List<string>)c.TempData.Peek(StatusMessage_Warning)).Add(Message);
            }
        public static void AdStatusMessages_Information(this ControllerBase c, string Message)
            {
            if (c.TempData.Peek(StatusMessage_Information) == null)
                c.TempData.Add(StatusMessage_Information, new List<string>());

            ((List<string>)c.TempData.Peek(StatusMessage_Information)).Add(Message);
            }
        }
    }