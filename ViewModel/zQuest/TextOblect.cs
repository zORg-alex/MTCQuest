namespace MTCQuest.ViewModel.zQuest {
	/// <summary>
	/// For Unification purposes
	/// </summary>
	public class TextObject : Selectable {

		private string _text;
		public string Text {
			get { return _text; }
			set {
				_text = value;
				OnPropertyChanged("Text");
			}
		}

	}
}