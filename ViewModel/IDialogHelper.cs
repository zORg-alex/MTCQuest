using System;

namespace MTCQuest.ViewModel {
	public interface IDialogHelper {
		Func<string, string, string, string> OpenDialog { get; set; }
	}
}