using Emgu.CV.CvEnum;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Chapter04Version2
{

    internal class FileUtil
    {

        public static string GetTempFilePath(string filePath)
        {

            string fileExtension = Path.GetExtension(filePath);
            string tempFilePath = Path.GetTempFileName();

            return string.Concat(tempFilePath, fileExtension);

        }
    }

    public class PixelProPlusBP
    {
        public static Bitmap ToGreyscale(Bitmap rawImage)
        {

            // Load the image
            Image<Bgr, byte> image = rawImage.ToImage<Bgr, byte>();

            // Convert the image to grayscale
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);
            Bitmap bitmapResult = grayImage.ToBitmap();

            // Dispose unused images
            image.Dispose();
            grayImage.Dispose();

            return bitmapResult;

        }

        public static Bitmap ToSketchImage(Bitmap rawImage)
        {
            //Open the image file
            Image<Bgr, byte> img = rawImage.ToImage<Bgr, byte>();

            // Convert the input image to grayscale
            Image<Gray, byte> imgGrayscale = img.Convert<Gray, byte>();

            // Invert the grayscale image
            Image<Gray, byte> invertedImg = new Image<Gray, byte>(imgGrayscale.Width, imgGrayscale.Height);
            CvInvoke.BitwiseNot(imgGrayscale, invertedImg);

            // Apply Gaussian blur
            Size blurSize = new Size(99, 99);
            CvInvoke.GaussianBlur(invertedImg, invertedImg, blurSize, 0);

            // Invert the blurred image
            CvInvoke.BitwiseNot(invertedImg, invertedImg);

            // Divide the original grayscale image by the inverted blurred image
            Image<Gray, byte> final = new Image<Gray, byte>(imgGrayscale.Size);
            CvInvoke.Divide(imgGrayscale, invertedImg, final, scale: 256.0);

            // Convert the result back to BGR
            Image<Bgr, byte> result = final.Convert<Bgr, byte>();            
            Bitmap bitmapResult = result.ToBitmap();

            //Dispose unused image
            img.Dispose();
            final.Dispose();
            result.Dispose();
            invertedImg.Dispose();
            imgGrayscale.Dispose();

            return bitmapResult;

        }

    }
}
