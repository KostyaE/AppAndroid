using System;
using Xamarin.Forms;

namespace AppWeather2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            friendsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        
        // обработка нажатия кнопки добавления
        private async void Button_Clicked(object sender, EventArgs e)
        {
            City friend = new City();
            FriendPage friendPage = new FriendPage();
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }

        private async void FriendsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            bool result = await DisplayAlert("Подтвердить действие", "Вы хотите удалить элемент?", "Да", "Нет");
            var friend = (City)e.Item;
            

            if (result)
            {
                App.Database.DeleteItem(friend.Id);

                friendsList.ItemsSource = App.Database.GetItems();
                base.OnAppearing();


            }

        }
    }
}
