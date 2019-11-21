using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppWeather2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendPage : ContentPage
    {
        public FriendPage()
        {
            InitializeComponent();
        }

        public City GetApiData()
        {
            string http_request = entryCity.Text;

            try
            {
                WebRequest request = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=" + http_request + "&lang=ru&units=metric&APPID=9ef54a4db0022f858b8abc4e37ca5faf");

                WebResponse response = request.GetResponse(); //await

                string answer = null;

                using (Stream s = response.GetResponseStream())
                {
                    using (StreamReader sR = new StreamReader(s))
                    {

                        answer = sR.ReadToEnd(); //await
                    }

                }

                response.Close();

                WeatherObjects rootObject = JsonConvert.DeserializeObject<WeatherObjects>(answer);

                entryCity.Text = "";

                return new City(rootObject.name, (int)rootObject.main.temp, (int)rootObject.wind.speed, rootObject.wind.deg);

            }

            catch
            {
                DisplayAlert("Ошибка!", "Нет подключения к интеренету, либо неверно введено название города.", "OK"); //await
                return new City("Не найдено", 0, 0, 0); ;
            }
        }
        private void SaveFriend(object sender, EventArgs e)
        {

            var city = GetApiData();
            if (!String.IsNullOrEmpty(city.Name_City))
            {
                App.Database.SaveItem(city);
            }
            this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}
