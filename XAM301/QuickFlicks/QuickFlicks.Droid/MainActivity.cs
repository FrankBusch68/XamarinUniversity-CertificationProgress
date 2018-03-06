using Android.App;
using Android.Widget;
using Android.OS;

namespace QuickFlicks.Droid
{
    [Activity(Label = "QuickFlicks.Droid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        MoviePresenter presenter = new MoviePresenter();

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var movieList = FindViewById<ListView>(Resource.Id.movieList);
            var adapter = new MovieAdapter();
            movieList.Adapter = adapter;

            var searchView = FindViewById<SearchView>(Resource.Id.searchView);
            searchView.QueryTextChange += OnSearch;

            presenter = new MoviePresenter();
            presenter.FilterApplied += adapter.SetData;
        }

        private async void OnSearch(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            await presenter.FilterMoviesAsync(e.NewText);
        }
    }
}

