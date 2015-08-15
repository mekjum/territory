using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerritoryWpf.Model;
using System.Data;
using Dapper;

namespace TerritoryWpf.Repositories
{
	public class HouseRepository : BaseRepository
	{
		string columns = @"CardName,
                           Street,
                           StreetNum,
                           Apt,
                           CityId,
                           Zip,
                           ZipExt,
                           LName,
                           FName,
                           Tel,
                           Map,
                           Grid,
                           Information,
                           StatusId,
                           LastUpdateDate,
                           CountyId,
                           Source,
                           DeleteFlag,
                           Longitude,
                           Latitude";

      public House Get(int Id) 
      {
         var sql = string.Format(@"select Id, {0} from House where Id = @Id;", this.columns);

         using(var cnn = (IDbConnection)SimpleDbConnection())
         {
            var r = cnn.Query<House>(sql, new { Id = Id });
            
            return r.FirstOrDefault();
         }
      }

      public House Add(House House)
      {
			var sql = string.Format(@"insert into House(
                           {0})
                     values(@CardName,
                           @Street,
                           @StreetNum,
                           @Apt,
                           @CityId,
                           @Zip,
                           @ZipExt,
                           @LName,
                           @FName,
                           @Tel,
                           @Map,
                           @Grid,
                           @Information,
                           @StatusId,
                           @LastUpdateDate,
                           @CountyId,
                           @Source,
                           @DeleteFlag,
                           @Longitude,
                           @Latitude);
                     select Id, {0} from House where Id = last_insert_rowid();", this.columns);
         
         using (var cnn = (IDbConnection)SimpleDbConnection())
         {
            var r = cnn.Query<House>(sql, House);

            return r.FirstOrDefault();
         }
      }

      public House Update(House house)
      {
         var sql = string.Format( @"update House
                        set  
									CardName = @CardName,
                           Street = @Street,
                           StreetNum = @StreetNum,
                           Apt = @Apt,
                           CityId = @CityId,
                           Zip = @Zip,
                           ZipExt = @ZipExt,
                           LName = @LName,
                           FName = @FName,
                           Tel = @Tel,
                           Map = @Map,
                           Grid = @Grid,
                           Information = @Information,
                           StatusId = @StatusId,
                           LastUpdateDate = @LastUpdateDate,
                           CountyId = @CountyId,
                           Source = @Source,
                           DeleteFlag = @DeleteFlag,
                           Longitude = @Longitude,
                           Latitude = @Latitude
                     where Id = @Id;
							
							select Id, {0} from House where Id = @Id;", this.columns);

         using (var cnn = (IDbConnection)SimpleDbConnection())
         {
            var r = cnn.Query<House>(sql, house);

            return r.FirstOrDefault();
         }
      }

      public bool Delete(int Id)
      {
         var sql = @"delete from House where Id = @Id;
                     select total_changes()";

         using (var cnn = (IDbConnection)SimpleDbConnection())
         {
            var r = cnn.ExecuteScalar<int>(sql, new {Id = @Id });

            return r == 1;
         }
      }
	}
}
