using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Form2 : Form
    {
        public class condition 
        {
            public int Current_condition{ get; protected set;}

            public string Transition_condition { get; protected set; }

            public int Next_condition { get; protected set; }
            public condition(int current_condition, string transition_condition, int next_condition)
            {
                Current_condition = current_condition;
                Transition_condition = transition_condition;
                Next_condition = next_condition;
            }
        }

        public Form2()
        {
            InitializeComponent();
        }
        public void Form2_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            try
            { 
                var Current_condition = Convert.ToInt32(textBox1.Text);
                var Transition_condition = textBox2.Text;
                var Next_condition = Convert.ToInt32(textBox3.Text);

                condition Condition = new condition(Current_condition, Transition_condition, Next_condition);
                Database.Conditions.Add(Condition);
                Close();

            }
            catch (ArgumentException ex)
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
    }
}
