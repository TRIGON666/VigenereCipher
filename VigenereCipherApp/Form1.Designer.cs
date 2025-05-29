namespace VigenereCipherApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.enc = new System.Windows.Forms.Button();
            this.dec = new System.Windows.Forms.Button();
            this.tKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHack = new System.Windows.Forms.Button();
            this.txtMaybeKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHacTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 55);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(404, 134);
            this.txtInput.TabIndex = 0;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 225);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(404, 134);
            this.txtOutput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Исходный текст:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Результат:";
            // 
            // enc
            // 
            this.enc.Location = new System.Drawing.Point(15, 415);
            this.enc.Name = "enc";
            this.enc.Size = new System.Drawing.Size(144, 23);
            this.enc.TabIndex = 4;
            this.enc.Text = "Зашифровать";
            this.enc.UseVisualStyleBackColor = true;
            this.enc.Click += new System.EventHandler(this.enc_Click);
            // 
            // dec
            // 
            this.dec.Location = new System.Drawing.Point(165, 415);
            this.dec.Name = "dec";
            this.dec.Size = new System.Drawing.Size(144, 23);
            this.dec.TabIndex = 5;
            this.dec.Text = "Расшифровать";
            this.dec.UseVisualStyleBackColor = true;
            this.dec.Click += new System.EventHandler(this.dec_Click);
            // 
            // tKey
            // 
            this.tKey.Location = new System.Drawing.Point(422, 55);
            this.tKey.Multiline = true;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(134, 25);
            this.tKey.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ключ:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(422, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(134, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(422, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Язык:";
            // 
            // btnHack
            // 
            this.btnHack.Location = new System.Drawing.Point(315, 415);
            this.btnHack.Name = "btnHack";
            this.btnHack.Size = new System.Drawing.Size(144, 23);
            this.btnHack.TabIndex = 10;
            this.btnHack.Text = "Взломать";
            this.btnHack.UseVisualStyleBackColor = true;
            this.btnHack.Click += new System.EventHandler(this.btnHack_Click);
            // 
            // txtMaybeKey
            // 
            this.txtMaybeKey.Location = new System.Drawing.Point(562, 55);
            this.txtMaybeKey.Multiline = true;
            this.txtMaybeKey.Name = "txtMaybeKey";
            this.txtMaybeKey.Size = new System.Drawing.Size(134, 25);
            this.txtMaybeKey.TabIndex = 11;
            this.txtMaybeKey.TextChanged += new System.EventHandler(this.txtMaybeKey_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(562, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Возможный ключ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(562, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Взломанный текст:";
            // 
            // txtHacTxt
            // 
            this.txtHacTxt.Location = new System.Drawing.Point(562, 104);
            this.txtHacTxt.Multiline = true;
            this.txtHacTxt.Name = "txtHacTxt";
            this.txtHacTxt.Size = new System.Drawing.Size(404, 134);
            this.txtHacTxt.TabIndex = 13;
            this.txtHacTxt.TextChanged += new System.EventHandler(this.txtHacTxt_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHacTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMaybeKey);
            this.Controls.Add(this.btnHack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tKey);
            this.Controls.Add(this.dec);
            this.Controls.Add(this.enc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button enc;
        private System.Windows.Forms.Button dec;
        private System.Windows.Forms.TextBox tKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHack;
        private System.Windows.Forms.TextBox txtMaybeKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHacTxt;
    }
}

