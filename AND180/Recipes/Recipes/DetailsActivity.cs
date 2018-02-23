using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;

namespace Recipes
{
	[Activity(Label = "DetailsActivity")]
	public class DetailsActivity : Android.Support.V7.App.AppCompatActivity
    {
		Recipe recipe;
		ArrayAdapter adapter;

        Android.Support.V7.Widget.Toolbar toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Details);

            //
            // Retrieve the recipe to be displayed on this page
            //
            int index = Intent.GetIntExtra("RecipeIndex", -1);
			recipe = RecipeData.Recipes[index];

            //
            // Show the recipe name
            //
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Title = recipe.Name;
            base.SetSupportActionBar(toolbar);

            //
            // Show the list of ingredients
            //
            var list = FindViewById<ListView>(Resource.Id.ingredientsListView);
			list.Adapter = adapter = new ArrayAdapter<Ingredient>(this, Android.Resource.Layout.SimpleListItem1, recipe.Ingredients);

			//
			// Navigation button: navigate back to the previous page
			//
			FindViewById<ImageButton>(Resource.Id.backButton).Click += (sender, e) => Finish();
		}

        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {
            base.MenuInflater.Inflate(Resource.Menu.actions, menu);
            SetFavoriteDrawable(recipe.IsFavorite);
            return true;
        }

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.addToFavorites:
                    recipe.IsFavorite = !recipe.IsFavorite;
                    SetFavoriteDrawable(recipe.IsFavorite);
                    break;

                case Resource.Id.about:
                    StartActivity(typeof(AboutActivity));
                    break;
                case Resource.Id.oneServing: SetServings(1); item.SetChecked(true); break;
                case Resource.Id.twoServings: SetServings(2); item.SetChecked(true); break;
                case Resource.Id.fourServings: SetServings(4); item.SetChecked(true); break;
            }

            return true;
        }

		void SetFavoriteDrawable(bool isFavorite)
		{
            if (isFavorite)
                toolbar.Menu.FindItem(Resource.Id.addToFavorites).SetIcon(Resource.Drawable.ic_favorite_white_24dp); // filled in 'heart' image
            else
                toolbar.Menu.FindItem(Resource.Id.addToFavorites).SetIcon(Resource.Drawable.ic_favorite_border_white_24dp); // 'heart' image border only
        }
		// Note: base.GetDrawable requires API level 21
		// To run on earlier versions, change the minimum API level in the project settings and use the following code:
		//void SetFavoriteDrawables(bool isFavorite)
		//{
		//	Drawable drawable = null;
		//
		//	if (isFavorite)
		//		drawable = Resources.GetDrawable(Resource.Drawable.ic_favorite_white_24dp);
		//	else
		//		drawable = Resources.GetDrawable(Resource.Drawable.ic_favorite_border_white_24dp);
		//
		//	FindViewById<ToggleButton>(Resource.Id.favoriteButton).SetCompoundDrawablesWithIntrinsicBounds(null, drawable, null, null);
		//}

		void SetServings(int numServings)
		{
			recipe.NumServings = numServings;

			adapter.NotifyDataSetChanged();
		}
	}
}