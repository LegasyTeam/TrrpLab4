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
            this.labelValHdr = new System.Windows.Forms.Label();
            this.btnExch = new System.Windows.Forms.Button();
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
            this.label1 = new System.Windows.Forms.Label();
            this.gbWallet = new System.Windows.Forms.GroupBox();
            this.gbExch = new System.Windows.Forms.GroupBox();
            this.labelExchHdr4 = new System.Windows.Forms.Label();
            this.labelExchHdr2 = new System.Windows.Forms.Label();
            this.labelExchHdr3 = new System.Windows.Forms.Label();
            this.labelExchHdr = new System.Windows.Forms.Label();
            this.tbExchTo = new System.Windows.Forms.TextBox();
            this.cbExchTo = new System.Windows.Forms.ComboBox();
            this.tbExchFrom = new System.Windows.Forms.TextBox();
            this.cbExchFrom = new System.Windows.Forms.ComboBox();
            this.gbCourse.SuspendLayout();
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
            // btnExch
            // 
            this.btnExch.Location = new System.Drawing.Point(174, 152);
            this.btnExch.Name = "btnExch";
            this.btnExch.Size = new System.Drawing.Size(75, 23);
            this.btnExch.TabIndex = 1;
            this.btnExch.Text = "Обменять";
            this.btnExch.UseVisualStyleBackColor = true;
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
            this.labelWalHdr.Location = new System.Drawing.Point(502, 23);
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
            this.labelWalRubHdr.Location = new System.Drawing.Point(509, 93);
            this.labelWalRubHdr.Name = "labelWalRubHdr";
            this.labelWalRubHdr.Size = new System.Drawing.Size(55, 29);
            this.labelWalRubHdr.TabIndex = 7;
            this.labelWalRubHdr.Text = "RUB";
            // 
            // labelWalUsdValue
            // 
            this.labelWalUsdValue.AutoSize = true;
            this.labelWalUsdValue.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWalUsdValue.Location = new System.Drawing.Point(647, 134);
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
            this.labelWalUsdHdr.Location = new System.Drawing.Point(509, 134);
            this.labelWalUsdHdr.Name = "labelWalUsdHdr";
            this.labelWalUsdHdr.Size = new System.Drawing.Size(54, 29);
            this.labelWalUsdHdr.TabIndex = 9;
            this.labelWalUsdHdr.Text = "USD";
            // 
            // labelWalEurValue
            // 
            this.labelWalEurValue.AutoSize = true;
            this.labelWalEurValue.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWalEurValue.Location = new System.Drawing.Point(647, 175);
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
            this.labelWalEurHdr.Location = new System.Drawing.Point(509, 175);
            this.labelWalEurHdr.Name = "labelWalEurHdr";
            this.labelWalEurHdr.Size = new System.Drawing.Size(54, 29);
            this.labelWalEurHdr.TabIndex = 11;
            this.labelWalEurHdr.Text = "EUR";
            // 
            // gbCourse
            // 
            this.gbCourse.Controls.Add(this.label1);
            this.gbCourse.Controls.Add(this.labelValHdr);
            this.gbCourse.Controls.Add(this.labelUsdHdr);
            this.gbCourse.Controls.Add(this.labelEurHdr);
            this.gbCourse.Controls.Add(this.labelUsdVal);
            this.gbCourse.Controls.Add(this.labelEurVal);
            this.gbCourse.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbCourse.Location = new System.Drawing.Point(0, 0);
            this.gbCourse.Name = "gbCourse";
            this.gbCourse.Size = new System.Drawing.Size(415, 461);
            this.gbCourse.TabIndex = 13;
            this.gbCourse.TabStop = false;
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
            this.gbWallet.Controls.Add(this.gbExch);
            this.gbWallet.Controls.Add(this.labelWalRubValue);
            this.gbWallet.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbWallet.Location = new System.Drawing.Point(415, 0);
            this.gbWallet.Name = "gbWallet";
            this.gbWallet.Size = new System.Drawing.Size(419, 461);
            this.gbWallet.TabIndex = 14;
            this.gbWallet.TabStop = false;
            // 
            // gbExch
            // 
            this.gbExch.Controls.Add(this.labelExchHdr4);
            this.gbExch.Controls.Add(this.labelExchHdr2);
            this.gbExch.Controls.Add(this.labelExchHdr3);
            this.gbExch.Controls.Add(this.labelExchHdr);
            this.gbExch.Controls.Add(this.tbExchTo);
            this.gbExch.Controls.Add(this.cbExchTo);
            this.gbExch.Controls.Add(this.tbExchFrom);
            this.gbExch.Controls.Add(this.cbExchFrom);
            this.gbExch.Controls.Add(this.btnExch);
            this.gbExch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbExch.Location = new System.Drawing.Point(3, 274);
            this.gbExch.Name = "gbExch";
            this.gbExch.Size = new System.Drawing.Size(413, 184);
            this.gbExch.TabIndex = 0;
            this.gbExch.TabStop = false;
            this.gbExch.Text = "Обмен валют";
            // 
            // labelExchHdr4
            // 
            this.labelExchHdr4.AutoSize = true;
            this.labelExchHdr4.Location = new System.Drawing.Point(191, 96);
            this.labelExchHdr4.Name = "labelExchHdr4";
            this.labelExchHdr4.Size = new System.Drawing.Size(53, 13);
            this.labelExchHdr4.TabIndex = 9;
            this.labelExchHdr4.Text = "Сколько:";
            // 
            // labelExchHdr2
            // 
            this.labelExchHdr2.AutoSize = true;
            this.labelExchHdr2.Location = new System.Drawing.Point(98, 96);
            this.labelExchHdr2.Name = "labelExchHdr2";
            this.labelExchHdr2.Size = new System.Drawing.Size(21, 13);
            this.labelExchHdr2.TabIndex = 8;
            this.labelExchHdr2.Text = "На";
            // 
            // labelExchHdr3
            // 
            this.labelExchHdr3.AutoSize = true;
            this.labelExchHdr3.Location = new System.Drawing.Point(191, 52);
            this.labelExchHdr3.Name = "labelExchHdr3";
            this.labelExchHdr3.Size = new System.Drawing.Size(53, 13);
            this.labelExchHdr3.TabIndex = 7;
            this.labelExchHdr3.Text = "Сколько:";
            // 
            // labelExchHdr
            // 
            this.labelExchHdr.AutoSize = true;
            this.labelExchHdr.Location = new System.Drawing.Point(61, 52);
            this.labelExchHdr.Name = "labelExchHdr";
            this.labelExchHdr.Size = new System.Drawing.Size(58, 13);
            this.labelExchHdr.TabIndex = 6;
            this.labelExchHdr.Text = "Обменять";
            // 
            // tbExchTo
            // 
            this.tbExchTo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbExchTo.Location = new System.Drawing.Point(245, 93);
            this.tbExchTo.Name = "tbExchTo";
            this.tbExchTo.ReadOnly = true;
            this.tbExchTo.Size = new System.Drawing.Size(92, 20);
            this.tbExchTo.TabIndex = 5;
            this.tbExchTo.Text = "0";
            this.tbExchTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExchFrom_KeyPress);
            // 
            // cbExchTo
            // 
            this.cbExchTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExchTo.FormattingEnabled = true;
            this.cbExchTo.Items.AddRange(new object[] {
            "RUB",
            "USD",
            "EUR"});
            this.cbExchTo.Location = new System.Drawing.Point(125, 93);
            this.cbExchTo.Name = "cbExchTo";
            this.cbExchTo.Size = new System.Drawing.Size(62, 21);
            this.cbExchTo.TabIndex = 4;
            this.cbExchTo.SelectedIndexChanged += new System.EventHandler(this.cbExchFrom_SelectedIndexChanged);
            // 
            // tbExchFrom
            // 
            this.tbExchFrom.Location = new System.Drawing.Point(245, 49);
            this.tbExchFrom.Name = "tbExchFrom";
            this.tbExchFrom.Size = new System.Drawing.Size(92, 20);
            this.tbExchFrom.TabIndex = 3;
            this.tbExchFrom.Text = "0";
            this.tbExchFrom.TextChanged += new System.EventHandler(this.tbExchFrom_TextChanged);
            this.tbExchFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExchFrom_KeyPress);
            // 
            // cbExchFrom
            // 
            this.cbExchFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExchFrom.FormattingEnabled = true;
            this.cbExchFrom.Items.AddRange(new object[] {
            "RUB",
            "USD",
            "EUR"});
            this.cbExchFrom.Location = new System.Drawing.Point(125, 49);
            this.cbExchFrom.Name = "cbExchFrom";
            this.cbExchFrom.Size = new System.Drawing.Size(62, 21);
            this.cbExchFrom.TabIndex = 2;
            this.cbExchFrom.SelectedIndexChanged += new System.EventHandler(this.cbExchFrom_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.labelWalEurValue);
            this.Controls.Add(this.labelWalEurHdr);
            this.Controls.Add(this.labelWalUsdValue);
            this.Controls.Add(this.labelWalUsdHdr);
            this.Controls.Add(this.labelWalRubHdr);
            this.Controls.Add(this.labelWalHdr);
            this.Controls.Add(this.gbCourse);
            this.Controls.Add(this.gbWallet);
            this.MaximumSize = new System.Drawing.Size(850, 500);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbCourse.ResumeLayout(false);
            this.gbCourse.PerformLayout();
            this.gbWallet.ResumeLayout(false);
            this.gbWallet.PerformLayout();
            this.gbExch.ResumeLayout(false);
            this.gbExch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelValHdr;
        private System.Windows.Forms.Button btnExch;
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
        private System.Windows.Forms.TextBox tbExchTo;
        private System.Windows.Forms.ComboBox cbExchTo;
        private System.Windows.Forms.TextBox tbExchFrom;
        private System.Windows.Forms.ComboBox cbExchFrom;
        private System.Windows.Forms.Label labelExchHdr4;
        private System.Windows.Forms.Label labelExchHdr2;
        private System.Windows.Forms.Label label1;
    }
}