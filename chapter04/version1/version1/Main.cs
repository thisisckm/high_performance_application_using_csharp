using Chapter04Version1;

namespace Chapter04Version1
{
    public partial class Main : Form
    {
        private string selectedFile;
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
                    selectedFile = dlg.FileName;
                    pictureBoxCanvas.Image = new Bitmap(dlg.FileName);
                    groupBoxToolbox.Enabled = true;
                }
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            string cmd = comboBoxConvert.Text;

            if ("Greyscale".Equals(cmd))
            {
                pictureBoxCanvas.ImageLocation = PixelProPlusBP.ToGreyscale(selectedFile);
            }
            else if ("Pencil Sketch".Equals(cmd))
            {
                pictureBoxCanvas.ImageLocation = PixelProPlusBP.ToSketchImage(selectedFile);
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