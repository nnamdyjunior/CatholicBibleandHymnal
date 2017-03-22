using Foundation;
using System;
using UIKit;

namespace CatholicBibleandHymnal
{
    public partial class Experiment2 : UITableViewController
    {
        public Experiment2 (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var stringAttributes2 = new UIStringAttributes
			{
				Font = GeneralVariables.fontSelected,
				ForegroundColor = GeneralVariables.fontColorSelected
			};
			var hymntext = new NSMutableAttributedString(GeneralVariables.hymnContent);
			hymntext.SetAttributes(stringAttributes2.Dictionary, new NSRange(0, hymntext.Length));

			hymnText.BackgroundColor = GeneralVariables.backColorSelected;
			hymnText.AttributedText = hymntext;
			hymnText.Editable = false;
		}
    }
}