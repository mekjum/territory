using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using TerritoryWpf.Model;
using DapperExtensions;
using TerritoryWpf.Repositories;

namespace TerritoryWpf.ViewModels
{
    public class CitiesViewModel : Screen
    {
		 CityRepository repository = new CityRepository();

		 private ObservableCollection<CityViewModel> cities;
		 public ObservableCollection<CityViewModel> Cities 
		 { 
			 get 
			 {
				 return cities;
			 } 
			 set 
			 {
				 cities = value;
				 NotifyOfPropertyChange(() => Cities);
			 } 
		 }

		 private CityViewModel selected;
		 public CityViewModel Selected
		 {
			 get
			 {
				 return selected;
			 }
			 set
			 {
				 selected = value;
				 NotifyOfPropertyChange(() => Selected);
			 }
		 }

		 public void SelectionChanged()
		 {
			 if (Selected != null)
			 {
				 Console.WriteLine("Selected: {0} - {1}", Selected.Id, Selected.Name);
			 }
			 else
			 {
				 Console.WriteLine("No selection");
			 }
		 }

		 public void Load()
		 {
			 Cities = this.ToObservableCollection(this.repository.GetAll());
		 }

		 public ObservableCollection<CityViewModel> ToObservableCollection(List<City> models)
		 {
			 var coll = new ObservableCollection<CityViewModel>();
			 models.ForEach(c => coll.Add(new CityViewModel(c)));
			 return coll;
		 }

		 public void SelectedCity()
		 { }
		 public void Save()
		 {
			 Console.WriteLine("Save() {0}", Selected.Name);
		 }
	 }
}
