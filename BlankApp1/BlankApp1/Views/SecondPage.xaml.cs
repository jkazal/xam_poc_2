
using BlankApp1.Entities.SQLEntities;

namespace BlankApp1.Views
{
    public partial class SecondPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Character myChar = new Character();
            myChar.Name = "zozo";
            await App.CharRepo.SaveCharacterAsync(myChar);
            charListView.ItemsSource = await App.CharRepo.GetCharactersAsync();
        }
    }
}
