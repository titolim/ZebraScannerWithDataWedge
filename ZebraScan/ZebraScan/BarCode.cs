using System;
using System.Collections.Generic;
using System.Text;

namespace ZebraScannerWithDataWedge
{
  public class BarCode
  {
    public string Type { get; set; }
    public string Data { get; set; }
    public DateTime ScanTime { get; set; }

    public BarCode(string pType, string pData)
    {
      this.Type = pType;
      this.Data = pData;
      this.ScanTime = DateTime.Now;
    }
  }
}