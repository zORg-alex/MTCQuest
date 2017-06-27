//using Newtonsoft.Json;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MTCQuest.ViewModel.zQuest {
	public class Player : TextObject {
		public Player() {

		}
		private int _score;
		public int Score { get { return _score; } set { _score = value; OnPropertyChanged("Score"); } }

		private ObservableCollection<Question> _questionList;
		public ObservableCollection<Question> QuestionList {
			get { return _questionList; }
			set { _questionList = value; OnPropertyChanged("QuestionList"); }
		}


		private UVMCommand _removeThis;
		[JsonIgnore]
		public UVMCommand RemoveThis { get { return _removeThis; } set { _removeThis = value; OnPropertyChanged("RemoveThis"); } }
	}
}