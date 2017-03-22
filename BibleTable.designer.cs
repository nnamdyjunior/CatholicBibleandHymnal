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
    [Register ("BibleTable")]
    partial class BibleTable
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar bibleSearch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView bibTable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (bibleSearch != null) {
                bibleSearch.Dispose ();
                bibleSearch = null;
            }

            if (bibTable != null) {
                bibTable.Dispose ();
                bibTable = null;
            }
        }
    }
}