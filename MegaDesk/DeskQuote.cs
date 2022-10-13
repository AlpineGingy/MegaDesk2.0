using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MegaDesk
{
    // enums
    public enum RushOrder
    {
        [Description("Rush 3 Days")]
        Rush3Days,
        [Description("Rush 5 Days")]
        Rush5Days,
        [Description("Rush 7 Days")]
        Rush7Days,
        [Description("No Rush")]
        Normal14Days
    }

    internal class DeskQuote
    {
        // private variables
        private int[,] _rushOrderPrice;

        // constants
        public const decimal BASE_PRICE = 200;

        // constructor
        public string CustomerName { get; set; }
        public decimal QuotePrice { get; set; }
        public DateTime QuoteDate { get; set; }
        public int RushOrder { get; set; }
        public Desk Desk { get; set; }


        public decimal GetQuotePrice(Desk desk)
        {
            decimal cost = BASE_PRICE;
            int surfaceArea = desk.Width * desk.Depth;
            if(surfaceArea > 1000)
                cost += (surfaceArea - 1000);

            cost += (desk.NumberOfDrawers * 50);

            if (desk.DesktopMaterial == DesktopMaterial.Oak)
                cost += 200;
            else if (desk.DesktopMaterial == DesktopMaterial.Laminate)
                cost += 100;
            else if (desk.DesktopMaterial == DesktopMaterial.Pine)
                cost += 50;
            else if (desk.DesktopMaterial == DesktopMaterial.Rosewoord)
                cost += 300;
            else if (desk.DesktopMaterial == DesktopMaterial.Veneer)
                cost += 125;



            return cost;

        }

        private void getRushOrderPrices()
        {
            _rushOrderPrice = new int[3, 3];

            var pricesFile = @"rushOrderPrices.txt";

            string[] prices = File.ReadAllLines(pricesFile);
            int i = 0, j = 0;

            foreach (string s in prices)
            {
                _rushOrderPrice[i, j] = int.Parse(s);

                if (j == 2)
                {
                    i++;
                    j = 0;
                }
                else
                {
                    j++;
                }
            }



        }

    }
}
