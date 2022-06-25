using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Görev_Programı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int süre;
        int ondakika = 10;
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Süre girmelisiniz. O yüzden Otomatik 10 dakika olarak ayarlanmış ve Süre başlatılmıştır. ");
                textBox1.Text = ondakika.ToString();
            }
            süre = Convert.ToInt16(textBox1.Text);
            textBox1.Clear();
            süre = süre * 60;
            label4.Text = süre.ToString();
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            süre--;
            label4.Text = süre.ToString();
            if (süre == 0)
            {
                if (radioButton1.Checked == true)
                {
                    timer1.Stop();
                    Process.Start("Shutdown.exe", "-S");
                }
                else if (radioButton2.Checked == true)
                {
                    timer1.Stop();
                    Process.Start("Shutdown.exe", "-R");
                }
                else if (radioButton3.Checked == true)
                {
                    timer1.Stop();
                    Process.Start("Rundll32.exe", "powrprof.dll, SetSuspendState 0,1,0");
                    

                }
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
