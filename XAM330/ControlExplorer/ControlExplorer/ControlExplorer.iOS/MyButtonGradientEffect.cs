using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreAnimation;
using ControlExplorer.iOS;

//[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(MyButtonGradientEffect), "ButtonGradientEffect")]
namespace ControlExplorer.iOS
{
    public class MyButtonGradientEffect : PlatformEffect
    {
        CAGradientLayer gradLayer;

        protected override void OnAttached()
        {
            if (Element is Button == false)
                return;

            SetGradient();
        }

        protected override void OnDetached()
        {
            if (gradLayer != null)
                gradLayer.RemoveFromSuperLayer();
        }
        void SetGradient()
        {
            gradLayer?.RemoveFromSuperLayer();

            var xfButton = Element as Button;
            var colorTop = xfButton.BackgroundColor;
            var colorBottom = Color.Black;

            gradLayer = Gradient.GetGradientLayer(colorTop.ToCGColor(), colorBottom.ToCGColor(), (float)xfButton.Width, (float)xfButton.Height);

            Control.Layer.InsertSublayer(gradLayer, 0);
        }
    }
}