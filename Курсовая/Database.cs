using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Курсовая.Form1;

namespace Курсовая
{
    public static class Database
    {
        public static List<condition_transition> Transitions = new List<condition_transition>();
        public static List<state> Conditions = new List<state>();
        public static string transition_condition = null;
        public static string current_state= null;
        public static string next_state = null;
    }
    
}
