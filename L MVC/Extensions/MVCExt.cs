using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

using System.IO;
using LCore.Extensions;
using LCore.Interfaces;

namespace LMVC.Extensions
    {
    [ExtensionProvider]
    public static class MVCExt
        {
        public class ResponseCapture : IDisposable
            {
            private readonly HttpResponseBase _Response;
            private readonly TextWriter _OriginalWriter;
            private StringWriter _LocalWriter;

            public ResponseCapture(HttpResponseBase Response)
                {
                this._Response = Response;
                this._OriginalWriter = Response.Output;
                this._LocalWriter = new StringWriter();
                Response.Output = this._LocalWriter;
                }
            public override string ToString()
                {
                this._LocalWriter.Flush();
                return this._LocalWriter.ToString();
                }
            public void Dispose()
                {
                if (this._LocalWriter != null)
                    {
                    this._LocalWriter.Dispose();
                    this._LocalWriter = null;
                    this._Response.Output = this._OriginalWriter;
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

        public static bool HasAttribute<TModel, TProperty, TAttribute>(this HtmlHelper<TModel> HTML, Expression<Func<TModel, TProperty>> Ex)
            where TAttribute : Attribute
            {
            var Member = Ex.Body as MemberExpression;

            return Member?.Member.HasAttribute<TAttribute>(false) == true;
            }

        public static TAttribute GetAttribute<TModel, TProperty, TAttribute>(this HtmlHelper<TModel> HTML, Expression<Func<TModel, TProperty>> Ex)
            where TAttribute : Attribute
            {
            var Member = Ex.Body as MemberExpression;
            
            return Member?.Member.GetAttribute<TAttribute>(false);
            }
        }
    }