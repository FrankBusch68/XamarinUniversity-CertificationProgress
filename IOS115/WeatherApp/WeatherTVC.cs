using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;

namespace WeatherApp
{
    partial class WeatherTVC : UITableViewController
    {
        const string CELL_ID = "id";
        List<Weather> data;

        public WeatherTVC(IntPtr handle) : base(handle)
        {
            data = WeatherFactory.GetWeatherData();

            TableView.RegisterClassForCellReuse(typeof(WeatherCell), CELL_ID);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (WeatherTableCell)tableView.DequeueReusableCell("cell_id");

            cell.UpdateData(data[indexPath.Row]);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return data.Count;
        }
    }
}
