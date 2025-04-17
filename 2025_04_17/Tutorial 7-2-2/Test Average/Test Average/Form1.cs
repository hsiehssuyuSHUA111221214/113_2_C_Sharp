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

        // Average 方法接受一個整數清單作為參數，
        // 並計算該清單中所有值的平均值，然後返回結果。
        private double Average(List<int> numbers)
        {
            // 確保清單不為空，避免例外發生。
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("清單不能為空。");
            }

            // 使用 numbers 清單累加所有分數計算總和，再除以清單長度求平均值。
            double sum = 0;
            foreach (int score in numbers)
            {
                sum += score;
            }
            return sum / numbers.Count;
        }

        // Highest 方法接受一個整數清單作為參數，
        // 並找出該清單中的最大值，然後返回該值。
        private int Highest(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("清單不能為空。");
            }
            return numbers.Max();
        }

        // Lowest 方法接受一個整數清單作為參數，
        // 並找出該清單中的最小值，然後返回該值。
        private int Lowest(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("清單不能為空。");
            }
            return numbers.Min();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            List<int> testScores = new List<int>(); // 用於存儲測試分數的整數清單。
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

                    // 清空 ListBox 以顯示新的成績
                    testScoresListBox.Items.Clear();

                    // 從檔案中逐行讀取測試分數，直到檔案結束
                    while (!inputFile.EndOfStream)
                    {
                        int score = Convert.ToInt32(inputFile.ReadLine());
                        testScores.Add(score); // 將讀取的分數新增到清單中
                        testScoresListBox.Items.Add(score); // 將分數顯示在 ListBox 中
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
