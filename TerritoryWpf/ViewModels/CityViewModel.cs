using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerritoryWpf.Model;
using TerritoryWpf.Repositories;

namespace TerritoryWpf.ViewModels
{
	public class CityViewModel : BaseViewModel
	{
		private City city;
		private CityRepository repository = new CityRepository();
		 
		public CityViewModel(City city)
		{
			this.city = city;
		}

		public int Id 
		{
			get
			{
				return city.Id;
			}
			set
			{
				city.Id = value;
				NotifyOfPropertyChange(()=>Id);
				IsDirty = true;
			}
		}
		public string Name 
		{
			get
			{
				return city.Name;
			}
			set
			{
				city.Name = value;
				NotifyOfPropertyChange(() => Name);
				IsDirty = true;
			}
		}

		public void Save()
		{
			Console.WriteLine("Saving {0}", this.city.Name);
			if(IsDirty && Id > 0)
			{
				repository.Update(this.city);
			}
			else if(IsDirty)
			{
				repository.Add(this.city);
			}
		}
	}
}
