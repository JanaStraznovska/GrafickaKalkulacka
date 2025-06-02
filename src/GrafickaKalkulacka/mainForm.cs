using System;
using System.Windows.Forms;
using KalkulackaPlus;

namespace GrafickaKalkulacka
{
    public partial class mainForm : Form
    {
        Kalkulacka kalkulacka = new Kalkulacka();
        double cisloOdUzivatele;
        char znaminkoOperace;
        bool prvniCisloZadano = false;

        public mainForm()
        {
            InitializeComponent();
        }

        public bool ZiskejCisloZLabelu()
        {
            if (double.TryParse(vysledekLabel.Text, out cisloOdUzivatele) == false)
            {
                return false;
            }

            vysledekLabel.Text = "";
            if (!prvniCisloZadano)
            {
                kalkulacka.Pricti(cisloOdUzivatele);
                prvniCisloZadano = true;
            }

            return true;
        }

        public void VypisVysledek()
        {
            double vysledek = kalkulacka.ZiskejVysledek();
            vysledekLabel.Text = vysledek.ToString();
        }

        private void cisloButton_Click(object sender, EventArgs e)
        {
            string textNaTlacitku = ((Button)sender).Text;
            vysledekButton.Focus();
            if (vysledekLabel.Text == "0")
            {
                if (textNaTlacitku != ",") 
                {
                    vysledekLabel.Text = string.Empty;
                }   
            }
            if (textNaTlacitku == ",")
            {
                if (vysledekLabel.Text.Contains(","))
                {
                    return;
                }
            }
            if (vysledekLabel.Text.Length < 12)
            {
                vysledekLabel.Text += textNaTlacitku;
            }

                   
        }
        private void operator_Click(object sender, EventArgs e)
        {
            if (ZiskejCisloZLabelu() == false)
            {
                return;
            }
            Button znamenkoButton = ((Button)sender);
            znaminkoOperace = znamenkoButton.Text[0];
            aktualniZnaminkoLabel.Text = $"{kalkulacka.ZiskejVysledek()} {znamenkoButton.Text}";
            vysledekButton.Focus();
        }

        private void vysledekButton_Click(object sender, EventArgs e)
        {
            ZiskejCisloZLabelu();

            switch (znaminkoOperace)
            {
                case '/':
                    kalkulacka.Vydel(cisloOdUzivatele);
                    break;
                case '*':
                    kalkulacka.Vynasob(cisloOdUzivatele);
                    break;
                case '+':
                    kalkulacka.Pricti(cisloOdUzivatele);
                    break;
                case '-':
                    kalkulacka.Odecti(cisloOdUzivatele);
                    break;
                case '^':
                    kalkulacka.Umocni((int)cisloOdUzivatele);
                    break;

            }
            aktualniZnaminkoLabel.Text = string.Empty;
            VypisVysledek();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            vysledekLabel.Text = "0";
            kalkulacka.Reset();
            aktualniZnaminkoLabel.Text = string.Empty;
            prvniCisloZadano = false;
            znaminkoOperace = ' ';
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteButton.PerformClick();
            }
            else if (e.KeyCode == Keys.C && e.Control)
            {
                Clipboard.SetText(vysledekLabel.Text);
            }
            else if (e.KeyCode == Keys.V && e.Control)
            {
                vysledekLabel.Text = Clipboard.GetText();
            }
        }

        private void mainForm_KeyPress(object sender, KeyPressEventArgs e)
        {

            switch (e.KeyChar)
            {
                case '0':
                    cislo0Button.PerformClick();
                    break;
                case '1':
                    cislo1Button.PerformClick();
                    break;
                case '2':
                    cislo2Button.PerformClick();
                    break;
                case '3':
                    cislo3Button.PerformClick();
                    break;
                case '4':
                    cislo4Button.PerformClick();
                    break;
                case '5':
                    cislo5Button.PerformClick();
                    break;
                case '6':
                    cislo6Button.PerformClick();
                    break;
                case '7':
                    cislo7Button.PerformClick();
                    break;
                case '8':
                    cislo8Button.PerformClick();
                    break;
                case '9':
                    cislo9Button.PerformClick();
                    break;
                case '/':
                    deleniButton.PerformClick();
                    break;
                case '*':
                    nasobeniButton.PerformClick();
                    break;
                case '+':
                    scitaniButton.PerformClick();
                    break;
                case '-':
                    odecitaniButton.PerformClick();
                    break;
                case '^':
                    mocneniButton.PerformClick();
                    break;
                case '=':
                    vysledekButton.PerformClick(); 
                    break;
                case ',':
                    doubleButton.PerformClick();
                    break;
            }


            // Mnohem kratsi moznost, ke ktero jsem byla dovedena pomoci, ale nechci ji vydavat za svoji.
            /*
            for (int i = 0; i < this.Controls.Count; i++)
            {
                Control control = this.Controls[i];

                if (control is Button button)
                {
                    if (e.KeyChar == button.Text[0])
                    {
                        button.PerformClick();
                    }
                }
            }
            */
        }


    }
}
