using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk
{
    public partial class ViewAllQuotes : Form
    {
        private Form _mainMenu;
        public ViewAllQuotes(Form mainMenu)
        {
            InitializeComponent();

            // assign private variables
            _mainMenu = mainMenu;

            loadGrid();
        }

        private void ViewAllQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            //var mainMenu = (MainMenu)this.Tag;
            //mainMenu.Show();
            _mainMenu.Show();
        }
        private void loadGrid()
        {
            var quotesFile = @"quotes.json";
            if (File.Exists(quotesFile))
            {
                using (StreamReader reader = new StreamReader(quotesFile))
                {
                    string quotes = reader.ReadToEnd();
                    List<DeskQuote> deskQuotes = JsonSerializer.Deserialize<List<DeskQuote>>(quotes);
                    dataGridView1.DataSource = deskQuotes.Select(d => new
                    {
                        Date = d.QuoteDate,
                        Costumer = d.CustomerName,
                        Depth = d.Desk.Depth,
                        Width = d.Desk.Width,
                        Drawers = d.Desk.NumberOfDrawers,
                        SurfaceMaterial = d.Desk.DesktopMaterial,
                        DeliveryType = d.RushOrder,
                        QuoteAmount = d.QuotePrice.ToString("c")
                    }
                    ).ToList();
                }
            }
        }
    }
}
