using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Passwords
{
    public partial class Form1 : Form
    {
        char[] ascii = new char[177];
        bool f=false;
        bool c=false;
        string[] str;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 177; i++) ascii[i] = (char)i;
            StreamReader stream = new StreamReader("baza.txt");
            str = stream.ReadToEnd().Split();
            Class1.parol = str[0];
            stream.Close();
            if (str[0].Length<4) f= true;
            else c= true;
            

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        int son = 1;
        private void Form1_Activated(object sender, EventArgs e)
        {
            if (f)
            {
                Form2 obj= new Form2();
                obj.ShowDialog();
                f = false;
            }
            else if(c)
            {
                Form3 sow = new Form3();
                sow.ShowDialog();
                c = false;
                int j = 0;
                for(int i=1;i<str.Length-3; i+=3)
                {
                    Button btn = new Button();
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn.ForeColor = System.Drawing.Color.Silver;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Dock = System.Windows.Forms.DockStyle.Right;
                    btn.Size = new System.Drawing.Size(210, 39);
                    btn.Name = str[i+2];
                    btn.Text = "🔒 ********";
                    btn.UseVisualStyleBackColor = true;
                    btn.Click += new EventHandler(show_Click);
                    TextBox txt = new TextBox();
                    txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
                    txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    txt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    txt.ForeColor = System.Drawing.Color.Silver;
                    txt.Location = new System.Drawing.Point(100, 60);
                    txt.Text = str[i] + " " + str[i + 1];
                    txt.Size = new System.Drawing.Size(200, 32);
                    son = int.Parse(str[i][0].ToString())+1;
                    txt.Dock = System.Windows.Forms.DockStyle.Left;
                    txt.Leave += new EventHandler(txt_change);
                    Panel obj = new Panel();
                    obj.BorderStyle = BorderStyle.FixedSingle;
                    obj.Dock = System.Windows.Forms.DockStyle.Top;
                    obj.Size = new System.Drawing.Size(433, 40);
                    list.Add(txt.Text + btn.Name);
                    obj.Controls.Add(btn);
                    obj.Controls.Add(txt);
                    panel4.Controls.Add(obj);
                }

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int l = 0;
            int katta = 0;
            int kichik = 0;
            int belgi = 0;
            int raqam = 0;
            if (textBox1.Text.Length < 8)
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Parol uzunligi 8 simvoldan kam!";
                panel1.BackColor = Color.Red;
            }
            else
            {
                int k = textBox1.Text.Length;

                char[] prl = new char[k];
                for (int i = 0; i < k; i++)
                {
                    prl[i] = textBox1.Text[l];
                    l++;
                }
                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < 177; j++)
                    {
                        if (prl[i] == ascii[j])
                        {
                            if (j >= 48 && j <= 57) raqam++;
                            else if (j >= 65 && j <= 90) katta++;
                            else if (j >= 97 && j <= 122) kichik++;
                            else belgi++;
                        }
                    }

                }

                if (kichik == 0 || katta == 0)
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "Parol zaif!";
                    panel1.BackColor = Color.Red;
                }
                else
                {
                    if (raqam != 0 || belgi != 0)
                    {

                        label1.ForeColor = Color.GreenYellow;
                        label1.Text = "Kuchli parol!";
                        panel1.BackColor = Color.GreenYellow;
                        if (belgi != 0 && raqam != 0)
                        {
                            label1.ForeColor = Color.DarkGreen;
                            label1.Text = "Zo'r parol!";
                            panel1.BackColor = Color.DarkGreen;
                        }
                    }
                    else
                    {
                        label1.ForeColor = Color.Orange;
                        label1.Text = "Yaxshi parol!";
                        panel1.BackColor = Color.Orange;
                    }

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<string> list = new List<string>();
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.ForeColor = System.Drawing.Color.Silver;
            btn.FlatAppearance.BorderSize = 0;
            btn.Dock = System.Windows.Forms.DockStyle.Right;
            btn.Size = new System.Drawing.Size(210, 39);
            btn.Name = textBox1.Text;
            btn.Text = "🔒 ********";
            btn.UseVisualStyleBackColor = true;            
            btn.Click += new EventHandler(show_Click);
            TextBox txt = new TextBox();
            txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txt.ForeColor = System.Drawing.Color.Silver;
            txt.Location = new System.Drawing.Point(100, 60);
            txt.Text = son + ") ";
            txt.Size = new System.Drawing.Size(200, 32);
            son++;
            txt.Dock = System.Windows.Forms.DockStyle.Left;
            txt.Leave += new EventHandler(txt_change);
            Panel obj = new Panel();
            obj.BorderStyle = BorderStyle.FixedSingle;
            obj.Dock = System.Windows.Forms.DockStyle.Top;
            obj.Size = new System.Drawing.Size(433, 40);
            list.Add(txt.Text + btn.Name);
            obj.Controls.Add(btn);
            obj.Controls.Add(txt);
            panel4.Controls.Add(obj);
        }
        int a = 0;
        private void txt_change(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            int index = 0;
            for(int i=0; i<list.Count; i++)
            {
                if (txt.Text[1] == list[i][1]) index = i;
            }
            
            File.AppendAllText("baza.txt", txt.Text + " " + list[index].Substring(3)+" ");
        }
        private void show_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "🔒 ********")
            {
                Form3 obj = new Form3();
                obj.ShowDialog();
                button.Text = button.Name;
            }
            else button.Text = "🔒 ********";


         }

       
    }
}