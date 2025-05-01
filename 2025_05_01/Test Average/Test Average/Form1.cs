using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Test_Average
{
    public partial class Form1 : Form
    {
        // 宣告一個整數List來存儲所有分數
        private List<int> scores = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        // Average 方法接受一個整數陣列作為參數，並返回該陣列中所有值的平均值。
        private double Average(int[] values)
        {
            // 檢查陣列是否為空
            if (values == null || values.Length == 0)
            {
                return 0;
            }

            double total = 0;
            foreach (int value in values)
            {
                total += value;
            }
            return total / values.Length;
        }

        // Highest 方法接受一個整數陣列作為參數，並返回該陣列中的最大值。
        private int Highest(int[] values)
        {
            // 檢查陣列是否為空
            if (values == null || values.Length == 0)
            {
                return 0;
            }

            int highest = values[0];
            foreach (int value in values)
            {
                if (value > highest)
                {
                    highest = value;
                }
            }
            return highest;
        }

        // Lowest 方法接受一個整數陣列作為參數，並返回該陣列中的最小值。
        private int Lowest(int[] values)
        {
            // 檢查陣列是否為空
            if (values == null || values.Length == 0)
            {
                return 0;
            }

            int lowest = values[0];
            foreach (int value in values)
            {
                if (value < lowest)
                {
                    lowest = value;
                }
            }
            return lowest;
        }

        // 此方法在按下 "離開" 按鈕時執行，用於關閉目前的表單。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 確認用戶是否真的要離開
            DialogResult result = MessageBox.Show("確定要離開程式嗎？", "確認離開",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // 此方法在按下 "取得分數" 按鈕時執行，用於從使用者輸入中取得測試分數並進行處理。
        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 清空ListBox和標籤
                testScoresListBox.Items.Clear();
                highScoreLabel.Text = "";
                lowScoreLabel.Text = "";
                averageScoreLabel.Text = "";

                // 設置OpenFileDialog的初始目錄和過濾器
                openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFile.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                openFile.Title = "選擇包含分數的文字檔";

                // 如果用戶選擇了文件
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 檢查文件是否存在
                    if (!File.Exists(openFile.FileName))
                    {
                        MessageBox.Show("找不到指定的檔案！", "檔案錯誤",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 清空分數列表
                    scores.Clear();

                    // 讀取文件中的所有行
                    string[] lines = File.ReadAllLines(openFile.FileName);

                    // 檢查文件是否為空
                    if (lines.Length == 0)
                    {
                        MessageBox.Show("所選檔案是空的！", "檔案錯誤",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 計數有效和無效分數
                    int validScoreCount = 0;
                    int invalidScoreCount = 0;
                    int outOfRangeCount = 0;

                    // 處理每一行
                    foreach (string line in lines)
                    {
                        if (int.TryParse(line.Trim(), out int score))
                        {
                            // 檢查分數是否在有效範圍內 (0~100)
                            if (score >= 0 && score <= 100)
                            {
                                // 添加分數到列表和ListBox
                                scores.Add(score);
                                testScoresListBox.Items.Add(score);
                                validScoreCount++;
                            }
                            else
                            {
                                // 計數範圍外的分數
                                outOfRangeCount++;
                            }
                        }
                        else
                        {
                            // 計數無效格式的分數
                            invalidScoreCount++;
                        }
                    }

                    // 如果有無效分數，顯示警告訊息
                    if (invalidScoreCount > 0 || outOfRangeCount > 0)
                    {
                        string message = "";
                        if (invalidScoreCount > 0)
                        {
                            message += $"已忽略 {invalidScoreCount} 個無效格式的分數。\n";
                        }
                        if (outOfRangeCount > 0)
                        {
                            message += $"已忽略 {outOfRangeCount} 個不在 0~100 範圍內的分數。";
                        }

                        MessageBox.Show(message, "分數警告",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // 如果沒有有效分數
                    if (validScoreCount == 0)
                    {
                        MessageBox.Show("沒有找到有效的分數！", "讀取結果",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // 計算並顯示統計數據
                    UpdateStatistics();

                    // 顯示成功訊息
                    MessageBox.Show($"成功讀取 {validScoreCount} 個有效分數。", "讀取成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 在讀取檔案後自動執行排序功能
                    if (scores.Count > 0)
                    {
                        sortButton_Click(this, EventArgs.Empty);
                    }
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"檔案讀取錯誤: {ioEx.Message}", "IO錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生未預期的錯誤: {ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 更新統計信息（平均分數、最高分數、最低分數）
        private void UpdateStatistics()
        {
            if (scores.Count > 0)
            {
                // 轉換列表為數組
                int[] scoresArray = scores.ToArray();

                // 計算並顯示平均分數、最高分數和最低分數
                highScoreLabel.Text = Highest(scoresArray).ToString();
                lowScoreLabel.Text = Lowest(scoresArray).ToString();
                averageScoreLabel.Text = Average(scoresArray).ToString("N2");
            }
            else
            {
                // 如果沒有分數，清空標籤
                highScoreLabel.Text = "";
                lowScoreLabel.Text = "";
                averageScoreLabel.Text = "";
            }
        }

        // 按下排序按鈕時執行 - 將成績由高到低排序
        private void sortButton_Click(object sender, EventArgs e)
        {
            if (scores.Count > 0)
            {
                // 清空排序後的ListBox
                sortedScoresListBox.Items.Clear();

                // 複製並排序分數列表 (由高到低)
                List<int> sortedScores = new List<int>(scores);
                sortedScores.Sort();
                sortedScores.Reverse(); // 將排序結果反轉，實現由高到低排序

                // 將排序後的分數添加到ListBox
                foreach (int score in sortedScores)
                {
                    sortedScoresListBox.Items.Add(score);
                }

                // 顯示排序完成訊息（只在明確按下排序按鈕時顯示）
                if (sender != this) // 檢查排序是由用戶主動觸發還是程式內部呼叫
                {
                    MessageBox.Show("分數已成功排序。", "排序完成",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (sender != this) // 只在用戶主動點擊排序按鈕時顯示
                {
                    MessageBox.Show("沒有可排序的分數。", "排序提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // 按下刪除按鈕時執行
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (testScoresListBox.SelectedIndex != -1)
                {
                    // 從原始列表中刪除
                    int index = testScoresListBox.SelectedIndex;
                    int scoreToDelete = scores[index]; // 獲取要刪除的分數
                    scores.RemoveAt(index);
                    testScoresListBox.Items.RemoveAt(index);

                    // 更新統計資訊
                    UpdateStatistics();

                    // 更新排序列表
                    UpdateSortedList();

                    MessageBox.Show($"已成功刪除分數 {scoreToDelete}。", "刪除成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (sortedScoresListBox.SelectedIndex != -1)
                {
                    // 從排序列表中刪除（需要找到在原始列表中的對應位置）
                    int selectedScore = (int)sortedScoresListBox.SelectedItem;

                    // 處理可能有重複分數的情況
                    // 顯示確認對話框，讓用戶確認要刪除的是哪一個分數
                    DialogResult result = MessageBox.Show(
                        $"確定要刪除所選的分數 {selectedScore}？如果有多個相同的分數，將刪除第一個找到的。",
                        "確認刪除",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // 找到該分數在原始列表中的位置
                        int indexInOriginalList = scores.IndexOf(selectedScore);
                        if (indexInOriginalList != -1)
                        {
                            scores.RemoveAt(indexInOriginalList);
                            testScoresListBox.Items.RemoveAt(indexInOriginalList);

                            // 更新統計資訊
                            UpdateStatistics();

                            // 更新排序列表
                            UpdateSortedList();

                            MessageBox.Show($"已成功刪除分數 {selectedScore}。", "刪除成功",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("請先在測試分數或排序後的分數列表中選擇要刪除的分數。",
                        "未選擇分數", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"刪除分數時發生錯誤: {ex.Message}", "刪除錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 更新排序列表的輔助方法
        private void UpdateSortedList()
        {
            sortedScoresListBox.Items.Clear();
            if (scores.Count > 0)
            {
                // 重新排序並顯示
                List<int> sortedScores = new List<int>(scores);
                sortedScores.Sort();
                sortedScores.Reverse();

                foreach (int score in sortedScores)
                {
                    sortedScoresListBox.Items.Add(score);
                }
            }
        }

        // 實現插入按鈕的功能
        private void insertButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 檢查分數輸入框是否有效
                if (string.IsNullOrWhiteSpace(scoreTextBox.Text))
                {
                    MessageBox.Show("請輸入分數。", "缺少分數",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    scoreTextBox.Focus();
                    return;
                }

                // 檢查位置輸入框是否有效
                if (string.IsNullOrWhiteSpace(positionTextBox.Text))
                {
                    MessageBox.Show("請輸入插入位置。", "缺少位置",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    positionTextBox.Focus();
                    return;
                }

                // 嘗試將分數和位置轉換為整數
                if (int.TryParse(scoreTextBox.Text, out int score) &&
                    int.TryParse(positionTextBox.Text, out int position))
                {
                    // 檢查分數是否在有效範圍內 (0~100)
                    if (score < 0 || score > 100)
                    {
                        MessageBox.Show("分數必須在0到100之間。", "分數範圍錯誤",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        scoreTextBox.Focus();
                        return;
                    }

                    // 檢查位置是否在有效範圍內 (用戶輸入從1開始，但程式內部從0開始)
                    if (position < 1 || position > scores.Count + 1)
                    {
                        MessageBox.Show($"位置必須在1和{scores.Count + 1}之間。", "位置範圍錯誤",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        positionTextBox.Focus();
                        return;
                    }

                    // 將用戶輸入的位置(從1開始)轉換為程式內部的索引(從0開始)
                    int actualPosition = position - 1;

                    // 在指定位置插入分數
                    scores.Insert(actualPosition, score);
                    testScoresListBox.Items.Insert(actualPosition, score);

                    // 清空輸入框
                    scoreTextBox.Clear();
                    positionTextBox.Clear();

                    // 更新統計信息
                    UpdateStatistics();

                    // 自動執行排序功能
                    UpdateSortedList();

                    // 顯示成功訊息
                    MessageBox.Show($"已成功在位置 {position} 插入分數 {score}。", "插入成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 將焦點設回分數輸入框
                    scoreTextBox.Focus();
                }
                else
                {
                    MessageBox.Show("分數和位置必須是整數。", "格式錯誤",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // 如果分數無效，將焦點設回分數輸入框
                    if (!int.TryParse(scoreTextBox.Text, out _))
                    {
                        scoreTextBox.Focus();
                    }
                    // 否則將焦點設回位置輸入框
                    else
                    {
                        positionTextBox.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"插入分數時發生錯誤: {ex.Message}", "插入錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 新增功能：清空所有分數
        private void clearAllButton_Click(object sender, EventArgs e)
        {
            if (scores.Count > 0)
            {
                DialogResult result = MessageBox.Show("確定要清空所有分數嗎？", "確認清空",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 清空資料
                    scores.Clear();
                    testScoresListBox.Items.Clear();
                    sortedScoresListBox.Items.Clear();

                    // 清空統計資訊
                    highScoreLabel.Text = "";
                    lowScoreLabel.Text = "";
                    averageScoreLabel.Text = "";

                    MessageBox.Show("已清空所有分數。", "清空完成",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("目前沒有任何分數可清空。", "清空提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 新增功能：保存分數到文件
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (scores.Count == 0)
            {
                MessageBox.Show("沒有分數可以保存！", "保存提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFile.Title = "保存分數";
            saveFile.DefaultExt = "txt";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFile.FileName))
                    {
                        foreach (int score in scores)
                        {
                            writer.WriteLine(score);
                        }
                    }

                    MessageBox.Show("分數已成功保存！", "保存成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"保存文件時發生錯誤: {ex.Message}", "保存錯誤",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}