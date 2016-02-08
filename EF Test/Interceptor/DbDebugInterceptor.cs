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
            
            Debug.WriteLine(command.CommandText + " thread id:" + Thread.CurrentThread.ManagedThreadId);
            Debug.Flush();
        }

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
           
        }

        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {

            Debug.WriteLine( "-------------------Start Query----------------------------");
            Debug.WriteLine(command.CommandText );

            if(command.Parameters !=null)
            {
                foreach(var p in command.Parameters)
                {
                    Debug.WriteLine(p.ToString());
                }
            }
          
            Debug.WriteLine("-------------------End Query----------------------------");
           
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            //base.ReaderExecuting(command, interceptionContext);

        }

        public override void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Debug.WriteLine(command.CommandText);
            //base.ScalarExecuted(command, interceptionContext);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            //base.ScalarExecuting(command, interceptionContext);
        }
    }
}
