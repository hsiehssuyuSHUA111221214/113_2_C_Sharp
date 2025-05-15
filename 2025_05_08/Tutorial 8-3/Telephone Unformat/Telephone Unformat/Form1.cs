using System;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    /// <summary>
    /// 主視窗 Form1：提供格式化電話號碼的取消功能
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 表單初始化建構子：載入控制項元件
        /// </summary>
        public Form1()
        {
            InitializeComponent(); // 呼叫 Designer.cs 自動產生的控制項初始化方法
        }

        /// <summary>
        /// 驗證輸入字串是否符合格式 (XXX)XXX-XXXX 的電話號碼格式
        /// </summary>
        /// <param name="str">使用者輸入的電話號碼</param>
        /// <returns>是否符合格式規則</returns>
        private bool IsValidFormat(string str)
        {
            // 空值或長度不為13直接回傳 false
            if (string.IsNullOrEmpty(str)) return false;
            if (str.Length != 13) return false;

            // 第 1、5、9 個字元必須為括號與連字號
            if (str[0] != '(' || str[4] != ')' || str[8] != '-') return false;

            // 檢查其餘字元是否為數字
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 || i == 4 || i == 8) continue; // 略過符號位
                if (!char.IsDigit(str[i])) return false;
            }

            return true; // 通過所有檢查則為合法格式
        }

        /// <summary>
        /// 移除電話號碼中的格式符號：括號與連字號
        /// </summary>
        /// <param name="str">傳入要修改的字串（使用 ref 傳址）</param>
        private void Unformat(ref string str)
        {
            // 將括號與 - 字元移除
            str = str.Replace("(", "").Replace(")", "").Replace("-", "");
        }

        /// <summary>
        /// [Unformat] 按鈕事件處理：驗證格式並取消格式顯示結果
        /// </summary>
        private void unformatButton_Click(object sender, EventArgs e)
        {
            // 取得使用者輸入的電話號碼
            string phoneNumber = numberTextBox.Text;

            // 如果格式正確，取消格式並顯示結果
            if (IsValidFormat(phoneNumber))
            {
                Unformat(ref phoneNumber); // 移除符號
                instructionLabel.Text = phoneNumber; // 顯示結果於標籤
            }
            else
            {
                // 若格式錯誤，顯示錯誤提示對話框
                MessageBox.Show("電話號碼格式不正確，請使用 (XXX)XXX-XXXX。",
                                "格式無效", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// [Exit] 按鈕事件處理：關閉視窗並結束應用程式
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); // 關閉表單
        }
    }
}
