﻿using System.Windows;
using UserControl = System.Windows.Controls.UserControl;
using WebExpress.Applets;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System;
using System.Windows.Input;

namespace WebExpress.Controls
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public MainWindow mainWindow;
        public Menu()
        {
            InitializeComponent();
            
        }

        private void DownloadsButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mainWindow.Downloads1.Visibility = Visibility.Visible;

            ExecuteStoryBoard();
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(TabView.Historylayoutpath);

            ApplicationCommands.New.Execute(new OpenTabCommandParameters("file://" + TabView.Historylayoutpath, "History", "#FFF9F9F9"), this);

            ExecuteStoryBoard();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ExecuteStoryBoard();
        }
        private void SettingsButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationCommands.New.Execute(new OpenTabCommandParameters(new Settings(), "Settings", "#1abc9c"), this);

            ExecuteStoryBoard();
        }

        private void AddonsButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationCommands.New.Execute(new OpenTabCommandParameters(new Extensions(), "Extensions", "#1abc9c"), this);

            ExecuteStoryBoard();
        }

        private void BookmarksButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(TabView.Historylayoutpath);

            ApplicationCommands.New.Execute(new OpenTabCommandParameters("file://" + TabView.Bookmarkslayoutpath, "Bookmarks", "#FFF9F9F9"), this);
            
            ExecuteStoryBoard();
        }

        private void ExecuteStoryBoard()
        {
            Storyboard sb = this.FindResource("sb") as Storyboard;
            Storyboard.SetTarget(sb, this);
            sb.Begin();
            sb.Completed += (o, e1) =>
            {
                Visibility = Visibility.Hidden;
            };
        }
    }
}
