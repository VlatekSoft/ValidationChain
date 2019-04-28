using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace SharpVersion
{
    public delegate void EventDelegate(object sender, object arg);
    interface IView
    {
        event EventDelegate SubmitForm;
        event EventDelegate PrintKeys;
        event EventDelegate SubSoft;
        event EventHandler test;
        event EventDelegate Restore;
        void Check(int i);
    }
    public partial class Form1 : Form, IView
    {
        public Form1()
        {
            InitializeComponent();
            PrintKeys += PrintKeysOut;
        }

        public event EventDelegate SubmitForm;
        public event EventDelegate PrintKeys;
        public event EventDelegate SubSoft;
        public event EventHandler test;
        public event EventDelegate Restore;

        public void Check(int i)
        {
            if (i == 0)
                checkBox1.Checked = true;
            else if (i == 1)
                checkBox2.Checked = true;
        }

        public void PrintKeysOut(object sender, object arg)
        {

        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            label6.Text = openFileDialog1.FileName;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> hard = new Dictionary<string, string>();
            hard.Add("Surname", textBox1.Text);
            hard.Add("Name", textBox2.Text);
            hard.Add("Name_2", textBox3.Text);
            hard.Add("Passport", textBox4.Text);
            hard.Add("Birthday", dateTimePicker1.Text);
            hard.Add("Phone", textBox8.Text);
            hard.Add("Email", textBox7.Text);
            hard.Add("Color", textBox6.Text);
            hard.Add("MumSurname", textBox5.Text);
            hard.Add("Image1", openFileDialog1.FileName);
            hard.Add("Image2", openFileDialog2.FileName);
            if (radioButton1.Checked == true)
            {
                if (SubSoft != null)
                {
                    SubSoft(this, hard);
                }
                if (SubmitForm != null)
                {
                    SubmitForm(this, hard);
                }
            }
            else
            {
                if (Restore != null)
                {
                    Restore(this, hard);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (test != null)
                test(this, EventArgs.Empty);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }
    }
}
