using QuickFlicks.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace QuickFlicks.XForms
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            BindingContext = new MainViewModel();
            InitializeComponent();
        }
	}
}
