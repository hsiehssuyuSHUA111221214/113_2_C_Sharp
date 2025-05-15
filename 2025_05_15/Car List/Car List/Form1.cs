using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_List
{
    // 定義汽車結構，包含品牌、年份與里程數
    struct Automobile
    {
        public string make;    // 品牌
        public int year;       // 年份
        public double mileage; // 里程數
    }

    public partial class Form1 : Form
    {
        // 建立一個汽車清單作為欄位，用來儲存所有輸入的汽車資料
        private List<Automobile> carList = new List<Automobile>();

        public Form1()
        {
            InitializeComponent();
            // 設定所有元件的 text 屬性為繁體中文
            this.Text = "汽車清單管理";
            addButton.Text = "新增";
            displayButton.Text = "顯示";
            makeLabel.Text = "品牌：";
            yearLabel.Text = "年份：";
            mileageLabel.Text = "里程數：";
            carListBox.Items.Clear();
        }

        /// <summary>
        /// 取得使用者輸入的資料，並指派給傳入的汽車物件欄位
        /// </summary>
        /// <param name="auto">傳入的汽車物件，會被填入使用者輸入的資料</param>
        /// <returns>若輸入成功則傳回 true，否則傳回 false</returns>
        private bool GetData(ref Automobile auto)
        {
            try
            {
                // 從文字方塊取得品牌、年份與里程數，並轉換成正確型別
                auto.make = makeTextBox.Text.Trim();

                // 驗證品牌不得為空
                if (string.IsNullOrWhiteSpace(auto.make))
                    throw new Exception("品牌不能為空。");

                auto.year = int.Parse(yearTextBox.Text.Trim());
                auto.mileage = double.Parse(mileageTextBox.Text.Trim());

                return true; // 轉換成功
            }
            catch (Exception ex)
            {
                // 顯示例外訊息（例如格式錯誤），以繁體中文提示
                MessageBox.Show("輸入資料格式錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // 資料轉換失敗
            }
        }

        /// <summary>
        /// 新增按鈕的事件處理函式，將使用者輸入的汽車資料加入清單
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            // 建立一個新的汽車結構實例
            Automobile car = new Automobile();

            // 嘗試取得資料，若成功才加入清單
            if (GetData(ref car))
            {
                carList.Add(car); // 將汽車物件加入清單

                // 清空所有輸入欄位
                makeTextBox.Clear();
                yearTextBox.Clear();
                mileageTextBox.Clear();

                // 將游標焦點設回品牌輸入框
                makeTextBox.Focus();
            }
        }

        /// <summary>
        /// 顯示按鈕的事件處理函式，將所有汽車資料顯示在清單方塊中
        /// </summary>
        private void displayButton_Click(object sender, EventArgs e)
        {
            // 宣告一個字串用來儲存每一行的輸出內容
            string output;

            // 清空清單方塊目前的內容
            carListBox.Items.Clear();

            // 逐一將每一台汽車的資訊格式化後加入清單方塊
            foreach (Automobile aCar in carList)
            {
                output = aCar.year + " 年 " + aCar.make +
                    "，里程數：" + aCar.mileage + " 公里";

                carListBox.Items.Add(output); // 加入 ListBox
            }
        }
    }
}

