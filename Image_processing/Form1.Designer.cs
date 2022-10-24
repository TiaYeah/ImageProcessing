
namespace Image_processing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autocontrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.точечнаяБинаризацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бинаризацияНиблэкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бинаризацияПоГистограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.моделированиеШумаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.гауссовШумToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uniformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеШумаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.метрикиСравненияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pSNRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.медианныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(629, 337);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.фильтрToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.открытьToolStripMenuItem.Text = "Открыть ";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // фильтрToolStripMenuItem
            // 
            this.фильтрToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayscaleToolStripMenuItem,
            this.averageToolStripMenuItem,
            this.autocontrastToolStripMenuItem});
            this.фильтрToolStripMenuItem.Name = "фильтрToolStripMenuItem";
            this.фильтрToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.фильтрToolStripMenuItem.Text = "Фильтр";
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.grayscaleToolStripMenuItem.Text = "grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // averageToolStripMenuItem
            // 
            this.averageToolStripMenuItem.Name = "averageToolStripMenuItem";
            this.averageToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.averageToolStripMenuItem.Text = "average";
            this.averageToolStripMenuItem.Click += new System.EventHandler(this.averageToolStripMenuItem_Click);
            // 
            // autocontrastToolStripMenuItem
            // 
            this.autocontrastToolStripMenuItem.Name = "autocontrastToolStripMenuItem";
            this.autocontrastToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.autocontrastToolStripMenuItem.Text = "autocontrast";
            this.autocontrastToolStripMenuItem.Click += new System.EventHandler(this.autocontrastToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.точечнаяБинаризацияToolStripMenuItem,
            this.бинаризацияНиблэкаToolStripMenuItem,
            this.бинаризацияПоГистограммеToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.toolStripMenuItem1.Text = "27.09";
            // 
            // точечнаяБинаризацияToolStripMenuItem
            // 
            this.точечнаяБинаризацияToolStripMenuItem.Name = "точечнаяБинаризацияToolStripMenuItem";
            this.точечнаяБинаризацияToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.точечнаяБинаризацияToolStripMenuItem.Text = "Точечная бинаризация";
            this.точечнаяБинаризацияToolStripMenuItem.Click += new System.EventHandler(this.точечнаяБинаризацияToolStripMenuItem_Click);
            // 
            // бинаризацияНиблэкаToolStripMenuItem
            // 
            this.бинаризацияНиблэкаToolStripMenuItem.Name = "бинаризацияНиблэкаToolStripMenuItem";
            this.бинаризацияНиблэкаToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.бинаризацияНиблэкаToolStripMenuItem.Text = "Бинаризация Ниблэка";
            this.бинаризацияНиблэкаToolStripMenuItem.Click += new System.EventHandler(this.бинаризацияНиблэкаToolStripMenuItem_Click);
            // 
            // бинаризацияПоГистограммеToolStripMenuItem
            // 
            this.бинаризацияПоГистограммеToolStripMenuItem.Name = "бинаризацияПоГистограммеToolStripMenuItem";
            this.бинаризацияПоГистограммеToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.бинаризацияПоГистограммеToolStripMenuItem.Text = "Бинаризация по гистограмме";
            this.бинаризацияПоГистограммеToolStripMenuItem.Click += new System.EventHandler(this.бинаризацияПоГистограммеToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.моделированиеШумаToolStripMenuItem,
            this.удалениеШумаToolStripMenuItem,
            this.метрикиСравненияToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(46, 20);
            this.toolStripMenuItem2.Text = "11.10";
            // 
            // моделированиеШумаToolStripMenuItem
            // 
            this.моделированиеШумаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.гауссовШумToolStripMenuItem,
            this.uniformToolStripMenuItem});
            this.моделированиеШумаToolStripMenuItem.Name = "моделированиеШумаToolStripMenuItem";
            this.моделированиеШумаToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.моделированиеШумаToolStripMenuItem.Text = "Моделирование шума";
            // 
            // гауссовШумToolStripMenuItem
            // 
            this.гауссовШумToolStripMenuItem.Name = "гауссовШумToolStripMenuItem";
            this.гауссовШумToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.гауссовШумToolStripMenuItem.Text = "Гауссов шум";
            this.гауссовШумToolStripMenuItem.Click += new System.EventHandler(this.гауссовШумToolStripMenuItem_Click);
            // 
            // uniformToolStripMenuItem
            // 
            this.uniformToolStripMenuItem.Name = "uniformToolStripMenuItem";
            this.uniformToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uniformToolStripMenuItem.Text = "uniform";
            this.uniformToolStripMenuItem.Click += new System.EventHandler(this.uniformToolStripMenuItem_Click);
            // 
            // удалениеШумаToolStripMenuItem
            // 
            this.удалениеШумаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фToolStripMenuItem,
            this.медианныйToolStripMenuItem});
            this.удалениеШумаToolStripMenuItem.Name = "удалениеШумаToolStripMenuItem";
            this.удалениеШумаToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.удалениеШумаToolStripMenuItem.Text = "Удаление шума";
            // 
            // фToolStripMenuItem
            // 
            this.фToolStripMenuItem.Name = "фToolStripMenuItem";
            this.фToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.фToolStripMenuItem.Text = "Фильтр Гаусса";
            this.фToolStripMenuItem.Click += new System.EventHandler(this.фToolStripMenuItem_Click);
            // 
            // метрикиСравненияToolStripMenuItem
            // 
            this.метрикиСравненияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pSNRToolStripMenuItem,
            this.sSIMToolStripMenuItem});
            this.метрикиСравненияToolStripMenuItem.Name = "метрикиСравненияToolStripMenuItem";
            this.метрикиСравненияToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.метрикиСравненияToolStripMenuItem.Text = "Метрики сравнения";
            // 
            // pSNRToolStripMenuItem
            // 
            this.pSNRToolStripMenuItem.Name = "pSNRToolStripMenuItem";
            this.pSNRToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.pSNRToolStripMenuItem.Text = "PSNR";
            this.pSNRToolStripMenuItem.Click += new System.EventHandler(this.pSNRToolStripMenuItem_Click);
            // 
            // sSIMToolStripMenuItem
            // 
            this.sSIMToolStripMenuItem.Name = "sSIMToolStripMenuItem";
            this.sSIMToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.sSIMToolStripMenuItem.Text = "SSIM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ожидание";
            // 
            // медианныйToolStripMenuItem
            // 
            this.медианныйToolStripMenuItem.Name = "медианныйToolStripMenuItem";
            this.медианныйToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.медианныйToolStripMenuItem.Text = "Медианный";
            this.медианныйToolStripMenuItem.Click += new System.EventHandler(this.медианныйToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autocontrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem точечнаяБинаризацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бинаризацияНиблэкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бинаризацияПоГистограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem моделированиеШумаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem гауссовШумToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалениеШумаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem метрикиСравненияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pSNRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSIMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uniformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem медианныйToolStripMenuItem;
    }
}

