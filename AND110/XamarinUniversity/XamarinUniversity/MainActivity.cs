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
            instructorList.Adapter = new InstructorAdapter(InstructorData.Instructors);

            instructorList.ItemClick += OnItemClick;

            instructorList.FastScrollEnabled = true;
            instructorList.FastScrollAlwaysVisible = true;
        }

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var instructor = InstructorData.Instructors[e.Position];

            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle(instructor.Name);
            dialog.SetMessage(instructor.Biography);
            dialog.SetNeutralButton("OK", delegate { });
            dialog.Show();
        }
    }
}

