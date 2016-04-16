﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pctesting
{
    public partial class UserForm : Form
    {
        FileManager fileWatcher = new FileManager();
        TrafficManager trafficWatcher = new TrafficManager();
        ProcessControl process = new ProcessControl();
        KeyHook kh = new KeyHook();
        public UserForm()
        {
            InitializeComponent();
            fileWatcher.watch();
            trafficWatcher.Start();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if(this.WindowState==FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            process.UpdateProcess();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            trafficWatcher.Stop();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            kh.KeyDown += new KeyEventHandler(kh_KeyDown);
            kh.KeyUp += new KeyEventHandler(kh_KeyUp);
        }

        void kh_KeyUp(object sender, KeyEventArgs e)
        {

            e.Handled = true;
        }

        void kh_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
