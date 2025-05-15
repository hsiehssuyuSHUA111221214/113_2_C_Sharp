namespace Telephone_Unformat
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 釋放使用中的資源
        /// </summary>
        /// <param name="disposing">是否釋放 managed 資源</param>
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
        /// 初始化表單元件（由 Visual Studio 設計工具自動產生）
        /// </summary>
        private void InitializeComponent()
        {
            // 退出按鈕：按下可關閉應用程式
            this.exitButton = new System.Windows.Forms.Button();
            // 取消格式按鈕：按下後移除電話格式中的符號
            this.unformatButton = new System.Windows.Forms.Button();
            // 說明標籤：顯示操作提示或顯示取消格式後的結果
            this.instructionLabel = new System.Windows.Forms.Label();
            // 電話輸入框：輸入格式化的電話號碼 (XXX)XXX-XXXX
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(145, 106); // 按鈕位置
            this.exitButton.Name = "exitButton"; // 控制項名稱
            this.exitButton.Size = new System.Drawing.Size(75, 23); // 尺寸
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit"; // 顯示文字
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click); // 綁定事件

            // 
            // unformatButton
            // 
            this.unformatButton.Location = new System.Drawing.Point(64, 106);
            this.unformatButton.Name = "unformatButton";
            this.unformatButton.Size = new System.Drawing.Size(75, 23);
            this.unformatButton.TabIndex = 6;
            this.unformatButton.Text = "Unformat";
            this.unformatButton.UseVisualStyleBackColor = true;
            this.unformatButton.Click += new System.EventHandler(this.unformatButton_Click);

            // 
            // instructionLabel
            // 
            this.instructionLabel.Location = new System.Drawing.Point(12, 12);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(260, 40);
            this.instructionLabel.TabIndex = 5;
            this.instructionLabel.Text = "Enter a telephone number in the format (XXX)XXX-XXXX and I will unformat it.";
            this.instructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(92, 67);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(100, 20);
            this.numberTextBox.TabIndex = 4;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 140);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.unformatButton);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.numberTextBox);
            this.Name = "Form1";
            this.Text = "Telephone Unformat";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        /// <summary>
        /// [退出按鈕] - 關閉程式
        /// </summary>
        private System.Windows.Forms.Button exitButton;

        /// <summary>
        /// [取消格式按鈕] - 移除電話格式符號
        /// </summary>
        private System.Windows.Forms.Button unformatButton;

        /// <summary>
        /// [說明文字標籤] - 顯示提示或轉換結果
        /// </summary>
        private System.Windows.Forms.Label instructionLabel;

        /// <summary>
        /// [電話輸入欄位] - 輸入格式化電話號碼 (XXX)XXX-XXXX
        /// </summary>
        private System.Windows.Forms.TextBox numberTextBox;
    }
}
