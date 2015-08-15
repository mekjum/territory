using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace TerritoryWpf.ViewModels
{
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
       int count;

       public void OpenTab()
       {
          ActivateItem(new CitiesViewModel
          {
             DisplayName = "Tab " + count++
          });
       }
        public void ShowCities()
        {
			  var vm = new CitiesViewModel()
			  {
				  DisplayName = "Cities"
			  };
			  vm.Load();
           ActivateItem(vm);
           //ActivateItem(new CitiesViewModel());
        }
    }
}
