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

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // 初始化表單元件
            this.Text = "CSV 分數平均計算程式"; // 設定表單標題為繁體中文
            getScoresButton.Text = "讀取並計算平均"; // 按鈕：讀取檔案
            exitButton.Text = "離開程式"; // 按鈕：關閉表單
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile; // 宣告 StreamReader 物件，用來讀取檔案
                string line; // 用來儲存每一列的文字資料
                int count = 0; // 計數器，用來統計有幾筆資料（幾位學生）
                int total = 0; // 總分數，每次讀取新的一列會重設
                double average = 0; // 平均分數，用來儲存每位學生的平均值

                char[] delimiter = { ',' }; // 定義資料的分隔符號（這裡是逗號）

                // 顯示開啟檔案對話框，讓使用者選取 CSV 檔案
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 使用者選擇檔案後開啟它
                    inputFile = File.OpenText(openFile.FileName);

                    // 讀取檔案直到結尾
                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine(); // 讀取一整列
                        line = line.Trim(); // 移除前後空白字元

                        // 將每一列以分隔符切割成陣列
                        string[] tokens = line.Split(delimiter);

                        total = 0; // 每讀取新列時，重製總分為0

                        // 將字串陣列轉為整數並加總
                        for (int i = 0; i < tokens.Length; i++)
                        {
                            total += int.Parse(tokens[i]); // 將每個分數字串轉換為整數並累加
                        }

                        // 計算平均值（轉型為 double 以避免整數除法）
                        average = (double)total / tokens.Length;

                        // 將計算結果顯示於 ListBox 控制項
                        averagesListBox.Items.Add("第 " + (++count) + " 位同學的平均分數為：" + average.ToString("F2"));
                    }

                    inputFile.Close(); // 使用完畢後關閉檔案
                }
                else
                {
                    MessageBox.Show("您尚未選擇任何檔案。", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // 如果發生錯誤則顯示錯誤訊息
                MessageBox.Show("發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉應用程式
            this.Close();
        }
    }
}
