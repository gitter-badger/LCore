using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using LCore;
using System.IO;

namespace MVCL
{
    public static class MVCExt
    {

        public class ResponseCapture : IDisposable
        {
            private readonly HttpResponseBase response;
            private readonly TextWriter originalWriter;
            private StringWriter localWriter;
            public ResponseCapture(HttpResponseBase response)
            {
                this.response = response;
                originalWriter = response.Output;
                localWriter = new StringWriter();
                response.Output = localWriter;
            }
            public override string ToString()
            {
                localWriter.Flush();
                return localWriter.ToString();
            }
            public void Dispose()
            {
                if (localWriter != null)
                {
                    localWriter.Dispose();
                    localWriter = null;
                    response.Output = originalWriter;
                }
            }
        }

        public static string Capture(this ActionResult Result, ControllerContext ControllerContext)
        {
            ResponseCapture Capture = new ResponseCapture(ControllerContext.RequestContext.HttpContext.Response);

            Result.ExecuteResult(ControllerContext);

            String Out = Capture.ToString();

            Capture.Dispose();

            return Out;
        }

        public static Boolean HasAttribute<TModel, TProperty, TAttribute>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> ex)
            where TAttribute : Attribute
        {
            var me = (ex.Body as MemberExpression);

            if (me != null)
            {
                var required = me
                    .Member
                    .GetCustomAttributes(typeof(TAttribute), false)
                    .FirstOrDefault();

                if (required != null)
                {
                    return true;
                }
            }
            return false;
        }

        public static TAttribute GetAttribute<TModel, TProperty, TAttribute>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> ex)
            where TAttribute : Attribute
        {
            var me = (ex.Body as MemberExpression);

            if (me != null)
            {
                var required = me
                    .Member
                    .GetCustomAttributes(typeof(TAttribute), false)
                    .FirstOrDefault();

                if (required != null)
                {
                    return required as TAttribute;
                }
            }

            return default(TAttribute);
        }
    }
}