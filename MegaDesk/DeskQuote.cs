using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk
{
    internal class DeskQuote
    {
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

    }
}
