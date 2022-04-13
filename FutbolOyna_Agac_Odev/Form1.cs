using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FutbolOyna_Agac_Odev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetComboBoxes();
        }

        private void SetComboBoxes()
        {
            List<string> HavaDurumu = new List<string> { "Gunesli", "Bulutlu", "Yagmurlu" };
            List<string> Sicaklik = new List<string> { "Sicak", "Ilik", "Soguk" };
            List<string> Nem = new List<string> { "Normal", "Yuksek" };
            List<string> Ruzgar = new List<string> { "Var", "Yok" };
            List<string> SahaBoyutu = new List<string> { "Kucuk", "Orta", "Buyuk" };
            List<string> CimDurumu = new List<string> { "Islak", "Kuru" };

            cbHavaDurumu.DataSource = HavaDurumu;
            cbSicaklik.DataSource = Sicaklik;
            cbNem.DataSource = Nem;
            cbRuzgar.DataSource = Ruzgar;
            cbSahaBoyutu.DataSource = SahaBoyutu;
            cbCimDurumu.DataSource = CimDurumu;

            cbHavaDurumu.Enabled = false;
            cbSicaklik.Enabled = false;
            cbNem.Enabled = false;
            cbRuzgar.Enabled = false;
            cbCimDurumu.Enabled = false;
        }

        public void PrintResult(string result)
        {
            if (result == "Evet")
            {
                lblFutbolOyna.Text = "Oynanabilir";
                lblFutbolOyna.ForeColor = Color.Green;
            }
            else if(result == "Hayir")
            {
                lblFutbolOyna.Text = "Oynanamaz";
                lblFutbolOyna.ForeColor = Color.DarkRed;
            }
            else
            {
                lblFutbolOyna.Text = result;
                lblFutbolOyna.ForeColor = Color.DarkRed;
            }
        }

        private void ResetComboBoxes(ComboBox comboBox)
        {
            if(comboBox == cbSahaBoyutu)
            {
                cbRuzgar.Enabled = false;
                cbSicaklik.Enabled = false;
                cbNem.Enabled = false;
                cbCimDurumu.Enabled = false;
                cbHavaDurumu.Enabled = false;
            }
            else if(comboBox == cbRuzgar)
            {
                cbSicaklik.Enabled = false;
                cbNem.Enabled = false;
                cbCimDurumu.Enabled = false;
                cbHavaDurumu.Enabled = false;
            }
            else if(comboBox == cbSicaklik)
            {
                cbNem.Enabled = false;
                cbCimDurumu.Enabled = false;
                cbHavaDurumu.Enabled = false;
            }
            else if(comboBox == cbNem)
            {
                cbCimDurumu.Enabled = false;
            }
            else if(comboBox == cbHavaDurumu)
            {
                cbCimDurumu.Enabled = false;
            }
        }

        private void cbSahaBoyutu_SelectedValueChanged(object sender, EventArgs e)
        {
            string value = (sender as ComboBox).SelectedItem as string;

            if(value == "Buyuk")
            {
                PrintResult("Hayir");
                ResetComboBoxes(sender as ComboBox);
            }
            else
            {
                PrintResult("?");
                cbRuzgar.Enabled = true;
            }
        }

        private void cbRuzgar_SelectedValueChanged(object sender, EventArgs e)
        {
            string value = (sender as ComboBox).SelectedItem as string;

            if ((cbSahaBoyutu.SelectedItem as string) == "Orta")
            {
                if (value == "Var")
                {
                    PrintResult("Hayir");
                    ResetComboBoxes(sender as ComboBox);
                }
                else
                {
                    PrintResult("?");
                    cbSicaklik.Enabled = true;
                }
            }
            else
            {
                if (value == "Yok")
                {
                    PrintResult("Evet");
                    ResetComboBoxes(sender as ComboBox);
                }
                else
                {
                    PrintResult("?");
                    cbSicaklik.Enabled = true;
                }
            }
        }

        private void cbSicaklik_SelectedValueChanged(object sender, EventArgs e)
        {
            string value = (sender as ComboBox).SelectedItem as string;

            if (value == "Sicak")
            {
                PrintResult("Evet");
                ResetComboBoxes(sender as ComboBox);
            }
            else if (value == "Soguk")
            {
                PrintResult("Hayir");
                ResetComboBoxes(sender as ComboBox);
            }
            else
            {
                PrintResult("?");
                if ((cbSahaBoyutu.SelectedItem as string) == "Orta")
                    cbHavaDurumu.Enabled = true;
                else
                    cbNem.Enabled = true;
            }
        }

        private void cbNem_SelectedValueChanged(object sender, EventArgs e)
        {
            string value = (sender as ComboBox).SelectedItem as string;

            if (value == "Yuksek")
            {
                PrintResult("Hayir");
                ResetComboBoxes(sender as ComboBox);
            }
            else
            {
                PrintResult("?");
                cbCimDurumu.Enabled = true;
            }
        }

        private void cbHavaDurumu_SelectedValueChanged(object sender, EventArgs e)
        {
            string value = (sender as ComboBox).SelectedItem as string;

            if (value == "Bulutlu")
            {
                PrintResult("Evet");
                ResetComboBoxes(sender as ComboBox);
            }
            else if (value == "Yagmurlu")
            {
                PrintResult("Hayir");
                ResetComboBoxes(sender as ComboBox);
            }
            else
            {
                PrintResult("?");
                cbCimDurumu.Enabled = true;
            }
        }

        private void cbCimDurumu_SelectedValueChanged(object sender, EventArgs e)
        {
            string value = (sender as ComboBox).SelectedItem as string;

            if (value == "Kuru")
                PrintResult("Evet");
            else
                PrintResult("Hayir");
        }

    }
}
