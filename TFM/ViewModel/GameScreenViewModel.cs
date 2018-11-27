using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TFM.Dataprovider;
using TFM.Model;

namespace TFM.ViewModel
{

    /// <summary>
    /// Interaktionslogik des eigentlichen Spiels
    /// </summary>
    public class GameScreenViewModel : NotifiableObject
    {


        public ObservableCollection<Card> Cards { get; set; }
        public string test { get; set; }
        public double Left { get; set; } = 10;
        public double Top { get; set; } = 10;
		static DBProv m_DbProv { get; set; }



		public GameScreenViewModel()
        {



            //test = "hello";

            //Cards = new ObservableCollection<Card>();
            //for (int i = 1; i > 1; i--)
            //{

            //    int leftdistance = i / 10;
            //    int topdistance = i / 5;

            //    Brush mycolor;
            //    if (i % 2 == 1)
            //    {
            //        mycolor = Brushes.AntiqueWhite;

            //    }
            //    else
            //    {
            //        mycolor = Brushes.Black;

            //    }

            //    Cards.Add(new Card(leftdistance, topdistance, mycolor));



            //}

        }





    }
}
