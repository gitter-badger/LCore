using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using LCore.Interfaces;

namespace Singularity.Extensions
    {
    [ExtensionProvider]
    public static class ControllerExt
        {
        #region Extensions +
        #region CName

        public static string CName(this Type Controller)
            {
            if (Controller == null) throw new ArgumentNullException(nameof(Controller));

            string name = Controller.Name;
            return name.EndsWith("Controller") ? 
                name.Substring(0, name.Length - "Controller".Length) : 
                name;
            }

        public static string CName(this Controller Controller)
            {
            if (Controller == null) throw new ArgumentNullException(nameof(Controller));

            string name = Controller.GetType().Name;
            return name.EndsWith("Controller") ? name.Substring(0, name.Length - "Controller".Length) : name;
            }

        #endregion
        #endregion
        }
    }