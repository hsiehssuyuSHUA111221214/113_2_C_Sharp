namespace Color_Spectrum
{
    partial class Form1
    {
        /// <summary>
        /// 必要的設計工具變數。
        /// 此變數用於儲存設計階段所需的元件容器，確保元件能正確釋放與管理。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 釋放正在使用的資源。
        /// 當 disposing 參數為 true 時，會釋放所有受控資源；否則僅釋放非受控資源。
        /// </summary>
        /// <param name="disposing">如果應釋放受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 設計工具所需的方法，請勿以程式碼編輯器修改此方法的內容。
        /// 此方法負責初始化表單上的所有元件，並設定其屬性與事件。
        /// </summary>
        private void InitializeComponent()
        {
            this.promptLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.redLabel = new System.Windows.Forms.Label();
            this.orangeLabel = new System.Windows.Forms.Label();
            this.yellowLabel = new System.Windows.Forms.Label();
            this.greenLabel = new System.Windows.Forms.Label();
            this.blueLabel = new System.Windows.Forms.Label();
            this.indigoLabel = new System.Windows.Forms.Label();
            this.violetLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.Location = new System.Drawing.Point(147, 8);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(149, 12);
            this.promptLabel.TabIndex = 7;
            this.promptLabel.Text = "請選擇一個光譜中的顏色";
            // 
            // colorLabel
            // 
            this.colorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorLabel.Location = new System.Drawing.Point(172, 66);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(100, 21);
            this.colorLabel.TabIndex = 8;
            this.colorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // redLabel
            // 
            this.redLabel.BackColor = System.Drawing.Color.Red;
            this.redLabel.Location = new System.Drawing.Point(8, 30);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(56, 21);
            this.redLabel.TabIndex = 9;
            this.redLabel.Text = null;
            this.redLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.redLabel.Click += new System.EventHandler(this.redLabel_Click);
            // 
            // orangeLabel
            // 
            this.orangeLabel.BackColor = System.Drawing.Color.Orange;
            this.orangeLabel.Location = new System.Drawing.Point(70, 30);
            this.orangeLabel.Name = "orangeLabel";
            this.orangeLabel.Size = new System.Drawing.Size(56, 21);
            this.orangeLabel.TabIndex = 10;
            this.orangeLabel.Text = null;
            this.orangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.orangeLabel.Click += new System.EventHandler(this.orangeLabel_Click);
            // 
            // yellowLabel
            // 
            this.yellowLabel.BackColor = System.Drawing.Color.Yellow;
            this.yellowLabel.Location = new System.Drawing.Point(132, 30);
            this.yellowLabel.Name = "yellowLabel";
            this.yellowLabel.Size = new System.Drawing.Size(56, 21);
            this.yellowLabel.TabIndex = 11;
            this.yellowLabel.Text = null;
            this.yellowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.yellowLabel.Click += new System.EventHandler(this.yellowLabel_Click);
            // 
            // greenLabel
            // 
            this.greenLabel.BackColor = System.Drawing.Color.Green;
            this.greenLabel.Location = new System.Drawing.Point(194, 30);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(56, 21);
            this.greenLabel.TabIndex = 12;
            this.greenLabel.Text = null;
            this.greenLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.greenLabel.Click += new System.EventHandler(this.greenLabel_Click);
            // 
            // blueLabel
            // 
            this.blueLabel.BackColor = System.Drawing.Color.Blue;
            this.blueLabel.Location = new System.Drawing.Point(256, 30);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(56, 21);
            this.blueLabel.TabIndex = 13;
            this.blueLabel.Text = null;
            this.blueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.blueLabel.Click += new System.EventHandler(this.blueLabel_Click);
            // 
            // indigoLabel
            // 
            this.indigoLabel.BackColor = System.Drawing.Color.Indigo;
            this.indigoLabel.Location = new System.Drawing.Point(318, 30);
            this.indigoLabel.Name = "indigoLabel";
            this.indigoLabel.Size = new System.Drawing.Size(56, 21);
            this.indigoLabel.TabIndex = 14;
            this.indigoLabel.Text = null;
            this.indigoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.indigoLabel.Click += new System.EventHandler(this.indigoLabel_Click);
            // 
            // violetLabel
            // 
            this.violetLabel.BackColor = System.Drawing.Color.Violet;
            this.violetLabel.Location = new System.Drawing.Point(380, 30);
            this.violetLabel.Name = "violetLabel";
            this.violetLabel.Size = new System.Drawing.Size(56, 21);
            this.violetLabel.TabIndex = 15;
            this.violetLabel.Text = null;
            this.violetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.violetLabel.Click += new System.EventHandler(this.violetLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 111);
            this.Controls.Add(this.violetLabel);
            this.Controls.Add(this.indigoLabel);
            this.Controls.Add(this.blueLabel);
            this.Controls.Add(this.greenLabel);
            this.Controls.Add(this.yellowLabel);
            this.Controls.Add(this.orangeLabel);
            this.Controls.Add(this.redLabel);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.promptLabel);
            this.Name = "Form1";
            this.Text = "色彩光譜";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// 定義表單上的提示標籤元件，用於顯示操作指示。
        /// </summary>
        private System.Windows.Forms.Label promptLabel;
        /// <summary>
        /// 定義顏色顯示標籤元件，用於顯示目前選擇的顏色名稱。
        /// </summary>
        private System.Windows.Forms.Label colorLabel;
        /// <summary>
        /// 定義紅色標籤元件，代表紅色區塊，並可點擊選擇。
        /// </summary>
        private System.Windows.Forms.Label redLabel;
        /// <summary>
        /// 定義橙色標籤元件，代表橙色區塊，並可點擊選擇。
        /// </summary>
        private System.Windows.Forms.Label orangeLabel;
        /// <summary>
        /// 定義黃色標籤元件，代表黃色區塊，並可點擊選擇。
        /// </summary>
        private System.Windows.Forms.Label yellowLabel;
        /// <summary>
        /// 定義綠色標籤元件，代表綠色區塊，並可點擊選擇。
        /// </summary>
        private System.Windows.Forms.Label greenLabel;
        /// <summary>
        /// 定義藍色標籤元件，代表藍色區塊，並可點擊選擇。
        /// </summary>
        private System.Windows.Forms.Label blueLabel;
        /// <summary>
        /// 定義靛色標籤元件，代表靛色區塊，並可點擊選擇。
        /// </summary>
        private System.Windows.Forms.Label indigoLabel;
        /// <summary>
        /// 定義紫色標籤元件，代表紫色區塊，並可點擊選擇。
        /// </summary>
        private System.Windows.Forms.Label violetLabel;
    }
}

