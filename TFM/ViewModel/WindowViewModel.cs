using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TFM.Model;

namespace TFM.ViewModel
{

    /// <summary>
    /// The Viewmodel for the custom styled windows
    /// </summary>
    public class WindowViewModel : BaseViewModel
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

        //Gegenwärtig Angezeigte Seite im Mainwindow
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

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

     


        #region constructor

        public WindowViewModel(Window window)
        {
            m_Window = window;


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
