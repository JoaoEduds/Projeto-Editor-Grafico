using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExCG
{
    internal class Filtros
    {

        public static void luminancia(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;
            Int32 gs;

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src++); //está armazenado dessa forma: b g r 
                        g = *(src++);
                        r = *(src++);
                        gs = (Int32)(r * 0.2990 + g * 0.5870 + b * 0.1140);
                        *(dst++) = (byte)gs;
                        *(dst++) = (byte)gs;
                        *(dst++) = (byte)gs;
                    }
                    src += padding;
                    dst += padding;
                }
            }
            //unlock imagem origem
            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            //unlock imagem destino
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }
        public static void aumentar(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;
            int valorBrilho = 20; // Aumenta 20 de brilho

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);

                        // Aumenta o brilho e limita entre 0 e 255
                        r = Math.Min(255, r + valorBrilho);
                        g = Math.Min(255, g + valorBrilho);
                        b = Math.Min(255, b + valorBrilho);

                        *(dst++) = (byte)b;
                        *(dst++) = (byte)g;
                        *(dst++) = (byte)r;
                    }
                    src += padding;
                    dst += padding;
                }
            }

            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }
        public static void diminuir(Bitmap imageBitmapSrc, Bitmap imageBitmapDest)
        {
            int width = imageBitmapSrc.Width;
            int height = imageBitmapSrc.Height;
            int pixelSize = 3;
            int valorBrilho = 20; // Diminui 20 de brilho

            //lock dados bitmap origem
            BitmapData bitmapDataSrc = imageBitmapSrc.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //lock dados bitmap destino
            BitmapData bitmapDataDst = imageBitmapDest.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bitmapDataSrc.Stride - (width * pixelSize);

            unsafe
            {
                byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
                byte* dst = (byte*)bitmapDataDst.Scan0.ToPointer();

                int r, g, b;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        b = *(src++);
                        g = *(src++);
                        r = *(src++);

                        // Diminui o brilho e limita entre 0 e 255
                        r = Math.Max(0, r - valorBrilho);
                        g = Math.Max(0, g - valorBrilho);
                        b = Math.Max(0, b - valorBrilho);

                        *(dst++) = (byte)b;
                        *(dst++) = (byte)g;
                        *(dst++) = (byte)r;
                    }
                    src += padding;
                    dst += padding;
                }
            }

            imageBitmapSrc.UnlockBits(bitmapDataSrc);
            imageBitmapDest.UnlockBits(bitmapDataDst);
        }
        public static void canalRGB(Bitmap src, Bitmap dst, char canal)
        {
            int width = src.Width;
            int height = src.Height;
            int pixelSize = 3;

            BitmapData srcData = src.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            BitmapData dstData = dst.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            int padding = srcData.Stride - (width * pixelSize);

            unsafe
            {
                byte* srcPtr = (byte*)srcData.Scan0;
                byte* dstPtr = (byte*)dstData.Scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte b = *(srcPtr++);
                        byte g = *(srcPtr++);
                        byte r = *(srcPtr++);

                        byte valor = 0;

                        if (canal == 'R') valor = r;
                        if (canal == 'G') valor = g;
                        if (canal == 'B') valor = b;

                        *(dstPtr++) = valor;
                        *(dstPtr++) = valor;
                        *(dstPtr++) = valor;
                    }
                    srcPtr += padding;
                    dstPtr += padding;
                }
            }
            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);
        }
        public static void canalHSI(Bitmap src, Bitmap dst, char canal)
        {
            int width = src.Width;
            int height = src.Height;
            int pixelSize = 3;

            BitmapData srcData = src.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            BitmapData dstData = dst.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            int padding = srcData.Stride - (width * pixelSize);

            unsafe
            {
                byte* srcPtr = (byte*)srcData.Scan0;
                byte* dstPtr = (byte*)dstData.Scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Leitura dos canais RGB normalizados (0–1)
                        double b = *(srcPtr++) / 255.0;
                        double g = *(srcPtr++) / 255.0;
                        double r = *(srcPtr++) / 255.0;

                        // Intensidade
                        double I = (r + g + b) / 3.0;

                        // Saturação
                        double min = Math.Min(r, Math.Min(g, b));
                        double S;

                        if (I == 0)
                        {
                            S = 0;
                        }
                        else
                        {
                            S = 1 - (min / I);
                        }

                        // Matiz (Hue)
                        double num = 0.5 * ((r - g) + (r - b));
                        double den = Math.Sqrt((r - g) * (r - g) + (r - b) * (g - b));

                        double theta;
                        if (den == 0)
                        {
                            theta = 0;
                        }
                        else
                        {
                            theta = Math.Acos(num / den);
                        }

                        double H;
                        if (b > g)
                        {
                            H = 2 * Math.PI - theta;
                        }
                        else
                        {
                            H = theta;
                        }

                        // Normaliza H para intervalo 0–1
                        H = H / (2 * Math.PI);

                        // Escolhe qual canal será exibido em tons de cinza
                        double valor = 0;

                        if (canal == 'H')
                        {
                            valor = H;
                        }
                        else if (canal == 'S')
                        {
                            valor = S;
                        }
                        else if (canal == 'I')
                        {
                            valor = I;
                        }

                        // Converte para escala de cinza (0–255)
                        byte cinza = (byte)(valor * 255);

                        *(dstPtr++) = cinza;
                        *(dstPtr++) = cinza;
                        *(dstPtr++) = cinza;
                    }

                    srcPtr += padding;
                    dstPtr += padding;
                }
            }
            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);
        }

        public static void RGB_HSI(int r, int g, int b,out double h, out double s,out double i)
        {
            h = s = i = 0;
            int sum = r + g + b;
            if (sum != 0)
            {
                double R = (double)r / sum;
                double G = (double)g / sum;
                double B = (double)b / sum;

                double num = 0.5 * ((R - G) + (R - B));
                double den = Math.Sqrt(Math.Pow(R - G, 2) + (R - B) * (G - B));

                if (den != 0)
                {
                    h = Math.Acos(num / den);
                    if (B > G)
                    {
                        h = 2 * Math.PI - h;
                    }
                    h = h * 180 / Math.PI;
                }
                else
                {
                    h = 1;
                }

                double min = Math.Min(R, Math.Min(G, B));
                s = (1 - 3 * min) * 100;

                i = (r + g + b) / 3;
            }
        }

        public static void HSI_RGB(out int r, out int g, out int b, double h, double s, double i)
        {
            h = h * Math.PI / 180;
            s = s / 100;
            i = i / 255; 

            double x = i * (1 - s);

            double y, z, R, G, B;

            double calc = 2 * Math.PI / 3;
            double calc2 = 4 * Math.PI / 3;
            if (h < calc)
            {
                double divisor = Math.Cos(Math.PI / 3 - h);
                if (Math.Abs(divisor) < 0.0001)
                    divisor = 0.0001;
                y = i * (1 + (s * Math.Cos(h)) / divisor);
                z = 3 * i - (x + y);
                R = y;
                G = z;
                B = x;
            }
            else if(h < calc2)
            {
                h = h - calc;
                double divisor = Math.Cos(Math.PI / 3 - h);
                if (Math.Abs(divisor) < 0.0001)
                    divisor = 0.0001;
                y = i * (1 + (s * Math.Cos(h)) / divisor);
                z = 3 * i - (x + y);
                R = x;
                G = y;
                B = z;
            }
            else{
                h = h - calc2;
                double divisor = Math.Cos(Math.PI / 3 - h);
                if (Math.Abs(divisor) < 0.0001)
                    divisor = 0.0001;
                y = i * (1 + (s * Math.Cos(h)) / divisor);
                z = 3 * i - (x + y);
                R = z;
                G = x;
                B = y;
            }

            R = Math.Max(0, Math.Min(1, R));
            G = Math.Max(0, Math.Min(1, G));
            B = Math.Max(0, Math.Min(1, B));

            r = (int)(R * 255);
            g = (int)(G * 255);
            b = (int)(B * 255);
        }

        public static void matiz_Hue(Bitmap imgBitmapSrc, Bitmap imgBitmapDst, int V)
        {
            int width = imgBitmapSrc.Width;
            int height = imgBitmapSrc.Height;
            int pixelSize = 3;

            BitmapData srcData = imgBitmapSrc.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            BitmapData dstData = imgBitmapDst.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            int padding = srcData.Stride - (width * pixelSize);

            unsafe
            {
                byte* srcPtr = (byte*)srcData.Scan0;
                byte* dstPtr = (byte*)dstData.Scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int b = *(srcPtr++);
                        int g = *(srcPtr++);
                        int r = *(srcPtr++);

                        double h, s, i;
                        RGB_HSI(r, g, b, out h, out s, out i);
                        h = (h + V) % 360;
                        if (h < 0) h += 360;
                        HSI_RGB(out r, out g, out b, h, s, i);

                        *(dstPtr++) = (byte)b;
                        *(dstPtr++) = (byte)g;
                        *(dstPtr++) = (byte)r;
                    }
                    srcPtr += padding;
                    dstPtr += padding;
                }
            }
            imgBitmapSrc.UnlockBits(srcData);
            imgBitmapDst.UnlockBits(dstData);
        }

        public static void segmentarHue(Bitmap imgBitmapSrc, Bitmap imgBitmapDst, int min, int max)
        {
            int width = imgBitmapSrc.Width;
            int height = imgBitmapSrc.Height;
            int pixelSize = 3;

            BitmapData srcData = imgBitmapSrc.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            BitmapData dstData = imgBitmapDst.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            int padding = srcData.Stride - (width * pixelSize);

            unsafe
            {
                byte* srcPtr = (byte*)srcData.Scan0;
                byte* dstPtr = (byte*)dstData.Scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int b = *(srcPtr++);
                        int g = *(srcPtr++);
                        int r = *(srcPtr++);

                        double h, s, i;
                        RGB_HSI(r, g, b, out h, out s, out i);

                        bool inter; 

                        if (min <= max)
                        {
                            inter = (h >= min && h <= max);
                        }
                        else
                        {
                            inter = (h >= min || h <= max);
                        }

                        if (inter)
                        {
                            *(dstPtr++) = (byte)b;
                            *(dstPtr++) = (byte)g;
                            *(dstPtr++) = (byte)r;
                        }
                        else
                        {
                            Int32 gs = (Int32)(r * 0.2990 + g * 0.5870 + b * 0.1140);
                            *(dstPtr++) = (byte)gs;
                            *(dstPtr++) = (byte)gs;
                            *(dstPtr++) = (byte)gs;
                        }
                    }
                    srcPtr += padding;
                    dstPtr += padding;
                }
            }
            imgBitmapSrc.UnlockBits(srcData);
            imgBitmapDst.UnlockBits(dstData);
        }
    }
}
