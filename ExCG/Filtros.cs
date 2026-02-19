using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
