using Emgu.CV.CvEnum;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Chapter04Version1
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
        public static string ToGreyscale(string filename)
        {
            // Load the image
            Mat image = new Mat(filename, ImreadModes.Color);

            // Convert the image to grayscale
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);

            // Store the image content to temp file
            string tempFilePath = FileUtil.GetTempFilePath(filename);
            grayImage.Save(tempFilePath);
            return tempFilePath;

        }

        public static string ToSketchImage(string filename)
        {
            //Open the image file
            Image<Bgr, byte> img = new Image<Bgr, byte>(filename);

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

            // Store the image content to temp file
            string tempFilePath = FileUtil.GetTempFilePath(filename);
            result.Save(tempFilePath);
            return tempFilePath;
        }

    }
}
