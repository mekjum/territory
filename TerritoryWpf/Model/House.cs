using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace TerritoryWpf.Model
{
    public class House
    {
        [AutoIncrement]
        public int Id { get; set; }
        public Guid Uuid { get; set; }
        public string CardName { get; set; }
        public string StreetNum { get; set; }
        public string Street { get; set; }
        public string Apt { get; set; }
        [References(typeof(City))]
        public int CityId { get; set; }
        public string Zip { get; set; }
        public string ZipExt { get; set; }
		  public string FName { get; set; }
        public string LName { get; set; }
        public string Tel { get; set; }
        public string Map { get; set; }
        public string Grid { get; set; }
        public string Information { get; set; }
		  public int StatusId { get; set; }
        public Status Status { get; set; }
        [References(typeof(County))]
        public int CountyId { get; set; }
        public string Source { get; set; }
        public bool DeleteFlag { get; set; }
        public Coordinates Coordinates {get; set;}
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string MPAddress { get; set; }
        public string MPCity { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedName { get; set; }
    }
}
