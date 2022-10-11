using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            // Fill the ComboBox with Enum DesktopMaterial
            this.selectSurfaceMat.DataSource = Enum.GetValues(typeof(DesktopMaterial));
            this.selectDelivery.DataSource = Enum.GetNames(typeof(RushOrder));
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
            var desk = new Desk();
            var deskQuote = new DeskQuote();

            // Fill in data for desk object
            desk.Depth = (int)numDeskDepth.Value;
            desk.Width = (int)numDeskWidth.Value;
            desk.NumberOfDrawers = (int)numDeskDrawers.Value;
            desk.DesktopMaterial = (DesktopMaterial)selectSurfaceMat.SelectedValue;

            // Fill in data for deskQuote object
            deskQuote.CustomerName = txtCustomerName.Text;
            deskQuote.QuoteDate = DateTime.Now;
            deskQuote.RushOrder = (int)selectDelivery.SelectedValue;
            deskQuote.Desk = desk;
            deskQuote.QuotePrice = deskQuote.GetQuotePrice(desk);

            // write quotes to quotes.json
            // If quote exists, write to it
            // Else load into new one and add to it
            // Load into list object of job DiskQuote

            // show DisplayQuote form


        }
    }
}
