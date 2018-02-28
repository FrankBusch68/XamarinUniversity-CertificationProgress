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
        ViewController owner;

        public EmailServerDataSource(ViewController owner)
        {
            this.owner = owner;
        }

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

            cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // Create the View Controller in the Main storyboard.
            var storyboard = UIStoryboard.FromName("Main", null);
            var detailViewController =
                 (DetailsViewController)storyboard.InstantiateViewController(
                    "DetailsViewController");

            // Set the email details
            var emailItem = emailServer.Email[indexPath.Row];
            detailViewController.Item = emailItem;

            // Show the new page as a "modal"
            owner.ShowDetailViewController(detailViewController, owner);

        }

        public override void AccessoryButtonTapped(UITableView tableView,
                                           NSIndexPath indexPath)
        {
            var emailItem = emailServer.Email[indexPath.Row];

            var controller = UIAlertController.Create("Email Details",
                                 emailItem.ToString(), UIAlertControllerStyle.Alert);
            controller.AddAction(UIAlertAction.Create("OK",
                                 UIAlertActionStyle.Default, null));

            owner.PresentViewController(controller, true, null);
        }
    }
}
