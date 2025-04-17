using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seating_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // 初始化表單元件
            InitializeComponent();
        }

        private void displayPriceButton_Click(object sender, EventArgs e)
        {
            // 定義座位的行數與列數
            const int ROWS = 6;
            const int COLS = 4;

            // 宣告行與列的變數
            int row;
            int col;

            // 定義座位價格的二維陣列
            decimal[,] seatPrices = {
                { 450m, 450m, 450m, 450m },//第一行 
                { 425m, 425m, 425m, 425m },//第二行 
                { 400m, 400m, 400m, 400m },//第三行
                { 375m, 375m, 375m, 375m },//第四行 
                { 375m, 375m, 375m, 375m },//第五行 
                { 350m, 350m, 350m, 350m } //第六行 
            };

            // 驗證使用者輸入的行號
            if (int.TryParse(rowTextBox.Text, out row))
            {
                // 驗證使用者輸入的列號
                if (int.TryParse(colTextBox.Text, out col))
                {
                    // 確保行號在有效範圍內
                    if (row >= 0 && row < ROWS)
                    {
                        // 確保列號在有效範圍內
                        if (col >= 0 && col < COLS)
                        {
                            // 顯示對應座位的價格，格式化為美元
                            priceLabel.Text = seatPrices[row, col].ToString("C", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                        }
                        else
                        {
                            // 列號超出範圍，顯示錯誤訊息
                            MessageBox.Show("行編號必須在0~3之間!");
                            colTextBox.Focus();
                            return;
                        }
                    }
                    else
                    {
                        // 行號超出範圍，顯示錯誤訊息
                        MessageBox.Show("列編號必須在0~5之間!");
                        rowTextBox.Focus();
                        return;
                    }
                }
                else
                {
                    // 列號輸入無效，顯示錯誤訊息
                    MessageBox.Show("請輸入有效的行號");
                    colTextBox.Focus();
                    return;
                }
            }
            else
            {
                // 行號輸入無效，顯示錯誤訊息
                MessageBox.Show("請輸入有效的列號。");
                rowTextBox.Focus();
                return;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
