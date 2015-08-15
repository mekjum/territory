using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace TerritoryWpf.ViewModels
{
	public class BaseViewModel : PropertyChangedBase
	{
		private bool isDirty;
		public bool IsDirty
		{
			get
			{
				return this.IsDirty;
			}
			set
			{
				this.isDirty = value;
				NotifyOfPropertyChange(() => isDirty);
			}
		}
	}
}
