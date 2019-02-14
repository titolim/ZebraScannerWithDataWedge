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
using Xamarin.Forms;

namespace ZebraScannerWithDataWedge.Droid
{
  [Activity(Label = "DataWedgeScanActivity")]
  [IntentFilter(new[] { MainActivity.IntentFilterName }, Categories = new[] { Intent.CategoryDefault })]
  public class DataWedgeScanActivity : Activity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      string labelType = Intent.GetStringExtra(MainActivity.DataWedgeLabelType);
      string data = Intent.GetStringExtra(MainActivity.DataWedgeDataString);

      MessagingCenter.Send<MainPage, BarCode>(App.Current.MainPage as MainPage, "ZebraScan", new BarCode(labelType, data));

      this.Finish(); // We don't want to see the UI of this activity
    }
  }
}