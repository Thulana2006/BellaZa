﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BellaZa
{
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void buttonSignin_Click(object sender, EventArgs e)
        {
            if(textL1.Text != "" && textL2.Text != "")
            {
                UserProfile user = (UserProfile)Properties.Settings.Default["User"];
                if(user.Name == textL1.Text && user.checkPassword(textL2.Text))
                {
                    this.Hide();
                    Application application = new Application();
                    application.Show();
                }

            }
        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {
            if (textR2.Text == textR3.Text && textR2.Text != "" && textR1.Text != "")
            {
                UserProfile user = new UserProfile(textR1.Text, textR2.Text);
                Properties.Settings.Default["User"] = user;
                Properties.Settings.Default.Save();
            }
        }
    }
}
