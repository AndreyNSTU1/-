using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static Курсовая.Form2;

namespace Курсовая
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            Form2 f2;
            f2 = new Form2();
            f2.ShowDialog();
            condition_transition transition = new condition_transition(Database.current_condition, Database.transition_condition, Database.next_condition);
            Database.Transitions.Add(transition);
            dataGridView1.Rows.Add(Database.Transitions[Database.Transitions.Count - 1].Current_condition, Database.Transitions[Database.Transitions.Count - 1].Transition_condition, Database.Transitions[Database.Transitions.Count - 1].Next_condition);
            Database.current_condition = null;
            Database.next_condition = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string initial_condition = "";
            string final_condition = textBox3.Text;
            string Curent_condition = initial_condition;
            string original_signal = textBox1.Text;

            bool err = false;
            string txt;
                for (int i = 0; i < original_signal.Length; i++)
                {                   
                    for (int j = 0; j< Database.Transitions.Count;j++)
                    {
                        txt = original_signal[i].ToString();
                        if ((String.Compare(txt,Database.Transitions[j].Transition_condition)) == 0)
                        {
                        Curent_condition = Database.Transitions[j].Next_condition;
                        textBox4.Text = Curent_condition.ToString();
                        err = false;
                        break;
                        }
                        else
                            err = true;                   
                    }
                    if (err)
                    {
                    textBox4.Text= Curent_condition;
                    break;                   
                    }
                                   
                }
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            for (int i=0;i <Convert.ToInt32(textBox5.Text);i++)
                Database.Conditions.Add(new condition(Convert.ToString(i)));
            for (int j = 0; j < Database.Conditions.Count; j++)
                dataGridView2.Rows.Add(Database.Conditions[j].name_of_condition);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if (Database.current_condition == null)
                Database.current_condition = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
           else
                Database.next_condition = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
    }   
}
