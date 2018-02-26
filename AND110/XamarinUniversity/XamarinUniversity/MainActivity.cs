using Android.App;
using Android.Widget;
using Android.OS;

namespace XamarinUniversity
{
    [Activity(Label = "XamarinUniversity", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            var instructorList = FindViewById<ListView>(Resource.Id.instructorListView);
            instructorList.Adapter = new ArrayAdapter<Instructor>(this, Android.Resource.Layout.SimpleListItem1, InstructorData.Instructors);

            instructorList.ItemClick += OnItemClick;
        }

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var instructor = InstructorData.Instructors[e.Position];

            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle(instructor.Name);
            dialog.SetMessage(instructor.Specialty);
            dialog.SetNeutralButton("OK", delegate { });
            dialog.Show();
        }
    }
}

