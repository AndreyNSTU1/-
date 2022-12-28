using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая
{
    public class state
    {
        public string name_of_state { get; protected set; }

        public state(string Name_of_state)
        {
            name_of_state = Name_of_state;
        }

        public virtual bool checking_state()
        {
            return false;
        }
    }
}
