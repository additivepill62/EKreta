using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKreta.Models
{
	public class Felhasznalo
	{
		public Felhasznalo()
		{
		}


		[PrimaryKey, AutoIncrement]
		public string id { get; set; }
		public string FelhasznaloNev { get; set; }
		public string TeljesNev { get; set; }
		public string Jelszo { get; set; }
		public int SzerepKor { get; set; }

		public Felhasznalo(string felhasznaloNev, string teljesNev, string jelszo, int szerepKor)
		{
			
			FelhasznaloNev = felhasznaloNev;
			TeljesNev = teljesNev;
			Jelszo = jelszo;
			SzerepKor = szerepKor;
		}
	}
}
