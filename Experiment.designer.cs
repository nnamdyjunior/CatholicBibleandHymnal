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
    [Register ("Experiment")]
    partial class Experiment
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView chapterText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (chapterText != null) {
                chapterText.Dispose ();
                chapterText = null;
            }
        }
    }
}