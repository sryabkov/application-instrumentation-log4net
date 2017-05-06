using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Common;

namespace DependencyInjectionAndLog4Net
{
    public class SuperBusinessObject
    {
        private static readonly ILogger Log = Common.LogManager.GetLogger<SuperBusinessObject>();
        
        public void DoBusiness()
        {
            if (Log.IsInfoEnabled)
            {
                Log.InfoFormat("Business is being done: [{0}]", ExpensiveBusinessProperty);
            }
        }

        public void DoBusinessWithDeferredLogging()
        {
            Log.Debug(()=>String.Format("Business is being done: [{0}]", ExpensiveBusinessProperty));
        }

        public void DoBusinessWithImplicitLogging()
        {
            this.Debug(()=>String.Format("Business is being done: [{0}]", ExpensiveBusinessProperty));
        }

        int ExpensiveBusinessProperty
        {
            get 
            { 
                Thread.Sleep(5000);
                return 1;
            }
        }
    }
}
