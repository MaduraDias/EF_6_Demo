using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Test
{
    public class Account
    {
        public long AccountId { get; set; }
        public virtual List<Card> Cards{get; set;}
        public string Description { get; set; }

}
}
