using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // 初始化表單元件
        }

        // 當使用者按下生成按鈕時觸發的事件處理程式
        private void generateButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5; // 陣列的大小，表示要生成的樂透號碼數量
            int[] lotteryNumbers = new int[SIZE]; // 儲存樂透號碼的陣列
            Random rand = new Random(); // 創建一個隨機數生成器

            // 迴圈生成樂透號碼
            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                lotteryNumbers[i] = rand.Next(1, 43); // 產生 1 到 42 的亂數，並存入陣列
            }

            // 使用迴圈顯示樂透號碼
            Label[] showlabels = { firstLabel, secondLabel, thirdLabel, fourthLabel, fifthLabel }; // 標籤陣列，用於顯示樂透號碼
            for (int i = 0; i < showlabels.Length; i++)
            {
                showlabels[i].Text = lotteryNumbers[i].ToString(); // 將樂透號碼轉換為字串並顯示在對應的標籤上
            }
        }

        // 當使用者按下退出按鈕時觸發的事件處理程式
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); // 關閉表單
        }
    }
}


