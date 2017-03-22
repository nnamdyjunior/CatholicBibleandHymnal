using System;
using Foundation;
using UIKit;
using System.IO;


namespace CatholicBibleandHymnal
{
	public class BibleTableSource : UITableViewSource
	{
		protected string[] tableItems1;
		protected string[] tableItems2;
		protected string cellIdentifier = "TableCell";
		public UIViewController owner;
		public string title = "";
		public BibleTableSource(string[] items1, string[] items2, UIViewController owner)
		{
			tableItems1 = items1;
			tableItems2 = items2;
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

			//check what section the cell belongs to before labeling it
			NSMutableAttributedString celltext;
			if (indexPath.Section == 0)
			{
				celltext = new NSMutableAttributedString(tableItems1[indexPath.Row]);
				//cell.TextLabel.Text = tableItems1[indexPath.Row];
			}
			else
			{
				celltext = new NSMutableAttributedString(tableItems2[indexPath.Row]);
				//cell.TextLabel.Text = tableItems2[indexPath.Row];
			}

			var stringAttributes2 = new UIStringAttributes
			{
				Font = GeneralVariables.fontSelected,
				ForegroundColor = GeneralVariables.fontColorSelected
			};

			celltext.SetAttributes(stringAttributes2.Dictionary, new NSRange(0, celltext.Length));
			cell.TextLabel.AttributedText = celltext;
			cell.BackgroundColor = GeneralVariables.backColorSelected;
			//cell.TextLabel.TextColor = GeneralVariables.fontColorSelected;

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			//throw new NotImplementedException();
			if (section == 0)
			{
				return GeneralVariables.oldTestSize;
			}
			else 
			{
				return GeneralVariables.newTestSize;	
			}
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			
			if (indexPath.Section == 0)
			{
				title = tableItems1[indexPath.Row];
			}
			else 
			{
				title = tableItems2[indexPath.Row];
			}

			//get directory
			string directory = "Bible/" + title;
			GeneralVariables.selectedDir = directory;
			GeneralVariables.selectedBook = title;
			try
			{
				string[] files = Directory.GetFiles(directory);
				int dirSize = files.Length;
				string[] booksNum = new string[dirSize];
				for (int i = 0; i < dirSize; i++)
				{
					booksNum[i] = (i + 1).ToString();
				}
				GeneralVariables.numOfChapters = booksNum;
			}
			catch (IOException){
				string[] crap = { "1", "2"};
				GeneralVariables.numOfChapters = crap;
			}


			//show the next table containing chapters in the selected book
			BooksTable bt = owner.Storyboard.InstantiateViewController("booksTable") as BooksTable;
			bt.Title = title;
			owner.NavigationController.PushViewController(bt, true);
			tableView.DeselectRow(indexPath, true);
		}

		//number of sections in table
		public override nint NumberOfSections(UITableView tableView)
		{
			//return base.NumberOfSections(tableView);
			return 2;
		}

		//will look into this later
		/*public override string[] SectionIndexTitles(UITableView tableView)
		{
			string[] secTitles = {"Old Testament", "New Testament" };
			return secTitles;
			//return base.SectionIndexTitles(tableView);
		}*/
	}
}

