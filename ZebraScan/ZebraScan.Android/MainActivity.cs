using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace ZebraScannerWithDataWedge.Droid
{
  [Activity(Label = "ZebraScannerWithDataWedge", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    public const string IntentFilterName = "com.titolim.ZebraScannerWithDataWedge";
    public const string DataWedgeLabelType = "com.symbol.datawedge.label_type";
    public const string DataWedgeDataString = "com.symbol.datawedge.data_string";

    // For using broadcast
    private DataWedgeBroadcastReceiver _broadcastReceiver = new DataWedgeBroadcastReceiver();
    private IntentFilter _broadcastIntentFilter = new IntentFilter(MainActivity.IntentFilterName);

    protected override void OnCreate(Bundle savedInstanceState)
    {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(savedInstanceState);
      global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
      LoadApplication(new App());

      _broadcastIntentFilter.AddCategory(Intent.CategoryDefault); // For using broadcast
    }

    protected override void OnResume()
    {
      Application.Context.RegisterReceiver(_broadcastReceiver, _broadcastIntentFilter); // Register broadcast receiver
      base.OnResume();
    }

    protected override void OnPause()
    {
      Application.Context.UnregisterReceiver(_broadcastReceiver); // Unregister broadcast receiver
      base.OnPause();
    }
  }
}