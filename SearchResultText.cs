using Foundation;
using System;
using UIKit;

namespace CatholicBibleandHymnal
{
    public partial class SearchResultText : UITableViewController
    {
        public SearchResultText (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var stringAttributes = new UIStringAttributes { 
				BackgroundColor = UIColor.Yellow,
				Font = GeneralVariables.fontSelected//UIFont.FromName("Courier", 18)
			};

			var stringAttributes2 = new UIStringAttributes
			{
				Font = GeneralVariables.fontSelected 
			};


			int startIndex = GeneralVariables.searchText.ToLower().IndexOf(GeneralVariables.query.ToLower());

			var resString = new NSMutableAttributedString(GeneralVariables.searchText);


			if (startIndex >= 0) {
				resString.SetAttributes(stringAttributes2.Dictionary, new NSRange(0, resString.Length));
				resString.SetAttributes(stringAttributes.Dictionary, new NSRange(startIndex, GeneralVariables.query.Length));
			}


			SearchResText.AttributedText = resString;
			SearchResText.Editable = false;

			SearchResText.BackgroundColor = GeneralVariables.backColorSelected;
			SearchResText.TextColor = GeneralVariables.fontColorSelected;

		}
    }
}