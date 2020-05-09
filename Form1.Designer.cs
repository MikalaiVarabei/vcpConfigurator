namespace scm
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.outTextBox = new System.Windows.Forms.RichTextBox();
            this.comPortList = new System.Windows.Forms.ComboBox();
            this.close = new System.Windows.Forms.Button();
            this.openBtt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.paramReadButton = new System.Windows.Forms.Button();
            this.sectionReadButton = new System.Windows.Forms.Button();
            this.meterCmdButton = new System.Windows.Forms.Button();
            this.allParamTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.paramReadСheckBox = new System.Windows.Forms.CheckBox();
            this.startCmdButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.stopCmdButton = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericUpDownByte0 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownByte1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownByte2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownByte3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownByte4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownByte5 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.readSettingsButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByte0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByte1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByte2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByte3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByte4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByte5)).BeginInit();
            this.SuspendLayout();
            // 
            // outTextBox
            // 
            this.outTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outTextBox.Location = new System.Drawing.Point(12, 433);
            this.outTextBox.Name = "outTextBox";
            this.outTextBox.Size = new System.Drawing.Size(548, 74);
            this.outTextBox.TabIndex = 2;
            this.outTextBox.Text = "";
            // 
            // comPortList
            // 
            this.comPortList.FormattingEnabled = true;
            this.comPortList.Location = new System.Drawing.Point(16, 13);
            this.comPortList.Name = "comPortList";
            this.comPortList.Size = new System.Drawing.Size(75, 21);
            this.comPortList.TabIndex = 5;
            this.comPortList.DropDown += new System.EventHandler(this.comPortList_DropDown);
            // 
            // close
            // 
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.Image = ((System.Drawing.Image)(resources.GetObject("close.Image")));
            this.close.Location = new System.Drawing.Point(128, 13);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(25, 25);
            this.close.TabIndex = 1;
            this.close.UseVisualStyleBackColor = false;
            this.close.Visible = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // openBtt
            // 
            this.openBtt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.openBtt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openBtt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openBtt.Image = ((System.Drawing.Image)(resources.GetObject("openBtt.Image")));
            this.openBtt.Location = new System.Drawing.Point(97, 13);
            this.openBtt.Name = "openBtt";
            this.openBtt.Size = new System.Drawing.Size(25, 25);
            this.openBtt.TabIndex = 0;
            this.openBtt.UseVisualStyleBackColor = true;
            this.openBtt.Click += new System.EventHandler(this.open_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "нет соединения";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comPortList);
            this.groupBox1.Controls.Add(this.openBtt);
            this.groupBox1.Controls.Add(this.close);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 44);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // paramReadButton
            // 
            this.paramReadButton.Location = new System.Drawing.Point(6, 36);
            this.paramReadButton.Name = "paramReadButton";
            this.paramReadButton.Size = new System.Drawing.Size(159, 35);
            this.paramReadButton.TabIndex = 17;
            this.paramReadButton.Text = "Запрос всех\r\nпараметров (06h)";
            this.paramReadButton.UseVisualStyleBackColor = true;
            this.paramReadButton.Click += new System.EventHandler(this.paramReadButton_Click);
            // 
            // sectionReadButton
            // 
            this.sectionReadButton.Location = new System.Drawing.Point(171, 36);
            this.sectionReadButton.Name = "sectionReadButton";
            this.sectionReadButton.Size = new System.Drawing.Size(135, 35);
            this.sectionReadButton.TabIndex = 18;
            this.sectionReadButton.Text = "Параметры\r\nкратко (07h)";
            this.sectionReadButton.UseVisualStyleBackColor = true;
            this.sectionReadButton.Click += new System.EventHandler(this.sectionReadButton_Click);
            // 
            // meterCmdButton
            // 
            this.meterCmdButton.Location = new System.Drawing.Point(15, 101);
            this.meterCmdButton.Name = "meterCmdButton";
            this.meterCmdButton.Size = new System.Drawing.Size(86, 35);
            this.meterCmdButton.TabIndex = 19;
            this.meterCmdButton.Text = "Произвести\r\nзамеры (08h)";
            this.meterCmdButton.UseVisualStyleBackColor = true;
            this.meterCmdButton.Click += new System.EventHandler(this.meterCmdButton_Click);
            // 
            // allParamTextBox
            // 
            this.allParamTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allParamTextBox.Location = new System.Drawing.Point(6, 81);
            this.allParamTextBox.Name = "allParamTextBox";
            this.allParamTextBox.Size = new System.Drawing.Size(300, 338);
            this.allParamTextBox.TabIndex = 20;
            this.allParamTextBox.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.paramReadСheckBox);
            this.groupBox2.Controls.Add(this.paramReadButton);
            this.groupBox2.Controls.Add(this.allParamTextBox);
            this.groupBox2.Controls.Add(this.sectionReadButton);
            this.groupBox2.Location = new System.Drawing.Point(410, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 425);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // paramReadСheckBox
            // 
            this.paramReadСheckBox.AutoSize = true;
            this.paramReadСheckBox.Location = new System.Drawing.Point(7, 11);
            this.paramReadСheckBox.Name = "paramReadСheckBox";
            this.paramReadСheckBox.Size = new System.Drawing.Size(168, 17);
            this.paramReadСheckBox.TabIndex = 21;
            this.paramReadСheckBox.Text = "Запрашивать периодически";
            this.paramReadСheckBox.UseVisualStyleBackColor = true;
            this.paramReadСheckBox.CheckedChanged += new System.EventHandler(this.paramReadСheckBox_CheckedChanged);
            // 
            // startCmdButton
            // 
            this.startCmdButton.Location = new System.Drawing.Point(15, 19);
            this.startCmdButton.Name = "startCmdButton";
            this.startCmdButton.Size = new System.Drawing.Size(86, 35);
            this.startCmdButton.TabIndex = 21;
            this.startCmdButton.Text = "Запустить (5Ah)";
            this.startCmdButton.UseVisualStyleBackColor = true;
            this.startCmdButton.Click += new System.EventHandler(this.startCmdButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.stopCmdButton);
            this.groupBox3.Controls.Add(this.startCmdButton);
            this.groupBox3.Controls.Add(this.meterCmdButton);
            this.groupBox3.Location = new System.Drawing.Point(196, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 153);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            // 
            // stopCmdButton
            // 
            this.stopCmdButton.Location = new System.Drawing.Point(15, 60);
            this.stopCmdButton.Name = "stopCmdButton";
            this.stopCmdButton.Size = new System.Drawing.Size(86, 35);
            this.stopCmdButton.TabIndex = 22;
            this.stopCmdButton.Text = "Остановить (5B)";
            this.stopCmdButton.UseVisualStyleBackColor = true;
            this.stopCmdButton.Click += new System.EventHandler(this.stopCmdButton_Click);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.saveSettingsButton);
            this.groupBox4.Controls.Add(this.readSettingsButton);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.numericUpDownByte5);
            this.groupBox4.Controls.Add(this.numericUpDownByte4);
            this.groupBox4.Controls.Add(this.numericUpDownByte3);
            this.groupBox4.Controls.Add(this.numericUpDownByte2);
            this.groupBox4.Controls.Add(this.numericUpDownByte1);
            this.groupBox4.Controls.Add(this.numericUpDownByte0);
            this.groupBox4.Location = new System.Drawing.Point(13, 232);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(391, 195);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            // 
            // numericUpDownByte0
            // 
            this.numericUpDownByte0.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownByte0.Location = new System.Drawing.Point(139, 17);
            this.numericUpDownByte0.Maximum = new decimal(new int[] {
            2550,
            0,
            0,
            0});
            this.numericUpDownByte0.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownByte0.Name = "numericUpDownByte0";
            this.numericUpDownByte0.Size = new System.Drawing.Size(87, 20);
            this.numericUpDownByte0.TabIndex = 0;
            this.numericUpDownByte0.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // numericUpDownByte1
            // 
            this.numericUpDownByte1.Location = new System.Drawing.Point(139, 45);
            this.numericUpDownByte1.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericUpDownByte1.Minimum = new decimal(new int[] {
            126,
            0,
            0,
            -2147483648});
            this.numericUpDownByte1.Name = "numericUpDownByte1";
            this.numericUpDownByte1.Size = new System.Drawing.Size(87, 20);
            this.numericUpDownByte1.TabIndex = 1;
            // 
            // numericUpDownByte2
            // 
            this.numericUpDownByte2.Location = new System.Drawing.Point(139, 71);
            this.numericUpDownByte2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownByte2.Name = "numericUpDownByte2";
            this.numericUpDownByte2.Size = new System.Drawing.Size(87, 20);
            this.numericUpDownByte2.TabIndex = 2;
            // 
            // numericUpDownByte3
            // 
            this.numericUpDownByte3.DecimalPlaces = 1;
            this.numericUpDownByte3.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownByte3.Location = new System.Drawing.Point(139, 95);
            this.numericUpDownByte3.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownByte3.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.numericUpDownByte3.Name = "numericUpDownByte3";
            this.numericUpDownByte3.Size = new System.Drawing.Size(87, 20);
            this.numericUpDownByte3.TabIndex = 3;
            this.numericUpDownByte3.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // numericUpDownByte4
            // 
            this.numericUpDownByte4.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownByte4.Location = new System.Drawing.Point(139, 121);
            this.numericUpDownByte4.Maximum = new decimal(new int[] {
            2550,
            0,
            0,
            0});
            this.numericUpDownByte4.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownByte4.Name = "numericUpDownByte4";
            this.numericUpDownByte4.Size = new System.Drawing.Size(87, 20);
            this.numericUpDownByte4.TabIndex = 4;
            this.numericUpDownByte4.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // numericUpDownByte5
            // 
            this.numericUpDownByte5.Location = new System.Drawing.Point(139, 165);
            this.numericUpDownByte5.Name = "numericUpDownByte5";
            this.numericUpDownByte5.ReadOnly = true;
            this.numericUpDownByte5.Size = new System.Drawing.Size(87, 20);
            this.numericUpDownByte5.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Время прогрева, с";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Температура прогр, °С";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Свет";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Вращение стартера, с";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Отсечка, об/мин";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Перезагрузок системы";
            // 
            // readSettingsButton
            // 
            this.readSettingsButton.Location = new System.Drawing.Point(270, 17);
            this.readSettingsButton.Name = "readSettingsButton";
            this.readSettingsButton.Size = new System.Drawing.Size(97, 41);
            this.readSettingsButton.TabIndex = 12;
            this.readSettingsButton.Text = "Читать\r\nнастройки (4Bh)";
            this.readSettingsButton.UseVisualStyleBackColor = true;
            this.readSettingsButton.Click += new System.EventHandler(this.readSettingsButton_Click);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(270, 74);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(97, 41);
            this.saveSettingsButton.TabIndex = 13;
            this.saveSettingsButton.Text = "Записать\r\nнастройки (4Ah)";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 519);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.outTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "S.M.A.R.T. RS-485";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByte0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByte1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByte2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByte3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByte4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownByte5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openBtt;
        private System.Windows.Forms.Button close;
        public System.Windows.Forms.RichTextBox outTextBox;
        private System.Windows.Forms.ComboBox comPortList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button paramReadButton;
        private System.Windows.Forms.Button sectionReadButton;
        private System.Windows.Forms.Button meterCmdButton;
        public System.Windows.Forms.RichTextBox allParamTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button startCmdButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button stopCmdButton;
        private System.Windows.Forms.CheckBox paramReadСheckBox;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Button readSettingsButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownByte5;
        private System.Windows.Forms.NumericUpDown numericUpDownByte4;
        private System.Windows.Forms.NumericUpDown numericUpDownByte3;
        private System.Windows.Forms.NumericUpDown numericUpDownByte2;
        private System.Windows.Forms.NumericUpDown numericUpDownByte1;
        private System.Windows.Forms.NumericUpDown numericUpDownByte0;
    }
}

