using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        // 用來儲存 CellPhone 物件的清單
        List<CellPhone> phoneList = new List<CellPhone>();

        public Form1()
        {
            InitializeComponent();
        }

        // GetPhoneData 方法接收一個 CellPhone 物件作為參數。
        // 此方法會將使用者輸入的資料指派給該物件的屬性。
        private void GetPhoneData(CellPhone phone)
        {
            // 用來暫存價格的變數
            decimal price;

            // 取得手機品牌
            phone.Brand = brandTextBox.Text;

            // 取得手機型號
            phone.Model = modelTextBox.Text;

            // 取得手機價格
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price;
            }
            else
            {
                // 顯示錯誤訊息
                MessageBox.Show("價格無效");
            }
        }

        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhone = new CellPhone(); // 建立新的 CellPhone 物件

            GetPhoneData(myPhone); //取得使用者輸入的手機資料

            // 將新的手機物件加入到手機清單中
            phoneList.Add(myPhone);

            //將新增手機的品牌與型號組合成字串，並加入到ListBox 中
            phoneListBox.Items.Add(myPhone.Brand + " " + myPhone.Model);

            // 清空輸入欄位，準備下一次輸入
            brandTextBox.Text = "";
            modelTextBox.Text = "";
            priceTextBox.Text = "";
            // 將焦點設回品牌輸入欄位，方便使用者繼續輸入
            brandTextBox.Focus();
        }

        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = phoneListBox.SelectedIndex; // 取得選取的手機在清單中的索引

            MessageBox.Show(phoneList[index].Price.ToString("C"));// 顯示選取手機的售價，格式化為貨幣顯示

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
