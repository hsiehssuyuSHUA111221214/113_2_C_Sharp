using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Password_Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // The NumberUpperCase method accepts a string argument
        // and returns the number of uppercase letters it contains.
        private int NumberUpperCase(string str)
        {
            int digits = 0;
            foreach (char ch in str)
            {
                //如果字元是數字，則計數器加1
                if (char.IsUpper(ch))
                {
                    digits++;
                }
            }
            return digits;  // 返回計數值
        }
        // The NumberLowerCase method accepts a string argument
        // and returns the number of lowercase letters it contains.
        private int NumberLowerCase(string str)
        {
            int lowerCount = 0;
            foreach (char ch in str)
            {
                if (char.IsLower(ch))
                {
                    lowerCount++;
                }
            }
            return lowerCount;
        }
        // The NumberDigits method accepts a string argument
        // and returns the number of numeric digits it contains.
        private int NumberDigits(string str)
        {
            int digitCount = 0;
            foreach (char ch in str)
            {
                if (char.IsDigit(ch))
                {
                    digitCount++;
                }
            }
            return digitCount;
        }
        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
            // 獲取密碼文本
            string password = passwordTextBox.Text;

            // 檢查密碼長度
            if (password.Length < 8)
            {
                MessageBox.Show("密碼長度必須至少為8個字符。", "錯誤");
                return;
            }

            // 檢查大寫字母數量
            int upperCount = NumberUpperCase(password);
            if (upperCount < 1)
            {
                MessageBox.Show("密碼必須包含至少一個大寫字母。", "錯誤");
                return;
            }

            // 檢查小寫字母數量
            int lowerCount = NumberLowerCase(password);
            if (lowerCount < 1)
            {
                MessageBox.Show("密碼必須包含至少一個小寫字母。", "錯誤");
                return;
            }

            // 檢查數字數量
            int digitCount = NumberDigits(password);
            if (digitCount < 1)
            {
                MessageBox.Show("密碼必須包含至少一個數字。", "錯誤");
                return;
            }

            // 如果所有條件都滿足，顯示成功訊息
            MessageBox.Show("密碼有效！", "成功");
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}