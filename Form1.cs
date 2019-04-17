using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gas_Station
{
    public partial class Form1 : Form
    {
        double D_Benzin95 = 0, D_Benzin97 = 0, D_Dizel = 0, D_EuroDizel = 0, D_LPG = 0;
        double E_Benzin95 = 0, E_Benzin97 = 0, E_Dizel = 0, E_EuroDizel = 0, E_LPG = 0;
        double F_Benzin95 = 0, F_Benzin97 = 0, F_Dizel = 0, F_EuroDizel = 0, F_LPG = 0;
        double S_Benzin95 = 0, S_Benzin97 = 0, S_Dizel = 0, S_EuroDizel = 0, S_LPG = 0;
        //--------D_ = In inentory || E_ = Adding value || F_ = Cost || S_ = selling value ||---------------------
        string[] depo_bilgileri;
        string[] fiyat_bilgileri;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Gasoline (95)")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "Gasoline (97)")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "Diesel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "Euro Diesel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;
            }
            if (comboBox1.Text == "LPG")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;
            }
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            lbl29.Text = "______";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lbl29.Visible = true;
            S_Benzin95 = double.Parse(numericUpDown1.Value.ToString());
            S_Benzin97 = double.Parse(numericUpDown2.Value.ToString());
            S_Dizel = double.Parse(numericUpDown3.Value.ToString());
            S_EuroDizel = double.Parse(numericUpDown4.Value.ToString());
            S_LPG = double.Parse(numericUpDown5.Value.ToString());

            if (numericUpDown1.Enabled == true)
            {
                D_Benzin95 = D_Benzin95 - S_Benzin95;
                lbl29.Text = Convert.ToString(S_Benzin95 * F_Benzin95);
            }
            else if ( numericUpDown2.Enabled == true)
            {
                D_Benzin97 = D_Benzin97 - S_Benzin97;
                lbl29.Text = Convert.ToString(S_Benzin97 * F_Benzin97);
            }
            else if (numericUpDown3.Enabled == true)
            {
                D_Dizel = D_Dizel - S_Dizel;
                lbl29.Text = Convert.ToString(S_Dizel * F_Dizel);
            }
            else if ( numericUpDown4.Enabled == true)
            {
                D_EuroDizel = D_EuroDizel - S_EuroDizel;
                lbl29.Text = Convert.ToString(S_EuroDizel * F_EuroDizel);
            }
            else if (numericUpDown5.Enabled == true)
            {
                D_LPG = D_LPG - S_LPG;
                lbl29.Text = Convert.ToString(S_LPG * F_LPG);
            }

            depo_bilgileri[0] = Convert.ToString(D_Benzin95);
            depo_bilgileri[1] = Convert.ToString(D_Benzin97);
            depo_bilgileri[2] = Convert.ToString(D_Dizel);
            depo_bilgileri[3] = Convert.ToString(D_EuroDizel);
            depo_bilgileri[4] = Convert.ToString(D_LPG);

            System.IO.File.WriteAllLines(Application.StartupPath + "\\Inventory.txt", depo_bilgileri);
            txt_depo_oku();
            txt_depo_yaz();
            progressbar_update();
            numericUpDown_value();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                F_Benzin95 = F_Benzin95 + (F_Benzin95 * Convert.ToDouble
                    (tb6.Text) / 100);
                fiyat_bilgileri[0] = Convert.ToString(F_Benzin95);
            }
            catch (Exception)
            {
                tb6.Text = "ERROR!";
            }
            try
            {
                F_Benzin97 = F_Benzin97 + (F_Benzin97 * Convert.ToDouble
                    (tb7.Text) / 100);
                fiyat_bilgileri[1] = Convert.ToString(F_Benzin97);
            }
            catch (Exception)
            {
                tb7.Text = "ERROR!";
            }
            try
            {
                F_Dizel = F_Dizel + (F_Dizel * Convert.ToDouble
                  (tb8.Text) / 100);
                fiyat_bilgileri[2] = Convert.ToString(F_Dizel);
            }
            catch (Exception)
            {
                tb8.Text = "ERROR!";
            }
            try
            {
                F_EuroDizel = F_EuroDizel + (F_EuroDizel * Convert.ToDouble
                    (tb9.Text) / 100);
                fiyat_bilgileri[3] = Convert.ToString(F_EuroDizel);
            }
            catch (Exception)
            {
                tb9.Text = "ERROR!";
            }
            try
            {
                F_LPG = F_LPG + (F_LPG * Convert.ToDouble
                    (tb10.Text) / 100);
                fiyat_bilgileri[4] = Convert.ToString(F_LPG);
            }
            catch (Exception)
            {
                tb10.Text = "ERROR!";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\cost.txt", fiyat_bilgileri);
            txt_fiyat_oku();
            txt_fiyat_yaz();
        } //--------ARRANGE raise and discount|| try catch is used-------
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                E_Benzin95 = Convert.ToDouble(tb1.Text);
                if (1000 < E_Benzin95 + D_Benzin95 || E_Benzin95 <= 0)
                    tb1.Text = "ERROR!";

                else depo_bilgileri[0] = Convert.ToString(D_Benzin95 + E_Benzin95);
            }
           
            catch (Exception)
            {
                   tb1.Text = "ERROR!";
            }
            try
            {
                E_Benzin97 = Convert.ToDouble(tb2.Text);
                if (1000 < E_Benzin97 + D_Benzin97 || E_Benzin97 <= 0)
                    tb2.Text = "ERROR!";

                else depo_bilgileri[1] = Convert.ToString(D_Benzin97 + E_Benzin97);
            }

            catch (Exception)
            {
                tb2.Text = "ERROR!";
            }
            try
            {
                E_Dizel = Convert.ToDouble(tb3.Text);
                if (1000 < E_Dizel + D_Dizel || E_Dizel <= 0)
                    tb3.Text = "ERROR!";

                else depo_bilgileri[2] = Convert.ToString(D_Dizel + E_Dizel);
            }

            catch (Exception)
            {
                tb3.Text = "ERROR!";
            }   //---------Try bloğunda progress bar'ın 1000 den fazla değer alamaması-hata vermesi------------
            try
            {
                E_EuroDizel = Convert.ToDouble(tb4.Text);
                if (1000 < E_EuroDizel + D_EuroDizel || E_EuroDizel <= 0)
                    tb4.Text = "ERROR!";

                else depo_bilgileri[3] = Convert.ToString(D_EuroDizel + E_EuroDizel);
            }

            catch (Exception)
            {
                tb4.Text = "ERROR!";
            }   //---------Sorun yoksa değeri yazması---------------------------------------------------
            try
            {
                E_LPG = Convert.ToDouble(tb5.Text);
                if (1000 < E_LPG + D_LPG || E_LPG <= 0)
                    tb5.Text = "ERROR!";

                else depo_bilgileri[4] = Convert.ToString(D_LPG + E_LPG);
            }
            catch (Exception)
            {
                tb5.Text = "ERROR!";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\Inventory.txt", depo_bilgileri);
            txt_depo_oku();
            txt_depo_yaz();
            progressbar_update();       //-----Yukarıdaki değerlerin txt dosyasına atılması ve update edilmesi -----------
            numericUpDown_value();
        } //--------Button 1 deki yazdırma ve try catch yapısı --------------

        // METHODS ARE CREATED IN BELOW ---------------------------------------------------------------------
        private void txt_depo_oku()
        {
            depo_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\inventory.txt");
            //Debug klasörünün içindeki her satırı oku, ve depo bilgileri dizinine aktar.
            // 5 satır olduğundan 5 elemanı oldu 100 adet satır olsa 100 elemanı olurdu.
            D_Benzin95 = Convert.ToDouble(depo_bilgileri[0]);
            // d_benzin double türünde ama dizimiz string türünde o yüzden convert ediyoruz.
            D_Benzin97 = Convert.ToDouble(depo_bilgileri[1]);
            D_Dizel = Convert.ToDouble(depo_bilgileri[2]);
            D_EuroDizel = Convert.ToDouble(depo_bilgileri[3]);
            D_LPG = Convert.ToDouble(depo_bilgileri[4]);
        }
        private void txt_depo_yaz()
        {
            lbl6.Text = D_Benzin95.ToString("N");
            //virgülden sonraki basamak sayısını 2' ye ayarlamayı sağlar "N"
            lbl7.Text = D_Benzin97.ToString("N");
            lbl8.Text = D_Dizel.ToString("N");
            lbl9.Text = D_EuroDizel.ToString("N");
            lbl10.Text = D_LPG.ToString("N");
        }
        private void txt_fiyat_oku()
        {
            fiyat_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\cost.txt");
            F_Benzin95 = Convert.ToDouble(fiyat_bilgileri[0]);
            F_Benzin97 = Convert.ToDouble(fiyat_bilgileri[1]);
            F_Dizel = Convert.ToDouble(fiyat_bilgileri[2]);
            F_EuroDizel = Convert.ToDouble(fiyat_bilgileri[3]);
            F_LPG = Convert.ToDouble(fiyat_bilgileri[4]);
        }
        private void txt_fiyat_yaz()
        {
            lbl16.Text = F_Benzin95.ToString("N");
            lbl17.Text = F_Benzin97.ToString("N");
            lbl18.Text = F_Dizel.ToString("N");
            lbl19.Text = F_EuroDizel.ToString("N");
            lbl20.Text = F_LPG.ToString("N");
        }
        private void progressbar_update()
        {
            progressBar1.Value = Convert.ToUInt16(D_Benzin95);
            progressBar2.Value = Convert.ToUInt16(D_Benzin97);
            progressBar3.Value = Convert.ToUInt16(D_Dizel);
            progressBar4.Value = Convert.ToInt16(D_EuroDizel);
            progressBar5.Value = Convert.ToInt16(D_LPG);
        }
        private void numericUpDown_value()
        {
            numericUpDown1.Maximum = decimal.Parse(D_Benzin95.ToString());
            // D_benzin değerini önce stringe dönüştürüyoruz. sonra decimale. çünkü  direk olarak decimale dönüştürülemez.
            numericUpDown2.Maximum = decimal.Parse(D_Benzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(D_Dizel.ToString());
            numericUpDown4.Maximum = decimal.Parse(D_EuroDizel.ToString());
            numericUpDown5.Maximum = decimal.Parse(D_LPG.ToString());
        }
        // -----------------------------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label19_Click(object sender, EventArgs e)
        {

        }
        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl29.Visible = false;
            this.Text= "GAS STATION : BY MUSTAFA ALPARSLAN PAMUK";
            progressBar1.Maximum = 1000;
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;
            txt_depo_oku();
            txt_depo_yaz();
            txt_fiyat_oku();
            txt_fiyat_yaz();
            progressbar_update();
            numericUpDown_value();

            string[] yakit_turleri = { "Gasoline (95)", "Gasoline (97)", "Diesel", "Euro Diesel", "LPG" };
            comboBox1.Items.AddRange(yakit_turleri);

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;           // virgülden sonraki basamak
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;

            numericUpDown1.Increment = 0.1m;
            numericUpDown2.Increment = 0.1m;
            numericUpDown3.Increment = 0.1m;            // increment değerini ondalıklı verdiğimiz zaman sonuna M koyulmalı!
            numericUpDown4.Increment = 0.1m;
            numericUpDown5.Increment = 0.1m;

            numericUpDown1.ReadOnly = true;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;              // dışarıdan numeric up downa veri girilememesi için
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;
            

        }
    }
}
