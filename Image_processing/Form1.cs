using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            saveDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
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

            float averageBrightness = calculateAverageBrightness(image);

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    float sigma = calculateSigma(i,j);
                    Color sourceColor = image.GetPixel(i, j);
                    float degree = (float)(-(Math.Pow(sourceColor.GetBrightness() - averageBrightness, 2)) / (2 * Math.Pow(sigma, 2)));
                    Color resColor = Color.FromArgb((int)(1 / (float)Math.Sqrt(2 * Math.PI * sigma) * (float) Math.Pow(Math.E, degree)));

                    resultImage.SetPixel(i, j, resColor);
                }
            }

            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            image = resultImage;
            label1.Text = "Обработка завершена";
        }

        private float calculateAverageBrightness(Bitmap image)
        {
            float res = 0.0f;

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    res += image.GetPixel(i, j).GetBrightness();
                }
            }

            res /= image.Width * image.Height;

            return res;
        }

        private float calculateSigma(int i, int j)
        {
            float sigma = 0.0f;
            int w_size = 5;

            int radiusX = w_size / 2;
            int radiusY = w_size / 2;


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

                    sigma += (float)((image.GetPixel(idX, idY).R - res) * (image.GetPixel(idX, idY).R - res));

                }
            }
            sigma = (float)(sigma / (w_size * w_size));

            //for (int i = 0; i < image.Width; i++)
            //    for (int j = 0; j < image.Height; j++)
            //    {
            //        Color color = image.GetPixel(i, j);

            //        sigma += (float)Math.Pow(color.GetBrightness() - averageBrightness, 2);
            //    }
            //sigma /= (image.Width * image.Height);
            return sigma;
        }

        private void сольПерецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Обработка изображения...";
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            const float p = 0.05f;
            int noisePixels = 0;
            int upBorder = 255, downBorder = 0;

            Random random = new Random();
            while (noisePixels < image.Height * image.Width * p)
            {
                int w = random.Next(image.Width);
                int h = random.Next(image.Height);
                Color color = image.GetPixel(w, h);
                if (color.GetBrightness() != upBorder && color.GetBrightness() != downBorder)
                {
                    color = Color.Black;
                }
                resultImage.SetPixel(w, h, color);
                noisePixels++;
            }

            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
            image = resultImage;
            label1.Text = "Обработка завершена";
        }

        private void фToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void pSNRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Результат сравнения: " + calculatePsnr().ToString());
        }

        private float calculatePsnr()
        {
            float res;
            if (image.Size != prevImage.Size)
            {
                res = -1.0f;
                return res;
            }

            float sigma = calculateSigma(image, prevImage);
            res = (float)(20 * Math.Log10(255.0f / Math.Sqrt(sigma)));
            return res;
        }

        

        private float calculateSigma(Bitmap image1, Bitmap image2)
        {
            float sigma = 0f;
            for (int i = 0; i < image1.Width; i++)
                for (int j = 0; j < image1.Height; j++)
                {
                    sigma += (float)(Math.Pow(image1.GetPixel(i, j).GetBrightness() - image2.GetPixel(i, j).GetBrightness(), 2));
                }
            return sigma / (image1.Width * image1.Height);
        }
    }

}