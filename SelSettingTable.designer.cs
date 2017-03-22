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
    [Register ("SelSettingTable")]
    partial class SelSettingTable
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView selSettingTab { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (selSettingTab != null) {
                selSettingTab.Dispose ();
                selSettingTab = null;
            }
        }
    }
}