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

        // Average 方法接受一個整數陣列作為參數，
        // 並計算該陣列中所有值的平均值，然後返回結果。
        private double Average(int[] numbers)
        {
            // 確保陣列不為空，避免例外發生。
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("陣列不能為空。");
            }

            // 使用 numbers 陣列累加所有分數計算總和，再除以陣列長度求平均值。
            double sum = 0;
            foreach (int score in numbers)
            {
                sum += score;
            }
            return sum / numbers.Length;
        }

        // Highest 方法接受一個整數陣列作為參數，
        // 並找出該陣列中的最大值，然後返回該值。
        private int Highest(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("陣列不能為空。");
            }
            return numbers.Max();
        }

        // Lowest 方法接受一個整數陣列作為參數，
        // 並找出該陣列中的最小值，然後返回該值。
        private int Lowest(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("陣列不能為空。");
            }
            return numbers.Min();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 48; // 定義陣列的大小為 48。
            int[] testScores = new int[SIZE]; // 用於存儲測試分數的整數陣列。
            int index = 0; // 用於追蹤陣列索引的變數。
            int highScore = 0; // 用於存儲最高分數的變數。
            int lowScore = 0; // 用於存儲最低分數的變數。
            double averageScore = 0.0; // 用於存儲平均分數的變數。
            StreamReader inputFile; // 用於讀取檔案的 StreamReader 物件。

            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 開啟選擇的檔案
                    inputFile = File.OpenText(openFile.FileName);

                    // 從檔案中逐行讀取測試分數，直到檔案結束或陣列已滿
                    while (!inputFile.EndOfStream && index < SIZE)
                    {
                        testScores[index] = Convert.ToInt32(inputFile.ReadLine());
                        index++;
                    }

                    // 關閉檔案以釋放資源
                    inputFile.Close();

                    // 使用 Average、Highest 與 Lowest 方法計算結果。
                    averageScore = Average(testScores);
                    highScore = Highest(testScores);
                    lowScore = Lowest(testScores);

                    // 將計算結果顯示在對應的標籤上。
                    averageScoreLabel.Text = averageScore.ToString("n1"); // 平均分數，保留一位小數
                    highScoreLabel.Text = highScore.ToString();
                    lowScoreLabel.Text = lowScore.ToString();
                }
            }
            catch (Exception ex)
            {
                // 發生例外時顯示錯誤訊息。
                MessageBox.Show("錯誤：" + ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉目前的表單。
            this.Close();
        }
    }
}
