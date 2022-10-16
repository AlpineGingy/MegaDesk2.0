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
    public partial class SearchQuotes : Form
    {
        private Form _mainMenu;
        public SearchQuotes(Form mainMenu)
        {
            InitializeComponent();

            // assign private variables
            _mainMenu = mainMenu;

            this.selectSurfaceMat.DataSource = Enum.GetValues(typeof(DesktopMaterial));

            selectSurfaceMat.SelectedIndex = -1;

            loadGrid();
        }

        private void SearchQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            //var mainMenu = (MainMenu)this.Tag;
            //mainMenu.Show();
            _mainMenu.Show();
        }
        private void loadGrid()
        {
            var quotesFile = @"quotes.json";

                using (StreamReader reader = new StreamReader(quotesFile))
                {
                    string quotes = reader.ReadToEnd();
                    List<DeskQuote> deskQuotes = System.Text.Json.JsonSerializer.Deserialize<List<DeskQuote>>(quotes);
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
        private void loadGrid(DesktopMaterial desktopMaterial)
        {
            var quotesFile = @"quotes.json";

                using (StreamReader reader = new StreamReader(quotesFile))
                {
                    string quotes = reader.ReadToEnd();
                    List<DeskQuote> deskQuotes = System.Text.Json.JsonSerializer.Deserialize<List<DeskQuote>>(quotes);
                    dataGridView1.DataSource = deskQuotes
                    .Select(d => new
                    {
                        Date = d.QuoteDate,
                        Costumer = d.CustomerName,
                        Depth = d.Desk.Depth,
                        Width = d.Desk.Width,
                        Drawers = d.Desk.NumberOfDrawers,
                        SurfaceMaterial = d.Desk.DesktopMaterial,
                        DeliveryType = d.RushOrder,
                        QuoteAmount = d.QuotePrice.ToString("c")
                    })
                    .Where(q => q.SurfaceMaterial == desktopMaterial)
                    .ToList();
                }
            
        }

        private void selectSurfaceMat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            if (combo.SelectedIndex < 0)
            {
                loadGrid();
            }
            else
            {
                loadGrid((DesktopMaterial)combo.SelectedValue);
            }
        }
    }
}
