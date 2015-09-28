using System;
using System.Collections.Generic;
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
      string myImages = AddSlash(Environment.GetEnvironmentVariable("USERPROFILE")) + 
        Environment.SpecialFolder.MyPictures;
      CreateDirectory(myImages);
      var device = Devices.Desktop;
      var path = string.Format(AddSlash(myImages) + "bbc-co-uk-{0}.png", device);
      //Screenshot.Save(url, path, ImageFormat.Png, device);
      Console.WriteLine("Saved " + path);
      //OpenImage(path);

      url = "http://www.codeproject.com/Articles/1030283/Neat-Tricks-for-Effortlessly-Formatting-Currency-i";
      path = string.Format(AddSlash(myImages) + "codeProjectArticle1-{0}.png", device);
      //Screenshot.Save(url, path, ImageFormat.Png, device);
      Console.WriteLine("Saved " + path);
      //OpenImage(path);

      device = Devices.TabletLandscape;
      path = string.Format(AddSlash(myImages) + "website-{0}.png", device);
      //Screenshot.Save(url, path, ImageFormat.Png, device);
      Console.WriteLine("Saved " + path);
      //OpenImage(path);

      device = Devices.PhonePortrait;
      path = string.Format(AddSlash(myImages) + "website-{0}.png", device);
      //Screenshot.Save(url, path, ImageFormat.Png, device);
      Console.WriteLine("Saved " + path);
      //OpenImage(path);

      device = Devices.Desktop;
      url = "http://www.stephenwiltshire.co.uk/art_gallery.aspx?Id=144";
      List<int> picturesIdList = new List<int>
      {
        7424, 7396, 7331, 7299, 7235, 7232, 7219, 7218, 7217, 7207,
        7214, 7178, 7298, 7089, 7293, 6987, 6971, 6958, 6957, 6897,
        6908, 6960, 6876, 6959, 6812, 6801, 6747, 6668, 6823, 6613,
        6616, 6826, 6827, 6507, 6487, 6825, 6437, 6480, 6438, 6373,
        6439, 6308, 6358, 6311, 6357, 6287, 6280, 6269, 6253, 6252,
        6248, 6237, 6356, 6219, 6216, 6181, 6166
      };
      //for (int i = 144; i < 149; i++)
      //{
      //  url = "http://www.stephenwiltshire.co.uk/art_gallery.aspx?Id=" + i;
      //  path = string.Format(AddSlash(myImages) + "StephenWiltshire-{0}.jpeg", i);
      //  Screenshot.Save(url, path, ImageFormat.Jpeg, device);
      //}

      foreach (int pictureId in picturesIdList)
      {
        url = "http://www.stephenwiltshire.co.uk/art_gallery.aspx?Id=" + pictureId;
        path = string.Format(AddSlash(myImages) + "StephenWiltshire-{0}.jpeg", pictureId);
        Screenshot.Save(url, path, ImageFormat.Jpeg, device);
        Console.WriteLine(pictureId);
        OpenImage(path);
      }

      Console.WriteLine("Press any key to exit");
      Console.ReadKey();
    }

    private static void CreateDirectory(string myImages)
    {
      if (!Directory.Exists(myImages))
      {
        Directory.CreateDirectory(myImages);
      }
    }

    private static string AddSlash(string filePath)
    {
      return filePath.EndsWith("\\") ? filePath : filePath + "\\";
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