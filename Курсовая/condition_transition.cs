using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая
{
    public class condition_transition
    {
        public string Current_condition { get; protected set; }

        public string Transition_condition { get; protected set; }

        public string Next_condition { get; protected set; }
        public condition_transition(string current_state, string transition_condition, string next_state)
        {
            Current_condition = current_state;
            Transition_condition = transition_condition;
            Next_condition = next_state;
        }
    }
}
