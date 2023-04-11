using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Passwords
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 4)
            {
                panel2.BackColor = Color.Red;
                button1.FlatAppearance.BorderColor = Color.Red;
            }
            else
            {
                panel2.BackColor = Color.White;
                Class1.parol = textBox1.Text;
                StreamWriter stream = new StreamWriter("baza.txt");
                stream.Write(Class1.parol+" ");
                stream.Close();
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 4)
            {
                panel2.BackColor = Color.Red;
                button1.FlatAppearance.BorderColor = Color.Red;
            }
            else
            {
                panel2.BackColor = Color.White;
                button1.FlatAppearance.BorderColor = Color.White;
            }
        }
    }
}
