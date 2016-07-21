using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using LCore.Extensions;
using LCore.Interfaces;

namespace LMVC.Extensions
    {
    [ExtensionProvider]
    public static class ControllerExt
        {
        #region Extensions +
        #region CName

        /// <exception cref="ArgumentNullException"><paramref name="Controller"/> is <see langword="null" />.</exception>
        public static string CName(this Type Controller)
            {
            if (Controller == null) throw new ArgumentNullException(nameof(Controller));

            string Name = Controller.Name;
            return Name.EndsWith("Controller") ? 
                Name.Sub(0, Name.Length - "Controller".Length) : 
                Name;
            }

        /// <exception cref="ArgumentNullException"><paramref name="Controller"/> is <see langword="null" />.</exception>
        public static string CName(this Controller Controller)
            {
            if (Controller == null) throw new ArgumentNullException(nameof(Controller));

            string Name = Controller.GetType().Name;
            return Name.EndsWith("Controller") 
                ? Name.Sub(0, Name.Length - "Controller".Length) 
                : Name;
            }

        #endregion
        #endregion
        }
    }