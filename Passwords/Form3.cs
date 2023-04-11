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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == Class1.parol)
            {
                Class1.check = true;
                this.Close();
            }
            if (textBox1.Text.Length > Class1.parol.Length)
            {

            } 
            
        }
    }
}
