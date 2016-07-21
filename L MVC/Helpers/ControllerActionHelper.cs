using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using LCore.Extensions;

namespace LMVC.Extensions
    {
    public class ControllerActionHelper<T>
        {
        private readonly UrlHelper _Url;
        private MethodInfo _Method;
        private ParameterInfo[] _Params;
        private RouteValueDictionary _Args;

        private string UrlAction(string ActionName, string UrlControllerName, dynamic UrlArgs)
            {
            if (string.IsNullOrEmpty(UrlControllerName))
                {
                return this._Args == null ? this._Url.Action(ActionName) : this._Url.Action(ActionName, UrlArgs);
                }
            return this._Url.Action(ActionName, UrlControllerName, UrlArgs);
            }

        private string HtmlActionLink(string ActionName, string LinkControllerName, dynamic LinkArgs)
            {
            return string.IsNullOrEmpty(LinkControllerName) ? this._Url.Action(ActionName, LinkArgs) : this._Url.Action(ActionName, LinkControllerName, LinkArgs);
            }

        public string ControllerName
            {
            get
                {
                if (typeof(T).IsAbstract)
                    {
                    return null;
                    }
                string Out = typeof(T).Name;

                if (Out.EndsWith("Controller"))
                    Out = Out.Sub(0, Out.Length - "Controller".Length);

                return Out;
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

        public ControllerActionHelper(UrlHelper Url)
            {
            this._Url = Url;
            }

        public string Action(Expression<Func<T, Func<ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public ControllerActionHelper<T> QS(IDictionary<string, object> Arguments)
            {
            this._Args = this._Args ?? new RouteValueDictionary();

            IDictionary<string, object> Dict = Arguments;

            foreach (string Key in Arguments.Keys)
                {
                Dict[Key] = Arguments[Key];
                }

            return this;
            }

        #region Func
        public string Action<A1>(
            Expression<Func<T, Func<A1, ActionResult>>> ActionExpression,
            A1 Value)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2>(
            Expression<Func<T, Func<A1, A2, ActionResult>>> ActionExpression,
            A1 Value, A2 Value2)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3>(
            Expression<Func<T, Func<A1, A2, A3, ActionResult>>> ActionExpression,
            A1 Value, A2 Value2, A3 Value3)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4>(
            Expression<Func<T, Func<A1, A2, A3, A4, ActionResult>>> ActionExpression,
            A1 Value, A2 Value2, A3 Value3, A4 Value4)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, ActionResult>>> ActionExpression,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, ActionResult>>> ActionExpression,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, ActionResult>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, ActionResult>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, ActionResult>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, ActionResult>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, ActionResult>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, ActionResult>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, ActionResult>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, ActionResult>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, ActionResult>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, ActionResult>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        #endregion

        #region Action

        public string Action(Expression<Func<T, Action>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1>(
            Expression<Func<T, Action<A1>>> ActionExpression,
            A1 Value)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2>(
            Expression<Func<T, Action<A1, A2>>> ActionExpression,
            A1 Value, A2 Value2)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3>(
            Expression<Func<T, Action<A1, A2, A3>>> ActionExpression,
            A1 Value, A2 Value2, A3 Value3)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4>(
            Expression<Func<T, Action<A1, A2, A3, A4>>> ActionExpression,
            A1 Value, A2 Value2, A3 Value3, A4 Value4)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5>>> ActionExpression,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6>>> ActionExpression,
            A1 Value, A2 Value2, A3 Value3, A4 Value4, A5 Value5, A6 Value6)
            {
            string ActionName = this.GetActionName(ActionExpression);

            this.FillParameter(0, Value);
            this.FillParameter(1, Value2);
            this.FillParameter(2, Value3);
            this.FillParameter(3, Value4);
            this.FillParameter(4, Value5);
            this.FillParameter(5, Value6);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>>> ActionExpression,
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

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        #endregion

        #region Func Lambda


        public string Lambda<A1>(
            Expression<Func<T, Func<A1, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2>(
            Expression<Func<T, Func<A1, A2, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3>(
            Expression<Func<T, Func<A1, A2, A3, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4>(
            Expression<Func<T, Func<A1, A2, A3, A4, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>(
            Expression<Func<T, Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, ActionResult>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }


        #endregion

        #region Action Lambda


        public string Lambda(Expression<Func<T, Action>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1>(
            Expression<Func<T, Action<A1>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2>(
            Expression<Func<T, Action<A1, A2>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3>(
            Expression<Func<T, Action<A1, A2, A3>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4>(
            Expression<Func<T, Action<A1, A2, A3, A4>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        public string Lambda<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>(
            Expression<Func<T, Action<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16>>> ActionExpression)
            {
            string ActionName = this.GetActionName(ActionExpression);

            return this.UrlAction(ActionName, this.ControllerName, this._Args);
            }

        #endregion
        }
    }