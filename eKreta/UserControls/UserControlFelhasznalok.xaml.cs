using eKreta.Models;
using System.Windows;
using System.Windows.Controls;

namespace eKreta.UserControls
{
	/// <summary>
	/// Interaction logic for UserControlFelhasznalok.xaml
	/// </summary>
	public partial class UserControlFelhasznalok : UserControl
	{
		List<Felhasznalo> felhasznalok;
		Felhasznalo kivalasztottFelhasznalo;

		public UserControlFelhasznalok()
		{
			InitializeComponent();
			szerepkorCBOX.ItemsSource = Enum.GetValues(typeof(Szerepkor));
			AdatbazisLekerdezes();
			felhasznalok = new List<Felhasznalo>();
		}

		private void AdatbazisLekerdezes()
		{
			//elemek 0-ra

			var felhasznaloRepo = new GenericRepository<Felhasznalo>(App.databasePath);
			var lekerdezes = felhasznaloRepo.GetAll();
			datagridFelhasznalok.ItemsSource = lekerdezes;


		}

		private void datagridFelhasznalok_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void mentesBTN_Click(object sender, RoutedEventArgs e)
		{
			//Szerepkör
			string kivalasztottSzerepkorNev = szerepkorCBOX.SelectedItem.ToString();
			Szerepkor kivalasztottSzerepkor = (Szerepkor)Enum.Parse(typeof(Szerepkor), kivalasztottSzerepkorNev);
			int kivalasztottSzerepkorId = (int)kivalasztottSzerepkor;

			//Új felhasználó létrehozása a megadott adatokkal
			Felhasznalo ujFelhasznalo = new Felhasznalo(felhasznalonevTBOX.Text, teljesnevTBOX.Text, jelszoTBOX.Password, kivalasztottSzerepkorId);

			//adatbázisba mentés
			var felhasznaloRepo = new GenericRepository<Felhasznalo>(App.databasePath);
			felhasznaloRepo.Insert(ujFelhasznalo);

			//datagrid frissítése
			AdatbazisLekerdezes();

		}

		private void torlesBTN_Click(object sender, RoutedEventArgs e)
		{
			//adatbázisba mentés
			var felhasznaloRepo = new GenericRepository<Felhasznalo>(App.databasePath);

			felhasznaloRepo.Delete(kivalasztottFelhasznalo);

			//datagrid frissítése
			AdatbazisLekerdezes();
		}

		private void modBTN_Click(object sender, RoutedEventArgs e)
		{
			kivalasztottFelhasznalo.FelhasznaloNev = felhasznalonevTBOX.Text;
			kivalasztottFelhasznalo.TeljesNev = teljesnevTBOX.Text;

			string kivalasztottSzerepkorNev = szerepkorCBOX.SelectedItem.ToString();
			Szerepkor kivalasztottSzerepkor = (Szerepkor)Enum.Parse(typeof(Szerepkor), kivalasztottSzerepkorNev);
			kivalasztottFelhasznalo.Szerepkor = (int)kivalasztottSzerepkor;

			if(jelszoTBOX.Password != "")
			{
				kivalasztottFelhasznalo.Jelszo = jelszoTBOX.Password; // TODO: hash jelszó
			}







		}
	}
}
