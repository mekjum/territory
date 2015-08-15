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
	public class CountyRepository : BaseRepository
	{
		string columns = @"Name";

		public County Get(int Id)
		{
			var sql = string.Format(@"select Id, {0} from County where Id = @Id;", this.columns);

			using (var cnn = (IDbConnection)SimpleDbConnection())
			{
				var r = cnn.Query<County>(sql, new { Id = Id });

				return r.FirstOrDefault();
			}
		}

		public County Add(County County)
		{
			var sql = string.Format(@"insert into County(
                           {0})
                     values(@Name);
                     select Id, {0} from County where Id = last_insert_rowid();", this.columns);

			using (var cnn = (IDbConnection)SimpleDbConnection())
			{
				var r = cnn.Query<County>(sql, County);

				return r.FirstOrDefault();
			}
		}

		public County Update(County County)
		{
			var sql = string.Format(@"update County
												  set Name = @Name
												where Id = @Id;
							
							select Id, {0} from County where Id = @Id;", this.columns);

			using (var cnn = (IDbConnection)SimpleDbConnection())
			{
				var r = cnn.Query<County>(sql, County);

				return r.FirstOrDefault();
			}
		}

		public bool Delete(int Id)
		{
			var sql = @"delete from County where Id = @Id;
                     select total_changes()";

			using (var cnn = (IDbConnection)SimpleDbConnection())
			{
				var r = cnn.ExecuteScalar<int>(sql, new { Id = @Id });

				return r == 1;
			}
		}
	}
}
