using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerritoryWpf.Repositories;
using TerritoryWpf.Model;
using Xunit;

namespace TerritoryWpf.Test
{
	public class HouseRepositoryFixture: IDisposable
	{
		HouseRepository rep = new HouseRepository();
      House instance;

      public HouseRepositoryFixture()
      {
         this.instance = new House(){
            CardName = "Test House",
            FName = "FName",
            Information = "NOT USE",
            StreetNum = "0000",
				DeleteFlag = false
         };

         this.instance = this.rep.Add(this.instance);
         Assert.NotNull(this.instance);
      }

      [Fact]
      public void TestAddDelete()
      {
         var c = this.rep.Get(this.instance.Id);
         Assert.NotNull(c);
      }

      [Fact]
      public void TestUpdate()
      {
         var updated = "Updated";
         this.instance.FName = updated;
         var i = this.rep.Update(this.instance);          
         Assert.Equal(updated, i.FName);
      }

      public void Dispose()
      {
         Assert.True(this.rep.Delete(this.instance.Id));
      }
   }	
}
