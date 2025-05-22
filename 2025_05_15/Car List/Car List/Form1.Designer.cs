namespace Car_List
{
    partial class Form1
    {
        /// <summary>
        /// 必要的設計工具變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 釋放正在使用的資源。
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

        #region Windows Form Designer generated code

        /// <summary>
        /// 設計工具所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.carInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.mileageTextBox = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.makeTextBox = new System.Windows.Forms.TextBox();
            this.mileageLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.makeLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.carListBox = new System.Windows.Forms.ListBox();
            this.displayButton = new System.Windows.Forms.Button();
            this.carInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // carInfoGroupBox
            // 
            // 群組方塊：用來包含汽車資訊的輸入欄位
            this.carInfoGroupBox.Controls.Add(this.mileageTextBox);
            this.carInfoGroupBox.Controls.Add(this.yearTextBox);
            this.carInfoGroupBox.Controls.Add(this.makeTextBox);
            this.carInfoGroupBox.Controls.Add(this.mileageLabel);
            this.carInfoGroupBox.Controls.Add(this.yearLabel);
            this.carInfoGroupBox.Controls.Add(this.makeLabel);
            this.carInfoGroupBox.Location = new System.Drawing.Point(12, 16);
            this.carInfoGroupBox.Name = "carInfoGroupBox";
            this.carInfoGroupBox.Size = new System.Drawing.Size(200, 97);
            this.carInfoGroupBox.TabIndex = 0;
            this.carInfoGroupBox.TabStop = false;
            this.carInfoGroupBox.Text = "汽車資訊";
            // 
            // mileageTextBox
            // 
            // 文字方塊：輸入汽車的里程數
            this.mileageTextBox.Location = new System.Drawing.Point(81, 66);
            this.mileageTextBox.Name = "mileageTextBox";
            this.mileageTextBox.Size = new System.Drawing.Size(100, 22);
            this.mileageTextBox.TabIndex = 5;
            // 
            // yearTextBox
            // 
            // 文字方塊：輸入汽車的年份
            this.yearTextBox.Location = new System.Drawing.Point(81, 42);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(100, 22);
            this.yearTextBox.TabIndex = 4;
            // 
            // makeTextBox
            // 
            // 文字方塊：輸入汽車的品牌
            this.makeTextBox.Location = new System.Drawing.Point(81, 18);
            this.makeTextBox.Name = "makeTextBox";
            this.makeTextBox.Size = new System.Drawing.Size(100, 22);
            this.makeTextBox.TabIndex = 3;
            // 
            // mileageLabel
            // 
            // 標籤：顯示「里程數：」文字
            this.mileageLabel.AutoSize = true;
            this.mileageLabel.Location = new System.Drawing.Point(19, 68);
            this.mileageLabel.Name = "mileageLabel";
            this.mileageLabel.Size = new System.Drawing.Size(53, 12);
            this.mileageLabel.TabIndex = 2;
            this.mileageLabel.Text = "里程數：";
            // 
            // yearLabel
            // 
            // 標籤：顯示「年份：」文字
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(34, 44);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(41, 12);
            this.yearLabel.TabIndex = 1;
            this.yearLabel.Text = "年份：";
            // 
            // makeLabel
            // 
            // 標籤：顯示「品牌：」文字
            this.makeLabel.AutoSize = true;
            this.makeLabel.Location = new System.Drawing.Point(34, 20);
            this.makeLabel.Name = "makeLabel";
            this.makeLabel.Size = new System.Drawing.Size(41, 12);
            this.makeLabel.TabIndex = 0;
            this.makeLabel.Text = "品牌：";
            // 
            // addButton
            // 
            // 按鈕：將輸入的汽車資料新增到清單
            this.addButton.Location = new System.Drawing.Point(75, 131);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 32);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "新增";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // carListBox
            // 
            // 清單方塊：顯示所有已新增的汽車資料
            this.carListBox.FormattingEnabled = true;
            this.carListBox.ItemHeight = 12;
            this.carListBox.Location = new System.Drawing.Point(238, 25);
            this.carListBox.Name = "carListBox";
            this.carListBox.Size = new System.Drawing.Size(207, 88);
            this.carListBox.TabIndex = 2;
            // 
            // displayButton
            // 
            // 按鈕：顯示所有汽車資料
            this.displayButton.Location = new System.Drawing.Point(304, 131);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(75, 32);
            this.displayButton.TabIndex = 3;
            this.displayButton.Text = "顯示";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // Form1
            // 
            // 主視窗設定
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 179);
            this.Controls.Add(this.displayButton);
            this.Controls.Add(this.carListBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.carInfoGroupBox);
            this.Name = "Form1";
            this.Text = "汽車清單管理";
            this.carInfoGroupBox.ResumeLayout(false);
            this.carInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // 群組方塊：用來包含汽車資訊的輸入欄位
        private System.Windows.Forms.GroupBox carInfoGroupBox;
        // 文字方塊：輸入汽車的里程數
        private System.Windows.Forms.TextBox mileageTextBox;
        // 文字方塊：輸入汽車的年份
        private System.Windows.Forms.TextBox yearTextBox;
        // 文字方塊：輸入汽車的品牌
        private System.Windows.Forms.TextBox makeTextBox;
        // 標籤：顯示「里程數：」文字
        private System.Windows.Forms.Label mileageLabel;
        // 標籤：顯示「年份：」文字
        private System.Windows.Forms.Label yearLabel;
        // 標籤：顯示「品牌：」文字
        private System.Windows.Forms.Label makeLabel;
        // 按鈕：將輸入的汽車資料新增到清單
        private System.Windows.Forms.Button addButton;
        // 清單方塊：顯示所有已新增的汽車資料
        private System.Windows.Forms.ListBox carListBox;
        // 按鈕：顯示所有汽車資料
        private System.Windows.Forms.Button displayButton;
    }
}

