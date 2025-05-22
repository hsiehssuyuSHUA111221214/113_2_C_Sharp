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

namespace Phonebook
{
    // 結構 PhoneBookEntry 用來儲存電話簿的每一筆資料，包括姓名與電話號碼。
    struct PhoneBookEntry
    {
        public string name;   // 儲存聯絡人姓名
        public string phone;  // 儲存聯絡人電話號碼
    }

    public partial class Form1 : Form
    {
        // 用來儲存多筆 PhoneBookEntry 物件的清單，代表整個電話簿的資料集合。
        private List<PhoneBookEntry> phoneList =
            new List<PhoneBookEntry>();

        // OpenFileDialog 控制項，用於讓使用者選擇要開啟的電話簿檔案。
        private OpenFileDialog openFile = new OpenFileDialog
        {
            Title = "選擇電話簿檔案",
            Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*"
        };

        public Form1()
        {
            InitializeComponent();
            // 設定所有元件的顯示文字為繁體中文
            this.Text = "電話簿";
            // 設定提示標籤
            promptLabel.Text = "請選擇姓名";
            // 設定電話號碼說明標籤
            selectedPhoneDescriptionLabel.Text = "電話號碼";
            // 設定離開按鈕文字
            exitButton.Text = "離開";
        }

        // ReadFile 方法會讀取 PhoneList.txt 檔案的內容，
        // 並將每一筆資料轉換成 PhoneBookEntry 物件後，存入 phoneList 清單中。
        // 這樣可以讓程式在執行時載入所有聯絡人資料，方便後續查詢與顯示。
        private void ReadFile()
        {
            StreamReader inputFile;
            // 顯示檔案選擇對話方塊，讓使用者選擇要載入的電話簿檔案
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    inputFile = File.OpenText(openFile.FileName);
                    string line;
                    // 逐行讀取檔案內容
                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine().Trim();
                        string[] parts = line.Split(',');
                        // 檢查每行是否正確分割為姓名與電話
                        if (parts.Length == 2)
                        {
                            PhoneBookEntry entry;
                            entry.name = parts[0];
                            entry.phone = parts[1];
                            phoneList.Add(entry);
                        }
                        else
                        {
                            // 若格式錯誤，顯示錯誤訊息
                            MessageBox.Show("檔案格式錯誤，請確認每行皆為「姓名,電話號碼」格式。", "檔案讀取錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    inputFile.Close();
                }
                catch (Exception ex)
                {
                    // 若檔案開啟或讀取過程發生例外，顯示詳細錯誤訊息
                    MessageBox.Show("檔案讀取錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // DisplayNames 方法會將 phoneList 清單中的所有聯絡人姓名，
        // 顯示在 nameListBox 控制項上，讓使用者可以從清單中選擇聯絡人。
        private void DisplayNames()
        {
            nameListBox.Items.Clear(); // 先清空清單，避免重複顯示
            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name);
            }
        }

        // Form1_Load 事件在表單載入時觸發，
        // 通常用來初始化資料或設定表單的初始狀態。
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile();    // 讀取電話簿資料
            DisplayNames(); // 顯示所有姓名在 nameListBox 控制項中
        }

        // nameListBox_SelectedIndexChanged 事件在使用者選取不同聯絡人時觸發，
        // 可以根據選取的項目顯示對應的電話號碼等詳細資訊。
        // 會顯示對應的電話號碼在 phoneLabel 控制項中。
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;//取得選擇的索引
            if(index !=-1)
            {
                //顯示對應的電話號碼在phoneLabel 控制項中
                phoneLabel.Text = phoneList[index].phone;
            }
            else
            {
                //如果沒有選取任何項目，則清空電話號碼顯示
                phoneLabel.Text = "無資料";
            }
        }
        // exitButton_Click 事件在使用者點擊離開按鈕時觸發，
        // 當使用者按下「離開」按鈕時，會關閉整個表單。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
