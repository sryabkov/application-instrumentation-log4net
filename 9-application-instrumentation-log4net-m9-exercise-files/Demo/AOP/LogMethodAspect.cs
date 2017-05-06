using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using log4net;

namespace AOP
{
    [Serializable]
    [MulticastAttributeUsage(
        MulticastTargets.Method | MulticastTargets.InstanceConstructor,
        TargetMemberAttributes = MulticastAttributes.NonAbstract,
        Inheritance = MulticastInheritance.Multicast)]
    [AttributeUsage(AttributeTargets.Assembly)]
    public class LogMethodAspect : OnMethodBoundaryAspect
    {
        private static readonly ILog Log = LogManager.GetLogger("TRACE");
        private static int indent = 0;

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (! Log.IsDebugEnabled)
            {
                return;
            }

            string parameters = "";
            if (null != args.Arguments && args.Arguments.Any())
            {
                parameters = String.Join("; ", args.Arguments.ToList().ConvertAll(a => (a ?? "null").ToString()).ToArray());
            }

            try
            {
                var s = String.Format(
                    "{3}[{0}] >> Entering [{1}] ( [{2}] )",
                    args.Method.DeclaringType.FullName,
                    args.Method.Name,
                    parameters,
                    new string(' ', indent));
                Log.Debug( s );
                ++indent;
            }
            catch
            {
            }
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            if (!Log.IsDebugEnabled)
            {
                return;
            }

            try
            {
                --indent;
                var s = String.Format(
                    "{3}[{0}] << Returning [{2}] from [{1}]",
                    args.Method.DeclaringType.FullName,
                    args.Method.Name,
                    args.ReturnValue ?? "<null>",
                    new string(' ', indent));
                Log.Debug(s);
                
            }
            catch
            {
            }
        }

        public override void OnException(MethodExecutionArgs args)
        {
            if (!Log.IsErrorEnabled)
            {
                return;
            }

            try
            {
                --indent;
                var s = String.Format(
                    "[{0}] !! Exception in [{1}]: [{2}]",
                    args.Method.DeclaringType.FullName,
                    args.Method.Name,
                    args.Exception);
                Log.Error( s, args.Exception );
            }
            catch
            {
            }
        }
    }
}
