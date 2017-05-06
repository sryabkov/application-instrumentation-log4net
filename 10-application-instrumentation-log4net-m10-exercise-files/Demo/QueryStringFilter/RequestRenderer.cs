using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using log4net.ObjectRenderer;

namespace QueryStringFilter
{
    [Renders( typeof( HttpRequestBase ) )]
    public class RequestRenderer : IObjectRenderer
    {
        public void RenderObject(RendererMap rendererMap, object obj, TextWriter writer)
        {
            HttpRequestBase requestBase = obj as HttpRequestBase;
            if (null == requestBase)
            {
                return;
            }

            var renderedRequest = FormatRequest(requestBase);
            writer.WriteLine(renderedRequest);
        }

        private static string FormatRequest(HttpRequestBase request)
        {
            var renderedRequest = String.Format(
                "([{0}] [{1}] from browser [{2}])",
                request.HttpMethod,
                request.RawUrl,
                request.Browser.Browser
                );
            return renderedRequest;
        }
    }
}
