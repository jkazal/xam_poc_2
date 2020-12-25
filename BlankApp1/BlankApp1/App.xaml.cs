using BlankApp1.Infra;
using BlankApp1.Infra.Distant.Interfaces;
using BlankApp1.Infra.Local.Implementations;
using BlankApp1.ViewModels;
using BlankApp1.Views;
using Prism;
using Prism.Ioc;
using System;
using System.IO;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace BlankApp1
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SecondPage, SecondPageViewModel>();

            // DAL
            containerRegistry.Register<ISwapiRepository, StarWarsRepository>();
        }

        static CharacterRepository charRepo;

        public static CharacterRepository CharRepo
        {
            get
            {
                if (charRepo == null)
                {
                    charRepo = new CharacterRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return charRepo;
            }
        }
    }
}
