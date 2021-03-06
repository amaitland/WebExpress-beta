﻿using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace WebExpress
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : UserControl
    {
        
        public StartPage()
        {
            InitializeComponent();
            Loaded += StartPage_Loaded;
            
        }
        public void loadFavs(MainWindow mw)
        {
            Dispatcher.BeginInvoke((Action) (() =>
            {
                try {
                    string[] readText = System.IO.File.ReadAllLines(TabView.Bookspath);
                    ArrayList arr = new ArrayList();
                    foreach (var sr in readText)
                    {
                        arr.Add(sr);
                    }
                    Grid parent = this.Parent as Grid;
                    TabView parent2 = parent.Parent as TabView;
                    foreach (string s in arr)
                    {
                        string[] split = s.Split((char)42);
                        bookmarks.AddBookmark(split[0], split[1], parent2, mw);
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine("LoadFavs error: " + ex.Message);
                }
            }));
        }
        private void StartPage_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(BookContainer, (this.ActualWidth / 2) - (BookContainer.ActualWidth / 2));
            Canvas.SetTop(BookContainer, (this.ActualHeight / 2) - (BookContainer.ActualHeight / 2));
        }
    }
}
