using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace gameArkanoid
{
    public partial class Form1 : Form
    {
        private void stopTime(int time)
        {
            System.Threading.Thread.Sleep(time);
        }

        private int[][] data =
        {
            new int[] { 2, 1, 3},
            new int[] { 1, 2, 4},
            new int[] { 4, 6, 5},
            new int[] { 6, 5, 3},
        };

        Semaphore sema;
        private string id;
        private Button lastBtn;
        private bool flag = false;
        private int counter = 0;
        private bool isWin()
        {
            return (data.Length * data[0].Length) / 2 == counter;
        }

        private void myClick(object sender, EventArgs e)
        {
            sema = new Semaphore(1, 2);
            sema.WaitOne();
            Button btn = sender as Button;
            if (!flag)
            {
                id = btn.Tag.ToString();
                lastBtn = btn;
                btn.BackColor = Color.BurlyWood;
                btn.Text = btn.Tag.ToString();
            }
            else
            {

                if (id == btn.Tag.ToString())
                {
                    btn.Text = btn.Tag.ToString();
                    btn.Click -= myClick;
                    lastBtn.Click -= myClick;
                    counter++;
                    btn.BackColor = Color.BurlyWood;
                    sema.WaitOne(200);
                    btn.BackColor = Color.AliceBlue;
                    lastBtn.BackColor = Color.AliceBlue;
                }
                else
                {
                    btn.Text = btn.Tag.ToString();
                    btn.BackColor = Color.BurlyWood;
                    sema.WaitOne(200);
                    btn.BackColor = Color.AliceBlue;
                    lastBtn.BackColor = Color.AliceBlue;
                    lastBtn.Text = "";
                    btn.Text = "";
                }
            }

            flag = !flag;

            if (isWin())
            {
                MessageBox.Show("WIN");
            }
        }
        public Form1()
        {
            InitializeComponent();
            int btnHeight = 100;
            int btnWidth = 100;
            panel1.Height = data.Length * btnHeight;
            panel1.Width = data[0].Length * btnWidth;

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[0].Length; j++)
                {
                    Button btn = new Button();
                    btn.Width = btnWidth;
                    btn.Height = btnHeight;
                    btn.Left = j * btnWidth;
                    btn.Top = i * btnHeight;
                    btn.Tag = $"{data[i][j]}";
                    btn.Click += myClick;
                    btn.Font = new Font(btn.Font.FontFamily, 16);
                    btn.BackColor = Color.AliceBlue;
                    panel1.Controls.Add(btn);
                }
            }
        }
    }
}
