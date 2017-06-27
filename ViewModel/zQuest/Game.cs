using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCQuest.ViewModel.zQuest {
	public class Game : Notifiable {
		public Game() {
			Quest = new Quest();
			Players = new ObservableCollection<Player>();
			AddNewPlayer = new UVMCommand("AddNewPlayer", p => {
				var pl = new Player() { Text = "New Player", IsSelected = true, IsEdited = true };
				pl.RemoveThis = new UVMCommand("RemoveThis", pp => Players.Remove(pl));
				Players.Add(pl);
			});
		}

		private Quest _quest;
		public Quest Quest { get { return _quest; } set { _quest = value; OnPropertyChanged("Quest"); } }

		private ObservableCollection<Player> _players;
		public ObservableCollection<Player> Players { get { return _players; } set { _players = value; OnPropertyChanged("Players"); } }

		
		private UVMCommand _addNewPlayer;
		[JsonIgnore]
		public UVMCommand AddNewPlayer { get { return _addNewPlayer; } set { _addNewPlayer = value; OnPropertyChanged("AddNewPlayer"); } }
	}
}