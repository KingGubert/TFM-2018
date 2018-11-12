using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TFM.Model;
using System.Windows.Media;

namespace TFM.ViewModel
{
    public class CardStackViewmodel
    {

        #region properties
        public ObservableCollection<Card> Cards { get; set; }
        public string test { get; set; }
        public double Left { get; set; } = 10;
        public double Top { get; set; } = 10;
        #endregion



        #region constructor


        public CardStackViewmodel()
        {
            test = "hello";

            Cards = new ObservableCollection<Card>();
            for (int i = 0; i < 350; i++)
            {
              
                int leftdistance = 350 -i / 5;
                int topdistance = 350 -i / 5;
                Brush mycolor;
                if (i%2 == 1)
                    {
                    mycolor = Brushes.AntiqueWhite;
          
                }
                else
                { 
                mycolor = Brushes.Black;
               
                }

                Cards.Add(new Card(leftdistance, topdistance, mycolor));
            }
            
       





        }
        #endregion

    }
}
