using FirstFloor.ModernUI.Windows.Controls;
using MTCQuest.CustomControls;
using MTCQuest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MTCQuest {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : ModernWindow {
		MainViewModel mvm;
		public MainWindow() {
			InitializeComponent();
			mvm = DataContext as MainViewModel;

			DataContextChanged += (dp, e) => {
				//((Resources as ResourceDictionary).FindName("DialogHelperObject") as DialogHelper).ViewModel = (DataContext as IDialogHelper);
				(DataContext as IDialogHelper).OpenDialog = DialogHelper.OpenDialog;
			};
			//mvm.MenuVisibilityChanged = new Action<bool>((b) => { RaiseMenuOpenedEvent(); });
		}

	//	public static readonly RoutedEvent MenuOpenedEvent = EventManager.RegisterRoutedEvent(
	//		"MenuOpened", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MainWindow));

	//	// Provide CLR accessors for the event
	//	public event RoutedEventHandler MenuOpened {
	//		add { AddHandler(MenuOpenedEvent, value); }
	//		remove { RemoveHandler(MenuOpenedEvent, value); }
	//	}

	//	// This method raises the Tap event
	//	void RaiseMenuOpenedEvent() {
	//		RoutedEventArgs newEventArgs = new RoutedEventArgs(MainWindow.MenuOpenedEvent);
	//		RaiseEvent(newEventArgs);
	//	}
	}
}
