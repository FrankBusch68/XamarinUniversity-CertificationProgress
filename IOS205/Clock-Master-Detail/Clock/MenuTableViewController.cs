using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Clock
{
	partial class MenuTableViewController : UITableViewController
	{
		public MenuTableViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			var sections = new string[]{ "Clock", "Stopwatch", "About" };

			this.TableView.Source = new MenuTableViewSource (this, sections);
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var clockVC = Storyboard.InstantiateViewController("ClockViewController");
            ShowDetailViewController(clockVC, this);
        }

        public class MenuTableViewSource : UITableViewSource
		{
			private UITableViewController controller;
			private string[] data;

			static string CELL_ID = "cellid";

			public MenuTableViewSource(UITableViewController controller, string[] data)
			{
				this.data = data;
				this.controller = controller;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (CELL_ID, indexPath);

				cell.TextLabel.Text = data [indexPath.Row];

				return cell;
			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return data.Length;
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
            {
                switch (indexPath.Row)
                {
                    case 0: //clock
                        var clockVC = controller.Storyboard.InstantiateViewController("ClockViewController");
                        controller.ShowDetailViewController(clockVC, controller);
                        break;
                    case 1://stopwatch
                        var stopwatchVC = controller.Storyboard.InstantiateViewController("StopwatchViewController");
                        controller.ShowDetailViewController(stopwatchVC, controller);
                        break;
                    case 2://about
                        var aboutVC = controller.Storyboard.InstantiateViewController("AboutViewController");
                        controller.ShowDetailViewController(aboutVC, controller);
                        break;
                }
            }

        }
    }
}
