using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TerritoryWpf.Repositories;
using TerritoryWpf.Model;

namespace TerritoryWpf.Test
{
    public class CityRepositoryFixture :IDisposable
    {
      CityRepository rep = new CityRepository();
      City instance;

      public CityRepositoryFixture()
      {
         this.instance = new City(){
            Name = "Test City",
            Code = "Code",
            MapPointCityName = "NOT USE",
            TerritoryCityID = 0
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
          this.instance.Name = updated;
          var c = this.rep.Update(this.instance);          
          Assert.Equal(updated, c.Name);
       }

      public void Dispose()
      {
         Assert.True(this.rep.Delete(this.instance.Id));
      }
    }
}
