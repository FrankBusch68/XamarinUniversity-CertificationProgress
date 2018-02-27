using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Mailbox
{
    public class EmailServerDataSource : UITableViewSource
    {
        EmailServer emailServer = new EmailServer();

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return emailServer.Email.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = new UITableViewCell(CGRect.Empty);
            var item = emailServer.Email[indexPath.Row];

            cell.TextLabel.Text = item.Subject;
            return cell;
        }
    }
}
