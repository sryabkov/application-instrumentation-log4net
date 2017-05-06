using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using log4net.Core;
using log4net.Filter;

namespace QueryStringFilter
{
    public class QueryStringFilter : FilterSkeleton
    {
        public override FilterDecision Decide(LoggingEvent loggingEvent)
        {
            if (null == HttpContext.Current)
            {
                return FilterDecision.Neutral;                
            }

            if (! HttpContext.Current.Request.QueryString.AllKeys.Contains("log"))
            {
                return FilterDecision.Neutral;
            }

            var logQueryStringValue = HttpContext.Current.Request.QueryString.Get("log");
            var values = new[] {"1", "yes", "true"};
            if( values.Contains( logQueryStringValue.ToLowerInvariant()))
            {
                return FilterDecision.Accept;
            }

            return FilterDecision.Deny;
        }
    }
}
