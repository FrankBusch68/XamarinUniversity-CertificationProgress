using ControlExplorer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using System.ComponentModel;

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

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(e);

            if (Element is Button == false)
                return;

            if (e.PropertyName == ButtonGradientEffect.GradientColorProperty.PropertyName)
                SetGradient();
        }

        void SetGradient()
        {
            var xfButton = Element as Xamarin.Forms.Button;

            var colorTop = xfButton.BackgroundColor;
            var colorBottom = ButtonGradientEffect.GetGradientColor(xfButton);

            var drawable = Gradient.GetGradientDrawable(colorTop.ToAndroid(), colorBottom.ToAndroid());

            Control.SetBackground(drawable);
        }

    }
}