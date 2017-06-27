using MTCQuest.ViewModel.zQuest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MTCQuest.ViewModel {
	public class MainViewModel : Notifiable, IDialogHelper {
		/// <summary>
		/// Test ViewModel constructor
		/// </summary>
		public MainViewModel() {
			CommonInit();
			CurrentQuest = TestData.GetTestQuest();
			CurrentGame = TestData.GetTestGame();
		}
		/// <summary>
		/// Actual ViewModel constructor
		/// </summary>
		/// <param name="Execute"></param>
		public MainViewModel(bool Execute) {
			CommonInit();
			////Temporally
			CurrentQuest = new Quest();
			CurrentGame = new Game() { Quest = CurrentQuest, Players = new System.Collections.ObjectModel.ObservableCollection<Player>() { new Player() { Text = "Player"} } };
			//CurrentQuest = TestData.GetTestQuest();
			//CurrentGame = TestData.GetTestGame();
			EditCommand.Exec(null);
		}

		void CommonInit() {
			Title = "MTC Quest";

			MenuButtonCommand = new UVMCommand(p =>MenuVisible = !MenuVisible);
			NewQuestCommand = new UVMCommand(p => CurrentQuest = new Quest());
			LoadQuestCommand = new UVMCommand(p => LoadQuest());
			SaveQuestCommand = new UVMCommand(p => SaveQuest());
			PlayCommand = new UVMCommand(p => {
				//if (CurrentGame.Quest == null) CurrentGame.Quest = CurrentQuest;
				CurrentGame.Quest = CurrentQuest;
				CurrentView = Views.Player;
				MenuVisible = false;
				//Show Presenter Window
			});
			EditCommand = new UVMCommand(p => {
				CurrentView = Views.Editor;
				MenuVisible = false;
				//Hide Presenter Window
			});

		}

		private string _title;
		public string Title { get { return _title; } set { _title = value; OnPropertyChanged("Title"); } }

		private Quest _currentQuest;
		public Quest CurrentQuest { get { return _currentQuest; } set { _currentQuest = value; OnPropertyChanged("CurrentQuest"); } }

		private string _currentQuestPath;
		public string CurrentQuestPath { get { return _currentQuestPath; } set { _currentQuestPath = value; OnPropertyChanged("CurrentQuestPath"); } }
		
		private bool _menuVisible;
		public bool MenuVisible {
			get { return _menuVisible; }
			set {_menuVisible = value; OnPropertyChanged("MenuVisible"); /*MenuVisibilityChanged(value);*/ }
		}
		private Visibility _editorVisibility;
		public Visibility EditorVisibility { get { return _editorVisibility; } set { _editorVisibility = value; OnPropertyChanged("EditorVisibility"); } }

		private Visibility _playerVisibility;
		public Visibility PlayerVisibility { get { return _playerVisibility; } set { _playerVisibility = value; OnPropertyChanged("PlayerVisibility"); } }

		public enum Views { Editor, Player}
		private Views _currentView;
		public Views CurrentView {
			get { return _currentView; }
			set {
				_currentView = value;
				OnPropertyChanged("CurrentView");
				if (value == Views.Editor) {
					EditorVisibility = Visibility.Visible;
					PlayerVisibility = Visibility.Collapsed;
				}
				else {
					EditorVisibility = Visibility.Collapsed;
					PlayerVisibility = Visibility.Visible;
				}
			}
		}

		#region EditorStuff
		private UVMCommand _menuButtonCommand;
		public UVMCommand MenuButtonCommand { get { return _menuButtonCommand; } set { _menuButtonCommand = value; } }

		private UVMCommand _newQuestCommand;
		public UVMCommand NewQuestCommand { get { return _newQuestCommand; } set { _newQuestCommand = value; OnPropertyChanged("NewQuestCommand"); } }

		private UVMCommand _loadQuestCommand;
		public UVMCommand LoadQuestCommand { get { return _loadQuestCommand; } set { _loadQuestCommand = value; OnPropertyChanged("LoadQuestCommand"); } }

		private UVMCommand _saveQuestCommand;
		public UVMCommand SaveQuestCommand { get { return _saveQuestCommand; } set { _saveQuestCommand = value; OnPropertyChanged("SaveQuestCommand"); } }

		private UVMCommand _playCommand;
		public UVMCommand PlayCommand { get { return _playCommand; } set { _playCommand = value; OnPropertyChanged("PlayCommand"); } }

		private UVMCommand _editCommand;
		public UVMCommand EditCommand { get { return _editCommand; } set { _editCommand = value; OnPropertyChanged("EditCommand"); } }

		void SaveQuest() {
			string FilePath = OpenDialog("Save", filter,"");
			if (FilePath == "") return;
			//Save to FilePath
			string serializedGame = JsonConvert.SerializeObject(CurrentQuest, Formatting.Indented, new JsonSerializerSettings {
				PreserveReferencesHandling = PreserveReferencesHandling.All
			});
			File.WriteAllText(FilePath, serializedGame);
			MenuVisible = false;
		}

		void LoadQuest() {
			string FilePath = OpenDialog("Open", filter, "");
			if (FilePath == "") return;
			//Open FilePath
			string serializedGame = File.ReadAllText(FilePath);
			CurrentQuest = JsonConvert.DeserializeObject<Quest>(serializedGame, new JsonSerializerSettings() { });
			CurrentGame.Quest = CurrentQuest;
			MenuVisible = false;
		}
		
		string filter = "Quest Files (*.zqt)|*.zqt|All files (*.*)|*.*";

		private Func<string, string, string, string> _openDialog = new Func<string, string, string, string>((a,b,c)=> { throw new Exception("OpenDialog not implemented. Nothing to call"); });
		Func<string, string, string, string> IDialogHelper.OpenDialog { get { return _openDialog; } set { _openDialog = value; } }
		public string OpenDialog(string Type, string Filter, string FilePath) {
			return _openDialog(Type, Filter, FilePath);
		}
		#endregion
		#region PlayerStuff

		private Game _currentGame;
		public Game CurrentGame { get { return _currentGame; } set { _currentGame = value; OnPropertyChanged("CurrentGame"); } }

		private UVMCommand _openQuestion;
		public UVMCommand OpenQuestion { get { return _openQuestion; } set { _openQuestion = value; OnPropertyChanged("OpenQuestion"); } }

		private UVMCommand _open;
		public UVMCommand Open { get { return _open; } set { _open = value; OnPropertyChanged("Open"); } }


		#endregion
	}
}
