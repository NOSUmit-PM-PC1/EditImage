using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditImage
{
    public partial class FormEditImage : Form
    {
        //Graphics g;
        Bitmap myBitmap;
        public FormEditImage()
        {
            InitializeComponent();
            //g = this.CreateGraphics();
            myBitmap = new Bitmap("26.jpg");
            this.BackgroundImage = myBitmap;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            for (int x = 0; x < myBitmap.Size.Width; x++)
                for (int y = 0; y < myBitmap.Size.Height; y++)
                {
                    int colorR = myBitmap.GetPixel(x, y).R;
                    int colorG = myBitmap.GetPixel(x, y).G;
                    int colorB = myBitmap.GetPixel(x, y).B;
                    //43.92 % красного, 25.88 % зеленого и 7.84 %
                    int gray = (int)(colorR * 0.4392 + colorG * 0.2588 + colorB * 0.784);
                    //gray = Math.Min(255, gray);
                    Color newColor = Color.FromArgb(5, (int)(colorR * 0.4392), (int)(colorG * 0.2588), (int)(colorB * 0.784));
                    myBitmap.SetPixel(x, y, newColor);
                }
            pictureBox1.Size = myBitmap.Size;
            pictureBox1.Image = myBitmap;
            MessageBox.Show("Готово!");
        }

        private void FormEditImage_MouseDown(object sender, MouseEventArgs e)
        {
            Color pixelColor = myBitmap.GetPixel(e.X, e.Y);
            MessageBox.Show(pixelColor.ToString());
        }
    }
}
