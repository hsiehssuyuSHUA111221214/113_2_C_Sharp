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
        // 宣告一個類級別的變量，用于存儲所有測試分數
        private List<int> testScores = new List<int>();

        public Form1()
        {
            InitializeComponent();

            // 確保排序按鈕的Click事件連接到正確的方法
            sortButton.Click += new EventHandler(sortButton_Click);

            // 添加刪除按鈕的Click事件
            deleteButton.Click += new EventHandler(deleteButton_Click);
        }

        private double Average(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("清單不能為空。");
            }
            double sum = 0;
            foreach (int score in numbers)
            {
                sum += score;
            }
            return sum / numbers.Count;
        }

        private int Highest(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("清單不能為空。");
            }
            return numbers.Max();
        }

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
            testScores = new List<int>(); // 重置測試分數列表
            int highScore = 0;
            int lowScore = 0;
            double averageScore = 0.0;
            StreamReader inputFile;

            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 開啟選擇的檔案
                    inputFile = File.OpenText(openFile.FileName);
                    // 清空 ListBox 以顯示新的成績
                    testScoresListBox.Items.Clear();
                    sortedScoresListBox.Items.Clear(); // 同時清空排序後的ListBox

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

        private void sortButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 確保有數據可以排序
                if (testScores == null || testScores.Count == 0)
                {
                    MessageBox.Show("成績清單為空，請先讀取成績數據！");
                    return;
                }

                // 創建一個新的排序列表
                List<int> sortedScores = new List<int>(testScores);
                sortedScores.Sort();
                sortedScores.Reverse(); // 從高到低排序

                // 更新排序後的ListBox
                sortedScoresListBox.Items.Clear();
                foreach (int score in sortedScores)
                {
                    sortedScoresListBox.Items.Add(score);
                }

                // 顯示提示訊息，確認排序完成
                MessageBox.Show("成績已從高到低排序完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("排序時發生錯誤：" + ex.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedScore;
                bool fromSortedList = false;

                // 檢查哪個列表有選中項
                if (sortedScoresListBox.SelectedIndex != -1)
                {
                    // 從排序列表中刪除
                    selectedScore = Convert.ToInt32(sortedScoresListBox.SelectedItem);
                    fromSortedList = true;
                }
                else if (testScoresListBox.SelectedIndex != -1)
                {
                    // 從原始列表中刪除
                    selectedScore = Convert.ToInt32(testScoresListBox.SelectedItem);
                }
                else
                {
                    MessageBox.Show("請在左側或右側列表中選擇要刪除的成績！");
                    return;
                }

                // 從 testScores 清單中移除該分數
                testScores.Remove(selectedScore);

                // 更新 testScoresListBox
                testScoresListBox.Items.Clear();
                foreach (int score in testScores)
                {
                    testScoresListBox.Items.Add(score);
                }

                // 更新 sortedScoresListBox
                List<int> sortedScores = new List<int>(testScores);
                sortedScores.Sort();
                sortedScores.Reverse(); // 從高到低排序
                sortedScoresListBox.Items.Clear();
                foreach (int score in sortedScores)
                {
                    sortedScoresListBox.Items.Add(score);
                }

                // 更新統計數據
                if (testScores.Count > 0)
                {
                    averageScoreLabel.Text = Average(testScores).ToString("n1");
                    highScoreLabel.Text = Highest(testScores).ToString();
                    lowScoreLabel.Text = Lowest(testScores).ToString();
                }
                else
                {
                    averageScoreLabel.Text = string.Empty;
                    highScoreLabel.Text = string.Empty;
                    lowScoreLabel.Text = string.Empty;
                }

                // 顯示刪除成功訊息
                if (fromSortedList)
                {
                    MessageBox.Show($"已從排序列表中刪除分數 {selectedScore}");
                }
                else
                {
                    MessageBox.Show($"已從原始列表中刪除分數 {selectedScore}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("刪除時發生錯誤：" + ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}