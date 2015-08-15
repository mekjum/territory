using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
//using ServiceStack.OrmLite;
using Dapper;
using Funq;
using TerritoryWpf.Model;
using TerritoryWpf.ViewModels;
using Caliburn.Micro;
using System.ComponentModel.Composition.Hosting;

namespace TerritoryWpf
{
    public class TerritoryBootstrapper: BootstrapperBase
    {
       /// <summary>
       /// The container.
       /// </summary>
       private Container container = new Container();

        public TerritoryBootstrapper()
        {            
            //DbCreate();
            Start();
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }

		  protected override void Configure()
		  {
           IoC.BuildUp
		  }
    }
}
