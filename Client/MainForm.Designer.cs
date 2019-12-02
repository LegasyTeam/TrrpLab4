namespace WindowsFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelValHdr = new System.Windows.Forms.Label();
            this.btnSell = new System.Windows.Forms.Button();
            this.labelUsdHdr = new System.Windows.Forms.Label();
            this.labelEurHdr = new System.Windows.Forms.Label();
            this.labelUsdVal = new System.Windows.Forms.Label();
            this.labelEurVal = new System.Windows.Forms.Label();
            this.labelWalHdr = new System.Windows.Forms.Label();
            this.labelWalRubValue = new System.Windows.Forms.Label();
            this.labelWalRubHdr = new System.Windows.Forms.Label();
            this.labelWalUsdValue = new System.Windows.Forms.Label();
            this.labelWalUsdHdr = new System.Windows.Forms.Label();
            this.labelWalEurValue = new System.Windows.Forms.Label();
            this.labelWalEurHdr = new System.Windows.Forms.Label();
            this.gbCourse = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbEUR = new System.Windows.Forms.RadioButton();
            this.rbUSD = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBMonth = new System.Windows.Forms.RadioButton();
            this.rBYear = new System.Windows.Forms.RadioButton();
            this.rBWeek = new System.Windows.Forms.RadioButton();
            this.chartChanges = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.gbWallet = new System.Windows.Forms.GroupBox();
            this.gbExch = new System.Windows.Forms.GroupBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.labelExchHdr4 = new System.Windows.Forms.Label();
            this.labelExchHdr2 = new System.Windows.Forms.Label();
            this.labelExchHdr3 = new System.Windows.Forms.Label();
            this.labelExchHdr = new System.Windows.Forms.Label();
            this.tbSellValue = new System.Windows.Forms.TextBox();
            this.cbSell = new System.Windows.Forms.ComboBox();
            this.tbBuyValue = new System.Windows.Forms.TextBox();
            this.cbBuy = new System.Windows.Forms.ComboBox();
            this.gbCourse.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartChanges)).BeginInit();
            this.gbWallet.SuspendLayout();
            this.gbExch.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelValHdr
            // 
            this.labelValHdr.AutoSize = true;
            this.labelValHdr.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelValHdr.Location = new System.Drawing.Point(67, 23);
            this.labelValHdr.Name = "labelValHdr";
            this.labelValHdr.Size = new System.Drawing.Size(252, 41);
            this.labelValHdr.TabIndex = 0;
            this.labelValHdr.Text = "Курсы валют";
            // 
            // btnSell
            // 
            this.btnSell.Enabled = false;
            this.btnSell.Location = new System.Drawing.Point(329, 91);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(75, 23);
            this.btnSell.TabIndex = 1;
            this.btnSell.Text = "Продать";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // labelUsdHdr
            // 
            this.labelUsdHdr.AutoSize = true;
            this.labelUsdHdr.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUsdHdr.Location = new System.Drawing.Point(68, 93);
            this.labelUsdHdr.Name = "labelUsdHdr";
            this.labelUsdHdr.Size = new System.Drawing.Size(54, 29);
            this.labelUsdHdr.TabIndex = 2;
            this.labelUsdHdr.Text = "USD";
            // 
            // labelEurHdr
            // 
            this.labelEurHdr.AutoSize = true;
            this.labelEurHdr.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEurHdr.Location = new System.Drawing.Point(68, 134);
            this.labelEurHdr.Name = "labelEurHdr";
            this.labelEurHdr.Size = new System.Drawing.Size(54, 29);
            this.labelEurHdr.TabIndex = 3;
            this.labelEurHdr.Text = "EUR";
            // 
            // labelUsdVal
            // 
            this.labelUsdVal.AutoSize = true;
            this.labelUsdVal.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUsdVal.Location = new System.Drawing.Point(206, 93);
            this.labelUsdVal.Name = "labelUsdVal";
            this.labelUsdVal.Size = new System.Drawing.Size(113, 29);
            this.labelUsdVal.TabIndex = 4;
            this.labelUsdVal.Text = "Загрузка...";
            this.labelUsdVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEurVal
            // 
            this.labelEurVal.AutoSize = true;
            this.labelEurVal.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEurVal.Location = new System.Drawing.Point(206, 134);
            this.labelEurVal.Name = "labelEurVal";
            this.labelEurVal.Size = new System.Drawing.Size(113, 29);
            this.labelEurVal.TabIndex = 5;
            this.labelEurVal.Text = "Загрузка...";
            this.labelEurVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelWalHdr
            // 
            this.labelWalHdr.AutoSize = true;
            this.labelWalHdr.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWalHdr.Location = new System.Drawing.Point(92, 23);
            this.labelWalHdr.Name = "labelWalHdr";
            this.labelWalHdr.Size = new System.Drawing.Size(258, 41);
            this.labelWalHdr.TabIndex = 6;
            this.labelWalHdr.Text = "Ваш кошелек";
            // 
            // labelWalRubValue
            // 
            this.labelWalRubValue.AutoSize = true;
            this.labelWalRubValue.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWalRubValue.Location = new System.Drawing.Point(232, 93);
            this.labelWalRubValue.Name = "labelWalRubValue";
            this.labelWalRubValue.Size = new System.Drawing.Size(113, 29);
            this.labelWalRubValue.TabIndex = 8;
            this.labelWalRubValue.Text = "Загрузка...";
            this.labelWalRubValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelWalRubHdr
            // 
            this.labelWalRubHdr.AutoSize = true;
            this.labelWalRubHdr.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWalRubHdr.Location = new System.Drawing.Point(94, 93);
            this.labelWalRubHdr.Name = "labelWalRubHdr";
            this.labelWalRubHdr.Size = new System.Drawing.Size(55, 29);
            this.labelWalRubHdr.TabIndex = 7;
            this.labelWalRubHdr.Text = "RUB";
            // 
            // labelWalUsdValue
            // 
            this.labelWalUsdValue.AutoSize = true;
            this.labelWalUsdValue.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWalUsdValue.Location = new System.Drawing.Point(232, 134);
            this.labelWalUsdValue.Name = "labelWalUsdValue";
            this.labelWalUsdValue.Size = new System.Drawing.Size(113, 29);
            this.labelWalUsdValue.TabIndex = 10;
            this.labelWalUsdValue.Text = "Загрузка...";
            this.labelWalUsdValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelWalUsdHdr
            // 
            this.labelWalUsdHdr.AutoSize = true;
            this.labelWalUsdHdr.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWalUsdHdr.Location = new System.Drawing.Point(94, 134);
            this.labelWalUsdHdr.Name = "labelWalUsdHdr";
            this.labelWalUsdHdr.Size = new System.Drawing.Size(54, 29);
            this.labelWalUsdHdr.TabIndex = 9;
            this.labelWalUsdHdr.Text = "USD";
            // 
            // labelWalEurValue
            // 
            this.labelWalEurValue.AutoSize = true;
            this.labelWalEurValue.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWalEurValue.Location = new System.Drawing.Point(232, 175);
            this.labelWalEurValue.Name = "labelWalEurValue";
            this.labelWalEurValue.Size = new System.Drawing.Size(113, 29);
            this.labelWalEurValue.TabIndex = 12;
            this.labelWalEurValue.Text = "Загрузка...";
            this.labelWalEurValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelWalEurHdr
            // 
            this.labelWalEurHdr.AutoSize = true;
            this.labelWalEurHdr.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWalEurHdr.Location = new System.Drawing.Point(94, 175);
            this.labelWalEurHdr.Name = "labelWalEurHdr";
            this.labelWalEurHdr.Size = new System.Drawing.Size(54, 29);
            this.labelWalEurHdr.TabIndex = 11;
            this.labelWalEurHdr.Text = "EUR";
            // 
            // gbCourse
            // 
            this.gbCourse.Controls.Add(this.groupBox2);
            this.gbCourse.Controls.Add(this.groupBox1);
            this.gbCourse.Controls.Add(this.chartChanges);
            this.gbCourse.Controls.Add(this.label1);
            this.gbCourse.Controls.Add(this.labelValHdr);
            this.gbCourse.Controls.Add(this.labelUsdHdr);
            this.gbCourse.Controls.Add(this.labelEurHdr);
            this.gbCourse.Controls.Add(this.labelUsdVal);
            this.gbCourse.Controls.Add(this.labelEurVal);
            this.gbCourse.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbCourse.Location = new System.Drawing.Point(0, 0);
            this.gbCourse.Name = "gbCourse";
            this.gbCourse.Size = new System.Drawing.Size(509, 461);
            this.gbCourse.TabIndex = 13;
            this.gbCourse.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbEUR);
            this.groupBox2.Controls.Add(this.rbUSD);
            this.groupBox2.Location = new System.Drawing.Point(372, 351);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 98);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // rbEUR
            // 
            this.rbEUR.AutoSize = true;
            this.rbEUR.Location = new System.Drawing.Point(6, 42);
            this.rbEUR.Name = "rbEUR";
            this.rbEUR.Size = new System.Drawing.Size(48, 17);
            this.rbEUR.TabIndex = 1;
            this.rbEUR.Tag = "";
            this.rbEUR.Text = "EUR";
            this.rbEUR.UseVisualStyleBackColor = true;
            this.rbEUR.CheckedChanged += new System.EventHandler(this.rBWeek_CheckedChanged);
            // 
            // rbUSD
            // 
            this.rbUSD.AutoSize = true;
            this.rbUSD.Checked = true;
            this.rbUSD.Location = new System.Drawing.Point(6, 19);
            this.rbUSD.Name = "rbUSD";
            this.rbUSD.Size = new System.Drawing.Size(48, 17);
            this.rbUSD.TabIndex = 0;
            this.rbUSD.TabStop = true;
            this.rbUSD.Tag = "";
            this.rbUSD.Text = "USD";
            this.rbUSD.UseVisualStyleBackColor = true;
            this.rbUSD.CheckedChanged += new System.EventHandler(this.rBWeek_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBMonth);
            this.groupBox1.Controls.Add(this.rBYear);
            this.groupBox1.Controls.Add(this.rBWeek);
            this.groupBox1.Location = new System.Drawing.Point(371, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 99);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // rBMonth
            // 
            this.rBMonth.AutoSize = true;
            this.rBMonth.Location = new System.Drawing.Point(6, 42);
            this.rBMonth.Name = "rBMonth";
            this.rBMonth.Size = new System.Drawing.Size(73, 17);
            this.rBMonth.TabIndex = 2;
            this.rBMonth.TabStop = true;
            this.rBMonth.Text = "За месяц";
            this.rBMonth.UseVisualStyleBackColor = true;
            this.rBMonth.CheckedChanged += new System.EventHandler(this.rBWeek_CheckedChanged);
            // 
            // rBYear
            // 
            this.rBYear.AutoSize = true;
            this.rBYear.Location = new System.Drawing.Point(6, 65);
            this.rBYear.Name = "rBYear";
            this.rBYear.Size = new System.Drawing.Size(58, 17);
            this.rBYear.TabIndex = 1;
            this.rBYear.TabStop = true;
            this.rBYear.Text = "За год";
            this.rBYear.UseVisualStyleBackColor = true;
            this.rBYear.CheckedChanged += new System.EventHandler(this.rBWeek_CheckedChanged);
            // 
            // rBWeek
            // 
            this.rBWeek.AutoSize = true;
            this.rBWeek.Checked = true;
            this.rBWeek.Location = new System.Drawing.Point(6, 19);
            this.rBWeek.Name = "rBWeek";
            this.rBWeek.Size = new System.Drawing.Size(79, 17);
            this.rBWeek.TabIndex = 0;
            this.rBWeek.TabStop = true;
            this.rBWeek.Text = "За неделю";
            this.rBWeek.UseVisualStyleBackColor = true;
            this.rBWeek.CheckedChanged += new System.EventHandler(this.rBWeek_CheckedChanged);
            // 
            // chartChanges
            // 
            chartArea1.Name = "ChartArea1";
            this.chartChanges.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartChanges.Legends.Add(legend1);
            this.chartChanges.Location = new System.Drawing.Point(37, 245);
            this.chartChanges.Name = "chartChanges";
            this.chartChanges.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "USD";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "EUR";
            this.chartChanges.Series.Add(series1);
            this.chartChanges.Series.Add(series2);
            this.chartChanges.Size = new System.Drawing.Size(328, 204);
            this.chartChanges.TabIndex = 7;
            this.chartChanges.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 41);
            this.label1.TabIndex = 6;
            this.label1.Text = "График изменения";
            // 
            // gbWallet
            // 
            this.gbWallet.Controls.Add(this.labelWalEurValue);
            this.gbWallet.Controls.Add(this.gbExch);
            this.gbWallet.Controls.Add(this.labelWalEurHdr);
            this.gbWallet.Controls.Add(this.labelWalRubValue);
            this.gbWallet.Controls.Add(this.labelWalUsdValue);
            this.gbWallet.Controls.Add(this.labelWalUsdHdr);
            this.gbWallet.Controls.Add(this.labelWalHdr);
            this.gbWallet.Controls.Add(this.labelWalRubHdr);
            this.gbWallet.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbWallet.Location = new System.Drawing.Point(515, 0);
            this.gbWallet.Name = "gbWallet";
            this.gbWallet.Size = new System.Drawing.Size(419, 461);
            this.gbWallet.TabIndex = 14;
            this.gbWallet.TabStop = false;
            // 
            // gbExch
            // 
            this.gbExch.Controls.Add(this.btnBuy);
            this.gbExch.Controls.Add(this.labelExchHdr4);
            this.gbExch.Controls.Add(this.labelExchHdr2);
            this.gbExch.Controls.Add(this.labelExchHdr3);
            this.gbExch.Controls.Add(this.labelExchHdr);
            this.gbExch.Controls.Add(this.tbSellValue);
            this.gbExch.Controls.Add(this.cbSell);
            this.gbExch.Controls.Add(this.tbBuyValue);
            this.gbExch.Controls.Add(this.cbBuy);
            this.gbExch.Controls.Add(this.btnSell);
            this.gbExch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbExch.Location = new System.Drawing.Point(3, 274);
            this.gbExch.Name = "gbExch";
            this.gbExch.Size = new System.Drawing.Size(413, 184);
            this.gbExch.TabIndex = 0;
            this.gbExch.TabStop = false;
            this.gbExch.Text = "Обмен валют";
            // 
            // btnBuy
            // 
            this.btnBuy.Enabled = false;
            this.btnBuy.Location = new System.Drawing.Point(329, 46);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 10;
            this.btnBuy.Text = "Купить";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // labelExchHdr4
            // 
            this.labelExchHdr4.AutoSize = true;
            this.labelExchHdr4.Location = new System.Drawing.Point(162, 96);
            this.labelExchHdr4.Name = "labelExchHdr4";
            this.labelExchHdr4.Size = new System.Drawing.Size(53, 13);
            this.labelExchHdr4.TabIndex = 9;
            this.labelExchHdr4.Text = "Сколько:";
            // 
            // labelExchHdr2
            // 
            this.labelExchHdr2.AutoSize = true;
            this.labelExchHdr2.Location = new System.Drawing.Point(32, 96);
            this.labelExchHdr2.Name = "labelExchHdr2";
            this.labelExchHdr2.Size = new System.Drawing.Size(50, 13);
            this.labelExchHdr2.TabIndex = 8;
            this.labelExchHdr2.Text = "Продать";
            // 
            // labelExchHdr3
            // 
            this.labelExchHdr3.AutoSize = true;
            this.labelExchHdr3.Location = new System.Drawing.Point(162, 52);
            this.labelExchHdr3.Name = "labelExchHdr3";
            this.labelExchHdr3.Size = new System.Drawing.Size(53, 13);
            this.labelExchHdr3.TabIndex = 7;
            this.labelExchHdr3.Text = "Сколько:";
            // 
            // labelExchHdr
            // 
            this.labelExchHdr.AutoSize = true;
            this.labelExchHdr.Location = new System.Drawing.Point(32, 52);
            this.labelExchHdr.Name = "labelExchHdr";
            this.labelExchHdr.Size = new System.Drawing.Size(42, 13);
            this.labelExchHdr.TabIndex = 6;
            this.labelExchHdr.Text = "Купить";
            // 
            // tbSellValue
            // 
            this.tbSellValue.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbSellValue.Location = new System.Drawing.Point(216, 93);
            this.tbSellValue.Name = "tbSellValue";
            this.tbSellValue.Size = new System.Drawing.Size(92, 20);
            this.tbSellValue.TabIndex = 5;
            this.tbSellValue.Text = "0";
            this.tbSellValue.TextChanged += new System.EventHandler(this.tbSellValue_TextChanged);
            this.tbSellValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExchFrom_KeyPress);
            // 
            // cbSell
            // 
            this.cbSell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSell.FormattingEnabled = true;
            this.cbSell.Items.AddRange(new object[] {
            "USD",
            "EUR"});
            this.cbSell.Location = new System.Drawing.Point(96, 93);
            this.cbSell.Name = "cbSell";
            this.cbSell.Size = new System.Drawing.Size(62, 21);
            this.cbSell.TabIndex = 4;
            // 
            // tbBuyValue
            // 
            this.tbBuyValue.Location = new System.Drawing.Point(216, 49);
            this.tbBuyValue.Name = "tbBuyValue";
            this.tbBuyValue.Size = new System.Drawing.Size(92, 20);
            this.tbBuyValue.TabIndex = 3;
            this.tbBuyValue.Text = "0";
            this.tbBuyValue.TextChanged += new System.EventHandler(this.tbBuyValue_TextChanged);
            this.tbBuyValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExchFrom_KeyPress);
            // 
            // cbBuy
            // 
            this.cbBuy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBuy.FormattingEnabled = true;
            this.cbBuy.Items.AddRange(new object[] {
            "USD",
            "EUR"});
            this.cbBuy.Location = new System.Drawing.Point(96, 49);
            this.cbBuy.Name = "cbBuy";
            this.cbBuy.Size = new System.Drawing.Size(62, 21);
            this.cbBuy.TabIndex = 2;
            this.cbBuy.SelectedIndexChanged += new System.EventHandler(this.cbBuy_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 461);
            this.Controls.Add(this.gbCourse);
            this.Controls.Add(this.gbWallet);
            this.MaximumSize = new System.Drawing.Size(950, 500);
            this.MinimumSize = new System.Drawing.Size(950, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbCourse.ResumeLayout(false);
            this.gbCourse.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartChanges)).EndInit();
            this.gbWallet.ResumeLayout(false);
            this.gbWallet.PerformLayout();
            this.gbExch.ResumeLayout(false);
            this.gbExch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelValHdr;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Label labelUsdHdr;
        private System.Windows.Forms.Label labelEurHdr;
        private System.Windows.Forms.Label labelUsdVal;
        private System.Windows.Forms.Label labelEurVal;
        private System.Windows.Forms.Label labelWalHdr;
        private System.Windows.Forms.Label labelWalRubValue;
        private System.Windows.Forms.Label labelWalRubHdr;
        private System.Windows.Forms.Label labelWalUsdValue;
        private System.Windows.Forms.Label labelWalUsdHdr;
        private System.Windows.Forms.Label labelWalEurValue;
        private System.Windows.Forms.Label labelWalEurHdr;
        private System.Windows.Forms.GroupBox gbCourse;
        private System.Windows.Forms.GroupBox gbWallet;
        private System.Windows.Forms.GroupBox gbExch;
        private System.Windows.Forms.Label labelExchHdr3;
        private System.Windows.Forms.Label labelExchHdr;
        private System.Windows.Forms.TextBox tbSellValue;
        private System.Windows.Forms.ComboBox cbSell;
        private System.Windows.Forms.TextBox tbBuyValue;
        private System.Windows.Forms.ComboBox cbBuy;
        private System.Windows.Forms.Label labelExchHdr4;
        private System.Windows.Forms.Label labelExchHdr2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartChanges;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBMonth;
        private System.Windows.Forms.RadioButton rBYear;
        private System.Windows.Forms.RadioButton rBWeek;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbEUR;
        private System.Windows.Forms.RadioButton rbUSD;
    }
}