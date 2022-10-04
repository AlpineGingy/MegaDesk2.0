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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnAddQuote_Click(object sender, EventArgs e)
        {
            // Create and show Add Quote form
            var addQuote = new AddQuote(this);
            // addQuote.Tag = this;
            addQuote.Show();

            // Hide Main Menu
            this.Hide();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnViewQuotes_Click(object sender, EventArgs e)
        {
            // Create and show Add Quote form
            var viewAllQuotes = new ViewAllQuotes(this);
            // addQuote.Tag = this;
            viewAllQuotes.Show();

            // Hide Main Menu
            this.Hide();
        }

        private void btnSearchQuotes_Click(object sender, EventArgs e)
        {
            var searchQuotes = new SearchQuotes(this);
            // addQuote.Tag = this;
            searchQuotes.Show();

            // Hide Main Menu
            this.Hide();
        }
    }
}
