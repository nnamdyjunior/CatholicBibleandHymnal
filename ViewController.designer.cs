// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CatholicBibleandHymnal
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton bibleButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView homeImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton hymnButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton settingsButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStackView subStack { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (bibleButton != null) {
                bibleButton.Dispose ();
                bibleButton = null;
            }

            if (homeImage != null) {
                homeImage.Dispose ();
                homeImage = null;
            }

            if (hymnButton != null) {
                hymnButton.Dispose ();
                hymnButton = null;
            }

            if (settingsButton != null) {
                settingsButton.Dispose ();
                settingsButton = null;
            }

            if (subStack != null) {
                subStack.Dispose ();
                subStack = null;
            }
        }
    }
}