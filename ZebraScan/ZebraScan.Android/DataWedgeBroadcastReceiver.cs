using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ZebraScannerWithDataWedge.Droid
{
  [BroadcastReceiver(Enabled = true, Exported = true)]
  [IntentFilter(new[] { MainActivity.IntentFilterName }, Categories = new[] { Intent.CategoryDefault })]
  public class DataWedgeBroadcastReceiver : BroadcastReceiver
  {
    public override void OnReceive(Context context, Intent intent)
    {
      string labelType = intent.GetStringExtra(MainActivity.DataWedgeLabelType);
      string data = intent.GetStringExtra(MainActivity.DataWedgeDataString);
    }
  }
}