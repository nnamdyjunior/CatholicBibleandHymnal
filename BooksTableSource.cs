using System;
using Foundation;
using UIKit;
using System.IO;


namespace CatholicBibleandHymnal
{
	public class BooksTableSource : UITableViewSource
	{
		protected string[] tableItems1;
		//protected string[] tableItems2;
		protected string cellIdentifier = "TableCell";
		public UIViewController owner;
		public string title = "";
		public BooksTableSource(string[] items1, UIViewController owner)
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
			return GeneralVariables.numOfChapters.Length;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//set the source directory
			string chapter = tableItems1[indexPath.Row];
			string chapterSelected = GeneralVariables.selectedBook + chapter;
			string chapToOpen = GeneralVariables.selectedDir + "/" + chapterSelected;

			//read file contents and store in a variable
			try
			{
				GeneralVariables.chapterContent = File.ReadAllText(chapToOpen + ".txt");
			}
			catch (IOException)
			{
				GeneralVariables.chapterContent = chapToOpen;
			}
			/*
			//initialize a new view (the text view)
			ChapterTextView ctv = owner.Storyboard.InstantiateViewController("chapterTextView") as ChapterTextView;
			ctv.Title = GeneralVariables.selectedBook + " " + chapter;
			owner.NavigationController.PushViewController(ctv, true);*/

			var exp = owner.Storyboard.InstantiateViewController("experiment") as Experiment;
			exp.Title = GeneralVariables.selectedBook + " " + chapter;
			owner.NavigationController.PushViewController(exp, true);

			tableView.DeselectRow(indexPath, true);

		}

	}
}


