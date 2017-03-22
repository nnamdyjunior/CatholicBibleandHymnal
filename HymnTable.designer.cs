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
    [Register ("HymnTable")]
    partial class HymnTable
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar hymnSearch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView hymTable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (hymnSearch != null) {
                hymnSearch.Dispose ();
                hymnSearch = null;
            }

            if (hymTable != null) {
                hymTable.Dispose ();
                hymTable = null;
            }
        }
    }
}