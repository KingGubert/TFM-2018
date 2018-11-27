using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TFM.Model
{
    public class Card : NotifiableObject
    {
        public string cardname { get; set; }
        public double Left { get; set; } = 10;
        public double Top { get; set; } = 10;
        public Color cardcolor {get;set;}
        public Brush cardcolorbrush { get; set; }
        public int ZIndex { get; set; }

        public Card(double leftDistance, double topdistance, Brush ucardcolor, int uZIndex)
        {
            cardname = "test";
            Left = leftDistance;
            Top = topdistance;
            ZIndex = uZIndex;
            cardcolorbrush = ucardcolor;
               
        }

    }
}
