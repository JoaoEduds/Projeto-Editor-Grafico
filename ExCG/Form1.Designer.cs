namespace ExCG
{
    partial class FrmPrincipal
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
            pictureBox1 = new PictureBox();
            btAbrirImg = new Button();
            button1 = new Button();
            openFileDialog = new OpenFileDialog();
            btLimpar = new Button();
            checkBox1 = new CheckBox();
            valorPixel = new Label();
            panelCor = new Panel();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            pictureBoxR = new PictureBox();
            pictureBoxG = new PictureBox();
            pictureBoxB = new PictureBox();
            pictureBoxH = new PictureBox();
            pictureBoxS = new PictureBox();
            pictureBoxI = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxI).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(500, 500);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btAbrirImg
            // 
            btAbrirImg.Location = new Point(531, 12);
            btAbrirImg.Name = "btAbrirImg";
            btAbrirImg.Size = new Size(104, 23);
            btAbrirImg.TabIndex = 1;
            btAbrirImg.Text = "Abrir Imagem";
            btAbrirImg.UseVisualStyleBackColor = true;
            btAbrirImg.Click += btAbrirImg_Click;
            // 
            // button1
            // 
            button1.Location = new Point(531, 41);
            button1.Name = "button1";
            button1.Size = new Size(98, 23);
            button1.TabIndex = 2;
            button1.Text = "Luminância";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btLuminancia_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // btLimpar
            // 
            btLimpar.Location = new Point(641, 12);
            btLimpar.Name = "btLimpar";
            btLimpar.Size = new Size(75, 23);
            btLimpar.TabIndex = 4;
            btLimpar.Text = "Limpar Imagem";
            btLimpar.UseVisualStyleBackColor = true;
            btLimpar.Click += btLimpar_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(637, 42);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(87, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Conversões";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkbox_Mudanca;
            // 
            // valorPixel
            // 
            valorPixel.AutoSize = true;
            valorPixel.Location = new Point(722, 28);
            valorPixel.Name = "valorPixel";
            valorPixel.Size = new Size(48, 45);
            valorPixel.TabIndex = 6;
            valorPixel.Text = "R: G: B: \r\nC: M: Y:\r\nH: S: I:";
            // 
            // panelCor
            // 
            panelCor.BackColor = SystemColors.Control;
            panelCor.Location = new Point(430, 243);
            panelCor.Name = "panelCor";
            panelCor.Size = new Size(68, 61);
            panelCor.TabIndex = 7;
            panelCor.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(531, 89);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(82, 22);
            button2.TabIndex = 8;
            button2.Text = "+";
            button2.UseVisualStyleBackColor = true;
            button2.Click += aumentar_Brilho;
            // 
            // button3
            // 
            button3.Location = new Point(636, 89);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(82, 22);
            button3.TabIndex = 9;
            button3.Text = "-";
            button3.UseVisualStyleBackColor = true;
            button3.Click += diminuir_Brilho;
            // 
            // button4
            // 
            button4.Location = new Point(531, 115);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(82, 22);
            button4.TabIndex = 10;
            button4.Text = "RGB";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(637, 115);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(82, 22);
            button5.TabIndex = 11;
            button5.Text = "HSI";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // pictureBoxR
            // 
            pictureBoxR.Location = new Point(589, 286);
            pictureBoxR.Margin = new Padding(3, 2, 3, 2);
            pictureBoxR.MaximumSize = new Size(105, 90);
            pictureBoxR.MinimumSize = new Size(105, 90);
            pictureBoxR.Name = "pictureBoxR";
            pictureBoxR.Size = new Size(105, 90);
            pictureBoxR.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxR.TabIndex = 12;
            pictureBoxR.TabStop = false;
            // 
            // pictureBoxG
            // 
            pictureBoxG.Location = new Point(735, 286);
            pictureBoxG.Margin = new Padding(3, 2, 3, 2);
            pictureBoxG.MaximumSize = new Size(105, 90);
            pictureBoxG.MinimumSize = new Size(105, 90);
            pictureBoxG.Name = "pictureBoxG";
            pictureBoxG.Size = new Size(105, 90);
            pictureBoxG.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxG.TabIndex = 13;
            pictureBoxG.TabStop = false;
            // 
            // pictureBoxB
            // 
            pictureBoxB.Location = new Point(878, 286);
            pictureBoxB.Margin = new Padding(3, 2, 3, 2);
            pictureBoxB.MaximumSize = new Size(105, 90);
            pictureBoxB.MinimumSize = new Size(105, 90);
            pictureBoxB.Name = "pictureBoxB";
            pictureBoxB.Size = new Size(105, 90);
            pictureBoxB.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxB.TabIndex = 14;
            pictureBoxB.TabStop = false;
            // 
            // pictureBoxH
            // 
            pictureBoxH.Location = new Point(589, 398);
            pictureBoxH.Margin = new Padding(3, 2, 3, 2);
            pictureBoxH.MaximumSize = new Size(105, 90);
            pictureBoxH.MinimumSize = new Size(105, 90);
            pictureBoxH.Name = "pictureBoxH";
            pictureBoxH.Size = new Size(105, 90);
            pictureBoxH.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxH.TabIndex = 15;
            pictureBoxH.TabStop = false;
            // 
            // pictureBoxS
            // 
            pictureBoxS.Location = new Point(735, 398);
            pictureBoxS.Margin = new Padding(3, 2, 3, 2);
            pictureBoxS.MaximumSize = new Size(105, 90);
            pictureBoxS.MinimumSize = new Size(105, 90);
            pictureBoxS.Name = "pictureBoxS";
            pictureBoxS.Size = new Size(105, 90);
            pictureBoxS.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxS.TabIndex = 16;
            pictureBoxS.TabStop = false;
            // 
            // pictureBoxI
            // 
            pictureBoxI.Location = new Point(878, 398);
            pictureBoxI.Margin = new Padding(3, 2, 3, 2);
            pictureBoxI.MaximumSize = new Size(105, 90);
            pictureBoxI.MinimumSize = new Size(105, 90);
            pictureBoxI.Name = "pictureBoxI";
            pictureBoxI.Size = new Size(105, 90);
            pictureBoxI.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxI.TabIndex = 17;
            pictureBoxI.TabStop = false;
            pictureBoxI.Click += pictureBox3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(531, 72);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 18;
            label1.Text = "Alterar brilho";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(531, 150);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 19;
            label2.Text = "Mudar Matiz";
            // 
            // button6
            // 
            button6.Location = new Point(530, 168);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 20;
            button6.Text = "+10°";
            button6.UseVisualStyleBackColor = true;
            button6.Click += aumentar_Hue;
            // 
            // button7
            // 
            button7.Location = new Point(641, 168);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 21;
            button7.Text = "-10°";
            button7.UseVisualStyleBackColor = true;
            button7.Click += diminuir_Hue;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 521);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBoxI);
            Controls.Add(pictureBoxS);
            Controls.Add(pictureBoxH);
            Controls.Add(pictureBoxB);
            Controls.Add(pictureBoxG);
            Controls.Add(pictureBoxR);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(panelCor);
            Controls.Add(valorPixel);
            Controls.Add(checkBox1);
            Controls.Add(btLimpar);
            Controls.Add(button1);
            Controls.Add(btAbrirImg);
            Controls.Add(pictureBox1);
            Name = "FrmPrincipal";
            Text = "Editor de Imagem";
            Load += FrmPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxR).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxG).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxB).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxH).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxS).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxI).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btAbrirImg;
        private System.Windows.Forms.Button button1;
        private OpenFileDialog openFileDialog;
        private Button btLimpar;
        private CheckBox checkBox1;
        private Label valorPixel;
        private Panel panelCor;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private PictureBox pictureBoxR;
        private PictureBox pictureBoxG;
        private PictureBox pictureBoxB;
        private PictureBox pictureBoxH;
        private PictureBox pictureBoxS;
        private PictureBox pictureBoxI;
        private Label label1;
        private Label label2;
        private Button button6;
        private Button button7;
    }
}
