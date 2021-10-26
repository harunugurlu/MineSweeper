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
                var btnInactivate = flowMain.Controls.OfType<Button>().ToList();
                for (int i = 0; i < 100; i++)
                {
                    btnInactivate[i].Enabled = false;
                }
            }
            #endregion
          
            
            else {
                int btnCheck = IsValid(index);
                switch (btnCheck)
                {
                    case 0:
                        ButtonZero(index);
                        break;

                    case 1:
                        ButtonNine(index);
                        break;

                    case 2:
                        ButtonNinety(index);
                        break;

                    case 3:
                        ButtonNinetyNine(index);
                        break;

                    case 4:
                        ButtonModZero(index);
                        break;

                    case 5:
                        ButtonModOne(index);
                        break;

                    case 6:
                        ButtonTopRow(index);
                        break;

                    case 7:
                        ButtonBottomRow(index);
                        break;

                    case 8:
                        ButtonMid(index);
                        break;
                }
                GetButtonControl(index).Text = count.ToString();
            }
            count = 0;
        }
        private Button GetButtonControl(int index)
        {
            return flowMain.Controls.OfType<Button>().ElementAt(index);
        }
        private int IsValid(int index)
        {
            if(index == 0) //Button zero
            {
                return 0;
            }
            if(index == 9)//Button nine
            {
                return 1;
            }
            if(index == 90)//Buttton ninety
            {
                return 2;
            }
            if(index == 99)//Button ninetynine
            {
                return 3;
            }
            if(index % 10 == 0)//Button mod zero
            {
                return 4;
            }
            if (index % 10 == 1)//Button mod one
            {
                return 5;
            }
            if (0 < index && index <10)//Button top row
            {
                return 6;
            }
            if (90 < index && index < 100) //Button bottom row
            {
                return 7;
            }


            return 8; //Button Mid
        }
        private void ButtonZero (int index)
        {
            if (btnIndex.Contains(GetButtonControl(index + 1)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 10)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 11)))
            {
                count++;
            }
        }
        private void ButtonNine(int index)
        {
            if (btnIndex.Contains(GetButtonControl(index - 1)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 9)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 10)))
            {
                count++;
            }
        }
        private void ButtonNinety(int index)
        {
            if (btnIndex.Contains(GetButtonControl(index - 10)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index - 9)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 1)))
            {
                count++;
            }
        }
        private void ButtonNinetyNine(int index)
        {
            if (btnIndex.Contains(GetButtonControl(index - 11)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index - 10)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index - 1)))
            {
                count++;
            }
        }
        private void ButtonModZero(int index)
        {
            if (btnIndex.Contains(GetButtonControl(index - 10)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index - 9)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 1)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 10)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 11)))
            {
                count++;
            }
        }
        private void ButtonModOne(int index)
        {
            if (btnIndex.Contains(GetButtonControl(index - 11)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index - 10)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index - 1)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 9)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 10)))
            {
                count++;
            }
        }

        private void ButtonTopRow(int index)
        {
            if (btnIndex.Contains(GetButtonControl(index - 1)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 1)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 9)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 10)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 11)))
            {
                count++;
            }
        }
        
        private void ButtonBottomRow(int index)
        {
            if (btnIndex.Contains(GetButtonControl(index - 11)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index - 10)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index - 9)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index - 1)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 1)))
            {
                count++;
            }

        }
        private void ButtonMid(int index)
        {
            if (btnIndex.Contains(GetButtonControl(index - 11)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index - 10)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index - 9)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index - 1)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 1)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 9)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 10)))
            {
                count++;
            }
            if (btnIndex.Contains(GetButtonControl(index + 11)))
            {
                count++;
            }
        }
        private void ButtonNoMine(int index)
        {
            int btnCheck = IsValid(index);
            switch (btnCheck)
            {
                case 0:
                    ButtonZero(index);
                    break;

                case 1:
                    ButtonNine(index);
                    break;

                case 2:
                    ButtonNinety(index);
                    break;

                case 3:
                    ButtonNinetyNine(index);
                    break;

                case 4:
                    ButtonModZero(index);
                    break;

                case 5:
                    ButtonModOne(index);
                    break;

                case 6:
                    ButtonTopRow(index);
                    break;

                case 7:
                    ButtonBottomRow(index);
                    break;

                case 8:
                    ButtonMid(index);
                    break;
            }
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
        
        

    }
}
