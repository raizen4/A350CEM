﻿using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class MainPage : ContentPage
    {
        private  MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = (MainPageViewModel)BindingContext;
        }

       
    }
}