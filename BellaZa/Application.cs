using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        private JObject pizzaConfig;

        private UserProfile user;

        private bool fromCollection = false;
        private decimal netTotal;

        private Customer customer;

        private GMapMarker marker;

        public Application()
        {
            InitializeComponent();

            customer = new Customer();

            user = (UserProfile)Properties.Settings.Default["User"];
            user.pizzaCollection.Add(new Pizza.PizzaBuilder().setSize(PizzaSize.mini).addCrust(PizzaCrust.thin).addSauce(PizzaSauce.tomato).build());
            loadPizzaCollection();
        }

        private void Application_Load(object sender, EventArgs e)
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

            pay2Checkout.Tag = new TwoCheckOutPayment();
            payStripe.Tag = new StripePayment();
            payPaypal.Tag = new PaypalPayment();

            toppings = new List<PizzaTopping>();

            tabPage7.Enabled = false; //2nd in ltr
            tabPage2.Enabled = false;
            tabPage3.Enabled = false;
            tabPage4.Enabled = false;
            tabPage5.Enabled = false;
            tabPage6.Enabled = false;

            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl1.ShowCenter = false;
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 20;

            gMapControl1.Position = new PointLatLng(6.830142926398925, 79.88819107037106);
            gMapControl1.Zoom = 5;
            gMapControl1.DragButton = MouseButtons.Left;

            marker = new GMarkerGoogle(new PointLatLng(6.830142926398925, 79.88819107037106), GMarkerGoogleType.green_dot);
            marker.ToolTipText = "Bella Za shop";
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markersOverlay);

            gMapControl1.Hide();
            labelDistance.Hide();
            labelDuration.Hide();
            labelDeliveryCharge.Hide();
        }
        private void gMapControl1_OnMapClick(PointLatLng pointClick, MouseEventArgs e)
        {
            gMapControl1.Overlays.Clear();
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            markersOverlay.Markers.Add(marker);
            markersOverlay.Markers.Add(new GMarkerGoogle(pointClick, GMarkerGoogleType.red_small));
            gMapControl1.Overlays.Add(markersOverlay);

            getNavigationDetails(pointClick);
            tabPage7.Enabled = true;
        }

        private void getNavigationDetails(PointLatLng destination)
        {
            string result = Get("http://router.project-osrm.org/route/v1/driving/" + marker.Position.Lat + 
                ',' + marker.Position.Lng + ';' + destination.Lat + ',' + destination.Lng + "?overview=false");
            if (result == null) {
                labelDuration.Text = labelDistance.Text = "something went wrong.";
            }
            
            JObject json = JObject.Parse(result);
            double duration = Convert.ToDouble(json["routes"][0]["duration"]) / 60;
            double distance = Convert.ToDouble(json["routes"][0]["duration"]) / 100;

            labelDuration.Text = Math.Round(duration, 2).ToString() + " hrs";
            labelDistance.Text = Math.Round(distance, 2).ToString() + " metres";

            Console.WriteLine(result);
        }

        public string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            Console.WriteLine(uri);

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
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
            tabPage2.Enabled = true;
        }

        private void crustChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                crust = (PizzaCrust)((RadioButton)sender).Tag;

            //Console.WriteLine(crust.ToString());
            tabPage3.Enabled = true;
        }

        private void sauceChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                sauce = (PizzaSauce)((RadioButton)sender).Tag;

            //Console.WriteLine(sauce.ToString());
            tabPage4.Enabled = true;
        }

        private void cheeseChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                cheese = (PizzaCheese)((RadioButton)sender).Tag;

            //Console.WriteLine(cheese.ToString());
            tabPage5.Enabled = true;
        }

        private void toppingsChanged(object sender, EventArgs e)
        {
            if(((CheckBox)sender).CheckState == CheckState.Checked)
                toppings.Add((PizzaTopping)((CheckBox)sender).Tag);
            if (((CheckBox)sender).CheckState == CheckState.Unchecked)
                toppings.Remove((PizzaTopping)((CheckBox)sender).Tag);
            tabPage6.Enabled = true;
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

            var arr = new string[] { mode.ToString(), "250" };
            var str = mode.ToString();

            var pickupItem = new ListViewItem(str, listPizzaComponents.Groups[0]);
            var deliveryItem = new ListViewItem(arr, listPizzaComponents.Groups[0]);

            listPizzaComponents.Items.Add(this.mode == PizzaMode.pickup ? pickupItem : deliveryItem);
            listPizzaComponents.Items.Add(new ListViewItem("Size: " + size.ToString(), listPizzaComponents.Groups[0]));
            listPizzaComponents.Items.Add(new ListViewItem(new string[]{ crust.ToString(), pizza.crustPrice.ToString() }, listPizzaComponents.Groups[1]));
            listPizzaComponents.Items.Add(new ListViewItem(new string[]{ sauce.ToString(), pizza.saucePrice.ToString() }, listPizzaComponents.Groups[1]));
            listPizzaComponents.Items.Add(new ListViewItem(new string[]{ cheese.ToString(), pizza.cheesePrice.ToString() }, listPizzaComponents.Groups[1]));
            listPizzaComponents.Items.Add(new ListViewItem(new string[]{ String.Join(", ", pizza.toppings), pizza.toppingsPrice.ToString() }, listPizzaComponents.Groups[1]));

            decimal loyaltyPercentage = 12;
            decimal total = pizza.getPrice();
            decimal discount = total * loyaltyPercentage / 100;
            netTotal = total - discount;

            labelDiscount.Text = discount.ToString();
            labelTotal.Text = netTotal.ToString();
        }

        private void loadPizzaCollection()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (Pizza pizza in user.pizzaCollection)
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

            if (mode == PizzaMode.delivery)
            {
                gMapControl1.Show();
                labelDistance.Show();
                labelDuration.Show();
                labelDeliveryCharge.Show();
                tabPage7.Enabled = false;
            }
            else
            {
                gMapControl1.Hide();
                labelDistance.Hide();
                labelDuration.Hide();
                labelDeliveryCharge.Hide();
                tabPage7.Enabled = true;
            }
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

            user.pizzaCollection.Add(newPizza);
            loadPizzaCollection();

            textPizzaName.Text = "";
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex < 0) return;
            e.Cancel = !e.TabPage.Enabled;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void PayButton_Click(object sender, EventArgs e)
        {
            var paymentStrategy = (IPaymentStrategy)((Button)sender).Tag;
            var paymentContext = new PaymentContext(paymentStrategy);
            paymentContext.ExecutePayment(netTotal);

            AddNewOrder();
        }

        private void AddNewOrder()
        {
            statusBarOrderCount.Text = (int.Parse(statusBarOrderCount.Text) + 1).ToString();

            OrderContext orderContext = new OrderContext(new OrderPlacedState());
        }
    }
}
