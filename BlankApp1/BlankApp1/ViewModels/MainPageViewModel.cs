using MvvmHelpers.Commands;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Entities;
using BlankApp1.Infra.Distant.Interfaces;
using BlankApp1.Infra.Local.Interfaces;

namespace BlankApp1.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public ISwapiRepository _swapiRepo { get; set; }
        public IMobileOs mobileOsService { get; set; }
        public StarWarsCharacter _chara;
        public StarWarsCharacter Chara
        {
            get { return _chara; }
            set { SetProperty(ref _chara, value); }
        }
        public string _osName;
        public string OSName { 
            get { return _osName;  }
            set { SetProperty(ref _osName, value); }
        }
        private string _basicBindString;
        public string BasicBindString
        {
            get { return _basicBindString; }
            set { SetProperty(ref _basicBindString, value); }
        }

        private List<StarWarsCharacter> _swchars;
        public List<StarWarsCharacter> SWChars
        {
            get { return _swchars; }
            set { SetProperty(ref _swchars, value); }
        }

        public ICommand NavigateTo2ndPageCommand { get; set; }
        public MainPageViewModel(
                INavigationService navigationService,
                ISwapiRepository swapiRepository,
                IMobileOs mobileOs
            ) : base(navigationService)
        {
            Title = "Main Page Test";
            BasicBindString = "bbbb";
            mobileOsService = mobileOs;
            _swapiRepo = swapiRepository;
            this.GetAllSWCharas();
            this.GetOSName();
            NavigateTo2ndPageCommand = new AsyncCommand(
                    DoNavigateTo2ndPage,
                    CanExecuteNavigateto2ndPageCommand, 
                    exception => Console.WriteLine(exception.Message)
                );

        }
        
        async void GetAllSWCharas()
        {
            SWChars = await _swapiRepo.GetAllStarWarsCharactersAsync();
            var blabla = SWChars;
            var test = 1;
        }

        bool CanExecuteNavigateto2ndPageCommand(object arg)
        {
            return true;
        }

        async Task DoNavigateTo2ndPage()
        {
            var navParams = new NavigationParameters(); 
            navParams.Add("MyFirstParam", "toto"); 
            navParams.Add("MySecondParam", "tata");

            await NavigationService.NavigateAsync("SecondPage", navParams);
        }

        void GetOSName()
        {
            OSName = mobileOsService.GetOSName();
            Console.WriteLine(OSName);
        }
    }
}
