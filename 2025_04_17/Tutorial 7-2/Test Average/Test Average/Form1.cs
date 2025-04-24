using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Average方法接收一個整數陣列參數，並返回陣列中所有值的平均數
        // 此方法用於計算全部測驗分數的平均值
        private double Average(int[] iArray)
        {
            double total = 0;  // 宣告變數total用於儲存所有分數的總和

            // 計算陣列中所有值的總和
            for (int i = 0; i < iArray.Length; i++)
            {
                total += iArray[i];  // 將目前索引的分數加到總和中
            }

            // 返回平均值（總和除以元素個數）
            return total / iArray.Length;
        }

        // Highest方法接收一個整數陣列參數，並返回陣列中的最高值
        // 此方法用於找出最高的測驗分數
        private int Highest(int[] iArray)
        {
            // 假設陣列的第一個元素為最高值
            int highest = iArray[0];

            // 遍歷陣列，尋找最高值
            for (int i = 1; i < iArray.Length; i++)
            {
                // 如果目前元素大於目前的最高值，則更新最高值
                if (iArray[i] > highest)
                {
                    highest = iArray[i];
                }
            }

            // 返回找到的最高值
            return highest;
        }

        // Lowest方法接收一個整數陣列參數，並返回陣列中的最低值
        // 此方法用於找出最低的測驗分數
        private int Lowest(int[] iArray)
        {
            // 假設陣列的第一個元素為最低值
            int lowest = iArray[0];

            // 遍歷陣列，尋找最低值
            for (int i = 1; i < iArray.Length; i++)
            {
                // 如果目前元素小於目前的最低值，則更新最低值
                if (iArray[i] < lowest)
                {
                    lowest = iArray[i];
                }
            }

            // 返回找到的最低值
            return lowest;
        }

        // 當使用者點擊「取得分數」按鈕時執行的事件處理程序
        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 宣告區域變數
                const int SIZE = 5;           // 分數的數量常數
                int[] scores = new int[SIZE]; // 宣告用於儲存測驗分數的陣列
                int index = 0;                // 迴圈計數器
                int highestScore;             // 用於儲存最高分數
                int lowestScore;              // 用於儲存最低分數
                double averageScore;          // 用於儲存平均分數

                // 從檔案中讀取測驗分數
                if (File.Exists("TestScores.txt"))
                {
                    // 開啟檔案
                    StreamReader inputFile = File.OpenText("TestScores.txt");

                    // 將檔案中的分數讀入陣列
                    while (index < scores.Length && !inputFile.EndOfStream)
                    {
                        // 讀取一行並轉換為整數，存入陣列
                        scores[index] = int.Parse(inputFile.ReadLine());
                        index++;  // 索引遞增
                    }

                    // 關閉檔案
                    inputFile.Close();

                    // 在ListBox中顯示測驗分數
                    for (index = 0; index < scores.Length; index++)
                    {
                        testScoresListBox.Items.Add(scores[index]);
                    }

                    // 獲取最高分數、最低分數和平均分數
                    highestScore = Highest(scores);
                    lowestScore = Lowest(scores);
                    averageScore = Average(scores);

                    // 在標籤中顯示計算結果
                    averageLabel.Text = averageScore.ToString("n1");  // 顯示平均值，格式化為一位小數
                    highestLabel.Text = highestScore.ToString();      // 顯示最高分
                    lowestLabel.Text = lowestScore.ToString();        // 顯示最低分
                }
                else
                {
                    // 如果檔案不存在，顯示錯誤訊息
                    MessageBox.Show("找不到檔案 TestScores.txt。");
                }
            }
            catch (Exception ex)
            {
                // 捕獲並顯示任何可能發生的錯誤
                MessageBox.Show(ex.Message);
            }
        }

        // 當使用者點擊「離開」按鈕時執行的事件處理程序
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
