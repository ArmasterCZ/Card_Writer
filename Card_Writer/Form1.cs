using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;

namespace Card_Writer
{

    public partial class Form1 : Form
    {
        //public string verze = "1.8";
        public string verze = Application.ProductVersion;

        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(this.label1, "Uživatelské jméno. Např: ftester.");
            toolTip1.SetToolTip(this.label2, "Desítková soustava.");
            toolTip1.SetToolTip(this.textBox_Name, "Zadej jméno uživatele.");
            toolTip1.SetToolTip(this.textBox_PreCard, "Zadej číslo karty v desítkové soustavě.");
            this.Text = "PowerShell - Card Writer V" + verze;

            //TODO:
            //zaskrtavatko na vypsani spusteneho skriptu. (mozna misto spusteni) = pomoc pokud by skript nesel spoustet mimo powershell
            //po zaškrtnutí přehodit kurzor do kolonky
        }

        //tlačítka

        private void button_clean_Click(object sender, EventArgs e)
        {
            ADuser_Class user1 = new ADuser_Class();
            refreshTextBoxData(user1);
            textBox_CardNumber.Text = "81AE04C300000";
            richTextBox1.Text = "";
            textBox_PreCard.Text = "";
        }

        private void TextBoxData_To_Console(object sender, EventArgs e)
        {
            TextBox[] allTextBoxes = { textBox_Name, textBox_Fullname, textBox_CardNumber, textBox_Mob, textBox_Tel, textBox_Place, textBox_Title };
            foreach (TextBox textboxActual in allTextBoxes)
            {
                if (textboxActual.Text != "")
                {
                    richTextBox1.Text += Environment.NewLine + textboxActual.Text;
                }
            }
        }

        private void checkBox_comfirm_Click(object sender, EventArgs e)
        {
            //zpracovava udalosti vyvolané checkBoxy
            //textbox dec
            if (sender == checkBox_PreCard)
            {
                if (checkBox_PreCard.Checked)
                {
                    checkBox_CardNumber.Checked = false;
                    textBox_PreCard.Enabled = true;
                    textBox_CardNumber.Enabled = false;
                }
                else
                {
                    textBox_PreCard.Enabled = false;
                }

            }
            //textbox hec
            if (sender == checkBox_CardNumber)
            {
                if (checkBox_CardNumber.Checked)
                {
                    checkBox_PreCard.Checked = false;
                    textBox_PreCard.Enabled = false;
                    textBox_CardNumber.Enabled = true;
                }
                else
                {
                    textBox_CardNumber.Enabled = false;
                }

            }
            //textbox user
            if (sender == checkBox_Name)
            {
                if (checkBox_Name.Checked)
                {
                    textBox_Name.Enabled = true;
                }
                else
                {
                    textBox_Name.Enabled = false;
                }
            }
            //button comfirm text
            if (checkBox_Name.Checked)
            {
                if(checkBox_CardNumber.Checked | checkBox_PreCard.Checked)
                {
                    button_comfirm.Text = "Zapsat";
                }
                else
                {
                    button_comfirm.Text = "Najít";
                }
            }
            else
            {
                button_comfirm.Text = "Najít";
            }
            
        }

