using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TallerS5JuanCumbicus
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.59.1//moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<TallerS5JuanCumbicus.datos> _post;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnget_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<TallerS5JuanCumbicus.datos> posts = JsonConvert.DeserializeObject<List<TallerS5JuanCumbicus.datos>>(content);
            _post = new ObservableCollection<TallerS5JuanCumbicus.datos>(posts);

            MyListView.ItemsSource = _post;
        }

        private void btnnext_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new registro());

        }
    }
}
