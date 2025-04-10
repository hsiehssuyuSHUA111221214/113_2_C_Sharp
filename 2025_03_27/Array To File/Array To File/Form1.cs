using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Array_To_File
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 建立一個包含數值的整數陣列。
                int[] numbers = { 10, 20, 30, 40, 50 };

                // 宣告一個 StreamWriter 變數，用於寫入檔案。
                StreamWriter outputFile;

                // 建立檔案並取得 StreamWriter 物件。
                outputFile = File.CreateText("Values.txt");

                // 將陣列的內容逐一寫入檔案中。
                for (int index = 0; index < numbers.Length; index++)
                {
                    outputFile.WriteLine(numbers[index]);
                }

                // 關閉檔案以釋放資源。
                outputFile.Close();

                // 顯示訊息通知使用者操作已完成。
                MessageBox.Show("完成");
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息，通知使用者發生的例外狀況。
                MessageBox.Show(ex.Message);
            }
        }
    }
}
