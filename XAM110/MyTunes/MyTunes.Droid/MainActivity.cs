using Android.App;
using Android.OS;
using System.Linq;

namespace MyTunes
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		protected override async void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            //ListAdapter = new ListAdapter<string>() {
            //	DataSource = new[] { "One", "Two", "Three" }
            //};

            // Load the data
            var data = await SongLoader.Load();

            // Register the TableView's data source
            ListAdapter = new ListAdapter<Song>
            {
                DataSource = data.ToList(),
                TextProc = s => s.Name,
                DetailTextProc = s => s.Artist + " - " + s.Album,
            };
        }
	}
}


