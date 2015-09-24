using System;
using System.Drawing.Imaging;
using Alx.Web;

namespace ConsoleAppDemo
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("Application started");
      const string url = "http://www.bbc.co.uk/news";

      var device = Devices.Desktop;
      var path = string.Format(@"C:\Temp\website-{0}.png", device);
      Alx.Web.Screenshot.Save(url, path, ImageFormat.Png, device);

      Console.WriteLine("Saved " + path);

      device = Devices.TabletLandscape;
      path = String.Format(@"C:\Temp\website-{0}.png", device);
      Alx.Web.Screenshot.Save(url, path, ImageFormat.Png, device);

      Console.WriteLine("Saved " + path);

      device = Devices.PhonePortrait;
      path = String.Format(@"C:\Temp\website-{0}.png", device);
      Alx.Web.Screenshot.Save(url, path, ImageFormat.Png, device);

      Console.WriteLine("Saved " + path);

      Console.WriteLine("Press [Enter] to exit...");
      Console.ReadLine();
    }
  }
}