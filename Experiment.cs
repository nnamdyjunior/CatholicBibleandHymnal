using Foundation;
using System;
using UIKit;

namespace CatholicBibleandHymnal
{
    public partial class Experiment : UITableViewController
    {
        public Experiment (IntPtr handle) : base (handle)
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
			var chaptext = new NSMutableAttributedString(GeneralVariables.chapterContent);
			chaptext.SetAttributes(stringAttributes2.Dictionary, new NSRange(0, chaptext.Length));

			chapterText.BackgroundColor = GeneralVariables.backColorSelected;
			chapterText.AttributedText = chaptext;
			chapterText.Editable = false;
		}
    }
}