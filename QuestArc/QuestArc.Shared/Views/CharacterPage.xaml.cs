﻿using System;
using System.Collections.Generic;
using QuestArc.ViewModels;

using Windows.UI.Xaml.Controls;
using QuestArc.Models;
using Windows.UI.Xaml;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace QuestArc.Views
{
    public sealed partial class CharacterPage : Page
    {
        public CharacterViewModel ViewModel { get; } = new CharacterViewModel();

        public CharacterPage()
        {
            
            InitializeComponent();
            DataContext = ViewModel;
        }

        private async void StrButton_Pressed(object sender, RoutedEventArgs e)
        {
            ViewModel.viewStr += 1;
            ViewModel.CharacterRef.Strength += 1;
            await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
        }

        private async void ConButton_Pressed(object sender, RoutedEventArgs e)
        {
            ViewModel.viewCon += 1;
            ViewModel.CharacterRef.Constitution += 1;
            await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
        }

        private async void DexButton_Pressed(object sender, RoutedEventArgs e)
        {
            ViewModel.viewDex += 1;
            ViewModel.CharacterRef.Dexterity += 1;
            await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
        }

        private async void WisButton_Pressed(object sender, RoutedEventArgs e)
        {
            ViewModel.viewWis += 1;
            ViewModel.CharacterRef.Wisdom += 1;
            await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
        }

        private async void ChaButton_Pressed(object sender, RoutedEventArgs e)
        {
            ViewModel.viewCha += 1;
            ViewModel.CharacterRef.Charisma += 1;
            await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
        }

        private async void IntButton_Pressed(object sender, RoutedEventArgs e)
        {
            ViewModel.viewInt += 1;
            ViewModel.CharacterRef.Intelligence += 1;
            await App.Database.SaveCharacterAsync(ViewModel.CharacterRef);
        }
    }
}
