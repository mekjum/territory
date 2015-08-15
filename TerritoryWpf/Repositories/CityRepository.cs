using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerritoryWpf.Model;
using System.Data;
using Dapper;
using DapperExtensions;

namespace TerritoryWpf.Repositories
{
   public class CityRepository : BaseRepository
   {
      public City Get(int Id) 
      {
         var sql = @"select Id, 
                            CityName Name, 
                            Code, 
                            MapPointCityName, 
                            TerritoryCityID 
                       from City where Id = @Id;";

         using(var cnn = (IDbConnection)SimpleDbConnection())
         {
            var r = cnn.Query<City>(sql, new { Id = Id });
            
            return r.FirstOrDefault();
         }
      }

		public List<City> GetAll()
		{
			var sql = @"select Id, 
                            CityName Name, 
                            Code, 
                            MapPointCityName, 
                            TerritoryCityID 
                       from City;";

			using (var cnn = (IDbConnection)SimpleDbConnection())
			{
				var r = cnn.Query<City>(sql, null).ToList();

				return r;
			}
		}
      public City Add(City city)
      {
			var sql = @"insert into City(
                                 CityName,
                                 Code,
                                 MapPointCityName,
                                 TerritoryCityID)
                     values(
                           @Name,
                           @Code,
                           @MapPointCityName,
                           @TerritoryCityID);
                     select Id, CityName Name, Code, MapPointCityName, TerritoryCityID from City where Id = last_insert_rowid();";
         
         using (var cnn = (IDbConnection)SimpleDbConnection())
         {
            var r = cnn.Query<City>(sql, city);

            return r.FirstOrDefault();
         }
      }

      public City Update(City city)
      {
         var sql = @"update City
                        set  CityName = @Name,
                              Code = @Code,
                              MapPointCityName = @MapPointCityName,
                              TerritoryCityID = @TerritoryCityID
                     where Id = @Id;

                     select Id, CityName Name, Code, MapPointCityName, TerritoryCityID from City where Id = @Id;";

         using (var cnn = (IDbConnection)SimpleDbConnection())
         {
            var r = cnn.Query<City>(sql, city);

            return r.FirstOrDefault();
         }
      }

      public bool Delete(int Id)
      {
         var sql = @"delete from City where Id = @Id;
                     select total_changes()";

         using (var cnn = (IDbConnection)SimpleDbConnection())
         {
            var r = cnn.ExecuteScalar<int>(sql, new {Id = @Id });

            return r == 1;
         }
      }
   }
}
