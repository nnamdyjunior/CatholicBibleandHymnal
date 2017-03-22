using System;
using System.IO;
using UIKit;
using Foundation;


namespace CatholicBibleandHymnal
{
	public class HymnTableSource : UITableViewSource
	{
		protected string[] tableItems1;
		//protected string[] tableItems2;
		protected string cellIdentifier = "TableCell";
		public UIViewController owner;
		public string title = "";
		public HymnTableSource(string[] items1, UIViewController owner)
		{
			tableItems1 = items1;
			this.owner = owner;
		}

		//adding content to each cell in the table
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			//throw new NotImplementedException();
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			//if there are no cells to reuse, create a new one
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
			}

			var stringAttributes2 = new UIStringAttributes
			{
				Font = GeneralVariables.fontSelected,
				ForegroundColor = GeneralVariables.fontColorSelected
			};
			var celltext = new NSMutableAttributedString(tableItems1[indexPath.Row]);
			celltext.SetAttributes(stringAttributes2.Dictionary, new NSRange(0, celltext.Length));
			cell.TextLabel.AttributedText = celltext;
			//cell.TextLabel.Text = tableItems1[indexPath.Row];
			cell.BackgroundColor = GeneralVariables.backColorSelected;
			//cell.TextLabel.TextColor = GeneralVariables.fontColorSelected;

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			//throw new NotImplementedException();
			return GeneralVariables.hymnCats.Length;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//set the source directory
			GeneralVariables.hymnCatSelected = tableItems1[indexPath.Row];
			string[] hym = Directory.GetFiles("Hymns/" + GeneralVariables.hymnCatSelected);
			GeneralVariables.hymns = new string[hym.Length];
			for (int i = 0; i < hym.Length; i++)
			{
				GeneralVariables.hymns[i] = hym[i].Substring(6 + GeneralVariables.hymnCatSelected.Length + 1);
			}
			/*
			string categorySelected = GeneralVariables.selectedBook + catSelected;
			string catToOpen = GeneralVariables.selectedDir + "/" + categorySelected;

			//read file contents and store in a variable
			try
			{
				GeneralVariables.chapterContent = File.ReadAllText(catToOpen + ".txt");
			}
			catch (IOException e)
			{
				GeneralVariables.chapterContent = catToOpen;
			}*/

			//initialize a new view (the text view)
			HymnCategory hymc = owner.Storyboard.InstantiateViewController("hymnCategory") as HymnCategory;
			hymc.Title = GeneralVariables.hymnCatSelected;
			owner.NavigationController.PushViewController(hymc, true);

			tableView.DeselectRow(indexPath, true);

		}

	}
}




