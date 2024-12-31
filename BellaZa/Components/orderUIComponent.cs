using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BellaZa.Components
{
    public partial class orderUIComponent : UserControl
    {
        public orderUIComponent(Order order)
        {
            InitializeComponent();

            InitializeDetails();
        }

        private void InitializeDetails()
        {
            Order.
        }

        private void labelStates_TextChanged(object sender, EventArgs e)
        {
            ((Label)sender).Text = ((Label)sender).Text.ToUpper();
        }
    }
}
