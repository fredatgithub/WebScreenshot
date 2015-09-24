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
      string url = "http://www.bbc.co.uk/news";

      var device = Devices.Desktop;
      var path = string.Format(@"C:\Temp\website-{0}.png", device);
      //Screenshot.Save(url, path, ImageFormat.Png, device);
      Console.WriteLine("Saved " + path);

      url = "http://www.codeproject.com/Articles/1030283/Neat-Tricks-for-Effortlessly-Formatting-Currency-i";
      path = string.Format(@"C:\Temp\codeProjectArticle1-{0}.png", device);
      Screenshot.Save(url, path, ImageFormat.Png, device);
      Console.WriteLine("Saved " + path);

      device = Devices.TabletLandscape;
      path = string.Format(@"C:\Temp\website-{0}.png", device);
      Screenshot.Save(url, path, ImageFormat.Png, device);

      Console.WriteLine("Saved " + path);

      device = Devices.PhonePortrait;
      path = string.Format(@"C:\Temp\website-{0}.png", device);
      Screenshot.Save(url, path, ImageFormat.Png, device);

      Console.WriteLine("Saved " + path);

      Console.WriteLine("Press any key to exit");
      Console.ReadKey();
    }
  }
}