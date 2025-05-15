using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Structure_Argument
{
    // 定義一個汽車（Automobile）結構，用來儲存汽車的品牌、年份與里程數
    struct Automobile
    {
        public string make;    // 汽車品牌
        public int year;       // 汽車年份
        public double mileage; // 汽車里程數
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// DisplayAuto 方法會接收一個 Automobile 結構物件作為參數，
        /// 並顯示該物件的所有欄位資訊於訊息方塊中。
        /// </summary>
        /// <param name="auto">要顯示資訊的汽車結構物件</param>
        private void DisplayAuto(Automobile auto)
        {
            // 以繁體中文顯示汽車的年份、品牌與里程數
            MessageBox.Show(
                auto.year + " 年的 " + auto.make +
                "，里程數為 " + auto.mileage + " 英里。"
            );
        }

        /// <summary>
        /// 當使用者按下「顯示汽車 #1」按鈕時執行此事件處理函式。
        /// 會建立一個 Automobile 結構實例，設定其欄位值，並顯示資訊。
        /// </summary>
        private void auto1Button_Click(object sender, EventArgs e)
        {
            // 建立一個新的汽車（Automobile）結構實例，代表跑車
            Automobile sportsCar = new Automobile();

            // 指定跑車的品牌、年份與里程數
            sportsCar.make = "雪佛蘭 Corvette";
            sportsCar.year = 1970;
            sportsCar.mileage = 50000.0;

            // 顯示跑車的所有欄位資訊
            DisplayAuto(sportsCar);
        }

        /// <summary>
        /// 當使用者按下「顯示汽車 #2」按鈕時執行此事件處理函式。
        /// 會建立一個 Automobile 結構實例，設定其欄位值，並顯示資訊。
        /// </summary>
        private void auto2Button_Click(object sender, EventArgs e)
        {
            // 建立一個新的汽車（Automobile）結構實例，代表皮卡車
            Automobile pickupTruck = new Automobile();

            // 指定皮卡車的品牌、年份與里程數
            pickupTruck.make = "福特 Ranger";
            pickupTruck.year = 1985;
            pickupTruck.mileage = 75000.0;

            // 顯示皮卡車的所有欄位資訊
            DisplayAuto(pickupTruck);
        }

        /// <summary>
        /// 當使用者按下「顯示汽車 #3」按鈕時執行此事件處理函式。
        /// 會建立一個 Automobile 結構實例，設定其欄位值，並顯示資訊。
        /// </summary>
        private void auto3Button_Click(object sender, EventArgs e)
        {
            // 建立一個新的汽車（Automobile）結構實例，代表轎車
            Automobile sedan = new Automobile();

            // 指定轎車的品牌、年份與里程數
            sedan.make = "本田 Accord";
            sedan.year = 2000;
            sedan.mileage = 80000.0;

            // 顯示轎車的所有欄位資訊
            DisplayAuto(sedan);
        }
    }
}
