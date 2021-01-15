﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DatabaseManagementUI.Properties;

namespace DatabaseManagementUI
{
    /// <summary>
    /// Interaction logic for FirstStart.xaml
    /// </summary>
    public partial class FirstStart : Window
    {
        public FirstStart()
        {
            InitializeComponent();
        }

        private void FirstStartSaveButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            App.Current.MainWindow = main;
            this.Close();
            main.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.ServerLocation != "" && Settings.Default.Username != "")
            {
                MainWindow main = new MainWindow();
                App.Current.MainWindow = main;
                this.Close();
                main.Show();
            }
        }
    }
}
