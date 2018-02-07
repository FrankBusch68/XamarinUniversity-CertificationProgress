using People.Models;
using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace People
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = string.Empty;

            await App.PersonRepo.AddNewPersonAsync(newPerson.Text);
            statusMessage.Text = App.PersonRepo.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = string.Empty;
            var people = await App.PersonRepo.GetAllPeopleAsync();
            peopleList.ItemsSource = people;
        }
    }
}