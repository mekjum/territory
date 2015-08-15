using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace TerritoryWpf.Model
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string MapPointCityName { get; set; }
        public int TerritoryCityID { get; set; }
    }
}
