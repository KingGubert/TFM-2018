using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFM.Model;

namespace TFM.Dataprovider
{
	/// <summary>
	/// Hier können Oberflächen aus der Datenbank aberufen werden
	/// </summary>
	public class DBProv : NotifiableObject
	{

		#region constructor

		public DBProv()
		{

		}


		#endregion

		

		#region Properties

		//Statische Sql verbindung
		static SqlConnection m_SQLConnection;

		//Handler Sql 
		private SqlConnection SqlConnection
		{
			get
			{
				//Returned die statische Instanz oder initiert sie
				return m_SQLConnection ?? (m_SQLConnection = new SqlConnection("user id=Jo-PC\\Jo;" +
																			   "password= ;Server=Jo-PC\\TERRA_MASTER;" +
																			   "Trusted_Connection=yes;" +
																			   "database=TERRAFORMING; " +
																			   "connection timeout=5"));
			}
		}


		#endregion


		#region methods




		/// <summary>
		/// Initialisiert die Oberfläche bei Spielstart
		/// </summary>
		/// <param name="SurfaceID"></param>

		public List<SurfaceSpot> InitializeSurface(SurfaceID uSurfaceID)
		{

			List<SurfaceSpot> CompleteSurface = new List<SurfaceSpot>();


			// Open Connection

			SqlConnection.Open();

			try
			{

				// Init DataReader
				SqlDataReader myReader = null;

				// Execute Command
				string SqlSelect = "";

				switch (uSurfaceID)
				{
					case SurfaceID.Mars:
						SqlSelect = "select * from sys_tblSurfaceSpotsMars";
						break;
					case SurfaceID.Hellas:
						SqlSelect = "select * from sys_tblSurfaceSpotsHellas";
						break;
					case SurfaceID.Elysium:
						SqlSelect = "select * from sys_tblSurfaceSpotsElysium";
						break;
					default:
						break;
				}

				SqlCommand SQLCommand = new SqlCommand(SqlSelect, SqlConnection);

				// Read Resultset
				int tempCanvasLeft = 248, tempCanvasTop =0, tempSpotCounter = 0;

				myReader = SQLCommand.ExecuteReader();
				while (myReader.Read())
				{
					
					var tempSpot = new SurfaceSpot();
					tempSpot.SpotID = Convert.ToInt32(myReader["nSpotID"]);
					tempSpot.SpotType = Convert.ToInt32(myReader["nSpotType"]);
					tempSpot.SpotName = Convert.ToString(myReader["szSpotName"]);
					tempSpot.Owner = Convert.ToInt32(myReader["nOwner"]);
					tempSpot.IsLocked = Convert.ToBoolean(myReader["bIsLocked"]);
					tempSpot.TileType = Convert.ToInt32(myReader["nTileType"]);
					tempSpot.TileName = Convert.ToString(myReader["szTileName"]);
					tempSpot.PB_Cards = Convert.ToInt32(myReader["nPB_Cards"]);
					tempSpot.PB_Plants = Convert.ToInt32(myReader["nPB_Plant"]);
					tempSpot.PB_Steel = Convert.ToInt32(myReader["nPB_Steel"]);
					tempSpot.PB_Titan = Convert.ToInt32(myReader["nPB_Titan"]);
					tempSpot.PB_Heat = Convert.ToInt32(myReader["nPB_Heat"]);
					tempSpot.PB_Money = Convert.ToInt32(myReader["nPB_Money"]);
					tempSpot.PB_Ocean = Convert.ToInt32(myReader["nPB_Ocean"]);
					tempSpot.PB_1 = Convert.ToInt32(myReader["nPB_1"]);
					tempSpot.PB_2 = Convert.ToInt32(myReader["nPB_2"]);
					tempSpot.PB_3 = Convert.ToInt32(myReader["nPB_3"]);
					tempSpot.CanvasLeft = tempCanvasLeft;
					tempSpot.CanvasTop = tempCanvasTop;

					tempSpotCounter++;
					tempCanvasLeft += 76;
					if (tempSpotCounter == 5)
					{
						tempCanvasLeft = 248 - 38*1;
						tempCanvasTop = 0 + 61*1;
					}
					if(tempSpotCounter == 11)
					{
						tempCanvasLeft = 248 - 38*2;
						tempCanvasTop = 0 + 61*2;
					}
					if (tempSpotCounter == 18)
					{
						tempCanvasLeft = 248 - 38*3;
						tempCanvasTop = 0 + 61*3;
					}
					if (tempSpotCounter == 26)
					{
						tempCanvasLeft = 248 - 38*4 ;
						tempCanvasTop = 0 + 61*4;
					}
					if (tempSpotCounter == 35)
					{
						tempCanvasLeft = 248 - 38*3 ;
						tempCanvasTop = 0 + 61*5;
					}
					if (tempSpotCounter == 43)
					{
						tempCanvasLeft = 248 - 38*2 ;
						tempCanvasTop = 0 + 61*6;
					}
					if (tempSpotCounter == 50)
					{
						tempCanvasLeft = 248 - 38*1;
						tempCanvasTop = 0 + 61*7;
					}
					if (tempSpotCounter == 56)
					{
						tempCanvasLeft = 248;
						tempCanvasTop = 0 + 61*8;
					}
					if (tempSpotCounter == 61)
					{
						tempCanvasLeft = 0;
						tempCanvasTop = -100;
					}
					if (tempSpotCounter == 62)
					{
						tempCanvasLeft = 90;
						tempCanvasTop = -160;
					}
					if (tempSpotCounter >= 63)
					{
						tempCanvasLeft = 0;
						tempCanvasTop = 0;
					}

					//Spot zur Surface hinzufügen
					CompleteSurface.Add(tempSpot);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Fehler beim Lesen der Daten aus der Datenbank. Fehler: \n {e.Message} Stacktrace: \n {e.StackTrace}");
			}

				SqlConnection.Close();
		

			return CompleteSurface;

		}


		#endregion












	}
}
