using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFM.Model
{
	public class SurfaceSpot : NotifiableObject
	{

		#region constructor

		public SurfaceSpot()
		{ }
		#endregion

		#region properties 

		private int m_SpotID;
		private int m_SpotType; // 1 = Ocean; 2 = Normal; 3 = Special (Named)
		private string m_SpotName;
		private int m_Owner; //PlayerID 1-4
		private bool m_islocked;
		private int m_TileType; // 0 = none; 1 = City ; 2 = Ocean; 3 = Greenery; 4 = Special
		private string m_TileName;
		private int m_PB_Steel, m_PB_Titan, m_PB_Cards, m_PB_Money, m_PB_Heat, m_PB_Ocean, m_PB_Plants, m_PB_1, m_PB_2, m_PB_3; //PlacementBonus
		private int m_canvastop, m_canvasleft;


		#region handler
		public int CanvasLeft
		{
			get { return m_canvasleft; }
			set { m_canvasleft = value; OnPropertyChanged("m_canvasleft"); }
		}

		public int CanvasTop
		{
			get { return m_canvastop; }
			set { m_canvastop = value; OnPropertyChanged("m_canvastop"); }
		}

		public int SpotID
		{
			get { return m_SpotID; }
			set { m_SpotID = value; OnPropertyChanged("SpotID"); }
		}
		public int SpotType
		{
			get { return m_SpotType; }
			set { m_SpotType = value; OnPropertyChanged("SpotType"); }
		}
		public string SpotName
		{
			get { return m_SpotName; }
			set { m_SpotName = value; OnPropertyChanged("SpotName"); }
		}
		public int Owner
		{
			get { return m_Owner; }
			set { m_Owner = value; OnPropertyChanged("Owner"); }
		}

		public bool IsLocked
		{
			get { return m_islocked; }
			set { m_islocked = value; OnPropertyChanged("IsLocked"); }
		}

		public int TileType
		{
			get { return m_TileType; }
			set { m_TileType = value; OnPropertyChanged("TileType"); }
		}

		public string TileName
		{
			get { return m_TileName; }
			set { m_TileName = value; OnPropertyChanged("TileName"); }
		}

		public int PB_Steel
		{
			get { return m_PB_Steel; }
			set { m_PB_Steel = value; OnPropertyChanged("PB_Steel"); }
		}
		public int PB_Titan
		{
			get { return m_PB_Titan; }
			set { m_PB_Titan = value; OnPropertyChanged("PB_Titan"); }
		}

		public int PB_Money
		{
			get { return m_PB_Money; }
			set { m_PB_Money = value; OnPropertyChanged("PB_Money"); }
		}

		public int PB_Plants
		{
			get { return m_PB_Plants; }
			set { m_PB_Plants = value; OnPropertyChanged("PB_Plants"); }
		}

		public int PB_Ocean
		{
			get { return m_PB_Ocean; }
			set { m_PB_Ocean = value; OnPropertyChanged("PB_Ocean"); }
		}

		public int PB_Cards
		{
			get { return m_PB_Cards; }
			set { m_PB_Cards = value; OnPropertyChanged("PB_Cards"); }
		}

		public int PB_Heat
		{
			get { return m_PB_Heat; }
			set { m_PB_Heat = value; OnPropertyChanged("PB_Heat"); }
		}

		public int PB_1
		{
			get { return m_PB_1; }
			set { m_PB_1 = value; OnPropertyChanged("PB_1"); }
		}

		public int PB_2
		{
			get { return m_PB_2; }
			set { m_PB_2 = value; OnPropertyChanged("PB_2"); }
		}

		public int PB_3
		{
			get { return m_PB_3; }
			set { m_PB_3 = value; OnPropertyChanged("PB_3"); }
		}










		#endregion







		#endregion





		/// <summary>
		/// Returns an Array containing all Neighboring SurfaceTilenumbers to a given SelectedSurfacetile
		/// </summary>
		/// <param name="SelectedSurfaceSpot"></param>
		/// <returns></returns>
		static public object GetSurfaceNeighbors(int SelectedSurfaceSpot)
		{
			ArrayList SurfaceSpotNeighbors = new ArrayList();

			#region SpotNeighbor Definitions

			//All 67 SurfaceSpots in Terraforming Mars with their Neighbor Spaces as as Integerarrays

			int[] SurfaceSpotNeighbors_1 = new int[] { 2, 6, 7 };
			int[] SurfaceSpotNeighbors_2 = new int[] { 1, 3, 7, 8 };
			int[] SurfaceSpotNeighbors_3 = new int[] { 2, 4, 8, 9 };
			int[] SurfaceSpotNeighbors_4 = new int[] { 3, 5, 9, 10 };
			int[] SurfaceSpotNeighbors_5 = new int[] { 4, 10, 11 };
			int[] SurfaceSpotNeighbors_6 = new int[] { 1, 7, 12, 13 };
			int[] SurfaceSpotNeighbors_7 = new int[] { 1, 2, 6, 8, 13, 14 };
			int[] SurfaceSpotNeighbors_8 = new int[] { 2, 3, 7, 9, 14, 15 };
			int[] SurfaceSpotNeighbors_9 = new int[] { 3, 4, 8, 10, 15, 16 };
			int[] SurfaceSpotNeighbors_10 = new int[] { 4, 5, 9, 11, 16, 17 };
			int[] SurfaceSpotNeighbors_11 = new int[] { 5, 10, 17, 18 };
			int[] SurfaceSpotNeighbors_12 = new int[] { 6, 13, 19, 20 };
			int[] SurfaceSpotNeighbors_13 = new int[] { 6, 7, 12, 14, 20, 21 };
			int[] SurfaceSpotNeighbors_14 = new int[] { 7, 8, 13, 15, 21, 22 };
			int[] SurfaceSpotNeighbors_15 = new int[] { 8, 9, 14, 16, 22, 23 };
			int[] SurfaceSpotNeighbors_16 = new int[] { 9, 10, 15, 17, 23, 24 };
			int[] SurfaceSpotNeighbors_17 = new int[] { 10, 11, 16, 18, 24, 25 };
			int[] SurfaceSpotNeighbors_18 = new int[] { 11, 17, 25, 26 };
			int[] SurfaceSpotNeighbors_19 = new int[] { 12, 20, 27, 28 };
			int[] SurfaceSpotNeighbors_20 = new int[] { 12, 13, 19, 21, 28, 29 };
			int[] SurfaceSpotNeighbors_21 = new int[] { 13, 14, 20, 22, 29, 30 };
			int[] SurfaceSpotNeighbors_22 = new int[] { 14, 15, 21, 23, 30, 31 };
			int[] SurfaceSpotNeighbors_23 = new int[] { 15, 16, 22, 24, 31, 32 };
			int[] SurfaceSpotNeighbors_24 = new int[] { 16, 17, 23, 25, 32, 33 };
			int[] SurfaceSpotNeighbors_25 = new int[] { 17, 18, 24, 26, 33, 34 };
			int[] SurfaceSpotNeighbors_26 = new int[] { 18, 25, 34, 35 };
			int[] SurfaceSpotNeighbors_27 = new int[] { 19, 28, 36 };
			int[] SurfaceSpotNeighbors_28 = new int[] { 19, 20, 27, 29, 36, 37 };
			int[] SurfaceSpotNeighbors_29 = new int[] { 20, 21, 28, 30, 37, 38 };
			int[] SurfaceSpotNeighbors_30 = new int[] { 21, 22, 29, 31, 38, 39 };
			int[] SurfaceSpotNeighbors_31 = new int[] { 22, 23, 30, 32, 39, 40 };
			int[] SurfaceSpotNeighbors_32 = new int[] { 23, 24, 31, 33, 40, 41 };
			int[] SurfaceSpotNeighbors_33 = new int[] { 24, 25, 32, 34, 41, 42 };
			int[] SurfaceSpotNeighbors_34 = new int[] { 25, 26, 33, 35, 42, 43 };
			int[] SurfaceSpotNeighbors_35 = new int[] { 26, 34, 43 };
			int[] SurfaceSpotNeighbors_36 = new int[] { 27, 28, 37, 44 };
			int[] SurfaceSpotNeighbors_37 = new int[] { 28, 29, 36, 38, 44, 45 };
			int[] SurfaceSpotNeighbors_38 = new int[] { 29, 30, 37, 39, 45, 46 };
			int[] SurfaceSpotNeighbors_39 = new int[] { 30, 31, 38, 40, 46, 47 };
			int[] SurfaceSpotNeighbors_40 = new int[] { 31, 32, 39, 41, 47, 48 };
			int[] SurfaceSpotNeighbors_41 = new int[] { 32, 33, 40, 42, 48, 49 };
			int[] SurfaceSpotNeighbors_42 = new int[] { 33, 34, 41, 43, 49, 50 };
			int[] SurfaceSpotNeighbors_43 = new int[] { 34, 35, 42, 50 };
			int[] SurfaceSpotNeighbors_44 = new int[] { 36, 37, 45, 51 };
			int[] SurfaceSpotNeighbors_45 = new int[] { 37, 38, 44, 46, 51, 52 };
			int[] SurfaceSpotNeighbors_46 = new int[] { 38, 39, 45, 47, 52, 53 };
			int[] SurfaceSpotNeighbors_47 = new int[] { 39, 40, 46, 48, 53, 54 };
			int[] SurfaceSpotNeighbors_48 = new int[] { 40, 41, 47, 49, 54, 55 };
			int[] SurfaceSpotNeighbors_49 = new int[] { 41, 42, 48, 50, 53, 56 };
			int[] SurfaceSpotNeighbors_50 = new int[] { 42, 43, 49, 56 };
			int[] SurfaceSpotNeighbors_51 = new int[] { 44, 45, 52, 57 };
			int[] SurfaceSpotNeighbors_52 = new int[] { 45, 46, 51, 53, 57, 58 };
			int[] SurfaceSpotNeighbors_53 = new int[] { 46, 47, 52, 54, 58, 59 };
			int[] SurfaceSpotNeighbors_54 = new int[] { 47, 48, 53, 55, 59, 60 };
			int[] SurfaceSpotNeighbors_55 = new int[] { 48, 49, 54, 56, 60, 61 };
			int[] SurfaceSpotNeighbors_56 = new int[] { 49, 50, 55, 61 };
			int[] SurfaceSpotNeighbors_57 = new int[] { 51, 52, 58 };
			int[] SurfaceSpotNeighbors_58 = new int[] { 52, 53, 57, 59 };
			int[] SurfaceSpotNeighbors_59 = new int[] { 53, 54, 58, 60 };
			int[] SurfaceSpotNeighbors_60 = new int[] { 54, 55, 59, 61 };
			int[] SurfaceSpotNeighbors_61 = new int[] { 55, 56, 60 };
			int[] SurfaceSpotNeighbors_62 = new int[] { };
			int[] SurfaceSpotNeighbors_63 = new int[] { };
			int[] SurfaceSpotNeighbors_64 = new int[] { };
			int[] SurfaceSpotNeighbors_65 = new int[] { };
			int[] SurfaceSpotNeighbors_66 = new int[] { };
			int[] SurfaceSpotNeighbors_67 = new int[] { };

			//Addition to Motherarray

			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_1);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_2);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_3);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_4);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_5);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_6);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_7);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_8);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_9);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_10);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_11);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_12);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_13);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_14);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_15);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_16);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_17);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_18);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_19);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_20);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_21);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_22);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_23);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_24);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_25);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_26);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_27);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_28);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_29);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_30);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_31);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_32);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_33);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_34);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_35);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_36);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_37);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_38);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_39);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_40);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_41);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_42);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_43);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_44);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_45);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_46);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_47);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_48);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_49);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_50);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_51);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_52);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_53);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_54);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_55);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_56);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_57);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_58);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_59);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_60);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_61);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_62);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_63);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_64);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_65);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_66);
			SurfaceSpotNeighbors.Add(SurfaceSpotNeighbors_67);


			#endregion

			return SurfaceSpotNeighbors[SelectedSurfaceSpot];
		}




	}
}
