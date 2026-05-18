using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKreta.Models
{
	internal class GenericRepository<T> : IGenericRepository<T> where T : new()
	{
		// Ez a konstruktor megkapja az adatbázis elérési útját, és elmenti egy privát mezőben.
		private readonly string _databasePath;
		public GenericRepository(string databasePath)
		{
			_databasePath = databasePath;
		}
		// Ez a metódus visszaadja az összes elemet a táblából. Jelenleg csak egy üres listát ad vissza, de később itt lesz a logika az adatbázisból való lekérdezéshez.
		public List<T> GetAll()
		{
			using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(_databasePath))
			{
				connection.CreateTable<T>();
				return connection.Table<T>().ToList();
			}
		}
		public void Insert(T item){
			using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(_databasePath))
			{
				connection.CreateTable<T>();
				connection.Insert(item);
			}
		}
		public void Update(T item){
			using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(_databasePath))
			{
				connection.CreateTable<T>();
				connection.Update(item);
			}
		}
		public void Delete(T item){
			using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(_databasePath))
			{
				connection.CreateTable<T>();
				connection.Delete(item);
			}
		}
	}
}
