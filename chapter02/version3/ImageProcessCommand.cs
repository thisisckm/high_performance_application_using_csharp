namespace PixelPlusPro.Command
{
    using System.Drawing;

    public class InvertImageCommand : ICommand
    {
        public Bitmap image;
        public Bitmap Image
        {
            get {return Image;}
            private set {this.image = value;}
        }

        public InvertImageCommand(Bitmap image)
        {
            this.image = image;
        }

        public void Execute()
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    Color invertedPixel = Color.FromArgb(pixel.A, 255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                    image.SetPixel(x, y, invertedPixel);
                }
            }
        }
    }

    public class ConvertToMonogramCommand : ICommand
    {
        private Bitmap image;
        public Bitmap Image
        {
            get {return Image;}
            private set {this.image = value;}
        }

        public ConvertToMonogramCommand(Bitmap image)
        {
            this.image = image;
        }

        public void Execute()
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int grayValue = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                    Color grayPixel = Color.FromArgb(pixel.A, grayValue, grayValue, grayValue);
                    image.SetPixel(x, y, grayPixel);
                }
            }
        }
    }

}