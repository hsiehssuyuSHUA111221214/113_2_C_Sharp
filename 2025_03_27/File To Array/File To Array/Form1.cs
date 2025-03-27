using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace File_To_Array
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getValuesButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 建立一個陣列來存放從檔案中讀取的項目。
                // 陣列大小為常數 SIZE，這裡設為 5。
                const int SIZE = 5;
                int[] numbers = new int[SIZE];

                // 用於迴圈的計數器變數，初始值為 0。
                int index = 0;

                // 宣告一個 StreamReader 變數，用於讀取檔案。
                StreamReader inputFile;

                // 開啟檔案 "Values.txt" 並獲取 StreamReader 物件。
                inputFile = File.OpenText("Values.txt");

                // 將檔案的內容讀取到陣列中。
                // 當前索引小於陣列長度且未到達檔案結尾時，繼續讀取。
                while (index < numbers.Length && !inputFile.EndOfStream)
                {
                    // 讀取一行並解析為整數，存入陣列對應位置。
                    numbers[index] = int.Parse(inputFile.ReadLine());
                    index++;
                }

                // 讀取完成後關閉檔案。
                inputFile.Close();

                // 在列表框中顯示陣列中的每個元素。
                foreach (int value in numbers)
                {
                    outputListBox.Items.Add(value);
                }
            }
            catch (Exception ex)
            {
                // 如果發生異常，顯示錯誤訊息。
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}

