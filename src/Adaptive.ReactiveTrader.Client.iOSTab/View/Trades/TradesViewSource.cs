﻿
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Adaptive.ReactiveTrader.Client.iOSTab.Tiles;
using Adaptive.ReactiveTrader.Client.iOSTab.Model;

namespace Adaptive.ReactiveTrader.Client.iOSTab.View
{
	public class TradesViewSource : UITableViewSource
	{
		private readonly TradeTilesModel _tradeTilesModel;

		public TradesViewSource (TradeTilesModel tradeTilesModel)
		{
			_tradeTilesModel = tradeTilesModel;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			return 1;
		}

		public override float GetHeightForHeader (UITableView tableView, int section)
		{
			// Crude fix for overlap with trades cells and phone status bar.
			return 20.0f;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _tradeTilesModel.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (PriceTileTradeAffirmationViewCell.Key) as PriceTileTradeAffirmationViewCell;
			if (cell == null)
				cell = PriceTileTradeAffirmationViewCell.Create ();

			var doneTrade = _tradeTilesModel [(int)indexPath.IndexAtPosition (1)];

			cell.UpdateFrom (doneTrade);

			return cell;
		}
		/*
		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			// For now all rows are the same height, set via ConfigureTable.
		}*/
	}
}

