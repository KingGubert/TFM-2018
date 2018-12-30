using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TFM.Controls;
using TFM.Dataprovider;
using TFM.Model;

namespace TFM.ViewModel
{

    /// <summary>
    /// The Viewmodel for the custom styled windows
    /// </summary>
    public class WindowViewModel : NotifiableObject
    {
        #region properties

        //The window the Viewmodel controls
        private Window m_Window;

        //Margin around Window for Dropshadow
        private int m_OuterMarginSize = 10;
        public Thickness OuterMarginThickness { get { return new Thickness(OuterMarginSize); } }

        //Curved window Radius
        private int m_WindowRadius = 10;
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

      

        /// <summary>
        /// Needed for Dropshadoweffect. Says how far "In" the Window is
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                //Set to 0 if Window Maximized because we dont need a shadow then
                return m_Window.WindowState == WindowState.Maximized ? 0 : m_OuterMarginSize;
            }

            set { m_OuterMarginSize = value; }
        }

        /// <summary>
        /// Gives the Window a curved optic
        /// </summary>
        public int WindowRadius
        {
            get
            {
                //Set to 0 if Window Maximized because we dont need curved corner
                return m_Window.WindowState == WindowState.Maximized ? 0 : m_WindowRadius;
            }

            set { m_WindowRadius = value; }
        }


        //How Big is ResizeHitdetection
        public int ResizeBorder { get; set; } = 6;
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }


        #endregion

        #region gameproperties

        //Gegenwärtig Angezeigte Seite im Mainwindow
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.GameScreen;
		public ApplicationPage GameSurfacePanel { get; private set; } = ApplicationPage.test;
		public TemperatureControl TemperatureGauge { get; set; } = new TemperatureControl();
		public OxygenControl OxygenGauge { get; set; } = new OxygenControl();
		public TFRTrack TFRTrack { get; set; } = new TFRTrack();
		public ObservableCollection<int> Tracktest { get; set; } = new ObservableCollection<int>();


		public ObservableCollection<Card> DiscardedCards { get; set; }
		public ObservableCollection<Card> Cards { get; set; }
        public string test { get; set; }
        public double Left { get; set; } = 10;
        public double Top { get; set; } = 10;
		static DBProv m_DBProv;
		private RangeObservableCollection<SurfaceSpot> m_Surface;

		public RangeObservableCollection<SurfaceSpot> Surface
		{
			get { return m_Surface ?? (m_Surface = new RangeObservableCollection<SurfaceSpot>()); }
			set { m_Surface = value; OnPropertyChanged("Surface"); }
		}
		public DBProv DBProv
		{
			get { return m_DBProv ?? (m_DBProv = new DBProv()); }
			set { m_DBProv = value; OnPropertyChanged("DBProv"); }
		}

		#endregion


		#region constructor

		public WindowViewModel(Window window)
        {
            m_Window = window;

			m_DBProv = new DBProv();

			Tracktest.Add(1);
			Tracktest.Add(2);

			Surface.AddRange(DBProv.InitializeSurface(SurfaceID.Mars));





			test = "hello";

            Cards = new ObservableCollection<Card>();
            for (int i = 200 ; i > 1; i--)
            {

                int leftdistance = 15 - i / 15 ;
                int topdistance =  65 - i  / 5 ;

                Brush mycolor;
                if (i % 2 == 1)
                {
                    mycolor = Brushes.AntiqueWhite;

                }
                else
                {
                    mycolor = Brushes.Black;

                }

                Cards.Add(new Card(leftdistance, topdistance, mycolor, i));
            }






            //Listen for Window Resizing
            m_Window.StateChanged += (sender, e) =>
            {
                //Fire events for all Properties
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(WindowCornerRadius));
                OnPropertyChanged(nameof(OuterMarginThickness));

            };
        }


        #endregion














    }
}
