using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTCQuest.ViewModel.zQuest;

namespace MTCQuest.ViewModel {
	class TestData {
		static Quest _quest;
		static Game _game;

		public static Quest GetTestQuest() {
			if (_quest != null) return _quest;

			Quest qst = new Quest() { Text = "TestGame" };
			for (int ti = 0; ti < 5; ti++) {
				Theme t = new Theme() { Text = "Theme" + ti };
				for (int qi = 0; qi < 5; qi++) {
					Question q = new Question() {
						Text = "This is a Question" + ti + "." + qi,
						AnswersVisible = true,
						Answer = "Answer" + qi,
						ParentTheme = t
					};
					for (int vi = 0; vi < 5; vi++) {
						q.Variants.Add(new Variant() { Text = "variant" + vi });
					}
					//q.SelectedVariant = q.Variants.FirstOrDefault();
					t.Questions.Add(q);
				}
				t.SelectedQuestion = t.Questions.FirstOrDefault();
				qst.Themes.Add(t);
			}
			qst.SelectedTheme = qst.Themes.FirstOrDefault();
			//qst.Themes = new ObservableCollection<Theme>() {
			//	new Theme() {
			//		Text = "First Theme",
			//		IsSelected = true,
			//		Questions = new ObservableCollection<Question>() {
			//			new Question() {
			//				Text = "First Question",
			//				IsSelected = true,
			//				IsEdited = true
			//			},
			//			new Question() {
			//				Text = "Another Question"
			//			},
			//			new Question() {
			//				Text = "One More Question"
			//			}
			//		}
			//	},
			//	new Theme() {
			//		Text = "Another Theme",
			//		Questions = new ObservableCollection<Question>() {
			//		}
			//	}
			//};
			return qst;
		}
		public static Game GetTestGame() {
			if (_game != null) return _game;

			Game g = new Game();
			g.Quest = GetTestQuest();
			for (int i = 0; i < 5; i++) {
				Player p = new Player() { Text = "Player " + i + " Name" };
				g.Players.Add(p);
			}

			return g;
		}
	}
}
