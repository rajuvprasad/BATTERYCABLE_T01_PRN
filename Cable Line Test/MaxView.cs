using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cable_Line_Test
{
    public partial class MaxView : Form
    {
        public MaxView()
        {
            InitializeComponent();
        }

        public void setImage(Image img)
        {
            pictureBox_MaxView.Image = img;
            var imageSize = pictureBox_MaxView.Image.Size;
            var fitSize = pictureBox_MaxView.ClientSize;
            pictureBox_MaxView.SizeMode = imageSize.Width > fitSize.Width || imageSize.Height > fitSize.Height ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
        }
    }
}
