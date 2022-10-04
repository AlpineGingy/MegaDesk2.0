using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk
{
    // enums
    public enum DesktopMaterial
    {
        Laminate,
        Oak,
        Rosewoord,
        Veneer,
        Pine
    }

    internal class Desk
    {
        // constants
        public const short MIN_WIDTH = 24;
        public const short MAX_WIDTH = 96;
        public const short MIN_DEPTH = 12;
        public const short MAX_DEPTH = 48;
        public const short MIN_DESK_DRAWERS = 0;
        public const short MAX_DESK_DRAWERS = 7;
        public float Width { get; set; }

        public float Depth { get; set; }

        public int NumberOfDrawers { get; set; }

        public DesktopMaterial DesktopMaterial { get; set; }

    }
}
