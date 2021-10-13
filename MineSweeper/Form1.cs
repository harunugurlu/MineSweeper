using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper

{

    public partial class Form1 : Form
    {
        int count;
        MinePlacer minePlacer = new MinePlacer();
        public Form1()
        {
            InitializeComponent();
        }
        List<Button> btnIndex;
        public void Form1_Load(object sender, EventArgs e)
        {

            lblTitle.Font = new Font(FontFamily.GenericSansSerif, 16f, FontStyle.Bold);
            
            
            Button btn;

            for (int i = 0; i < 100; i++)
            {
                
                btn = new Button();
                btn.Margin = new Padding(-5);
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Size = new Size(30, 30);
                btn.Click += Btn_Click;
                btn.BackColor = System.Drawing.SystemColors.Window;
                btn.Font = new Font(Font, FontStyle.Bold);
                
                flowMain.Controls.Add(btn);
            }
            BtnMinePlacer();
            //List<string> array = new List<string>();
            //foreach (var item in arrInt)
            //{
            //    array.Add(item.ToString());
            //}
            //string yeterUlan = array[0] + " " + array[1] + " " + array[2] + " " + array[3] + " " + array[4] + " " + array[5] + " " + array[6] + " "
            //    + array[7] + " " + array[8] + " " + array[9] + " " + array[10] + " " + array[11] + " " + array[12] + " " + array[13] + " " + array[14];
            //MessageBox.Show(yeterUlan);

        }
        private void BtnMinePlacer()
        {
            
            btnIndex = new List<Button>();
            Random rnd = new Random();
            int[] arrInt = new int[15];
            for (int i = 0; i < arrInt.Length; i++)
            {
                int rndIndex = rnd.Next(0, 100);
                arrInt[i] = rndIndex;
            }

            while (arrInt.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                for (int i = 0; i < arrInt.Length; i++)
                {
                    int rndIndex = rnd.Next(0, 100);
                    arrInt[i] = rndIndex;
                }
            }
            bool abc = arrInt.GroupBy(x => x).Any(g => g.Count() > 1);
            //List<string> array = new List<string>();
            //foreach (var item in arrInt)
            //{
            //    array.Add(item.ToString());
            //}
            //string yeterUlan = array[0] + " " + array[1] + " " + array[2] + " " + array[3] + " " + array[4] + " " + array[5] + " " + array[6] + " "
            //    + array[7] + " " + array[8] + " " + array[9] + " " + array[10] + " " + array[11] + " " + array[12] + " " + array[13] + " " + array[14];
            //MessageBox.Show(yeterUlan);
            for (int i = 0; i < arrInt.Length; i++)
            {
                btnIndex.Add(flowMain.Controls.OfType<Button>().ElementAt(arrInt[i]));
            }
        }

        
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var index = flowMain.Controls.IndexOf(btn);
            #region Fail
            if (btnIndex.Contains(GetButtonControl(index)))
            {
                GetButtonControl(index).BackColor = Color.Red;
                GetButtonControl(index).Text = "*";
                for (int i = 0; i < btnIndex.Count; i++)
                {
                    btnIndex[i].Text = "*";
                }
                MessageBox.Show("Game Over :(");
                Form1.ActiveForm.Close();
            }
            #endregion
            

            #region 0th button
            if (index == 0)
            {
               bool mineCheck1 = btnIndex.Contains(GetButtonControl(index + 1));
               bool mineCheck2 = btnIndex.Contains(GetButtonControl(index + 10));
               bool mineCheck3 = btnIndex.Contains(GetButtonControl(index + 11));
               
                //F-F-F   
                if((!mineCheck1 && !mineCheck2) && !mineCheck3)
                {
                    GetButtonControl(index).Text = "0";
                }
                //F-F-T
                else if((!mineCheck1 && !mineCheck2) && mineCheck3)
                {
                    GetButtonControl(index).Text = "1";
                }
                //F-T-T
                else if((!mineCheck1 && mineCheck2) && mineCheck3)
                {
                    GetButtonControl(index).Text = "2";
                }
                //F-T-F
                else if((!mineCheck1 && mineCheck2) && !mineCheck3)
                {
                    GetButtonControl(index).Text = "1";
                }
                //T-F-F
                else if((mineCheck1 && !mineCheck2) && !mineCheck3)
                {
                    GetButtonControl(index).Text = "1";
                }
                //T-T-F
                else if((mineCheck1 && mineCheck2) && !mineCheck3)
                {
                    GetButtonControl(index).Text = "2";
                }
                //T-T-T
                else if((mineCheck1 && mineCheck2) && mineCheck3)
                {
                    GetButtonControl(index).Text = "3";
                }
                //T-F-T
                else if((mineCheck1 && !mineCheck2) && mineCheck3)
                {
                    GetButtonControl(index).Text = "2";
                }
               
            }
            #endregion

            #region 1th button
            if (index == 1)
            {
                bool mineCheck1 = btnIndex.Contains(GetButtonControl(index - 1));
                bool mineCheck2 = btnIndex.Contains(GetButtonControl(index + 1));
                bool mineCheck3 = btnIndex.Contains(GetButtonControl(index + 9));
                bool mineCheck4 = btnIndex.Contains(GetButtonControl(index + 10));
                bool mineCheck5 = btnIndex.Contains(GetButtonControl(index + 11));

                //F-F-F   
                if ((!mineCheck1 && !mineCheck2) && !mineCheck3)
                {
                    GetButtonControl(index).Text = "0";
                }
                //F-F-T
                else if ((!mineCheck1 && !mineCheck2) && mineCheck3)
                {
                    GetButtonControl(index).Text = "1";
                }
                //F-T-T
                else if ((!mineCheck1 && mineCheck2) && mineCheck3)
                {
                    GetButtonControl(index).Text = "2";
                }
                //F-T-F
                else if ((!mineCheck1 && mineCheck2) && !mineCheck3)
                {
                    GetButtonControl(index).Text = "1";
                }
                //T-F-F
                else if ((mineCheck1 && !mineCheck2) && !mineCheck3)
                {
                    GetButtonControl(index).Text = "1";
                }
                //T-T-F
                else if ((mineCheck1 && mineCheck2) && !mineCheck3)
                {
                    GetButtonControl(index).Text = "2";
                }
                //T-T-T
                else if ((mineCheck1 && mineCheck2) && mineCheck3)
                {
                    GetButtonControl(index).Text = "3";
                }
                //T-F-T
                else if ((mineCheck1 && !mineCheck2) && mineCheck3)
                {
                    GetButtonControl(index).Text = "2";
                }

            }
            #endregion
            if(index == 11)
            {
                CheckUp(index);
            }

        }
        private Button GetButtonControl(int index)
        {
            return flowMain.Controls.OfType<Button>().ElementAt(index);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowMain_Paint(object sender, PaintEventArgs e)
        {

        }
        private void CheckUp(int index)
        {
            bool mineCheck = btnIndex.Contains(GetButtonControl(index-10));
            if (mineCheck)
            {

            }
        }
        private void CheckDown(int index)
        {

        }
        private void CheckLeft(int index)
        {

        }
        private void CheckRight(int inde)
        {

        }
        private void CheckTopLeft(int index)
        {

        }
        private void CheckTopRight(int index)
        {

        }
        private void CheckBottomLeft(int index)
        {

        }
        private void CheckBottomRight(int index)
        {

        }
    }
}
