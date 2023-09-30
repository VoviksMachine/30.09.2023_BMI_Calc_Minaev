using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _30._09._2023_BMI_Calc_Minaev
{
    public partial class Form1 : Form
    {
        private bool gender = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonMale_Click(object sender, EventArgs e)
        {
            gender = true;
            buttonMale.Enabled = false;
            buttonMale.BackColor = SystemColors.ActiveCaption;
            buttonFemale.Enabled = true;
            buttonFemale.BackColor = SystemColors.Control;
        }

        private void buttonFemale_Click(object sender, EventArgs e)
        {
            gender = false;
            buttonMale.Enabled = true;
            buttonMale.BackColor = SystemColors.Control;
            buttonFemale.Enabled = false;
            buttonFemale.BackColor = SystemColors.ActiveCaption;
        }

        private void buttonClaim_Click(object sender, EventArgs e)
        {
            double BMI, height = double.Parse(textBoxHeight.Text), weight = double.Parse(textBoxWeight.Text);
            
            if(gender)
            {
                height /= 100;
            }
            else
            {
                height /= 110;
            }
            BMI = weight / (height * height);
            labelBMI.Text = BMI.ToString();
            if(BMI < 10)
            {
                trackBarHealth.Value = 10;
            }
            else if(BMI > 40)
            {
                trackBarHealth.Value = 40;
            }
            else
            {
                trackBarHealth.Value = (int)BMI;
            }
            
            if (BMI < 18.5)
            {
                labelHealth.Text = "Недовес";
                pictureBoxHealth.Image = Image.FromFile("C:\\Проекты Программирование\\C#РазработкаПО\\30.09.2023_BMI_Calc_Minaev\\30.09.2023_BMI_Calc_Minaev\\Resources\\bmi-underweight-icon.png");
            }
            else if(BMI >= 18.5 && BMI <25)
            {
                labelHealth.Text = "Здролвый";
                pictureBoxHealth.Image = Image.FromFile("C:\\Проекты Программирование\\C#РазработкаПО\\30.09.2023_BMI_Calc_Minaev\\30.09.2023_BMI_Calc_Minaev\\Resources\\bmi-healthy-icon.png");
            }
            else if(BMI >= 25 &&  BMI < 30)
            {
                labelHealth.Text = "Лишний вес";
                pictureBoxHealth.Image = Image.FromFile("C:\\Проекты Программирование\\C#РазработкаПО\\30.09.2023_BMI_Calc_Minaev\\30.09.2023_BMI_Calc_Minaev\\Resources\\bmi-overweight-icon.png");
            }
            else
            {
                labelHealth.Text = "Ожирение";
                pictureBoxHealth.Image = Image.FromFile("C:\\Проекты Программирование\\C#РазработкаПО\\30.09.2023_BMI_Calc_Minaev\\30.09.2023_BMI_Calc_Minaev\\Resources\\bmi-obese-icon.png");
            }
        }

        private void textBoxHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
