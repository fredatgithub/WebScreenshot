using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using Alx.Web;

namespace ConsoleAppDemo
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("Application started");
      string url = "http://www.bbc.co.uk/news";

      var device = Devices.Desktop;
      var path = string.Format(@"C:\Temp\website-{0}.png", device);
      Screenshot.Save(url, path, ImageFormat.Png, device);
      Console.WriteLine("Saved " + path);
      OpenImage(path);

      url = "http://www.codeproject.com/Articles/1030283/Neat-Tricks-for-Effortlessly-Formatting-Currency-i";
      path = string.Format(@"C:\Temp\codeProjectArticle1-{0}.png", device);
      Screenshot.Save(url, path, ImageFormat.Png, device);
      Console.WriteLine("Saved " + path);
      OpenImage(path);

      device = Devices.TabletLandscape;
      path = string.Format(@"C:\Temp\website-{0}.png", device);
      Screenshot.Save(url, path, ImageFormat.Png, device);
      Console.WriteLine("Saved " + path);
      OpenImage(path);

      device = Devices.PhonePortrait;
      path = string.Format(@"C:\Temp\website-{0}.png", device);
      Screenshot.Save(url, path, ImageFormat.Png, device);
      Console.WriteLine("Saved " + path);
      OpenImage(path);

      Console.WriteLine("Press any key to exit");
      Console.ReadKey();
    }

    private static void OpenImage(string fileName)
    {
      if (File.Exists(fileName))
      {
        Process.Start(fileName);
      }
    }
  }
}