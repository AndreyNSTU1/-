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
            if (Database.current_state != null && Database.next_state != null)
            {
                condition_transition transition = new condition_transition(Database.current_state, Database.transition_condition, Database.next_state);
                Database.Transitions.Add(transition);
                dataGridView1.Rows.Add(Database.Transitions[Database.Transitions.Count - 1].Current_condition, Database.Transitions[Database.Transitions.Count - 1].Transition_condition, Database.Transitions[Database.Transitions.Count - 1].Next_condition);
                Database.current_state = null;
                Database.next_state = null;
            }
            else
                MessageBox.Show("Не выбрано начальное и конечное состояния,повторите попытку!");

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            initial_state initial_State = new initial_state(textBox2.Text);
            final_state final_State = new final_state(textBox3.Text);
            string Curent_state = initial_State.name_of_state;
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
                        Curent_state = Database.Transitions[j].Next_condition;
                        err = false;
                        break;
                        }
                        else
                            err = true;                   
                    }
                    if (err)
                    {

                    break;                   
                    }
                                   
                }
            if (final_State.name_of_state != "" && initial_State.name_of_state!="")
            {
                if (Curent_state != final_State.name_of_state)
                    MessageBox.Show("Автомат не пришёл в конечное состояние" + " " + "Текущее состояние автомата" + " " + Curent_state);
                else
                    MessageBox.Show("Автомат пришёл в конечное состояние" + "" + Curent_state);
            }
            else
                MessageBox.Show("Введите начальное и конечное состояния");
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            try
            {
                for (int i = 0; i < Convert.ToInt32(textBox5.Text); i++)
                    Database.Conditions.Add(new state(Convert.ToString(i)));
                for (int j = 0; j < Database.Conditions.Count; j++)
                    dataGridView2.Rows.Add(Database.Conditions[j].name_of_state);
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show($"Argument error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                DialogResult = DialogResult.None;
            }
            catch (OverflowException ex)
            {
                MessageBox.Show($"Overflow error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                DialogResult = DialogResult.None;
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if (Database.current_state == null)
                Database.current_state = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
           else
                Database.next_state = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
    }   
}
