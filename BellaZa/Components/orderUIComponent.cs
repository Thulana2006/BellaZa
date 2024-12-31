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
    public partial class OrderUIComponent : UserControl, IOrderObserver
    {
        public PizzaOrder Order { get; }

        private string _status;
        public string Status { get
            {
                return _status;
            }
        }

        public OrderUIComponent(PizzaOrder order)
        {
            InitializeComponent();

            this.Order = order;
            Order.Subscribe(this);

            InitializeDetails();
        }

        private void InitializeDetails()
        {
            labelDetails.Text = Order.Pizza.getDescription();
            labelPrice.Text = Order.DiscountedPrice.ToString() + " LKR";
            
            buttonCancel.Visible = !Order.Paid;
            labelPaidState.Visible = Order.Paid;
            labelMode.Text = Order.Mode.ToString().ToUpper();
        }

        private void labelStates_TextChanged(object sender, EventArgs e)
        {
            ((Label)sender).Text = ((Label)sender).Text.ToUpper();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Order.Rating = (double) numericUpDown1.Value;
        }

        public void Update(string status)
        {
            labelState.Text = status;
            this._status = status;

            if(status.ToLower() != "order placed") buttonCancel.Visible = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //user executing cancel command
            //undo ing order
        }
    }
}
