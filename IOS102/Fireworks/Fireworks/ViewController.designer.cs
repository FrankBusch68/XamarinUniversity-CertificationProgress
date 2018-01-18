// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Fireworks
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton buttonStart { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider sliderSize { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch switchNight { get; set; }

        [Action ("SliderSize_ValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SliderSize_ValueChanged (UIKit.UISlider sender);

        [Action ("SwitchNight_ValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SwitchNight_ValueChanged (UIKit.UISwitch sender);

        void ReleaseDesignerOutlets ()
        {
            if (buttonStart != null) {
                buttonStart.Dispose ();
                buttonStart = null;
            }

            if (sliderSize != null) {
                sliderSize.Dispose ();
                sliderSize = null;
            }

            if (switchNight != null) {
                switchNight.Dispose ();
                switchNight = null;
            }
        }
    }
}