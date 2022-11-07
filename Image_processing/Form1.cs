using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;
using Syncfusion.XlsIO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Image_processing
{
    public partial class Form1 : Form
    {
        Bitmap image, prevImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp; | All Files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG Image|*.png|JPeg Image|*.jpg|Bmp Image|*.bmp";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveDialog.OpenFile();
                switch (saveDialog.FilterIndex)
                {
                    case 1:
                        image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case 2:
                        image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 3:
                        image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                }
            }
        }
        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Обработка изображения...";
            prevImage = image;
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color sourceColor = image.GetPixel(i, j);
                    int Intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
                    Color resultColor = Color.FromArgb(Intensity, Intensity, Intensity);
                    resultImage.SetPixel(i, j, resultColor);
                }
            }
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            image = resultImage;
            label1.Text = "Обработка завершена";
        }

        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Обработка изображения...";
            prevImage = image;
            Bitmap resultImage = new Bitmap(image.Width, image.Height);
            int radiusX = 1;
            int radiusY = 1;

            int red = 0, green = 0, blue = 0;

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    for (int l = -radiusY; l <= radiusY; l++)
                    {
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = Clamp(i + k, 0, image.Width - 1);
                            int idY = Clamp(j + l, 0, image.Height - 1);
                            red += image.GetPixel(idX, idY).R;
                            green += image.GetPixel(idX, idY).G;
                            blue += image.GetPixel(idX, idY).B;
                        }
                    }
                    Color resultColor = Color.FromArgb(Clamp(red / 9, 0, 255), Clamp(green / 9, 0, 255), Clamp(blue / 9, 0, 255));
                    red = green = blue = 0;
                    resultImage.SetPixel(i, j, resultColor);
                }
            }
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            image = resultImage;
            label1.Text = "Обработка завершена";
        }

        private int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        private void autocontrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Обработка изображения...";
            prevImage = image;
            Bitmap resultImage = new Bitmap(image.Width, image.Height);
            double R2, G2, B2, R3, G3, B3;
            R2 = maxR(image);
            G2 = maxG(image);
            B2 = maxB(image);
            R3 = minR(image);
            G3 = minG(image);
            B3 = minB(image);
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color sourceColor = image.GetPixel(i, j);
                    int R1 = sourceColor.R;
                    int G1 = sourceColor.G;
                    int B1 = sourceColor.B;

                    int newR = (int)((R1 - R3) * 255 / (R2 - R3));
                    int newG = (int)((G1 - G3) * 255 / (G2 - G3));
                    int newB = (int)((B1 - B3) * 255 / (B2 - B3));


                    Color resultColor = Color.FromArgb(Clamp(newR, 0, 255), Clamp(newG, 0, 255), Clamp(newB, 0, 255));
                    resultImage.SetPixel(i, j, resultColor);
                }
            }
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            image = resultImage;
            label1.Text = "Обработка завершена";
        }

        public static double maxR(Bitmap image)
        {
            double R = -1;
            Color imageColor;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    imageColor = image.GetPixel(i, j);
                    if (R < imageColor.R)
                        R = imageColor.R;
                }
            }
            return R;
        }
        public static double maxG(Bitmap image)
        {
            double G = -1;
            Color imageColor;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    imageColor = image.GetPixel(i, j);
                    if (G < imageColor.G)
                        G = imageColor.G;
                }
            }
            return G;
        }
        public static double maxB(Bitmap image)
        {
            double B = -1;
            Color imageColor;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    imageColor = image.GetPixel(i, j);
                    if (B < imageColor.B)
                        B = imageColor.B;
                }
            }
            return B;
        }

        public static double minR(Bitmap image)
        {
            double R = 256;
            Color imageColor;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    imageColor = image.GetPixel(i, j);
                    if (R > imageColor.R)
                        R = imageColor.R;
                }
            }
            return R;
        }
        public static double minG(Bitmap image)
        {
            double G = 256;
            Color imageColor;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    imageColor = image.GetPixel(i, j);
                    if (G > imageColor.G)
                        G = imageColor.G;
                }
            }
            return G;
        }
        public static double minB(Bitmap image)
        {
            double B = 256;
            Color imageColor;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    imageColor = image.GetPixel(i, j);
                    if (B > imageColor.B)
                        B = imageColor.B;
                }
            }
            return B;
        }

        private void точечнаяБинаризацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Обработка изображения...";
            prevImage = image;
            Bitmap resultImage = new Bitmap(image.Width, image.Height);
            int threshold = 128;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color sourceColor = image.GetPixel(i, j);
                    int result;
                    if (sourceColor.R < threshold)
                    {
                        result = 0;
                    }
                    else
                    {
                        result = 255;
                    }
                    Color resultColor = Color.FromArgb(result, result, result);
                    resultImage.SetPixel(i, j, resultColor);
                }
            }
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            image = resultImage;
            label1.Text = "Обработка завершена";
        }

        private void бинаризацияНиблэкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Обработка изображения...";
            prevImage = image;
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            int w_size = 3;

            int radiusX = w_size / 2;
            int radiusY = w_size / 2;

            double res2 = 0;
            double sum = 0;

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    double resColor1 = 0;
                    for (int l = -radiusY; l <= radiusY; l++)
                    {
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = Clamp(i + k, 0, image.Width - 1);
                            int idY = Clamp(j + l, 0, image.Height - 1);

                            resColor1 += image.GetPixel(idX, idY).R;
                        }
                    }
                    double res = resColor1 / (w_size * w_size);

                    for (int l = -radiusY; l <= radiusY; l++)
                    {
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = Clamp(i + k, 0, image.Width - 1);
                            int idY = Clamp(j + l, 0, image.Height - 1);

                            sum += (image.GetPixel(idX, idY).R - res) * (image.GetPixel(idX, idY).R - res);

                        }
                    }
                    res2 = Math.Sqrt(sum / (w_size * w_size));

                    int T = (int)(res + (-0.2) * res2);
                    sum = 0;
                    Color sourceColor = image.GetPixel(i, j);
                    int result;
                    if (sourceColor.R < T)
                    {
                        result = 0;
                    }
                    else
                    {
                        result = 255;
                    }
                    Color resultColor = Color.FromArgb(result, result, result);
                    resultImage.SetPixel(i, j, resultColor);
                }
            }
            image = resultImage;
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            label1.Text = "Обработка завершена";

        }

        private void бинаризацияПоГистограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Обработка изображения...";
            prevImage = image;
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            int[] hist = calculateHistogram(image);
            int pixelSum = image.Width * image.Height;

            float fivePercentCut = pixelSum * 0.05f;

            for (int i = 0; i < 255; i++)
            {
                if (hist[i] < fivePercentCut)
                {
                    fivePercentCut -= hist[i];
                    hist[i] = 0;
                }
                else
                {
                    hist[i] -= (int)fivePercentCut;
                }
                if (fivePercentCut == 0) break;
            }

            fivePercentCut = pixelSum * 0.05f;

            for (int i = 255; i > 0; i--)
            {
                if (hist[i] < fivePercentCut)
                {
                    fivePercentCut -= hist[i];
                    hist[i] = 0;
                }
                else
                {
                    hist[i] -= (int)fivePercentCut;
                }
                if (fivePercentCut == 0) break;
            }


            int threshold = 0;
            for (int i = 0; i < 255; i++)
            {
                threshold += hist[i] * i;
            }

            threshold = (int)(threshold / hist.Sum());

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color sourceColor = image.GetPixel(i, j);
                    int result;
                    if (sourceColor.R < threshold)
                    {
                        result = 0;
                    }
                    else
                    {
                        result = 255;
                    }
                    Color resultColor = Color.FromArgb(result, result, result);
                    resultImage.SetPixel(i, j, resultColor);
                }
            }

            image = resultImage;
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            label1.Text = "Обработка завершена";
        }

        private int[] calculateHistogram(Bitmap image)
        {
            int[] hist = new int[256];

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    hist[image.GetPixel(i, j).R]++;
                }
            }

            return hist;
        }

        private void гауссовШумToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Обработка изображения...";
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            int size = image.Height * image.Width;
            byte[] noise = new byte[size];
            double[] gaussian = new double[256];
            int sigma = 20;
            int z = 0;
            Random rnd = new Random();
            double sum = 0;
            for (int i = 0; i < 256; i++)
            {
                gaussian[i] = (double)((1 / (Math.Sqrt(2 * Math.PI) * sigma)) * Math.Exp(z - Math.Pow(i, 2) / (2 * Math.Pow(sigma, 2))));
                sum += gaussian[i];
            }

            for (int i = 0; i < 256; i++)
            {
                gaussian[i] /= sum;
                gaussian[i] *= size;
                gaussian[i] = (int)Math.Floor(gaussian[i]);
            }

            int count = 0;
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < (int)gaussian[i]; j++)
                {
                    noise[j + count] = (byte)i;
                }
                count += (int)gaussian[i];
            }

            for (int i = 0; i < size - count; i++)
            {
                noise[count + i] = 0;
            }

            noise = noise.OrderBy(x => rnd.Next()).ToArray();


            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    Color color = image.GetPixel(j, i);

                    resultImage.SetPixel(j, i, Color.FromArgb(Clamp(color.R + noise[image.Width * i + j], 0, 255),
                        Clamp(color.G + noise[image.Width * i + j], 0, 255),
                        Clamp(color.B + noise[image.Width * i + j], 0, 255)));

                }
            }
            int[] hist = calculateHistogram(resultImage);
            ArrToExcel(hist, "..\\..\\..\\..\\GaussianNoise.xls");

            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            image = resultImage;
            label1.Text = "Обработка завершена";
        }

       
        private void uniformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Обработка изображения...";
            prevImage = image;
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            const double a = 32;
            const double b = 120;

            int size = image.Height * image.Width;
            var uniform = new float[256];
            float sum = 0f;

            for (int i = 0; i < 256; i++)
            {
                float step = i;
                if (step >= a && step <= b)
                {
                    uniform[i] = (1 / (float)(b - a));
                }
                else
                {
                    uniform[i] = 0;
                }
                sum += uniform[i];
            }

            for (int i = 0; i < 256; i++)
            {
                uniform[i] /= sum;
                uniform[i] *= size;
                uniform[i] = (int)Math.Floor(uniform[i]);
            }

            Random rand = new Random();
            int count = 0;
            var noise = new byte[size];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < (int)uniform[i]; j++)
                {
                    noise[j + count] = (byte)i;
                }
                count += (int)uniform[i];
            }

            for (int i = 0; i < size - count; i++)
            {
                noise[count + i] = 0;
            }

            noise = noise.OrderBy(x => rand.Next()).ToArray();

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    Color color = image.GetPixel(j, i);

                    resultImage.SetPixel(j, i, Color.FromArgb(Clamp(color.R + noise[image.Width * i + j], 0, 255),
                        Clamp(color.G + noise[image.Width * i + j], 0, 255),
                        Clamp(color.B + noise[image.Width * i + j], 0, 255)));

                }
            }

            int[] hist = calculateHistogram(resultImage);
            ArrToExcel(hist, "..\\..\\..\\..\\UniformNoise.xls");
            image = resultImage;
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            label1.Text = "Обработка завершена";
        }

        private void фильтрГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Обработка изображения...";
            prevImage = image;
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            int w_size = 3;

            int radiusX = w_size / 2;
            int radiusY = w_size / 2;
            float sigma = 0.5f;
            double gauss, sumGauss = 0;

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    sumGauss = 0;
                    for (int l = -radiusY; l <= radiusY; l++)
                    {
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = Clamp(i + k, 0, image.Width - 1);
                            int idY = Clamp(j + l, 0, image.Height - 1);
                            Color neighborColor = image.GetPixel(idX, idY);
                            gauss = 1 / (2 * Math.PI * Math.Pow(sigma, 2)) * Math.Exp(-(Math.Pow(l, 2) + Math.Pow(k, 2)) / (2 * Math.Pow(sigma, 2)));
                            sumGauss += gauss * neighborColor.R;
                        }
                    }
                    Color resultColor = Color.FromArgb(Clamp((int)sumGauss,0,255), Clamp((int)sumGauss, 0, 255), Clamp((int)sumGauss, 0, 255));
                    resultImage.SetPixel(i, j, resultColor);
                }
            }
            image = resultImage;
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            label1.Text = "Обработка завершена";

        }
        private void медианныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Обработка изображения...";
            prevImage = image;
            Bitmap resultImage = new Bitmap(image.Width, image.Height);
            int w = image.Width, h = image.Height;
            int radiusX = 1, radiusY = 1;

            for (int i = radiusX; i < (w - radiusX); i++)
            {
                for (int j = radiusY; j < (h - radiusY); j++)
                {
                    List<Color> roundPixelsList = new List<Color>();
                    for (int l = -radiusY; l <= radiusY; l++)
                    {
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int idX = Clamp(i + k, 0, image.Width - 1);
                            int idY = Clamp(j + l, 0, image.Height - 1);
                            roundPixelsList.Add(image.GetPixel(idX, idY));
                        }
                    }

                    roundPixelsList.Sort((color1, color2) => color1.ToArgb() - color2.ToArgb());
                    resultImage.SetPixel(i, j, roundPixelsList[4]);
                }
            }

            image = resultImage;
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            label1.Text = "Обработка завершена";
        }

        private float calculateSigma(Bitmap image1, Bitmap image2)
        {
            float sigma = 0f;
            for (int i = 0; i < image1.Width; i++)
                for (int j = 0; j < image1.Height; j++)
                {
                    sigma += (float)(Math.Pow(GetBrightness(image1.GetPixel(i, j)) - GetBrightness(image2.GetPixel(i, j)), 2));
                }
            return sigma / (image1.Width * image1.Height);
        }

        private void pSNRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Результат сравнения: " + calculatePsnr().ToString());
        }

        private float calculatePsnr()
        {
            Bitmap compareImage = null;
            OpenFileDialog dialog2 = new OpenFileDialog();
            dialog2.Filter = "Image files | *.png; *.jpg; *.bmp; | All Files (*.*) | *.*";
            if (dialog2.ShowDialog() == DialogResult.OK)
            {
                compareImage = new Bitmap(dialog2.FileName);
            }
            float res;
            if (image.Size != compareImage.Size)
            {
                res = -1.0f;
                return res;
            }

            float mse = calculateMse(compareImage);
            res = (float)(20 * Math.Log10(255.0f / Math.Sqrt(mse)));
            return res;
        }

        private float calculateMse(Bitmap compareImage)
        {
            float sumR = 0f;
            float sumG = 0f;
            float sumB = 0f;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    sumR += (float)Math.Pow((int)compareImage.GetPixel(i, j).R - (int)image.GetPixel(i, j).R, 2);
                    sumG += (float)Math.Pow((int)compareImage.GetPixel(i, j).G - (int)image.GetPixel(i, j).G, 2);
                    sumB += (float)Math.Pow((int)compareImage.GetPixel(i, j).B - (int)image.GetPixel(i, j).B, 2);
                }
            }
            var res = (sumR + sumG + sumB) / (image.Width * image.Height) / 3;
            return res;
        }

        private void sSIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Результат сравнения: " + calculateSsim().ToString());
        }
        private float calculateSsim()
        {
            Bitmap compareImage = null;
            OpenFileDialog dialog2 = new OpenFileDialog();
            dialog2.Filter = "Image files | *.png; *.jpg; *.bmp; | All Files (*.*) | *.*";
            if (dialog2.ShowDialog() == DialogResult.OK)
            {
                compareImage = new Bitmap(dialog2.FileName);
            }
            float res;

            

            if (image.Size != compareImage.Size)
            {
                res = -1.0f;
                return res;
            }
            float k1 = 0.01f, k2 = 0.03f;
            float c1 = (float)Math.Pow(255f * k1, 2);
            float c2 = (float)Math.Pow(255f * k2, 2);

            float avgBrightX = calculateAverageBrightness(compareImage);
            float avgBrightY = calculateAverageBrightness(image);
            float disX = calculateDis(compareImage, avgBrightX);
            float disY = calculateDis(image, avgBrightY);
            float covXY = calculateCov(compareImage, avgBrightX, image, avgBrightY);
            ;
            res = (2 * avgBrightX * avgBrightY + c1) * (2 * covXY + c2) / (float)(Math.Pow(avgBrightX, 2) + Math.Pow(avgBrightY, 2) + c1)
                / (float)(Math.Pow(disX, 2) + Math.Pow(disY, 2) + c2); ;
            return res;
        }

        private float calculateDis(Bitmap image, float AvBr)
        {
            float sum = 0f;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    sum += (float)Math.Pow(GetBrightness(image.GetPixel(i, j)) - AvBr, 2);
                }
            }
            return (float)Math.Sqrt(sum / ((float)(image.Width * image.Height) - 1f));
        }

        private float calculateAverageBrightness(Bitmap image)
        {
            float sum = 0.0f;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    sum += GetBrightness(image.GetPixel(i, j));
                }
            }
            return sum / (float)(image.Width * image.Height);
        }

        private static float calculateCov(Bitmap image1, float m1, Bitmap image2, float m2)
        {
            float sum = 0f;
            for (int i = 0; i < image1.Width; i++)
            {
                for (int j = 0; j < image1.Height; j++)
                {
                    sum += (GetBrightness(image1.GetPixel(i, j)) - m1) *
                        (GetBrightness(image2.GetPixel(i, j)) - m2);
                }
            }
            return sum / ((float)(image1.Width * image1.Height) - 1f);
        }


        private static byte GetBrightness(Color color)
        {
            return (byte)(.299 * color.R + .587 * color.G + .114 * color.B);
        }
        public void ArrToExcel(int[] arr, string path)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2016;

            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet sheet = workbook.Worksheets[0];
            sheet.ImportArray(arr, 1, 1, false);

            Stream excelStream = File.Create(path);
            workbook.SaveAs(excelStream);
            excelStream.Dispose();
        }
       
    }

}