﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentGestion.View
{
    /// <summary>
    /// Logique d'interaction pour BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {
        private bool _isPasswordChanging;

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox), new PropertyMetadata(string.Empty,PasswordPropertyChagned));

        private static void PasswordPropertyChagned(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is BindablePasswordBox passwordBox)
            {
                passwordBox.UpdatePassword();
            }
        }

     
        public BindablePasswordBox()
        {
            InitializeComponent();
        }

        private void passwordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _isPasswordChanging = true;
            Password = passwordbox.Password;
            _isPasswordChanging = false;
        }
        private void UpdatePassword()
        {
            if (!_isPasswordChanging)
            {
                passwordbox.Password = Password;
            }
        }

    }
}
