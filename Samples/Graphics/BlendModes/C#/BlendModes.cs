﻿using System.Diagnostics;
using System.Drawing;

namespace BitMiracle.Docotic.Pdf.Samples
{
    public static class BlendModes
    {
        public static void Main()
        {
            // NOTE: 
            // When used in trial mode, the library imposes some restrictions.
            // Please visit http://bitmiracle.com/pdf-library/trial-restrictions.aspx
            // for more information.

            string pathToFile = "BlendModes.pdf";

            using (PdfDocument pdf = new PdfDocument())
            {
                PdfCanvas canvas = pdf.Pages[0].Canvas;

                PointF location = new PointF(50, 80);
                SizeF size = new SizeF(50, 50);

                PdfBlendMode[] modes = new PdfBlendMode[] { PdfBlendMode.Hue, PdfBlendMode.Lighten, PdfBlendMode.Darken };
                for (int i = 0; i < modes.Length; ++i)
                {
                    if (i != 0)
                        location.X = location.X + size.Width * 2;

                    canvas.BlendMode = PdfBlendMode.Normal;

                    canvas.Brush.Color = new PdfRgbColor(0, 0, 0);
                    canvas.DrawString(location.X, location.Y - 20, "BlendMode: " + modes[i].ToString());

                    canvas.Brush.Color = new PdfRgbColor(200, 140, 7);
                    canvas.DrawRectangle(new RectangleF(location, size), 0, PdfDrawMode.Fill);

                    canvas.BlendMode = modes[i];
                    canvas.Brush.Color = new PdfRgbColor(125, 125, 255);
                    RectangleF secondRect = new RectangleF(location.X + 15, location.Y + 15, size.Width, size.Height);
                    canvas.DrawRectangle(secondRect, 0, PdfDrawMode.Fill);
                }

                pdf.Save(pathToFile);
            }

            Process.Start(pathToFile);
        }
    }
}