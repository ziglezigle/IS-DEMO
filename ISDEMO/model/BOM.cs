using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ISDEMO.model;

public class BOM
{
    private int length;
    private int scrap = 0;
    private List<Part> parts;

    public BOM(int length)
    {
        this.length = length;
        scrap = length - scrap;
        parts = new List<Part>();
    }

    public BOM(int length, List<Part> list)
    {
        this.length = length;
        parts = list;
        var totalPartLength = list.Sum(part => part.Length);
        scrap = length - totalPartLength;
    }
    public int Length
    {
        get => length;
        set => length = value;
    }
    
    public List<Part> Parts
    {
        get => parts;
        set => parts = value;
    }


    public int Scrap
    {
        get => scrap;
        set => scrap = value;
    }

    public void FillPart(Part part)
    {
        parts.Add(part);
        scrap = length - parts.Sum(part => part.Length);
    }

    public Bitmap GenerateBarChartImage()
    {
        int width = 480;
        int height = 27;
        // Create a new bitmap image with the specified width and height
        Bitmap image = new Bitmap(width, height);

        // Calculate the total length of parts
        int totalLength = length;

        // Draw black border for the bar chart
        using (Graphics g = Graphics.FromImage(image))
        {
            g.Clear(Color.Empty); // Clear the image with transparent color
            Pen pen = new Pen(Color.Black, 3); // Create a black pen with thickness 2
            g.DrawRectangle(pen, 0, 0, width - 1, height - 1); // Draw a black rectangle border
        }

        // Draw vertical lines and labels for each part
        using (Graphics g = Graphics.FromImage(image))
        {
            Pen pen = new Pen(Color.Black, 2); // Create a black pen with thickness 1

            int accumulatedLength = 0;
            int i = 1;
            int lineX = 0;

            foreach (var part in parts)
            {
                accumulatedLength += part.Length; // Update the accumulated length

                // Draw the label
                string label = i.ToString();
                using (Font font = new Font("Arial", 10))
                {
                    SizeF textSize = g.MeasureString(label, font);
                    float x = lineX - textSize.Width / 2 + 10;
                    float y = height / 2 - textSize.Height / 2;
                    g.DrawString(label, font, Brushes.Black, x, y);
                }
                
                // Calculate the x-coordinate for drawing the vertical line
                lineX = (int)Math.Round((double)accumulatedLength / totalLength * (width - 2));

                // Draw a vertical line at the calculated position
                g.DrawLine(pen, lineX, 0, lineX, height - 1);
                

                i++; // Increment the index for the next part
            }
        }

        return image; // Return the generated bitmap image
    }
}
