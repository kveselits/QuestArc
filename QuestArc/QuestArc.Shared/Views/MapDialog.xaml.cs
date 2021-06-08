using QuestArc.Models;
using QuestArc.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace QuestArc.Views
{
	public sealed partial class MapDialog : ContentDialog
	{
		public Quest SelectedQuest { get; set; }

		public MapDialog(Quest selectedQuest)
		{
			this.InitializeComponent();
			SelectedQuest = selectedQuest;
		}

		public MapViewModel ViewModel { get; } = new MapViewModel();

		private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
			BattleSimulator sim = new BattleSimulator();
			this.Hide();
			await sim.RandomBattle();
		}

		private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
			this.Hide();
		}
	}
}
