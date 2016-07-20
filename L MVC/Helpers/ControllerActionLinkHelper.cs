using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace LMVC.Extensions
    {
    public class ControllerActionLinkHelper<T>
        where T : Controller
        {
        private readonly HtmlHelper _Html;
        private MethodInfo _Method;
        private ParameterInfo[] _Params;
        private RouteValueDictionary _Args;

        private MvcHtmlString HtmlActionLink(string Text, string Action, string Controller, dynamic LinkArgs)
            {
            LinkArgs = LinkArgs ?? new RouteValueDictionary();

            return string.IsNullOrEmpty(Controller) ? LinkExtensions.ActionLink(this._Html, Text, Action, LinkArgs) : LinkExtensions.ActionLink(this._Html, Text, Action, Controller, LinkArgs, null);
            }

        public string ControllerName
            {
            get
                {
                if (typeof(T).IsAbstract)
                    {
                    return null;
                    }
                    string ControllerName = typeof(T).Name;

                    if (ControllerName.EndsWith("Controller"))
                        ControllerName = ControllerName.Substring(0, ControllerName.Length - "Controller".Length);

                    return ControllerName;
                }
            }

        private string GetActionName(LambdaExpression ActionExpression)
            {
            if (this._Method == null)
                this._Method = (MethodInfo)
                    (((ActionExpression.Body as UnaryExpression)
                        ?.Operand as MethodCallExpression)
                        ?.Object as ConstantExpression)?.Value;

            string ActionName = this._Method?.Name;

            return ActionName;
            }

        public void FillParameter(int Index, object Value)
            {
            if (this._Params == null)
                this._Params = this._Method.GetParameters();

            this._Args = this._Args ?? new RouteValueDictionary();

            this._Args[this._Params[Index].Name] = Value;
            }

        public ControllerActionLinkHelper(HtmlHelper Html)
            {
            this._Html = Html;
            }

        #region Func

        public MvcHtmlString ActionLink(Expression<Func<T, Func<ActionResult>>> ActionExpression, string Text)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1>(
            Expression<Func<T, Func<A1, ActionResult>>> ActionExpression,
            string Text,
            A1 Value)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2>(
            Expression<Func<T, Func<A1, A2, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3>(
            Expression<Func<T, Func<A1, A2, A3, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4>(
            Expression<Func<T, Func<A1, A2, A3, A4, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);
            this.FillParameter(10, Value11);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);
            this.FillParameter(10, Value11);
            this.FillParameter(11, Value12);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);
            this.FillParameter(10, Value11);
            this.FillParameter(11, Value12);
            this.FillParameter(12, Value13);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13, A14 Value14)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);
            this.FillParameter(10, Value11);
            this.FillParameter(11, Value12);
            this.FillParameter(12, Value13);
            this.FillParameter(13, Value14);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13, A14 Value14, A15 Value15)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);
            this.FillParameter(10, Value11);
            this.FillParameter(11, Value12);
            this.FillParameter(12, Value13);
            this.FillParameter(13, Value14);
            this.FillParameter(14, Value15);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, ActionResult>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13, A14 Value14, A15 Value15, A16 Value16)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);
            this.FillParameter(10, Value11);
            this.FillParameter(11, Value12);
            this.FillParameter(12, Value13);
            this.FillParameter(13, Value14);
            this.FillParameter(14, Value15);
            this.FillParameter(15, Value16);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        #endregion

        #region Action

        public MvcHtmlString Action(Expression<Func<T, Action>> ActionExpression, string Text)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1>(
            Expression<Func<T, Action<A1>>> ActionExpression,
            string Text,
            A1 Value)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2>(
            Expression<Func<T, Action<A1, A2>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3>(
            Expression<Func<T, Action<A1, A2, A3>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4>(
            Expression<Func<T, Action<A1, A2, A3, A4>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);
            this.FillParameter(10, Value11);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);
            this.FillParameter(10, Value11);
            this.FillParameter(11, Value12);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);
            this.FillParameter(10, Value11);
            this.FillParameter(11, Value12);
            this.FillParameter(12, Value13);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13, A14 Value14)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);
            this.FillParameter(10, Value11);
            this.FillParameter(11, Value12);
            this.FillParameter(12, Value13);
            this.FillParameter(13, Value14);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13, A14 Value14, A15 Value15)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);
            this.FillParameter(10, Value11);
            this.FillParameter(11, Value12);
            this.FillParameter(12, Value13);
            this.FillParameter(13, Value14);
            this.FillParameter(14, Value15);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        public MvcHtmlString ActionLink<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>>> ActionExpression,
            string Text,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6, A7 Value7, A8 Value8, A9 Value9, A10 Value10,
            A11 Value11, A12 Value12, A13 Value13, A14 Value14, A15 Value15, A16 Value16)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);
            this.FillParameter(6, Value7);
            this.FillParameter(7, Value8);
            this.FillParameter(8, Value9);
            this.FillParameter(9, Value10);
            this.FillParameter(10, Value11);
            this.FillParameter(11, Value12);
            this.FillParameter(12, Value13);
            this.FillParameter(13, Value14);
            this.FillParameter(14, Value15);
            this.FillParameter(15, Value16);

            return this.HtmlActionLink(Text, ActionName, this.ControllerName, this._Args);
            }

        #endregion
        }
    }