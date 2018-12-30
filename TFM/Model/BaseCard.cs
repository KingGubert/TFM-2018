using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TFM.Model
{
	/// <summary>
	/// Basisklasse aller Kartentypen
	/// </summary>
	/// 
    public abstract class BaseCard : NotifiableObject
    {
		/// <summary>
		/// CardPositioning properties for frontend
		/// </summary>
		public double Left { get; set; } = 10;
		public double Top { get; set; } = 10;
		public Color cardcolor { get; set; }
		public Brush cardcolorbrush { get; set; }
		public int ZIndex { get; set; }











		#region methods

		/// <summary>
		/// What happens when a card is played
		/// </summary>
		public abstract void PlayCard();

		/// <summary>
		/// Called upon discarding a card
		/// </summary>
		public abstract void DiscardCard();

	




		#endregion





	}
}
