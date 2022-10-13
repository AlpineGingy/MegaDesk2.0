using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace MegaDesk
{
    public partial class AddQuote : Form
    {
        private Form _mainMenu;
        public AddQuote(Form mainMenu)
        {
            InitializeComponent();

            // assign private variables
            _mainMenu = mainMenu;

            // assign min/max of controls
            this.numDeskWidth.Maximum = Desk.MAX_WIDTH;
            this.numDeskWidth.Minimum = Desk.MIN_WIDTH;
            this.numDeskDepth.Maximum = Desk.MAX_DEPTH;
            this.numDeskDepth.Minimum = Desk.MIN_DEPTH;
            this.numDeskDrawers.Maximum = Desk.MAX_DESK_DRAWERS;
            this.numDeskDrawers.Minimum = Desk.MIN_DESK_DRAWERS;

            // Get and store date
            DateTime today = DateTime.Now;
            this.lblDate.Text = today.ToString("dd MMMM yyyy");

            // Fill the ComboBox with Enums
            this.selectSurfaceMat.DataSource = Enum.GetValues(typeof(DesktopMaterial));
            //List<string> shippingDescriptions = new List<string>();
            //foreach (DeliveryNotificationOptions delivery in shipping)
            this.selectDelivery.DataSource = Enum.GetNames(typeof(RushOrder));

            // Set default to empty
            selectSurfaceMat.SelectedIndex = -1;
            selectDelivery.SelectedIndex = -1;

            // Set number boxes to a blank string
            numDeskDepth.Text = "";
            numDeskWidth.Text = "";
            numDeskDrawers.Text = "";
        }

        private void AddQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            //var mainMenu = (MainMenu)this.Tag;
            //mainMenu.Show();
            _mainMenu.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Create a Desk object and a DeskQuote object
            var desk = new Desk
            {
                // Fill in data for desk object
                Depth = (int)numDeskDepth.Value,
                Width = (int)numDeskWidth.Value,
                NumberOfDrawers = (int)numDeskDrawers.Value,
                DesktopMaterial = (DesktopMaterial)selectSurfaceMat.SelectedValue
            };
            var deskQuote = new DeskQuote
            {
                // Fill in data for deskQuote object
                CustomerName = txtCustomerName.Text,
                QuoteDate = DateTime.Now,
                RushOrder = 3,//selectDelivery.SelectedValue,
                Desk = desk,
            };

            deskQuote.QuotePrice = deskQuote.GetQuotePrice(desk);

            // add quote to file
            AddQuoteToFile(deskQuote);


            // show DisplayQuote form


        }

        // write quotes to quotes.json
        // If quote exists, write to it
        // Else load into new one and add to it
        // Load into list object of job DiskQuote
        private void AddQuoteToFile(DeskQuote deskQuote)
        {
            var quotesFile = @"quotes.json";
            List<DeskQuote> deskQuotes = new List<DeskQuote>();

            // read existing quotes
            if (File.Exists(quotesFile))
            {
                using (StreamReader reader = new StreamReader(quotesFile))
                {
                    // load existing quotes
                    string quotes = reader.ReadToEnd();

                    if (quotes.Length > 0)
                    {
                        // deserialize quotes
                        deskQuotes = JsonSerializer.Deserialize<List<DeskQuote>>(quotes);
                    }
                }
            }

            deskQuotes.Add(deskQuote);

            SaveQuotes(deskQuotes);

        }

        private void SaveQuotes(List<DeskQuote> quotes)
        {
            var quotesFile = @"quotes.json";

            // serialize quotes
            var serializedQuotes = JsonSerializer.Serialize(quotes);

            // wrtie quotes to file
            File.WriteAllText(quotesFile, serializedQuotes);
        }

    }
}
