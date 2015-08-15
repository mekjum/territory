using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerritoryWpf.Model;

namespace TerritoryWpf.ViewModel
{
    public class HouseViewModel
    {
        private House _house;
        public HouseViewModel()
        {
            _house = new House();
        }

        public House House { get { return _house; } set { } }
    }
}
