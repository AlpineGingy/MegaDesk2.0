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
    public partial class DisplayQuote : Form
    {
        private DeskQuote _deskQuote;
        private Form _addQuote;
        internal DisplayQuote(DeskQuote deskQuote, Form addQuote)
        {
            InitializeComponent();

            // assign private variables
            _deskQuote = deskQuote;
            _addQuote = addQuote;

            // disable everything
            txtCustomerName.Enabled = false;

            // fill in form
            lblCost.Text = _deskQuote.QuotePrice.ToString();
            txtCustomerName.Text = _deskQuote.CustomerName.ToString();
            lblDate.Text = _deskQuote.QuoteDate.ToString();
            lblWidth.Text = _deskQuote.Desk.Width.ToString();
            lblDepth.Text = _deskQuote.Desk.Depth.ToString();
            lblDrawers.Text = _deskQuote.Desk.NumberOfDrawers.ToString();
            lblSurfaceMaterial.Text = _deskQuote.Desk.DesktopMaterial.ToString();
            lblDelivery.Text = _deskQuote.RushOrder.ToString();
            

        }

        private void DisplayQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            _addQuote.Close();
        }
    }
}