        private void executeOrder(object sender, EventArgs e)
        {
            //rozřazení spuštěné operace podle zaškrtávátek
            richTextBox1.Text = "";
            progressBar1.Value = 100;
            progressBar1.Visible = true;
            bool Xname = checkBox_Name.Checked;
            bool XpreCard = checkBox_PreCard.Checked;
            bool XCardNumber = checkBox_CardNumber.Checked;
            ADuser_Class user1 = new ADuser_Class();

            
            if (Xname)
            {
                //Zaškrtlé: +jméno
                if (checkIstEmpty(textBox_Name.Text,"jména"))
                {
                    //vyplněné jméno
                    user1.userNameAcco = textBox_Name.Text;
                    if (XpreCard | XCardNumber)
                    {
                        //Zaškrtlé: +jmeno +karta (jedna nebo druhá)
                        user1 = PS_GetOldCardNumber_UserName(user1);
                        //převedení čísla karty do druhého formátu
                        if (XpreCard)
                        {
                            user1.cardNumberPre = textBox_PreCard.Text;
                            user1.cardNumberFull = "81AE04C300000" + converter_Dec_To_Hex(user1.cardNumberPre);
                        }
                        else
                        {
                            user1.cardNumberFull = textBox_CardNumber.Text;
                            user1.cardNumberPre = converter_CardNumber_to_Dec(user1.cardNumberFull);
                        }
                        refreshTextBoxData(user1);

                        //if (checkIstEmpty(textBox_PreCard.Text, "karty"))
                        if (!(textBox_PreCard.Text == ""))
                        {
                            //vyplněná karta

                            //pokus o nalezení karty (aby nebyla zapsána duplicita)
                            ADuser_Class user2 = PS_SearchUser_CardNumber(user1);
                            if (user2.userNameFull != "")
                            {
                                MessageBox.Show(string.Format("Karta byla již nalezena u uživatele {0}.", user2.userNameFull),"Pozor",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            }

                            //zapsání karty k uživately
                            string textMessage = string.Format("Opravdu chcete změnit číslo karty u uživatele {0} \nZ karty    - {1}\nNa kartu - {2}?", user1.userNameAcco, user1.cardNumberOld, user1.cardNumberFull);
                            DialogResult result1 = MessageBox.Show(textMessage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result1 == DialogResult.Yes)
                            {
                                //Textbox ano na změnu čísla karty
                                PS_WriteNewCardNumber_userName(user1);
                            }
                        } else
                        {
                            //prázdná karta
                            string textMessage = string.Format("Opravdu chcete SMAZAT číslo karty u uživatele {0} \nZ karty    - {1}", user1.userNameAcco, user1.cardNumberOld);
                            DialogResult result1 = MessageBox.Show(textMessage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result1 == DialogResult.Yes)
                            {
                                //Textbox ano na smazání čísla karty
                                PS_ClearCard_userName(user1);
                            }
                            
                        }
                    }
                    else
                    {
                        //Zaškrtlé: +jmeno
                        textBox_Name.Text = user1.userNameAcco;
                        user1 = PS_SearchUser_UserName(user1);
                        refreshTextBoxData(user1);
                    }
                }
            }
            else
            {
                //Zaškrtlé: -jmeno +karta
                if (XpreCard | XCardNumber)
                {
                    //Vyhledaní uživatele podle čísla karty
                    if (XpreCard)
                    {
                        //vyplněn PreCard
                        user1.cardNumberPre = textBox_PreCard.Text;
                        user1.cardNumberFull = "81AE04C300000" + converter_Dec_To_Hex(user1.cardNumberPre);
                    }
                    else
                    {
                        //vyplněn cardNumber
                        user1.cardNumberFull = textBox_CardNumber.Text;
                        user1.cardNumberPre = converter_CardNumber_to_Dec(user1.cardNumberFull);
                    }
                    refreshTextBoxData(user1);
                    if (checkIstEmpty(textBox_PreCard.Text, "karty"))
                    {
                        user1 = PS_SearchUser_CardNumber(user1);
                        refreshTextBoxData(user1);
                    }
                }
                else
                {
                    //Zaškrtlé: -jmeno -karta
                    richTextBox1.Text = "(Nebyla vybrána žádná volba. Zašktněte nějaké políčko.)";
                }
            }
            progressBar1.Visible = false;
            
            //usnadneni zasrtavatek
            if (Xname & XpreCard)
            {
                checkBox_Name.Checked = false;
            }
        }

        //příkazy

        private void refreshTextBoxData (ADuser_Class user1)
        {
            textBox_Name.Text = user1.userNameAcco;
            textBox_Fullname.Text = user1.userNameFull;
            textBox_CardNumber.Text = user1.cardNumberFull;
            textBox_Mob.Text = user1.mob;
            textBox_Tel.Text = user1.tel;
            textBox_Title.Text = user1.title;
            textBox_Place.Text = user1.place;
            //textBox_PreCard.Text = user1.cardNumberPre;
            //if (user1.cardNumberFull != "")
            textBox_PreCard.Text = converter_CardNumber_to_Dec(user1.cardNumberFull);
        }

        private bool checkIstEmpty(string imput, string message)
        {
            bool result = true;
            if (imput == "")
            {
                MessageBox.Show(string.Format("Není vyplněna kolonka {0}. Pro pokračování ji vyplňte.", message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }

            return result;
        }

        private string converter_Dec_To_Hex(int number)
        {
            //převádí číslo z desítkové soustavy do Hexadecimální
            
            //if (number == null) throw new Exception( String.Format("Error: metoda - {0}. {1}. ",System.Reflection.MethodBase.GetCurrentMethod().Name, "Číslo je null"));
            string finalNumber = "";
            try
            {
                finalNumber = number.ToString("X");
            }
            catch
            {
                //throw new Exception(String.Format("Error: metoda - {0}. {1}. ", System.Reflection.MethodBase.GetCurrentMethod().Name, "Číslo je null"));
                finalNumber = "";
            }

            return finalNumber;
        }

        private string converter_Dec_To_Hex(string number)
        {
            //převádí číslo z desítkové soustavy do Hexadecimální
            string finalNumber = "";
            try
            {
                int number2 = Int32.Parse(number);
                finalNumber = number2.ToString("X");
            } catch
            {
                richTextBox1.Text += Environment.NewLine + "Error: chyba při převodu z Dec do Hex. " + "Dec číslo:" + number;
                finalNumber = "";
            }

            return finalNumber;
        }

        private string converter_Hex_To_Dec(string number)
        {
            //převádí číslo z hexadecimální soustavy do desítkové.
            string finalNumber = "";
            try
            {
                finalNumber = int.Parse(number, System.Globalization.NumberStyles.HexNumber).ToString();
            }
            catch
            {
                richTextBox1.Text += Environment.NewLine + "Error: chyba při převodu z Hex do Dec. " + "Hex číslo:" + number;
                finalNumber = "";
            }

            return finalNumber;
        }

        private string converter_CardNumber_to_Dec(string cardNumber)
        {
            //převede poslední tři čísla karty (z 16ti znaků) z hexadecimální na Desítkovou
            string preNumber = "";
            string lastNumbers;

            if (cardNumber.Length == 16)
            {
                lastNumbers = cardNumber.Substring(cardNumber.Length - 3);
                //lastNumber = cardNumber[13] + "" + cardNumber[14] + "" + cardNumber[15] + "";
                preNumber = converter_Hex_To_Dec(lastNumbers);
            }
            else if(cardNumber.Length == 0)
            {
                richTextBox1.Text += Environment.NewLine + "Číslo karty nenalezeno.";
            } else
            {
                richTextBox1.Text += Environment.NewLine + "Error: špatná délka čísla karty.";
            }
            return preNumber;
        }

        //PowerShell

        private ADuser_Class PS_SearchUser_UserName(ADuser_Class user1)
        {
            //spustí PowerShell script na vyhledání uživatele na základě jména
            if (user1.userNameAcco != "")
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    using (var powerShell = PowerShell.Create())
                    {
                        richTextBox1.Text += Environment.NewLine + "(Hledám uživatele podle jména)";

                        //Get-ADUser -filter 'sAMAccountName -like $ADuser' -Properties PhysicalDeliveryOfficeName, title, sAMAccountName | Format-table Name, sAMAccountName,PhysicalDeliveryOfficeName, Title
                        powerShell.Runspace = runspace;
                        powerShell.Runspace.Open();
                        //Import-Module ActiveDirectory; 
                        powerShell.AddScript("Get-ADUser -filter 'sAMAccountName -like " + '"' + user1.userNameAcco + '"' + "' -Properties name, sAMAccountName, title, PhysicalDeliveryOfficeName, pager, otherPager, mobile, TelephoneNumber | select name, sAMAccountName, title, PhysicalDeliveryOfficeName, pager, mobile, TelephoneNumber, @{name=" + '"' + "otherPager" + '"' + ";expression={$_.otherPager -join " + '"' + ";" + '"' + "}}");

                        // Výsledky
                        foreach (PSObject result in powerShell.Invoke())
                        {
                            try { user1.userNameFull = result.Members["name"].Value.ToString(); } catch { }
                            try { user1.userNameAcco = result.Members["sAMAccountName"].Value.ToString(); } catch { }
                            try { user1.cardNumberFull = result.Members["otherPager"].Value.ToString(); } catch { }
                            try { user1.place = result.Members["PhysicalDeliveryOfficeName"].Value.ToString(); } catch { }
                            try { user1.title = result.Members["title"].Value.ToString(); } catch { }
                            try { user1.tel = result.Members["TelephoneNumber"].Value.ToString(); } catch { }
                            try { user1.mob = result.Members["mobile"].Value.ToString(); } catch { }
                        }
                        richTextBox1.Text += Environment.NewLine + "(Hledani uživatele podle jména dokončeno.)";
                        powerShell.Runspace.Close();
                    }
                }
            }
            else
            {
                richTextBox1.Text += Environment.NewLine + "(Error. Prázdné jméno)";
            }
            return user1;
        }

        private ADuser_Class PS_SearchUser_CardNumber(ADuser_Class user1)
        {
            //spustí PowerShell script na vyhledání uživatele na základě čísla karty
            if (user1.cardNumberFull != "")
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    using (var powerShell = PowerShell.Create())
                    {
                        richTextBox1.Text += Environment.NewLine + "(Hledám uživatele podle jména)";

                        //Get-ADUser -filter 'sAMAccountName -like $ADuser' -Properties PhysicalDeliveryOfficeName, title, sAMAccountName | Format-table Name, sAMAccountName,PhysicalDeliveryOfficeName, Title
                        powerShell.Runspace = runspace;
                        powerShell.Runspace.Open();

                        powerShell.AddScript("Get-ADUser -filter 'otherPager -like " + '"' + user1.cardNumberFull + '"' + "' -Properties name, sAMAccountName, title, PhysicalDeliveryOfficeName, pager, otherPager, mobile, TelephoneNumber | select name, sAMAccountName, title, PhysicalDeliveryOfficeName, pager, mobile, TelephoneNumber, @{name=" + '"' + "otherPager" + '"' + ";expression={$_.otherPager -join " + '"' + ";" + '"' + "}}");

                        // Výsledky
                        bool multipleResults = false;
                        foreach (PSObject result in powerShell.Invoke())
                        {
                            //kontrola nalezení více výsledků
                            if (multipleResults)
                            {
                                MessageBox.Show("Dané číslo nalezeno u více jak jednoho uživatele: " + user1.userNameAcco);
                            }
                            multipleResults = true;

                            //získání informací z výsledku hledání
                            try { user1.userNameFull = result.Members["name"].Value.ToString(); } catch { }
                            try { user1.userNameAcco = result.Members["sAMAccountName"].Value.ToString(); } catch { }
                            try { user1.cardNumberFull = result.Members["otherPager"].Value.ToString(); } catch { }
                            try { user1.place = result.Members["PhysicalDeliveryOfficeName"].Value.ToString(); } catch { }
                            try { user1.title = result.Members["title"].Value.ToString(); } catch { }
                            try { user1.tel = result.Members["TelephoneNumber"].Value.ToString(); } catch { }
                            try { user1.mob = result.Members["mobile"].Value.ToString(); } catch { }

                            
                        }
                        richTextBox1.Text += Environment.NewLine + "(Hledani uživatele podle jména dokončeno.)";
                        powerShell.Runspace.Close();
                    }
                }
            }
            else
            {
                richTextBox1.Text += Environment.NewLine + "Error. Prázdné číslo karty";
            }
            return user1;
        }

        private ADuser_Class PS_GetOldCardNumber_UserName(ADuser_Class user1)
        {
            //powershellový script na doplnění čísla karty na základě uživatelského jména.
            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                using (var powerShell = PowerShell.Create())
                {
                    powerShell.Runspace = runspace;
                    powerShell.Runspace.Open();
                    powerShell.AddScript("Get-ADUser -filter 'sAMAccountName -like " + '"' + user1.userNameAcco + '"' + "' -Properties name, otherPager | select name, @{name=" + '"' + "otherPager" + '"' + ";expression={$_.otherPager -join " + '"' + ";" + '"' + "}}");
                    // Výsledky
                    foreach (PSObject result in powerShell.Invoke())
                    {
                        try
                        {
                            user1.cardNumberOld = result.Members["otherPager"].Value.ToString();
                        }
                        catch { richTextBox1.Text += Environment.NewLine + "(Cislo karty uživatele nezjisteno.)"; }
                    }
                    powerShell.Runspace.Close();
                }
            }
            return user1;
        }

        private void PS_WriteNewCardNumber_userName(ADuser_Class user1)
        {
            //spustí PowerShell script na zapsání čísla karty.
            //Set-ADUser $ADuser -Replace @{pager="k";otherPager=$Karta} 

            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                using (var powerShell = PowerShell.Create())
                {
                    richTextBox1.Text = "(Zapisování karty uživatele)";
                    powerShell.Runspace = runspace;
                    powerShell.Runspace.Open();
                    powerShell.AddScript("Set-ADUser " + '"' + user1.userNameAcco + '"' + " -Replace @{pager= " + '"' + "k" + '"' + ";otherPager=" + '"' + user1.cardNumberFull + '"' + "}");

                    // Výsledky
                    powerShell.Invoke();

                    if (powerShell.HadErrors)
                    {
                        richTextBox1.Text += Environment.NewLine + "(Errors = " + powerShell.HadErrors + ")";
                    }
                    else
                    {
                        richTextBox1.Text += Environment.NewLine + "(Zapsání karty uživatele dokončeno)";
                    }
                    powerShell.Runspace.Close();
                }
            }
        }

        private void PS_ClearCard_userName(ADuser_Class user1)
        {
            //spustí PowerShell script na vymazání čísla karty.

            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                using (var powerShell = PowerShell.Create())
                {
                    richTextBox1.Text = "(Mazání karty uživatele)";
                    powerShell.Runspace = runspace;
                    powerShell.Runspace.Open();
                    powerShell.AddScript("Set-ADUser -Identity " + '"' + user1.userNameAcco + '"' + " -Clear pager,otherPager");

                    // Výsledky
                    powerShell.Invoke();

                    if (powerShell.HadErrors)
                    {
                        richTextBox1.Text += Environment.NewLine + "(Errors = " + powerShell.HadErrors + ")";
                    }
                    else
                    {
                        richTextBox1.Text += Environment.NewLine + "(Mazání karty uživatele dokončeno)";
                    }
                    powerShell.Runspace.Close();
                }
            }
        }

        //Testovací část

        private void PS_TestScript()
        {
            //otestuje powershellový skript zda na počítači funguje. Vypíše seznam procesů PC.

            //Get-WmiObject win32_process | where {$_.name -like "*powershell*"} | select name
            richTextBox1.Text = "(spuštěn test funkčnosti PowerShellového skriptu.)";
            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                using (var powerShell = PowerShell.Create())
                {
                    string programName = "*";
                    powerShell.Runspace = runspace;
                    if (powerShell.HadErrors)
                        richTextBox1.Text += Environment.NewLine + "(HadErrors =" + powerShell.HadErrors + ")";
                    powerShell.Runspace.Open();
                    powerShell.AddScript("Get-WmiObject win32_process | where {$_.name -like " + '"' + programName + '"' + "}");
                    
                    // Výsledky
                    if (powerShell.HadErrors)
                        richTextBox1.Text += Environment.NewLine + "(HadErrors =" + powerShell.HadErrors + ")";

                    foreach (PSObject result in powerShell.Invoke())
                    {
                        //richTextBox1.Text += Environment.NewLine + result.Members["name"].Value;
                        richTextBox1.Text += Environment.NewLine + result.Members["ProcessName"].Value;
                    }
                    if (powerShell.HadErrors)
                        richTextBox1.Text += Environment.NewLine + "(HadErrors =" + powerShell.HadErrors + ")";

                    powerShell.Runspace.Close();
                }
            }
            richTextBox1.Text += Environment.NewLine + "(Ukončen test funkčnosti PowerShellového skriptu.)";
        }

        private void PS_TestScript2()
        {
            //otestuje powershellový skript zda na počítači funguje. Vypíše seznam procesů PC.

            //Get-WmiObject win32_process | where {$_.name -like "*powershell*"} | select name
            richTextBox1.Text = "(spuštěn test funkčnosti PowerShellového skriptu.)";
            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                using (var powerShell = PowerShell.Create())
                {
                    string programName = "*";
                    powerShell.Runspace = runspace;
                    if (powerShell.HadErrors)
                        richTextBox1.Text += Environment.NewLine + "(HadErrors =" + powerShell.HadErrors + ")";
                    powerShell.Runspace.Open();
                    powerShell.AddScript("Get-WmiObject win32_process | where {$_.name -like " + '"' + programName + '"' + "}");

                    PSObject[] results = powerShell.Invoke().ToArray();
                    //results[83].Properties["ProcessName"].Value.ToString();

                    foreach (PSObject result in results)
                    {
                        richTextBox1.Text += Environment.NewLine + result.Properties["ProcessName"].Value.ToString();
                    }

                    powerShell.Runspace.Close();
                }
            }
            richTextBox1.Text += Environment.NewLine + "(Ukončen test funkčnosti PowerShellového skriptu.)";
        }

        private void PS_TestScriptAD()
        {
            //Get-WmiObject win32_process | where {$_.name -like "*powershell*"} | select name
            richTextBox1.Text = "(spuštěn test funkčnosti PowerShellového AD skriptu.)";
            richTextBox1.Text += Environment.NewLine + "Get-ADUser -filter 'sAMAccountName -like " + '"' + "ftester" + '"' + "' -Properties name, sAMAccountName | Format-table name, sAMAccountName";
            try
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    using (var powerShell = PowerShell.Create())
                    {
                        //Get-ADUser -filter 'sAMAccountName -like $ADuser' -Properties PhysicalDeliveryOfficeName, title, sAMAccountName | Format-table Name, sAMAccountName,PhysicalDeliveryOfficeName, Title
                        powerShell.Runspace = runspace;
                        powerShell.Runspace.Open();
                        powerShell.Commands.AddCommand("Import-Module").AddArgument("ActiveDirectory");
                        powerShell.AddScript("Get-ADUser -filter 'sAMAccountName -like " + '"' + "ftester" + '"' + "' -Properties name, sAMAccountName | select name, sAMAccountName");
                        // Výsledky
                        foreach (PSObject result in powerShell.Invoke())
                        {
                            richTextBox1.Text += Environment.NewLine + result.Members["name"].Value.ToString();
                            richTextBox1.Text += Environment.NewLine + result.Members["sAMAccountName"].Value.ToString();
                        }

                        if (powerShell.HadErrors)
                            richTextBox1.Text += Environment.NewLine + "(HadErrors =" + powerShell.HadErrors + ")";

                        richTextBox1.Text += Environment.NewLine + "(Ukončen test funkčnosti PowerShellového AD skriptu.)";
                    }
                }
            }
            catch (Exception e)
            {
                richTextBox1.Text += Environment.NewLine + "-------ERROR------";
                richTextBox1.Text += Environment.NewLine + e.Message;
                richTextBox1.Text += Environment.NewLine + e.HelpLink;
                //richTextBox1.Text += Environment.NewLine + e.HResult;
                richTextBox1.Text += Environment.NewLine + e.InnerException;
                richTextBox1.Text += Environment.NewLine + e.TargetSite;
                richTextBox1.Text += Environment.NewLine + "-------StackTrace------";
                richTextBox1.Text += Environment.NewLine + e.StackTrace;
            }
        }

        private void PS_TestScriptAD2()
        {
            richTextBox1.Text = "(spuštěn test funkčnosti PowerShellového AD skriptu.)";
            richTextBox1.Text += Environment.NewLine + "Get-ADUser -filter 'sAMAccountName -like " + '"' + "ftester" + '"' + "' -Properties name, sAMAccountName | Format-table name, sAMAccountName";
            using (var runspace = RunspaceFactory.CreateRunspace())
            {
                using (var powerShell = PowerShell.Create())
                {
                    //Get-ADUser -filter 'sAMAccountName -like $ADuser' -Properties PhysicalDeliveryOfficeName, title, sAMAccountName | Format-table Name, sAMAccountName,PhysicalDeliveryOfficeName, Title
                    powerShell.Runspace = runspace;
                    powerShell.Runspace.Open();
                    powerShell.Commands.AddCommand("Import-Module").AddArgument("ActiveDirectory");
                    powerShell.AddScript("Get-ADUser -filter 'sAMAccountName -like " + '"' + "ftester" + '"' + "' -Properties name, sAMAccountName | select name, sAMAccountName");
                    // Výsledky

                    PSObject[] results = powerShell.Invoke().ToArray();
                    //foreach (PSObject Member in results[1].Methods)
                    //{
                    //    Member
                    //}

                        foreach (PSObject result in results)
                    {
                        //richTextBox1.Text += Environment.NewLine + result.Properties["ProcessName"].Value.ToString();
                        richTextBox1.Text += Environment.NewLine + result.Members["name"].Value.ToString();
                    }

                    foreach (PSObject result in results)
                    {
                        //richTextBox1.Text += Environment.NewLine + result.Members["name"].Value.ToString();
                        richTextBox1.Text += Environment.NewLine + result.Members["sAMAccountName"].Value.ToString();
                    }

                    richTextBox1.Text += Environment.NewLine + "(Ukončen test funkčnosti PowerShellového AD skriptu.)";
                }
            }

        }

        private void PS_TestScriptVlatni()
        {
            //pokusi se spustit skript zapsany do konzolovebo vystupu. A vypsat znej uzivstelska data.
            string skript = richTextBox1.Text;
            richTextBox1.Text = "(spuštěn test funkčnosti PowerShellového vlastního skriptu.)";
            richTextBox1.Text += Environment.NewLine + skript;
            try
            {
                using (var runspace = RunspaceFactory.CreateRunspace())
                {
                    using (var powerShell = PowerShell.Create())
                    {
                        powerShell.Runspace = runspace;
                        powerShell.Runspace.Open();
                        powerShell.Commands.AddCommand("Import-Module").AddArgument("ActiveDirectory");
                        powerShell.AddScript(skript);
                        // Výsledky
                        foreach (PSObject result in powerShell.Invoke())
                        {
                            //vypsat vsechny promnene
                            try { richTextBox1.Text += Environment.NewLine + "Name: " + result.Members["name"].Value.ToString(); } catch { }
                            try { richTextBox1.Text += Environment.NewLine + "sAMAccountName: " + result.Members["sAMAccountName"].Value.ToString(); } catch { }
                            try { richTextBox1.Text += Environment.NewLine + "PhysicalDeliveryOfficeName: " + result.Members["PhysicalDeliveryOfficeName"].Value.ToString(); } catch { }
                            try { richTextBox1.Text += Environment.NewLine + "title: " + result.Members["title"].Value.ToString(); } catch { }
                            try { richTextBox1.Text += Environment.NewLine + "pager: " + result.Members["pager"].Value.ToString(); } catch { }
                            try { richTextBox1.Text += Environment.NewLine + "otherPager: " + result.Members["otherPager"].Value.ToString(); } catch { }
                        }
                        richTextBox1.Text += Environment.NewLine + "(Ukončen test funkčnosti PowerShellového AD skriptu.)";
                    }
                }
            }
            catch (Exception e)
            {
                richTextBox1.Text += Environment.NewLine + "-------ERROR------";
                richTextBox1.Text += Environment.NewLine + e.Message;
                richTextBox1.Text += Environment.NewLine + e.HelpLink;
                //richTextBox1.Text += Environment.NewLine + e.HResult;
                richTextBox1.Text += Environment.NewLine + e.InnerException;
                richTextBox1.Text += Environment.NewLine + e.TargetSite;
                richTextBox1.Text += Environment.NewLine + "-------StackTrace------";
                richTextBox1.Text += Environment.NewLine + e.StackTrace;
            }
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            int jedna = 0;

            try
            {
                converter_Dec_To_Hex(jedna);
            }
            catch (Exception exce)
            {

                MessageBox.Show(exce.Message);
            }

            DialogResult result1 = MessageBox.Show("Totoje test funkčnosti PowerShelového skriptu. Chceš otestovat AD skript (Ano) nebo normální skript (Ne)", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                PS_TestScriptAD();
            }
            else if (result1 == DialogResult.No)
            {
                PS_TestScript();
            }
            else
            {

            }

        }

        /*private void button_cleanCard_Click(object sender, EventArgs e)
        {
            ADuser_Class user1 = new ADuser_Class();
            string accountName = textBox_Name.Text;
            if(accountName != "") {
                user1.userNameAcco = accountName;
                PS_ClearCard_userName(user1);
            }
            else {
                MessageBox.Show("Doplň jméno.");
            }
        }*/

    }
}
