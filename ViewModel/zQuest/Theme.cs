using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace MTCQuest.ViewModel.zQuest {
	public class Theme : TextObject {

		public Theme() {
			Questions = new ObservableCollection<Question>();
			AddNewQuestion = new UVMCommand("AddNewQuestion", p => {
				var q = new Question() { IsSelected = true, IsEdited = true };
				q.RemoveThis = new UVMCommand("RemoveThis", pp => Questions.Remove(q));
				q.Selected = () => {
					SelectedQuestion = q;
					Selected();
				};
				Questions.Add(q);
			});
			Color = Colors.LightYellow;
		}

		[JsonConstructor]
		public Theme(string text, ObservableCollection<Question> questions, Color color) {
			Text = text;
			Questions = questions;
			foreach (var q in Questions) {
				q.RemoveThis = new UVMCommand("RemoveThis", pp => Questions.Remove(q));
				q.Selected = () => {
					SelectedQuestion = q;
					Selected();
				};
			}
			Color = color;
		}

		private ObservableCollection<Question> _questions;
		public ObservableCollection<Question> Questions { get { return _questions; } set { _questions = value; OnPropertyChanged("Questions"); } }

		private Question _selectedQuestion;
		public Question SelectedQuestion { get { return _selectedQuestion; } set { _selectedQuestion = value; OnPropertyChanged("SelectedQuestion"); } }

		private Color _color;
		public Color Color { get { return _color; } set { _color = value; OnPropertyChanged("Color"); } }
		
		private UVMCommand _addNewQuestion;
		[JsonIgnore]
		public UVMCommand AddNewQuestion { get { return _addNewQuestion; } set { _addNewQuestion = value; OnPropertyChanged("AddNewQuestion"); } }

		//private UVMCommand _editColor;
		//[JsonIgnore]
		//public UVMCommand EditColor { get { return _editColor; } set { _editColor = value; OnPropertyChanged("EditColor"); } }

		private UVMCommand _removeThis;
		[JsonIgnore]
		public UVMCommand RemoveThis { get { return _removeThis; } set { _removeThis = value; OnPropertyChanged("RemoveThis"); } }

		public override string ToString() {
			return "Theme: " + Text;
		}
	}
}