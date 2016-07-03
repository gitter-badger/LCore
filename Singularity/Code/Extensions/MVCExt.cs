using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

using System.IO;
using LCore.Interfaces;

namespace Singularity.Extensions
    {
    [ExtensionProvider]
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
                this.originalWriter = response.Output;
                this.localWriter = new StringWriter();
                response.Output = this.localWriter;
                }
            public override string ToString()
                {
                this.localWriter.Flush();
                return this.localWriter.ToString();
                }
            public void Dispose()
                {
                if (this.localWriter != null)
                    {
                    this.localWriter.Dispose();
                    this.localWriter = null;
                    this.response.Output = this.originalWriter;
                    }
                }
            }

        public static string Capture(this ActionResult Result, ControllerContext ControllerContext)
            {
            var Capture = new ResponseCapture(ControllerContext.RequestContext.HttpContext.Response);

            Result.ExecuteResult(ControllerContext);

            string Out = Capture.ToString();

            Capture.Dispose();

            return Out;
            }

        public static bool HasAttribute<TModel, TProperty, TAttribute>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> ex)
            where TAttribute : Attribute
            {
            var me = ex.Body as MemberExpression;

            var required = me?.Member
                .GetCustomAttributes(typeof(TAttribute), false)
                .FirstOrDefault();

            return required != null;
            }

        public static TAttribute GetAttribute<TModel, TProperty, TAttribute>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> ex)
            where TAttribute : Attribute
            {
            var me = ex.Body as MemberExpression;

            var required = me?.Member
                .GetCustomAttributes(typeof(TAttribute), false)
                .FirstOrDefault();

            return required as TAttribute;
            }
        }
    }