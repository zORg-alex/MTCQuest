using MTCQuest.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MTCQuest {
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application {

		MainWindow mw;
		MainViewModel mvm;
		public bool IsRunning;

		protected override void OnStartup(StartupEventArgs e) {
			////Set Localization
			//System.Threading.Thread.CurrentThread.CurrentUICulture =
			//new System.Globalization.CultureInfo("lv");

			IsRunning = true;

			mw = new MainWindow();
			mvm = new MainViewModel(true);
			mw.DataContext = mvm;
			mw.Show();

			MainWindow = mw;
		}
		protected override void OnExit(ExitEventArgs e) {
			//mvm.Dispose();
			base.OnExit(e);
		}
	}
}
