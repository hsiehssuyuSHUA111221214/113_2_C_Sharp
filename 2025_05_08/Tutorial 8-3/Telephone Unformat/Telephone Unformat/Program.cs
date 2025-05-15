using System;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    /// <summary>
    /// 應用程式的主進入點
    /// </summary>
    static class Program
    {
        /// <summary>
        /// 主方法 - 程式執行從這裡開始
        /// </summary>
        [STAThread] // 指定使用單一執行緒模型（Single Thread Apartment），必要於 Windows Forms 中
        static void Main()
        {
            // 啟用視覺樣式：讓表單使用目前 Windows 主題風格（例如按鈕外觀）
            Application.EnableVisualStyles();

            // 設定文字呈現方式為與 GDI 相容，提升文字渲染相容性
            Application.SetCompatibleTextRenderingDefault(false);

            // 啟動並執行主表單（Form1）
            Application.Run(new Form1());
        }
    }
}
