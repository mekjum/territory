using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace TerritoryWpf.Repositories
{
   public class BaseRepository
   {
      public static string DbFile
      {
         get { return Environment.CurrentDirectory + "\\TerritoryData.sqlite"; }
      }

      public static SQLiteConnection SimpleDbConnection()
      {
         return new SQLiteConnection("Data Source=" + DbFile);
      }
   }   
}
