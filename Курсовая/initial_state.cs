using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая
{
    internal class initial_state : state
    {
        public initial_state(string Name_of_state) : base(Name_of_state)
        {

        }
        public override bool checking_state()
        {            
            return true;
        }
    }
}
