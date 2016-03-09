using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Helpers;
using System.IO;
using System.Dynamic;
using System.Web.Routing;

using LCore;

using Singularity.Models;
using Singularity.Routes;
using Singularity.Controllers;
using Singularity.Context;

namespace Singularity.Extensions
    {
    public class ControllerActionLinkHelper<T>
        where T : Controller
        {
        private HtmlHelper Html;
        private MethodInfo Method;
        private ParameterInfo[] Params;
        private RouteValueDictionary Args;

        private MvcHtmlString HtmlActionLink(String Text, String ActionName, String ControllerName, dynamic Args)
            {
            Args = Args ?? new RouteValueDictionary();

            if (String.IsNullOrEmpty(ControllerName))
                {
                return LinkExtensions.ActionLink(Html, Text, ActionName, Args);
                }
            else
                {
                return LinkExtensions.ActionLink(Html, Text, ActionName, ControllerName, Args, null);
                }
            }

        public string ControllerName
            {
            get
                {
                if (typeof(T).IsAbstract)
                    {
                    return null;
                    }
                else
                    {
                    String ControllerName = typeof(T).Name;

                    if (ControllerName.EndsWith("Controller"))
                        ControllerName = ControllerName.Substring(0, ControllerName.Length - ("Controller").Length);

                    return ControllerName;
                    }
                }
            }

        private string GetActionName(LambdaExpression ActionExpression)
            {
            if (Method == null)
                Method = (MethodInfo)
                    ((((ActionExpression.Body as UnaryExpression)
                    .Operand as MethodCallExpression)
                    .Object) as ConstantExpression).Value;

            String ActionName = Method.Name;

            return ActionName;
            }

        public void FillParameter(int Index, Object Value)
            {
            if (Params == null)
                Params = Method.GetParameters();

            Args = Args ?? new RouteValueDictionary();

            Args[Params[Index].Name] = Value;
            }

        public ControllerActionLinkHelper(HtmlHelper Html)
            {
            this.Html = Html;
            }

        #region Func

        public MvcHtmlString ActionLink(Expression<Func<T, Func<ActionResult>>> ActionExpression, String Text)
            {
            String ActionName = GetActionName(ActionExpression);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1>(
            Expression<Func<T, Func<A1, ActionResult>>> ActionExpression,
            String Text,
            A1 Value)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2>(
            Expression<Func<T, Func<A1, A2, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3>(
            Expression<Func<T, Func<A1, A2, A3, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4>(
            Expression<Func<T, Func<A1, A2, A3, A4, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);
            FillParameter(10, Value11);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);
            FillParameter(10, Value11);
            FillParameter(11, Value12);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);
            FillParameter(10, Value11);
            FillParameter(11, Value12);
            FillParameter(12, Value13);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13, A14 Value14)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);
            FillParameter(10, Value11);
            FillParameter(11, Value12);
            FillParameter(12, Value13);
            FillParameter(13, Value14);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13, A14 Value14, A15 Value15)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);
            FillParameter(10, Value11);
            FillParameter(11, Value12);
            FillParameter(12, Value13);
            FillParameter(13, Value14);
            FillParameter(14, Value15);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, ActionResult>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13, A14 Value14, A15 Value15, A16 Value16)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);
            FillParameter(10, Value11);
            FillParameter(11, Value12);
            FillParameter(12, Value13);
            FillParameter(13, Value14);
            FillParameter(14, Value15);
            FillParameter(15, Value16);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        #endregion

        #region Action

        public MvcHtmlString Action(Expression<Func<T, Action>> ActionExpression, String Text)
            {
            String ActionName = GetActionName(ActionExpression);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1>(
            Expression<Func<T, Action<A1>>> ActionExpression,
            String Text,
            A1 Value)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2>(
            Expression<Func<T, Action<A1, A2>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3>(
            Expression<Func<T, Action<A1, A2, A3>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4>(
            Expression<Func<T, Action<A1, A2, A3, A4>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);
            FillParameter(10, Value11);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);
            FillParameter(10, Value11);
            FillParameter(11, Value12);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);
            FillParameter(10, Value11);
            FillParameter(11, Value12);
            FillParameter(12, Value13);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13, A14 Value14)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);
            FillParameter(10, Value11);
            FillParameter(11, Value12);
            FillParameter(12, Value13);
            FillParameter(13, Value14);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13, A14 Value14, A15 Value15)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);
            FillParameter(10, Value11);
            FillParameter(11, Value12);
            FillParameter(12, Value13);
            FillParameter(13, Value14);
            FillParameter(14, Value15);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>>> ActionExpression,
            String Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13, A14 Value14, A15 Value15, A16 Value16)
            {
            String ActionName = GetActionName(ActionExpression);

            FillParameter(0, Value);
            FillParameter(1, Value2);
            FillParameter(2, Value3);
            FillParameter(3, Value4);
            FillParameter(4, Value5);
            FillParameter(5, Value6);
            FillParameter(6, Value7);
            FillParameter(7, Value8);
            FillParameter(8, Value9);
            FillParameter(9, Value10);
            FillParameter(10, Value11);
            FillParameter(11, Value12);
            FillParameter(12, Value13);
            FillParameter(13, Value14);
            FillParameter(14, Value15);
            FillParameter(15, Value16);

            return HtmlActionLink(Text, ActionName, ControllerName, Args);
            }

        #endregion
        }
    }