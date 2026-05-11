using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKreta.Models
{
	public class Diak
	{
		public Diak()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		public string VezNev{ get; set; }
		public string UtoNev { get; set; }
		public string Szuldatum { get; set; }
		public string Anyjaneve { get; set; }
		public string Lakcim { get; set; }


		public Diak(string vezNev, string utoNev, string szuldatum, string anyjaneve, string lakcim)
		{
			VezNev = vezNev;
			UtoNev = utoNev;
			Szuldatum = szuldatum;
			Anyjaneve = anyjaneve;
			Lakcim = lakcim;
		}
	}
}
