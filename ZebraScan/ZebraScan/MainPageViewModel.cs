using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ZebraScannerWithDataWedge
{
  public class MainPageViewModel : INotifyPropertyChanged
  {
    public string AppTitle { get { return "Zebra Scanner With DataWedge Demo!"; } } // If title show then binding context is good

    public ObservableCollection<BarCode> ScannedCodes { get; }

    private bool _isRefreshing = false;
    public bool IsRefreshing
    {
      get
      {
        return _isRefreshing;
      }
      set
      {
        if (_isRefreshing != value)
        {
          _isRefreshing = value;
          this.OnPropertyChanged();
        }
      }
    }

    public ICommand ClearCommand { get; }

    public MainPageViewModel()
    {
      // Initializing members
      this.ScannedCodes = new ObservableCollection<BarCode>();

      // Setting bindings
      this.ClearCommand = new Command(this.ClearBarCodeList);

      // Testing data
      this.ScannedCodes.Add(new BarCode("QR1", "Test1"));
      this.ScannedCodes.Add(new BarCode("QR2", "Test2"));
      this.ScannedCodes.Add(new BarCode("QR3", "Test3"));

      MessagingCenter.Subscribe<MainPage, BarCode>(this, "ZebraScan", (sender, args) => { this.ScannedCodes.Add(args); });
    }

    public void ClearBarCodeList()
    {
      this.ScannedCodes.Clear();
      this.IsRefreshing = false;
    }

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName]string pPropertyName = "") => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pPropertyName));
    #endregion INotifyPropertyChanged
  }
}