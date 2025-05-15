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
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile; // 宣告 StreamReader 物件以讀取文件
                string line; // 用來儲存讀取的每一列資料
                //int count = 0; // 計數器，用來計算讀取的列數（目前未使用）
                int total = 0; // 總分數，用來計算所有的分數總和
                double average = 0; // 平均分數，用來計算所有的分數平均值

                char[] delimiter = { ',', ':' }; // 定義分隔符號，冒號分隔姓名與分數串，逗號分隔每筆分數

                // 顯示檔案選擇對話方塊，讓使用者選擇要開啟的檔案
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName); // 開啟選取的檔案進行讀取

                    while (!inputFile.EndOfStream)
                    {
                        // 讀取一列資料
                        line = inputFile.ReadLine();
                        line = line.Trim(); // 去除前後空白
                        string[] tokens = line.Split(delimiter); // 將資料依照 : 和 , 分割成陣列
                        total = 0; // 每次讀取新列時，重設總分數為 0

                        // tokens[0] 是學生姓名，其後是分數
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            total += int.Parse(tokens[i]); // 將每個分數字串轉換為整數並累加
                        }

                        // 計算平均值（轉型為 double 以避免整數除法）
                        average = (double)total / (tokens.Length - 1); // 除以分數數量

                        // 將計算結果顯示於 ListBox 控制項
                        averagesListBox.Items.Add(tokens[0] + "的平均分數為：" + average.ToString("F2"));
                    }

                    inputFile.Close(); // 使用完畢後關閉檔案
                }
                else
                {
                    MessageBox.Show("未選擇任何檔案"); // 提示未選擇檔案
                }
            }
            catch (Exception ex)
            {
                // 如果發生錯誤則顯示錯誤訊息
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉應用程式
            this.Close();
        }
    }
}

