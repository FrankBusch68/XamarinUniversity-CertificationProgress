using ControlExplorer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;

//[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(MyButtonGradientEffect), "ButtonGradientEffect")]
namespace ControlExplorer.Droid
{
    public class MyButtonGradientEffect : PlatformEffect
    {
        Drawable oldDrawable;

        protected override void OnAttached()
        {
            if (Element is Button == false)
                return;

            oldDrawable = Control.Background;

            SetGradient();
        }

        protected override void OnDetached()
        {
            if (oldDrawable != null)
                Control.Background = oldDrawable;
        }

        void SetGradient()
        {
            var xfButton = Element as Xamarin.Forms.Button;

            var colorTop = xfButton.BackgroundColor;
            var colorBottom = Xamarin.Forms.Color.Black;

            var drawable = Gradient.GetGradientDrawable(colorTop.ToAndroid(), colorBottom.ToAndroid());

            Control.SetBackground(drawable);
        }

    }
}