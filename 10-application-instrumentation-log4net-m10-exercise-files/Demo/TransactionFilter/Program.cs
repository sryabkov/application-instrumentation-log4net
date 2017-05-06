using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using log4net.Core;
using log4net.Filter;

namespace TransactionFilter
{
    public class TransactionFilter : FilterSkeleton
    {
        public TransactionFilter()
        {
            AcceptOnMatch = true;
        }

        public bool AcceptOnMatch
        {
            get; set;
        }

        public override FilterDecision Decide(LoggingEvent loggingEvent)
        {
            bool transactionExists = null != Transaction.Current;
            FilterDecision transactionDecision = AcceptOnMatch ? FilterDecision.Accept : FilterDecision.Deny;

            return transactionExists ? transactionDecision : FilterDecision.Neutral;
        }
    }
}
