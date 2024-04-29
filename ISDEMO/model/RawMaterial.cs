using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace New_IS_Heavy.Models
{
    public class RawMaterial
    {
        public int Length;
        public List<Part> parts_inside;

        public RawMaterial(int length)
        {
            this.Length = length;
            this.parts_inside = new List<Part>();
        }

        public void add_part(Part part)
        {
            if (part.Num > 0)
            {
                parts_inside.Add(part);
            }
            else
            {
                System.Console.WriteLine(
                    "=======================================No Parts Left to add to RawMaterial! =======================================");
            }
        }

        public int get_remaining_length()
        {
            int remaining_length = Length;
            if (parts_inside == null)
            {
                return remaining_length;
            }
            else
            {
                foreach (var part in parts_inside)
                {
                    remaining_length -= part.Length;
                }

                return remaining_length;
            }
        }

        public void remove_all_parts()
        {
            parts_inside.Clear();
        }

        public void remove_part(int length)
        {
            var partToRemove = parts_inside.FirstOrDefault(part => part.Length == length);

            if (partToRemove != null)
            {
                parts_inside.Remove(partToRemove);
            }
            else
            {
                System.Console.WriteLine("No part found with given length.");
            }
        }

        public List<Part> get_parts_inside()
        {
            return parts_inside;
        }

        public override string ToString()
        {
            string result = "Raw Length: " + Length + "\nParts inside the Raw Material:\n";

            foreach (var part in parts_inside)
            {
                result += "Part Length: " + part.Length + "\n";
            }

            result += "Remaining Length: " + get_remaining_length() + "\n";

            return result;
        }
        
        public Bitmap GenerateBarChartImage()
        {
            int width = 480;
            int height = 27;
            // Create a new bitmap image with the specified width and height
            Bitmap image = new Bitmap(width, height);

            // Calculate the total length of parts
            int totalLength = Length;

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

                foreach (var part in parts_inside)
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
}