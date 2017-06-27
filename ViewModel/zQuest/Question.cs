using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace MTCQuest.ViewModel.zQuest {
	public class Question : TextObject{

		[JsonConstructor]
		public Question() {
			Variants = new ObservableCollection<Variant>();
			AddNewVariant = new UVMCommand("AddNewVariant", p => Variants.Add(new Variant() { IsSelected = true, IsEdited = true}));
			ToggleAnswersVisible = new UVMCommand("ToggleAnswersVisible", p => AnswersVisible = !AnswersVisible);
			Color = Colors.LightGray;
		}

		private string _question;
		public string QuestionText { get { return _question; } set { _question = value; OnPropertyChanged("QuestionText"); } }
		
		private string _answer;
		public string Answer { get { return _answer; } set { _answer = value; OnPropertyChanged("Answer"); } }

		private ObservableCollection<Variant> _variants;
		public ObservableCollection<Variant> Variants { get { return _variants; } set { _variants = value; OnPropertyChanged("Variants"); } }

		private bool _answersVisible;
		public bool AnswersVisible { get { return _answersVisible; } set { _answersVisible = value; OnPropertyChanged("AnswersVisible"); } }

		private Variant _selectedVariant;
		public Variant SelectedVariant { get { return _selectedVariant; } set { _selectedVariant = value; OnPropertyChanged("SelectedVariant"); } }

		/// <summary>
		/// May be unnecessary and even wrong to use this
		/// </summary>
		private Theme _parentTheme;
		public Theme ParentTheme { get { return _parentTheme; } set { _parentTheme = value; OnPropertyChanged("ParentTheme"); } }

		private Color _color;
		public Color Color { get { return _color; } set { _color = value; OnPropertyChanged("Color"); } }


		private UVMCommand _removeThis;
		[JsonIgnore]
		public UVMCommand RemoveThis { get { return _removeThis; } set { _removeThis = value; OnPropertyChanged("RemoveThis"); } }
		
		private UVMCommand _addNewVariant;
		[JsonIgnore]
		public UVMCommand AddNewVariant { get { return _addNewVariant; } set { _addNewVariant = value; OnPropertyChanged("AddNewVariant"); } }

		private UVMCommand _toggleAnswersVisible;
		[JsonIgnore]
		public UVMCommand ToggleAnswersVisible { get { return _toggleAnswersVisible; } set { _toggleAnswersVisible = value; OnPropertyChanged("ToggleAnswersVisible"); } }

		public override string ToString() {
			return "Question: " + Text;
		}
	}
}