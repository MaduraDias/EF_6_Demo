using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Test
{
    public class Configuration:DbConfiguration
    {
        public Configuration()
        {
            SetDatabaseInitializer<CardAccountDBContext>(new DropCreateDatabaseIfModelChanges<CardAccountDBContext>());
        }
         
    }
}
