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


        DataTable table = new DataTable();


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


            dataGridView1.Rows.Add(Database.Conditions[Database.Conditions.Count-1].Current_condition, Database.Conditions[Database.Conditions.Count-1].Transition_condition, Database.Conditions[Database.Conditions.Count-1].Next_condition);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int initial_condition = Convert.ToInt32(textBox2.Text);
            int final_condition = Convert.ToInt32(textBox3.Text);
            int curent_condition = initial_condition;
            string original_signal = textBox1.Text;

            bool err = false;
            string txt;
                for (int i = 0; i < original_signal.Length; i++)
                {                   
                    for (int j = 0; j< Database.Conditions.Count;j++)
                    {
                        txt = original_signal[i].ToString();
                        if ((String.Compare(txt,Database.Conditions[j].Transition_condition)) == 0)
                        {
                        curent_condition = Database.Conditions[j].Next_condition;
                        textBox4.Text = curent_condition.ToString();
                        err = false;
                        break;
                        }
                        else
                            err = true;                   
                    }
                    if (err)
                    {
                    textBox4.Text= curent_condition.ToString();
                    break;
                    
                    }
                                   
                }
        }

    }   
}
