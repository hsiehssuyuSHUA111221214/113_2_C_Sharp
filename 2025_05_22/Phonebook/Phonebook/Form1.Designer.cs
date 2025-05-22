using System;

namespace Phonebook
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
            // 當 disposing 為 true 時，釋放所有受控資源（如元件）。
            // 若 components 不為 null，則呼叫其 Dispose 方法釋放資源。
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            // 呼叫基底類別的 Dispose 方法，確保所有資源都正確釋放。
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 設計工具支援所需的方法，請勿使用程式碼編輯器修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.promptLabel = new System.Windows.Forms.Label();
            this.nameListBox = new System.Windows.Forms.ListBox();
            this.selectedPhoneDescriptionLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.新增通訊錄 = new System.Windows.Forms.GroupBox();
            this.addPhoneTextBox = new System.Windows.Forms.TextBox();
            this.addNameTextBox = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.電話號碼 = new System.Windows.Forms.Label();
            this.姓名 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.新增通訊錄.SuspendLayout();
            this.SuspendLayout();
            // 
            // promptLabel
            // 
            this.promptLabel.AutoSize = true;
            this.promptLabel.Location = new System.Drawing.Point(44, 11);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(65, 12);
            this.promptLabel.TabIndex = 0;
            this.promptLabel.Text = "請選擇姓名";
            // 
            // nameListBox
            // 
            this.nameListBox.FormattingEnabled = true;
            this.nameListBox.ItemHeight = 12;
            this.nameListBox.Location = new System.Drawing.Point(22, 26);
            this.nameListBox.Name = "nameListBox";
            this.nameListBox.Size = new System.Drawing.Size(120, 88);
            this.nameListBox.TabIndex = 1;
            this.nameListBox.SelectedIndexChanged += new System.EventHandler(this.nameListBox_SelectedIndexChanged);
            // 
            // selectedPhoneDescriptionLabel
            // 
            this.selectedPhoneDescriptionLabel.AutoSize = true;
            this.selectedPhoneDescriptionLabel.Location = new System.Drawing.Point(173, 41);
            this.selectedPhoneDescriptionLabel.Name = "selectedPhoneDescriptionLabel";
            this.selectedPhoneDescriptionLabel.Size = new System.Drawing.Size(53, 12);
            this.selectedPhoneDescriptionLabel.TabIndex = 2;
            this.selectedPhoneDescriptionLabel.Text = "電話號碼";
            // 
            // phoneLabel
            // 
            this.phoneLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phoneLabel.Location = new System.Drawing.Point(162, 66);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(159, 21);
            this.phoneLabel.TabIndex = 3;
            this.phoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(105, 141);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 21);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "離開";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // 新增通訊錄
            // 
            this.新增通訊錄.Controls.Add(this.addPhoneTextBox);
            this.新增通訊錄.Controls.Add(this.addNameTextBox);
            this.新增通訊錄.Controls.Add(this.add);
            this.新增通訊錄.Controls.Add(this.電話號碼);
            this.新增通訊錄.Controls.Add(this.姓名);
            this.新增通訊錄.Location = new System.Drawing.Point(344, 26);
            this.新增通訊錄.Name = "新增通訊錄";
            this.新增通訊錄.Size = new System.Drawing.Size(200, 151);
            this.新增通訊錄.TabIndex = 5;
            this.新增通訊錄.TabStop = false;
            this.新增通訊錄.Text = "新增通訊錄";
            // 
            // addPhoneTextBox
            // 
            this.addPhoneTextBox.Location = new System.Drawing.Point(66, 56);
            this.addPhoneTextBox.Name = "addPhoneTextBox";
            this.addPhoneTextBox.Size = new System.Drawing.Size(100, 22);
            this.addPhoneTextBox.TabIndex = 8;
            // 
            // addNameTextBox
            // 
            this.addNameTextBox.Location = new System.Drawing.Point(66, 21);
            this.addNameTextBox.Name = "addNameTextBox";
            this.addNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.addNameTextBox.TabIndex = 7;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(91, 115);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 21);
            this.add.TabIndex = 6;
            this.add.Text = "加入";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.Add_Click);
            // 
            // 電話號碼
            // 
            this.電話號碼.AutoSize = true;
            this.電話號碼.Location = new System.Drawing.Point(7, 59);
            this.電話號碼.Name = "電話號碼";
            this.電話號碼.Size = new System.Drawing.Size(53, 12);
            this.電話號碼.TabIndex = 5;
            this.電話號碼.Text = "電話號碼";
            // 
            // 姓名
            // 
            this.姓名.AutoSize = true;
            this.姓名.Location = new System.Drawing.Point(7, 22);
            this.姓名.Name = "姓名";
            this.姓名.Size = new System.Drawing.Size(29, 12);
            this.姓名.TabIndex = 0;
            this.姓名.Text = "姓名";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 417);
            this.Controls.Add(this.新增通訊錄);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.selectedPhoneDescriptionLabel);
            this.Controls.Add(this.nameListBox);
            this.Controls.Add(this.promptLabel);
            this.Name = "Form1";
            this.Text = "電話簿";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.新增通訊錄.ResumeLayout(false);
            this.新增通訊錄.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void addphonelabel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        // 宣告表單上所使用的控制項
        private System.Windows.Forms.Label promptLabel; // 提示使用者選擇姓名的標籤
        private System.Windows.Forms.ListBox nameListBox; // 顯示聯絡人姓名的清單方塊
        private System.Windows.Forms.Label selectedPhoneDescriptionLabel; // 顯示「電話號碼」說明的標籤
        private System.Windows.Forms.Label phoneLabel; // 顯示聯絡人電話號碼的標籤
        private System.Windows.Forms.Button exitButton; // 離開程式的按鈕
        private System.Windows.Forms.GroupBox 新增通訊錄;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label 電話號碼;
        private System.Windows.Forms.Label 姓名;
        private System.Windows.Forms.TextBox addPhoneTextBox;
        private System.Windows.Forms.TextBox addNameTextBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

