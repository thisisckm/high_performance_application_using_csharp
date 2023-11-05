namespace Chapter04Version2
{
    public partial class Main : Form
    {
        private Bitmap selectedImage;

        public Main()
        {
            InitializeComponent();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (selectedImage != null)
                    {
                        selectedImage.Dispose();
                        pictureBoxCanvas.Image.Dispose();
                    }
                    selectedImage = new Bitmap(dlg.FileName);
                    pictureBoxCanvas.Image = (Bitmap)selectedImage.Clone();
                    groupBoxToolbox.Enabled = true;
                }
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            string cmd = comboBoxConvert.Text;

            if ("Greyscale".Equals(cmd))
            {
                Bitmap forDispose = (Bitmap)pictureBoxCanvas.Image;
                pictureBoxCanvas.Image = PixelProPlusBP.ToGreyscale(selectedImage);
                forDispose.Dispose();
            }
            else if ("Pencil Sketch".Equals(cmd))
            {
                Bitmap forDispose = (Bitmap)pictureBoxCanvas.Image;
                pictureBoxCanvas.Image = PixelProPlusBP.ToSketchImage(selectedImage);
                forDispose.Dispose();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBoxConvert_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxConvert.SelectedItem != null)
            {
                buttonGo.Enabled = true;
            }
            else
            {
                buttonGo.Enabled = false;
            }
        }
    }
}