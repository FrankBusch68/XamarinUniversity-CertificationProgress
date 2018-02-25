// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PeerPromotion
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider TheSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ValueLabel { get; set; }

        [Action ("slider_ValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void slider_ValueChanged (UIKit.UISlider sender);

        void ReleaseDesignerOutlets ()
        {
            if (TheSlider != null) {
                TheSlider.Dispose ();
                TheSlider = null;
            }

            if (ValueLabel != null) {
                ValueLabel.Dispose ();
                ValueLabel = null;
            }
        }
    }
}