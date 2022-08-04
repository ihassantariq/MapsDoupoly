using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MapSampleForDoupoly
{
    public partial class MapsPage : ContentPage
    {
        private MapsPageViewModel viewModel = new MapsPageViewModel();
        public MapsPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.CurrentPage = this;
        }
    }
}
