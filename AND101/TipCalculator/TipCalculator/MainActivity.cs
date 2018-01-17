using Android.App;
using Android.Widget;
using Android.OS;

namespace TipCalculator
{
    [Activity(Label = "TipCalculator", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        EditText inputBill;
        Button calculateButton;
        TextView outputTip;
        TextView outputTotal;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            inputBill = FindViewById<EditText>(Resource.Id.inputBill);

            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            calculateButton.Click += OnCalculateClick;

            outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);
        }

        private void OnCalculateClick(object sender, System.EventArgs e)
        {
            string sBill = inputBill.Text;
            double dBill = double.Parse(sBill);

            var tip = dBill * 0.15;
            var total = dBill + tip;

            outputTip.Text = tip.ToString();
            outputTotal.Text = total.ToString();
        }
    }
}

