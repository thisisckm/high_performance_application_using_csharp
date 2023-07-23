using System.Drawing;
using System.Diagnostics;

/*
    Project Name: PixelPlus Pro
    
    Description: The initial release of PixelPlus PRO combines the functionalities of converting images to 
    monograms and inverting them. This version currently has hardcoded input and output paths in the source code, 
    although it is acknowledged that this practice is not recommended.
    
    Version: chapter02.1
    Author: Chandrakumar Murugesan
*/
class PixelPlusPro
{
    static void Main(string[] args)
    {
        // Start the stopwatch
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Replace "inputImagePath" with the path to your color image
        // Don't forgot to try with a image which have transparency background
        string inputImagePath = "input/color_image.jpeg";

        // Create the output if not exists
        if (!Directory.Exists("output"))
        {
            // Create the folder
            Directory.CreateDirectory("output");
            Console.WriteLine("Output folder created successfully.");
        }
        // Replace "outputMonogramPath" with the path where you want to save the monochrome image
        string outputMonogramPath = "output/output_monogram.jpg";

        // Replace "outputInvertedPath" with the path where you want to save the inverted image
        string outputInvertedPath = "output/output_inverted.jpg";

        try
        {
            // Load the color image from the file
            using (Bitmap originalImage = new Bitmap(inputImagePath))
            {
                // Convert the color image to monochrome
                Bitmap monochromeImage = ConvertToMonochrome(originalImage);

                // Save the monochrome image
                monochromeImage.Save(outputMonogramPath);

                // Invert the monochrome image
                Bitmap invertedImage = InvertImage(monochromeImage);

                // Save the inverted image
                invertedImage.Save(outputInvertedPath);

                Console.WriteLine("Images converted and saved successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        // Stop the stopwatch
        stopwatch.Stop();

        // Get the elapsed time in milliseconds
        long elapsedTimeMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Execution time: {elapsedTimeMs} ms");
    }

    // Convert a color image to monochrome (grayscale)
    static Bitmap ConvertToMonochrome(Bitmap originalImage)
    {
        Bitmap monochromeImage = new Bitmap(originalImage.Width, originalImage.Height);

        for (int x = 0; x < originalImage.Width; x++)
        {
            for (int y = 0; y < originalImage.Height; y++)
            {
                Color pixelColor = originalImage.GetPixel(x, y);
                if (pixelColor.A != 0)
                {
                    int averageColor = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    Color newColor = Color.FromArgb(averageColor, averageColor, averageColor);
                    monochromeImage.SetPixel(x, y, newColor);
                }
            }
        }

        return monochromeImage;
    }

    // Invert the colors of a monochrome image
    static Bitmap InvertImage(Bitmap monochromeImage)
    {
        Bitmap invertedImage = new Bitmap(monochromeImage.Width, monochromeImage.Height);

        for (int x = 0; x < monochromeImage.Width; x++)
        {
            for (int y = 0; y < monochromeImage.Height; y++)
            {
                Color pixelColor = monochromeImage.GetPixel(x, y);
                if (pixelColor.A != 0) 
                {
                    Color invertedColor = Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                    invertedImage.SetPixel(x, y, invertedColor);
                }
            }
        }

        return invertedImage;
    }
}
