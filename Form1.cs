using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeAreDevs_API;

namespace ShansPloit_v2
{
    public partial class ShansPloitV2 : Form
    {
        Point lastPoint;
        ExploitAPI exploit = new ExploitAPI();
        public ShansPloitV2()
        {
            InitializeComponent();
        }
        
        private async void ShansPloitV2_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");

            while (true)
            {
                if (exploit.isAPIAttached() == true)
                {
                    label4.Text = "Injected";
                    label4.ForeColor = Color.Green;
                }
                else
                {
                    label4.Text = "Not Injected";
                    label4.ForeColor = Color.Red;
                }
                await Task.Delay(50);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            exploit.LaunchExploit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            exploit.SendLuaScript(fastColoredTextBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Clear();
            fastColoredTextBox1.Text = "-- Made by smallpp#1045 on discord or @shany26M10 on roblox.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                fastColoredTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(fastColoredTextBox1.Text);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Options openform = new Options();
            openform.Show();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//Clear Items in the LuaScriptList
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }
    }
}
