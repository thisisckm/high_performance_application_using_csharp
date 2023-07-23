using System.Drawing;
using System.Diagnostics;

/*
    Project Name: PixelPlus Pro
    
    Description: In version (chapter02.2), the program has been updated to support command-line arguments, enabling 
    users to specify whether to convert the image to monogram or invert it. The program now accepts two parameters: 
    the command and the input file path.

    Moreover, to embrace object-oriented principles, the static functions ConvertToMonogram and InvertImage have been 
    rewritten by implementing OOP concepts. A new interface named IImageProcess has been introduced, defining a method 
    called Convert that takes an image of type Bitmap as a parameter.

    To achieve greater modularity, two classes, InvertImageProcess and MonogramImageProcess, have been created to 
    implement the IImageProcess interface. These classes encapsulate the functionality of inverting images and 
    converting them to monograms, respectively. This design fosters code reusability and enhances the organization of 
    the program's image processing operations.
    
    Version: chapter02.2
    
    Author: Chandrakumar Murugesan
*/
class Program
{
    static void Main(string[] args)
    {

        Stopwatch stopwatch = Stopwatch.StartNew();

        // Create the output if not exists
        if (!Directory.Exists("output"))
        {
            // Create the folder
            Directory.CreateDirectory("output");
            Console.WriteLine("Output folder created successfully.");
        }

        List<string> commands = new List<string>
        {
            "monogram",
            "invert"
        };

        if (args.Length == 2 && commands.Contains(args[0]))
        {

            var command = args[0];
            var inputFilePath = args[1];

            try
            {
                // Load the color image from the file
                using (Bitmap originalImage = new Bitmap(inputFilePath))
                {
                    
                    PixelPlusPro.IImageProcess? imageProcess = null;
                    string? outputFilePath = null;
                    var outputFilename = Path.GetFileName(inputFilePath);

                    if (command.Equals("monogram")) // If command is monogram
                    {
                        imageProcess = new PixelPlusPro.MonogramImageProcess();
                        outputFilePath = $"output/monogran_{outputFilename}";
                    }
                    else if (command.Equals("invert")) // if command is invert
                    {
                        imageProcess = new PixelPlusPro.InvertImageProcess();
                        outputFilePath = $"output/invert_{outputFilename}";
                    }

                    // Convert the image
                    Bitmap outputImage = imageProcess!.Convert(originalImage);

                    // Save the image
                    outputImage.Save(outputFilePath!);

                    Console.WriteLine("Images converted and saved successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        else
        {
            // Show usage if unexcepted the arguments passed
            Console.WriteLine("Usage: dotnet run <command> <input file>");
            Console.WriteLine("<command> - monogram or invert");
            Console.WriteLine("<input file> - Path to the file");
        }

        stopwatch.Stop();

        // Get the elapsed time in milliseconds
        long elapsedTimeMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Execution time: {elapsedTimeMs} ms");
    }

}

namespace PixelPlusPro
{

    /*
        This interface defines a standardized contract for image processing classes, ensuring a consistent approach to 
        implementing image manipulation functionalities.
    */
    interface IImageProcess
    {
        Bitmap Convert(Bitmap image);
    }

    /* 
        Invert the image
    */
    class InvertImageProcess : IImageProcess
    {
        public Bitmap Convert(Bitmap image)
        {
            Bitmap invertedImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    if (pixelColor.A != 0) //Check the pixel is transparent
                    {
                        Color invertedColor = Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                        invertedImage.SetPixel(x, y, invertedColor);
                    }
                }
            }

            return invertedImage;
        }
    }

    /* 
        Convert a color image to monogram (grayscale)
    */
    class MonogramImageProcess : IImageProcess
    {
        public Bitmap Convert(Bitmap image)
        {
            Bitmap monochromeImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
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
    }

}