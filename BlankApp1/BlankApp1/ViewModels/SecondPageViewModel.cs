using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlankApp1.ViewModels
{
    public class SecondPageViewModel : ViewModelBase
    {
        public string _firstParam;
        public string FirstParam
        {
            get { return _firstParam; }
            set { SetProperty(ref _firstParam, value); }
        }
        public string _secondParam;
        public string SecondParam
        {
            get { return _secondParam; }
            set { SetProperty(ref _secondParam, value); }
        }
        public SecondPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "2nd Page";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            FirstParam = parameters.GetValue<string>("MyFirstParam");
            SecondParam = parameters.GetValue<string>("MySecondParam");
        }
    }
}
