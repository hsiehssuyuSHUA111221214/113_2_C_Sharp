namespace ArrayEquality
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 2, 3, 4, 5 };

            //浪琩ㄢ皚琌单
            bool arraysEqual = isArraysEqual(array1, array2);

            if (arraysEqual)
            {
                MessageBox.Show("ㄢ皚单");
            }
            else
            {
                MessageBox.Show("ㄢ皚ぃ单");
            }
        }

        private bool isArraysEqual(int[] array1, int[] array2)
        {
            //浪琩皚琌单
            if (array1.Length != array2.Length)
            {
                return false;
            }
            //浪琩–じ琌单
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

}
