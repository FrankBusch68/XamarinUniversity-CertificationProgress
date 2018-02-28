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
            UITableViewCell cell = new UITableViewCell(UITableViewCellStyle.Subtitle, null);
            var item = emailServer.Email[indexPath.Row];

            cell.TextLabel.Font = UIFont.FromName("Avenir-Light", 17); 
            cell.DetailTextLabel.Font = UIFont.FromName("Avenir-Light", 14);
            cell.DetailTextLabel.TextColor = UIColor.LightGray;

            cell.TextLabel.Text = item.Subject;
            cell.DetailTextLabel.Text = item.Body;
            cell.ImageView.Image = item.GetImage();
            return cell;
        }
    }
}
