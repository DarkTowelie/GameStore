﻿using GameStore.CustomControlls;
using GameStore.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GameStore.Views
{
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
            WindowBorder windowBorder = new WindowBorder(this);
            MainGrid.SetValue(Grid.RowProperty, 0);
            MainGrid.Children.Add(windowBorder);
        }
    }
}
