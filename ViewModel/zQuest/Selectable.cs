using Newtonsoft.Json;
using System;

namespace MTCQuest.ViewModel.zQuest {
	public class Selectable : Notifiable {
		private bool _isSelected;
		public bool IsSelected {
			get { return _isSelected; }
			set {
				_isSelected = value; OnPropertyChanged("IsSelected");
				if (Selected != null && value == true) Selected();
				if (value == false) IsEdited = value;
			}
		}

		private Action _selected;
		[JsonIgnore]
		public Action Selected { get { return _selected; } set { _selected = value; OnPropertyChanged("Selected"); } }

		private bool _isEdited;
		[JsonIgnore]
		public bool IsEdited { get { return _isEdited; } set { _isEdited = value; OnPropertyChanged("IsEdited"); } }
	}
}