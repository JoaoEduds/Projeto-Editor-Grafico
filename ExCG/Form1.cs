using System.Drawing.Imaging;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace ExCG
{
    public partial class FrmPrincipal : Form
    {
        private Image image;
        private Bitmap imgBitmap;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e) { }

        private void btAbrirImg_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Arquivos de Imagem (*.jpg;*.gif;*.bmp;*.png)|*.jpg;*.gif;*.bmp;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void btLuminancia_Click(object sender, EventArgs e)
        {
            Bitmap imgDest = new Bitmap(image);
            imgBitmap = (Bitmap)image;
            Filtros.luminancia(imgBitmap, imgDest);
            pictureBox1.Image = imgDest;
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void checkbox_Mudanca(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                pictureBox1.MouseMove += exibir_valores;
            }
            else
            {
                pictureBox1.MouseMove -= exibir_valores;
                valorPixel.Text = ""; // limpa a exibição
                panelCor.Visible = false;
            }
        }

        private unsafe void exibir_valores(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap imgBitmap = (Bitmap)pictureBox1.Image;

                if (e.X >= 0 || e.Y >= 0 || e.X < imgBitmap.Width || e.Y < imgBitmap.Height)
                {
                    BitmapData bitmapDataSrc = imgBitmap.LockBits(
                    new Rectangle(0, 0, imgBitmap.Width, imgBitmap.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format24bppRgb);

                    try
                    {
                        byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                        int pixelSize = 3;

                        byte* srcLine = src + e.Y * bitmapDataSrc.Stride;
                        byte* srcPixel = srcLine + e.X * pixelSize;

                        int b = srcPixel[0];
                        int g = srcPixel[1];
                        int r = srcPixel[2];

                        panelCor.Visible = true;
                        panelCor.BackColor = Color.FromArgb(r, g, b);
                        panelCor.Location = new Point(e.X + 15, e.Y + 15);
                        valorPixel.Text = $"R:{r} G:{g} B:{b}";
                    }
                    finally
                    {
                        imgBitmap.UnlockBits(bitmapDataSrc);
                    }
                }
            }
        }

        private void panelCor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
