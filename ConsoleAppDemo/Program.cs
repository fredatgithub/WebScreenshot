using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
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
        6248, 6237, 6356, 6219, 6216, 6181, 6166, 6167, 6165, 6162,
        6163, 6161, 6057, 6054, 6047, 5996, 6016, 5947, 5945, 5946,
        5935, 5903, 5901, 5902, 5852, 5803, 5748, 5655, 5660, 5620,
        5607, 5601, 5589, 5582, 5567, 5550, 5542, 5489, 5463, 6481,
        5279, 4223, 4221, 4220, 4094, 4075, 3999, 4001, 4000, 3974,
        3878, 3952, 1849, 3855, 4012, 5649, 3428, 3709, 3710, 3624,
        3594, 3595, 3556, 3475, 3484, 3367, 3342, 3329, 3228, 3482,
        3289, 3175, 3169, 3162, 3216, 3161, 3133, 3135, 3120, 3122,
        3110, 3114, 3025, 3041, 3081, 3032, 2976, 2971, 2956, 2937,
        2918, 2917, 2929, 2892, 3299, 3423, 2836, 2820, 3247, 2759,
        2749, 3409, 2869, 3291, 2603, 3245, 2219, 3290, 3031, 2424,
        2483, 2476, 2442, 2396, 2370, 2462, 2377, 2443, 2338, 2435,
        2324, 2434, 2315, 2463, 2431, 2432, 2275, 2437, 6473, 3036,
        2232, 2224, 2302, 2768, 2113, 2104, 2069, 2017, 2003, 1994,
        1996, 1887, 1890, 1873, 1853, 1872, 1871, 1856, 1850, 2166,
        1845, 1839, 1935, 1817, 1808, 1805, 1762, 1725, 1705, 1726,
        1704, 1684, 1681, 3754, 1706, 1677, 1744, 1625, 1727, 1619,
        1627, 1604, 1673, 1544, 1546, 1539, 2481, 1538, 1611, 1541,
        1523, 1522, 1545, 1504, 1496, 1484, 1466, 1648, 1452, 1426,
        1420, 1431, 1416, 1565, 1372, 1456, 1352, 1534, 1365, 1415,
        1511, 1373, 1414, 1635, 1636, 1336, 1337, 1319, 1318, 1312,
        1316, 1311, 1315, 1314, 1442, 1350, 1269, 1260, 1465, 1253,
        1533, 3248, 1567, 1238, 1266, 1218, 1225, 1215, 1202, 1647,
        1183, 1182, 1176, 1161, 1152, 1192, 3249, 1729, 1149, 1259,
        2355, 1140, 1133, 1191, 1141, 1098, 1099, 1668, 1132, 1093,
        1223, 1092, 1364, 1078, 1077, 1214, 1091, 1041, 1221, 1021,
        1023, 1060, 1036, 1046, 1203, 998, 1066, 991, 1359, 965,
        948, 949, 940, 935, 964, 1252, 996, 982, 971, 1012, 1052,
        976, 907, 899, 913, 832, 844, 1190, 850, 912, 112, 1067,
        1068, 113, 1196, 973, 1006, 99, 1061, 1464, 98, 104, 280,
        102, 100, 947, 111, 93, 94, 270, 81, 83, 91, 85, 86, 92, 90,
        82, 77, 78, 73, 74, 76, 84, 89, 75, 917, 69, 70, 1144, 1143,
        68, 67, 65, 66, 64, 62, 63, 2857, 143, 135, 121, 16, 26, 33,
        42, 18, 20, 4, 15, 5, 12, 128, 140, 60, 11, 54, 25, 46, 2354,
        27, 40, 118, 119, 120, 117, 2425, 918, 32, 133, 145, 13, 38,
        56, 23, 1028, 43, 30, 7, 9, 24, 52, 37, 36, 8, 31, 51, 61, 47,
        3571, 50, 53, 19, 10, 21, 1, 138, 45, 2, 123, 125, 4128, 39,
        35, 34, 49, 41, 28, 29, 57, 48, 22, 3, 6, 55, 17, 44, 58, 59,
        1333, 1332, 1331, 1330, 1193, 1329, 1327, 1326, 1328, 1334,
        1210, 1323, 129, 1313, 130, 142, 136, 1322, 1321, 14, 124,
        1513, 139, 1017, 1324, 126, 122, 72, 71, 141, 149, 4070, 4069,
        4068, 4067, 4066, 4065, 4064, 4063, 4062, 4061, 4060, 4059,
        4058, 4057, 4056, 4055, 4054, 4053, 4052, 4051, 4050, 4049,
        4048, 4047, 4046, 4045, 147, 148, 150, 144
      };
      var badUrl = new List<string>();
      foreach (int pictureId in picturesIdList)
      {
        url = "http://www.stephenwiltshire.co.uk/art_gallery.aspx?Id=" + pictureId;
        path = string.Format(AddSlash(myImages) + "StephenWiltshire-{0}.jpeg", pictureId);
        Thread.Sleep(1000 * new Random(DateTime.Now.Millisecond).Next(0, 3));
        try
        {
          Screenshot.Save(url, path, ImageFormat.Jpeg, device);
        }
        catch (Exception)
        {
          badUrl.Add(url);
          Console.WriteLine("bad url: " + pictureId);
        }

        Console.WriteLine(pictureId);
        //OpenImage(path);
      }

      if (badUrl.Count != 0)
      {
        var sw = new StreamWriter("badurl.txt");
        foreach (string item in badUrl)
        {
          sw.WriteLine(item);
        }

        sw.Close();
        Console.WriteLine("a badurl text file has been written to list all bad URL");
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