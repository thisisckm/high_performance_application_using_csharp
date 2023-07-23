namespace PixelPlusPro.Command
{
    using System.Drawing;

    public class SaveImageCommand : ISaveCommand
    {
        private Bitmap image;
        private string filePath;

        public SaveImageCommand(Bitmap image, string filePath)
        {
            this.image = image;
            this.filePath = filePath;
        }

        public void Execute()
        {
            Save(filePath);
        }

        public void Save(string filePath)
        {
            image.Save(filePath);
        }
    }

}