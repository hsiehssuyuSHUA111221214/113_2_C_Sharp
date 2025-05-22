using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System;

namespace Phonebook
{
    // 結構 PhoneBookEntry 用來儲存每筆聯絡人資料，包括姓名與電話號碼。
    struct PhoneBookEntry
    {
        public string name;   // 聯絡人姓名
        public string phone;  // 聯絡人電話號碼
    }

    public partial class Form1 : Form
    {
        // 用來儲存電話簿聯絡人資料的清單
        private List<PhoneBookEntry> phoneList = new List<PhoneBookEntry>();

        // 開啟檔案對話框，用來選擇電話簿文字檔
        private OpenFileDialog openFile = new OpenFileDialog
        {
            Title = "選擇電話簿檔案",
            Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*"
        };

        public Form1()
        {
            InitializeComponent();
            this.Text = "電話簿"; // 設定視窗標題為繁體中文
            promptLabel.Text = "請選擇姓名"; // 提示使用者選擇姓名
            selectedPhoneDescriptionLabel.Text = "電話號碼"; // 電話號碼標籤
            exitButton.Text = "離開"; // 離開按鈕
        }

        // 讀取文字檔案中的聯絡人資料，並儲存到 phoneList 清單中
        private void ReadFile()
        {
            StreamReader inputFile;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    inputFile = File.OpenText(openFile.FileName);
                    string line;
                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine().Trim();
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            PhoneBookEntry entry;
                            entry.name = parts[0];
                            entry.phone = parts[1];
                            phoneList.Add(entry);
                        }
                        else
                        {
                            MessageBox.Show("檔案格式錯誤，請確認每行皆為「姓名,電話號碼」格式。", "檔案讀取錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    inputFile.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("檔案讀取錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 將目前的 phoneList 清單內容寫入文字檔中，達到儲存效果
        private void WriteFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(openFile.FileName))
                {
                    foreach (PhoneBookEntry entry in phoneList)
                    {
                        writer.WriteLine($"{entry.name},{entry.phone}");
                    }
                }
                MessageBox.Show("資料已成功儲存到原始檔案！", "儲存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("檔案寫入失敗：" + ex.Message, "寫入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 顯示所有聯絡人姓名到 ListBox 中
        private void DisplayNames()
        {
            nameListBox.Items.Clear();
            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name);
            }
        }

        // 表單載入時自動讀取檔案並顯示資料
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile();
            DisplayNames();
        }

        // 當使用者從 ListBox 中選擇聯絡人時，顯示其電話號碼
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;
            if (index != -1)
            {
                phoneLabel.Text = phoneList[index].phone;
            }
            else
            {
                phoneLabel.Text = "無資料";
            }
        }

        // 點擊「離開」按鈕時關閉程式
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 在結束程式前先將目前的 phoneList 儲存至原始檔案
            WriteFile();
            this.Close();
        }

        // 點擊「姓名」標籤時提示輸入姓名
        private void AddNameLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("請在下方輸入姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 點擊「電話號碼」標籤時提示輸入電話
        private void AddPhoneLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("請在下方輸入電話號碼", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 點擊「加入」按鈕時將新資料加入清單並寫入檔案
        private void Add_Click(object sender, EventArgs e)
        {
            string name = addNameTextBox.Text.Trim();
            string phone = addPhoneTextBox.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("請輸入姓名和電話號碼", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PhoneBookEntry entry;
            entry.name = name;
            entry.phone = phone;
            phoneList.Add(entry);

            DisplayNames();
            WriteFile();

            addNameTextBox.Text = string.Empty;
            addPhoneTextBox.Text = string.Empty;
        }

        // SaveFileDialog 觸發事件（預留）
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
