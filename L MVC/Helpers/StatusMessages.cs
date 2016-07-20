using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LMVC.Controllers
    {
    public static class StatusMessages
        {
        public const string StatusMessage_Success = "StatusMessage_Success";
        public const string StatusMessage_Error = "StatusMessage_Error";
        public const string StatusMessage_Warning = "StatusMessage_Warning";
        public const string StatusMessage_Information = "StatusMessage_Information";

        public static List<string> GetStatusMessages_Success(this ControllerBase Controller)
            {
            var Out = Controller.TempData[StatusMessage_Success];

            var List = Out as List<string>;
            return List ?? new List<string>();
            }
        public static List<string> GetStatusMessages_Error(this ControllerBase Controller)
            {
            var Out = Controller.TempData[StatusMessage_Error];

            var List = Out as List<string>;
            return List ?? new List<string>();
            }
        public static List<string> GetStatusMessages_Warning(this ControllerBase Controller)
            {
            var Out = Controller.TempData[StatusMessage_Warning];

            var List = Out as List<string>;
            return List ?? new List<string>();
            }
        public static List<string> GetStatusMessages_Information(this ControllerBase Controller)
            {
            var Out = Controller.TempData[StatusMessage_Information];

            var OutList = Out as List<string>;
            return OutList ?? new List<string>();
            }

        public static void AddStatusMessages_Success(this ControllerBase Controller, string Message)
            {
            if (Controller.TempData.Peek(StatusMessage_Success) == null)
                Controller.TempData.Add(StatusMessage_Success, new List<string>());

            ((List<string>)Controller.TempData.Peek(StatusMessage_Success)).Add(Message);
            }
        public static void AddStatusMessages_Error(this ControllerBase Controller, string Message)
            {
            if (Controller.TempData.Peek(StatusMessage_Error) == null)
                Controller.TempData.Add(StatusMessage_Error, new List<string>());

            ((List<string>)Controller.TempData.Peek(StatusMessage_Error)).Add(Message);
            }
        public static void AddStatusMessages_Warning(this ControllerBase Controller, string Message)
            {
            if (Controller.TempData.Peek(StatusMessage_Warning) == null)
                Controller.TempData.Add(StatusMessage_Warning, new List<string>());

            ((List<string>)Controller.TempData.Peek(StatusMessage_Warning)).Add(Message);
            }
        public static void AdStatusMessages_Information(this ControllerBase Controller, string Message)
            {
            if (Controller.TempData.Peek(StatusMessage_Information) == null)
                Controller.TempData.Add(StatusMessage_Information, new List<string>());

            ((List<string>)Controller.TempData.Peek(StatusMessage_Information)).Add(Message);
            }
        }
    }