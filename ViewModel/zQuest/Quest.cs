using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCQuest.ViewModel.zQuest {
	public class Quest : TextObject {
		public Quest() {
			Themes = new ObservableCollection<Theme>();
			AddNewTheme = new UVMCommand("AddNewTheme", p => {
				var t = new Theme() { IsSelected = true, IsEdited = true };
				t.RemoveThis = new UVMCommand("RemoveThis", pp => Themes.Remove(t));
				t.Selected = () => { SelectedTheme = t; };
				Themes.Add(t);
			});
		}

		[JsonConstructor]
		public Quest(string text, ObservableCollection<Theme> themes) {
			Text = text;
			Themes = themes;
			foreach (var t in Themes) {
				t.RemoveThis = new UVMCommand("RemoveThis", pp => Themes.Remove(t));
				t.Selected = () => { SelectedTheme = t; };
			}
		}

		private ObservableCollection<Theme> _themes;
		public ObservableCollection<Theme> Themes { get { return _themes; } set { _themes = value; OnPropertyChanged("Themes"); } }

		private Theme _selectedTheme;
		public Theme SelectedTheme { get { return _selectedTheme; } set { _selectedTheme = value; OnPropertyChanged("SelectedTheme"); } }

		private UVMCommand _addNewTheme;
		[JsonIgnore]
		public UVMCommand AddNewTheme { get { return _addNewTheme; } set { _addNewTheme = value; OnPropertyChanged("AddNewTheme"); } }

		public override string ToString() {
			return "Game: " + Text;
		}
	}
}
