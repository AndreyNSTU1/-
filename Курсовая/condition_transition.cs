using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая
{
    public class condition_transition
    {
        public string Current_state;

        public string Transition_condition;

        public string Next_state;

        public condition_transition(string current_state, string transition_condition, string next_state)
        {
            Current_state = current_state;
            Transition_condition = transition_condition;
            Next_state = next_state;
        }
    }
}
