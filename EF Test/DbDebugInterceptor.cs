using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace EF_Test
{
    public class DbDebugInterceptor:DbCommandInterceptor
    {

        public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            //   base.NonQueryExecuted(command, interceptionContext);

            
            Trace.WriteLine(command.CommandText + " thread id:" + Thread.CurrentThread.ManagedThreadId);
            Trace.Flush();
        }

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            //base.NonQueryExecuting(command, interceptionContext);
        }

        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {

            Trace.WriteLine( "-------------------Start thread id:" + Thread.CurrentThread.ManagedThreadId + "----------------------------");
            Trace.WriteLine(command.CommandText );

            if(command.Parameters !=null && command.Parameters.Count >0)
            {
                Trace.WriteLine(command.Parameters[0].Value);
            }
          
            Trace.WriteLine("-------------------End thread id:" + Thread.CurrentThread.ManagedThreadId + "----------------------------");


            Trace.Flush();
            //base.ReaderExecuted(command, interceptionContext);
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            //base.ReaderExecuting(command, interceptionContext);

        }

        public override void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Trace.WriteLine(command.CommandText);
            //base.ScalarExecuted(command, interceptionContext);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            //base.ScalarExecuting(command, interceptionContext);
        }
    }
}
