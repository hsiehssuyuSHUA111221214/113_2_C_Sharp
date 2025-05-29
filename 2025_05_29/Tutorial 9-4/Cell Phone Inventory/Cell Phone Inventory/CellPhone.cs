using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Phone_Inventory
{
    class CellPhone
    {
        // 欄位：儲存手機品牌名稱的私有變數
        private string _brand;   // 儲存手機品牌，例如：Apple、Samsung 等

        // 欄位：儲存手機型號的私有變數
        private string _model;   // 儲存手機型號，例如：iPhone 15、Galaxy S24 等

        // 欄位：儲存手機建議售價的私有變數
        private decimal _price;  // 儲存手機的零售價格，使用 decimal 型別以確保金額精確

        // 建構函式：初始化 CellPhone 物件的欄位
        // 將品牌與型號設為空字串，價格設為 0
        public CellPhone()
        {
            _brand = "";
            _model = "";
            _price = 0m;
        }

        // 品牌屬性：取得或設定手機品牌名稱
        // 透過此屬性可存取或修改 _brand 欄位的值
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        // 型號屬性：取得或設定手機型號
        // 透過此屬性可存取或修改 _model 欄位的值
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        // 價格屬性：取得或設定手機價格
        // 透過此屬性可存取或修改 _price 欄位的值
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
