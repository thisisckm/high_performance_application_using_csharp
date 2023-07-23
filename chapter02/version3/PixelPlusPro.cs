using CommandLine;
using CommandLine.Text;
using System.Drawing;
using System.Diagnostics;
using PixelPlusPro.Command;

/*
    Project Name: PixelPlus Pro
    
    Description: In version (chapter02.3), significant enhancements have been made to the command-line argument 
    function by adopting the CommandLineParser library. This choice empowers the application with reduced code 
    complexity and enhanced functionality. The program now efficiently accepts two parameters: the command and the 
    input file path, thanks to the capabilities of CommandLineParser.

    Moreover, the image processing functionality, previously built on the IImageProcess concept, has been restructured 
    using the Command pattern. This design decision introduces improved control and scalability to the application's 
    image processing operations. The Command pattern facilitates the encapsulation of requests as objects, allowing for 
    more flexibility and easier management of image processing actions.

    Overall, these upgrades in version (chapter02.3) lead to an even more efficient and maintainable PixelPlus PRO 
    application, offering improved command-line handling and a scalable architecture for image processing operations.

    Version: chapter02.3

    Author: Chandrakumar Murugesan
*/
class Program
{
    public class Options
    {
        [Value(0, Required = true, MetaName = "command", MetaValue = "monogram|invert", HelpText = "The command to be executed.")]
        public string Command { get; set; }

        [Value(1, Required = true, MetaName = "file", HelpText = "The file to be processed.")]
        public string File { get; set; }
    }

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

        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(RunOptions)
            .WithNotParsed(errors =>
            {
                HelpText helpText = HelpText.AutoBuild(Parser.Default.ParseArguments<Options>(args));
                Console.WriteLine(helpText);
            });

        stopwatch.Stop();

        // Get the elapsed time in milliseconds
        long elapsedTimeMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"Execution time: {elapsedTimeMs} ms");
    }

    static void RunOptions(Options options)
    {
        string command = options.Command.ToLower(); // Convert command to lowercase for case-insensitivity
        string inputFilePath = options.File;
        try
        {
            // Load the color image from the file
            using (Bitmap originalImage = new Bitmap(inputFilePath))
            {

                string? outputFilePath = null;
                var outputFilename = Path.GetFileName(inputFilePath);
                CommandInvoker invoker = new CommandInvoker();

                if (command.Equals("monogram")) 
                {
                    invoker.AddCommand(new ConvertToMonogramCommand(originalImage));
                    outputFilePath = $"output/monogran_{outputFilename}";
                    invoker.AddCommand(new SaveImageCommand(originalImage, outputFilePath));
                }
                else if (command.Equals("invert")) 
                {
                    invoker.AddCommand(new InvertImageCommand(originalImage));
                    outputFilePath = $"output/invert_{outputFilename}";
                    invoker.AddCommand(new SaveImageCommand(originalImage, outputFilePath));
                }
                else
                {
                    // Handle invalid command
                    throw new InvalidCommandException($"'{options.Command}'. Valid options are 'monogram' or 'invert'.");
                    
                }

                invoker.ExecuteCommands();
                Console.WriteLine("Images converted and saved successfully.");
            }
        }
        catch(InvalidCommandException ex) 
        {
            Console.WriteLine("Invalid command: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
