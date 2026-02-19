using System.Drawing.Imaging;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace ExCG
{
    public partial class FrmPrincipal : Form
    {
        private Image image;
        private Bitmap imgBitmap;
        private Bitmap imagemOriginal;  // Guarda a imagem original
        private int nivelBrilho = 0;    // Contador de brilho

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
                imagemOriginal = new Bitmap(image); // SALVA A ORIGINAL
                pictureBox1.Image = image;
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                nivelBrilho = 0; // Reseta o contador
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
                valorPixel.Text = "R: G: B:\nC: M: Y:\nH: S: I:";
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

                        int c = 255 - r;
                        int m = 255 - g;
                        int y = 255 - b;

                        int h, s, i;


                        panelCor.Visible = true;
                        panelCor.BackColor = Color.FromArgb(r, g, b);
                        panelCor.Location = new Point(e.X + 15, e.Y + 15);
                        valorPixel.Text = $"R:{r} G:{g} B:{b}\nC:{c} M:{m} Y:{y}";
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

        private void aumentar_Brilho(object sender, EventArgs e)
        {
            if (imagemOriginal == null)
            {
                MessageBox.Show("Carregue uma imagem primeiro!");
                return;
            }

            nivelBrilho += 20; // Aumenta o contador
            aplicarBrilho(); // Aplica o brilho acumulado
        }

        private void diminuir_Brilho(object sender, EventArgs e)
        {
            if (imagemOriginal == null)
            {
                MessageBox.Show("Carregue uma imagem primeiro!");
                return;
            }

            nivelBrilho -= 20; // Diminui o contador
            aplicarBrilho(); // Aplica o brilho acumulado
        }

        private void aplicarBrilho()
        {
            // Sempre começa da imagem ORIGINAL
            Bitmap imgTemp = new Bitmap(imagemOriginal);
            Bitmap imgResultado = imgTemp;

            // Aplica aumentar ou diminuir múltiplas vezes
            int vezes = Math.Abs(nivelBrilho) / 20;

            for (int i = 0; i < vezes; i++)
            {
                Bitmap imgDest = new Bitmap(imgResultado.Width, imgResultado.Height);

                if (nivelBrilho > 0)
                {
                    Filtros.aumentar(imgResultado, imgDest); // Usa a função aumentar
                }
                else
                {
                    Filtros.diminuir(imgResultado, imgDest); // Usa a função diminuir
                }

                if (imgResultado != imgTemp)
                {
                    imgResultado.Dispose();
                }
                imgResultado = imgDest;
            }

            // Se o brilho é zero, usa a original
            if (nivelBrilho == 0)
            {
                imgResultado = new Bitmap(imagemOriginal);
            }

            // Atualiza o PictureBox
            pictureBox1.Image = imgResultado;

            // Opcional: mostra o nível no título
            this.Text = $"Editor - Brilho: {nivelBrilho}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (imagemOriginal == null) return;

            Bitmap rImg = new Bitmap(imagemOriginal.Width, imagemOriginal.Height);
            Bitmap gImg = new Bitmap(imagemOriginal.Width, imagemOriginal.Height);
            Bitmap bImg = new Bitmap(imagemOriginal.Width, imagemOriginal.Height);

            Filtros.canalRGB(imagemOriginal, rImg, 'R');
            Filtros.canalRGB(imagemOriginal, gImg, 'G');
            Filtros.canalRGB(imagemOriginal, bImg, 'B');

            pictureBoxR.Image = rImg;
            pictureBoxG.Image = gImg;
            pictureBoxB.Image = bImg;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (imagemOriginal == null) return;

            Bitmap hImg = new Bitmap(imagemOriginal.Width, imagemOriginal.Height);
            Bitmap sImg = new Bitmap(imagemOriginal.Width, imagemOriginal.Height);
            Bitmap iImg = new Bitmap(imagemOriginal.Width, imagemOriginal.Height);

            Filtros.canalHSI(imagemOriginal, hImg, 'H');
            Filtros.canalHSI(imagemOriginal, sImg, 'S');
            Filtros.canalHSI(imagemOriginal, iImg, 'I');

            pictureBoxH.Image = hImg;
            pictureBoxS.Image = sImg;
            pictureBoxI.Image = iImg;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}