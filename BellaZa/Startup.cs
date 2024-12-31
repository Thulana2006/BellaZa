using System;
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
            UserProfile user = (UserProfile)Properties.Settings.Default["User"];
            
            if(textL1.Text != "" && textL2.Text != "" && 
                user.Name == textL1.Text && user.checkPassword(textL2.Text))
            {
                this.Hide();
                Application application = new Application();
                application.Show();
            }
            else
            {
                string msgStr = "error occured";

                if (textL1.Text == "") msgStr = "Please enter the username !";
                if (textL2.Text == "") msgStr = "Please enter the password !";
                else if (user.Name != textL1.Text) msgStr = "Username or password is incorrect !";
                if (!user.checkPassword(textL2.Text)) msgStr = "Username or password is incorrect !";

                MessageBox.Show(msgStr, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {
            if (textR2.Text == textR3.Text && textR2.Text != "" && textR1.Text != "")
            {
                try
                {
                    UserProfile user = new UserProfile(textR1.Text, textR2.Text);
                    Properties.Settings.Default["User"] = user;
                    Properties.Settings.Default.Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                string msgStr = "error occured";

                if (textR2.Text == "") msgStr = "Please provide a password !";
                else if (textR1.Text == "") msgStr = "Please provide a name !";
                else if (textR3.Text == "") msgStr = "Please confirm the password !";
                else if (textR2.Text != textR3.Text) msgStr = "Passwords do not match !";

                MessageBox.Show(msgStr, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
