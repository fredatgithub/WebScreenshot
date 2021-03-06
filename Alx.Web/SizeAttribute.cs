﻿using System;
using System.Drawing;
namespace Alx.Web
{
  public class SizeAttribute : Attribute
  {
    public int Width { get; set; }
    public int Height { get; set; }

    //public Size Size => new Size(Width, Height); // Framework 4.6
    public Size Size { get; set; }

    public SizeAttribute(int width, int height)
    {
      Width = width;
      Height = height;
      Size = new Size(Width, Height);
    }
  }
}