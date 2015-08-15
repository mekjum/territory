using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace TerritoryWpf.Model
{
    public class County
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
