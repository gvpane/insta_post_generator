using System;
using System.Collections.Generic;
using SkiaSharp;
using System.IO;
using System.Linq;
using System.Text;

public class ImageGenerator
{
    public static void Main(string[] args)
    {
        // Customizable parameters
        string inputFilePath = "input.txt"; 
        SKColor backgroundColor = SKColors.Black; 
        string outputFolderPath = $"Images_{DateTime.Now:yyyyMMdd_HHmmss}"; 
        int imageWidth = 1080; // Instagram recommended width
        int imageHeight = 1080; // Instagram recommended height

        // Create output directory
        Directory.CreateDirectory(outputFolderPath);

        // Read text file
        string[] lines = File.ReadAllLines(inputFilePath, Encoding.UTF8);

        // List of fonts to use
        string[] fonts = { "Segoe UI Emoji", "Arial", "Times New Roman", "Verdana", "Courier New" };

        int imageCounter = 1; // Initialize image counter

        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line)) // Skip empty lines
            {
                foreach (string fontName in fonts)
                {
                    using (SKBitmap bmp = new SKBitmap(imageWidth, imageHeight))
                    {
                        using (SKCanvas canvas = new SKCanvas(bmp))
                        {
                            canvas.Clear(backgroundColor);

                            // Set the font
                            SKTypeface typeface = SKTypeface.FromFamilyName(fontName, SKFontStyle.Bold);
                            SKFont font = new SKFont(typeface, 60);
                            SKPaint paint = new SKPaint
                            {
                                IsAntialias = true,
                                Color = SKColors.White
                            };

                            // Calculate text position for centering and justifying
                            string[] words = line.Split(' ');
                            float totalWidth = 0;
                            foreach (string word in words)
                            {
                                totalWidth += font.MeasureText(word);
                            }
                            float spaceWidth = (imageWidth - totalWidth) / (words.Length - 1);
                            float x = 0;
                            float y = (imageHeight - font.Size) / 2;

                            foreach (string word in words)
                            {
                                canvas.DrawText(word, x, y, font, paint);
                                x += font.MeasureText(word) + spaceWidth;
                            }

                            // Save image with a simple number as the filename
                            using (var image = SKImage.FromBitmap(bmp))
                            using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                            {
                                string filename = $"{outputFolderPath}/image_{imageCounter}_{fontName.Replace(" ", "_")}.png";
                                using (var stream = File.OpenWrite(filename))
                                {
                                    data.SaveTo(stream);
                                }
                            }

                        }
                    }
                            imageCounter++; // Increment image counter
                }
            }
        }
        Console.WriteLine("Image generation complete!");
    }
}