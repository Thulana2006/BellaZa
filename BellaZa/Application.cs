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
    public partial class Application : Form
    {
        private PizzaMode mode;
        private PizzaSize size;
        private PizzaCrust crust;
        private PizzaSauce sauce;
        private PizzaCheese cheese;
        private List<PizzaTopping> toppings;

        private Customer customer;

        private bool fromCollection = false;

        public Application()
        {
            InitializeComponent();

            customer = (Customer)Properties.Settings.Default["User"];
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            radioM1.Tag = PizzaMode.pickup;
            radioM2.Tag = PizzaMode.delivery;

            radioS1.Tag = PizzaSize.mini;
            radioS2.Tag = PizzaSize.large;
            radioS3.Tag = PizzaSize.extraLarge;

            radioC1.Tag = PizzaCrust.thin;
            radioC2.Tag = PizzaCrust.thick;
            radioC3.Tag = PizzaCrust.cauliflower;
            radioC4.Tag = PizzaCrust.sicilian;

            radioSa1.Tag = PizzaSauce.tomato;
            radioSa2.Tag = PizzaSauce.marinara;

            radioCh1.Tag = PizzaCheese.mozarella;
            radioCh2.Tag = PizzaCheese.parmessa;
            radioCh3.Tag = PizzaCheese.provolone;
            radioCh4.Tag = PizzaCheese.cheddar;
            radioCh5.Tag = PizzaCheese.ricotto;
            radioCh6.Tag = PizzaCheese.feta;

            checkT1.Tag = PizzaTopping.pepperoni;
            checkT2.Tag = PizzaTopping.mushrooms;
            checkT3.Tag = PizzaTopping.sausage;
            checkT4.Tag = PizzaTopping.spinach;
            checkT5.Tag = PizzaTopping.bacon;
            checkT6.Tag = PizzaTopping.blackOlive;

            toppings = new List<PizzaTopping>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 4;
        }

        private void btnPickup_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void sizeChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                size = (PizzaSize)((RadioButton)sender).Tag;

            //Console.WriteLine(size.ToString());
        }

        private void crustChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                crust = (PizzaCrust)((RadioButton)sender).Tag;
        
            //Console.WriteLine(crust.ToString());

        }

        private void sauceChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                sauce = (PizzaSauce)((RadioButton)sender).Tag;
        
            //Console.WriteLine(sauce.ToString());

        }

        private void cheeseChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                cheese = (PizzaCheese)((RadioButton)sender).Tag;
        
            //Console.WriteLine(cheese.ToString());
        }

        private void toppingsChanged(object sender, EventArgs e)
        {
            if(((CheckBox)sender).CheckState == CheckState.Checked)
                toppings.Add((PizzaTopping)((CheckBox)sender).Tag);
            if (((CheckBox)sender).CheckState == CheckState.Unchecked)
                toppings.Remove((PizzaTopping)((CheckBox)sender).Tag);
        }

        private void tabPage6_Enter(object sender, EventArgs e)
        { 
            if(fromCollection)
            {
                fromCollection = false;
                return;
            }    

            Pizza newPizza = new Pizza.PizzaBuilder()
                .setSize(size)
                .addCrust(crust)
                .addSauce(sauce)
                .addCheese(cheese)
                .addToppings(toppings)
                .build();

            loadPizzaBill(newPizza);
        }

        private void loadPizzaBill(Pizza pizza)
        {
            listPizzaComponents.Items.Clear();

            listPizzaComponents.Items.Add(new ListViewItem(mode.ToString(), listPizzaComponents.Groups[0]));
            listPizzaComponents.Items.Add(new ListViewItem("Size: " + size.ToString(), listPizzaComponents.Groups[0]));
            listPizzaComponents.Items.Add(new ListViewItem(new string[]{ crust.ToString(), pizza.crustPrice.ToString() }, listPizzaComponents.Groups[1]));
            listPizzaComponents.Items.Add(new ListViewItem(new string[]{ sauce.ToString(), pizza.saucePrice.ToString() }, listPizzaComponents.Groups[1]));
            listPizzaComponents.Items.Add(new ListViewItem(new string[]{ cheese.ToString(), pizza.cheesePrice.ToString() }, listPizzaComponents.Groups[1]));
            listPizzaComponents.Items.Add(new ListViewItem(new string[]{ String.Join(", ", pizza.toppings), pizza.toppingsPrice.ToString() }, listPizzaComponents.Groups[1]));

            double loyaltyPercentage = 12;
            double total = pizza.getPrice();
            double discount = total * loyaltyPercentage / 100;
            double netTotal = total - discount;

            labelDiscount.Text = discount.ToString();
            labelTotal.Text = netTotal.ToString();
        }

        private void loadPizzaCollection()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (Pizza pizza in customer.pizzaCollection)
            {
                Console.WriteLine(pizza.getDescription());

                Button button = new Button();
                button.Text = pizza.getDescription();
                button.AutoSize = true;
                button.Parent = flowLayoutPanel1;
                button.Tag = pizza;

                button.Click += CollectionPizza_Click;
            }
        }

        private void CollectionPizza_Click(object sender, EventArgs e)
        {
            Pizza pizza = (Pizza)((Button)sender).Tag;

            fromCollection = true;

            tabControl2.SelectedIndex = 0;
            tabControl1.SelectedIndex = tabControl1.TabCount - 1;

            textPizzaName.Text = pizza.name;

            loadPizzaBill(pizza);
        }

        private void modeChanged(object sender, EventArgs e)
        {
            mode = (PizzaMode)((RadioButton)sender).Tag;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (textPizzaName.Text == "") return;

            Pizza newPizza = new Pizza.PizzaBuilder()
                .setSize(size)
                .addCrust(crust)
                .addSauce(sauce)
                .addCheese(cheese)
                .addToppings(toppings)
                .build();

            newPizza.name = textPizzaName.Text;

            customer.pizzaCollection.Add(newPizza);
            loadPizzaCollection();

            textPizzaName.Text = "";
        }
    }
}
