using ControlExplorer.UWP;
using System.ComponentModel;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

//[assembly: ResolutionGroupName ("Xamarin")]
[assembly: ExportEffect(typeof(MyButtonGradientEffect), "ButtonGradientEffect")]
namespace ControlExplorer.UWP
{    
    public class MyButtonGradientEffect : PlatformEffect
    {
        Brush oldBrush;

        protected override void OnAttached()
        {
            if (Element is Button == false)
                return;

            var button = Control as FormsButton;
            oldBrush = button.BackgroundColor;

            SetGradient();
        }

        protected override void OnDetached()
        {
            if (oldBrush == null)
                return;

            var button = Control as FormsButton;
            button.BackgroundColor = oldBrush;
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(e);

            if (Element is Button == false)
                return;

            if (e.PropertyName == ButtonGradientEffect.GradientColorProperty.PropertyName)
                SetGradient();
        }

        Windows.UI.Color GetWindowsColor(Color color)
        {
            return Windows.UI.Color.FromArgb((byte)(255 * color.A), (byte)(255 * color.R), (byte)(255 * color.G), (byte)(255 * color.B));
        }

        void SetGradient()
        {
            var xfButton = Element as Button;

            var button = Control as FormsButton;

            var colorTop = xfButton.BackgroundColor;
            var colorBottom = ButtonGradientEffect.GetGradientColor(xfButton);

            button.BackgroundColor = Gradient.GetGradientBrush(GetWindowsColor(colorTop), GetWindowsColor(colorBottom));
        }
    }
}