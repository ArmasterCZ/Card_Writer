namespace Card_Writer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_comfirm = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button_clean = new System.Windows.Forms.Button();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_PreCard = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox_Name = new System.Windows.Forms.CheckBox();
            this.checkBox_PreCard = new System.Windows.Forms.CheckBox();
            this.textBox_CardNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_CardNumber = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox_Fullname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Place = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Tel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Mob = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_test = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button_test2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_comfirm
            // 
            this.button_comfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_comfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_comfirm.Location = new System.Drawing.Point(409, 329);
            this.button_comfirm.Margin = new System.Windows.Forms.Padding(2);
            this.button_comfirm.Name = "button_comfirm";
            this.button_comfirm.Size = new System.Drawing.Size(87, 25);
            this.button_comfirm.TabIndex = 6;
            this.button_comfirm.Text = "Najít";
            this.button_comfirm.UseVisualStyleBackColor = true;
            this.button_comfirm.Click += new System.EventHandler(this.executeOrder);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(9, 240);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(488, 73);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // button_clean
            // 
            this.button_clean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_clean.Location = new System.Drawing.Point(9, 330);
            this.button_clean.Margin = new System.Windows.Forms.Padding(2);
            this.button_clean.Name = "button_clean";
            this.button_clean.Size = new System.Drawing.Size(105, 24);
            this.button_clean.TabIndex = 9;
            this.button_clean.Text = "Vyčistit kolonky";
            this.button_clean.UseVisualStyleBackColor = true;
            this.button_clean.Click += new System.EventHandler(this.button_clean_Click);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(26, 32);
            this.textBox_Name.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(197, 20);
            this.textBox_Name.TabIndex = 1;
            // 
            // textBox_PreCard
            // 
            this.textBox_PreCard.Enabled = false;
            this.textBox_PreCard.Location = new System.Drawing.Point(302, 32);
            this.textBox_PreCard.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_PreCard.Name = "textBox_PreCard";
            this.textBox_PreCard.Size = new System.Drawing.Size(195, 20);
            this.textBox_PreCard.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Jméno uživatele";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Číslo karty (dec)";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 100;
            // 
            // checkBox_Name
            // 
            this.checkBox_Name.AutoSize = true;
            this.checkBox_Name.Checked = true;
            this.checkBox_Name.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Name.Location = new System.Drawing.Point(8, 32);
            this.checkBox_Name.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_Name.Name = "checkBox_Name";
            this.checkBox_Name.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Name.TabIndex = 11;
            this.checkBox_Name.UseVisualStyleBackColor = true;
            this.checkBox_Name.CheckedChanged += new System.EventHandler(this.checkBox_comfirm_Click);
            this.checkBox_Name.Click += new System.EventHandler(this.checkBox_Click);
            // 
            // checkBox_PreCard
            // 
            this.checkBox_PreCard.AutoSize = true;
            this.checkBox_PreCard.Location = new System.Drawing.Point(284, 32);
            this.checkBox_PreCard.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_PreCard.Name = "checkBox_PreCard";
            this.checkBox_PreCard.Size = new System.Drawing.Size(15, 14);
            this.checkBox_PreCard.TabIndex = 2;
            this.checkBox_PreCard.UseVisualStyleBackColor = true;
            this.checkBox_PreCard.CheckedChanged += new System.EventHandler(this.checkBox_comfirm_Click);
            this.checkBox_PreCard.Click += new System.EventHandler(this.checkBox_Click);
            // 
            // textBox_CardNumber
            // 
            this.textBox_CardNumber.Enabled = false;
            this.textBox_CardNumber.Location = new System.Drawing.Point(302, 85);
            this.textBox_CardNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CardNumber.Name = "textBox_CardNumber";
            this.textBox_CardNumber.Size = new System.Drawing.Size(195, 20);
            this.textBox_CardNumber.TabIndex = 5;
            this.textBox_CardNumber.Text = "81AE04C300000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Celé Číslo karty (hex)";
            // 
            // checkBox_CardNumber
            // 
            this.checkBox_CardNumber.AutoSize = true;
            this.checkBox_CardNumber.Location = new System.Drawing.Point(284, 85);
            this.checkBox_CardNumber.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_CardNumber.Name = "checkBox_CardNumber";
            this.checkBox_CardNumber.Size = new System.Drawing.Size(15, 14);
            this.checkBox_CardNumber.TabIndex = 4;
            this.checkBox_CardNumber.UseVisualStyleBackColor = true;
            this.checkBox_CardNumber.CheckedChanged += new System.EventHandler(this.checkBox_comfirm_Click);
            this.checkBox_CardNumber.Click += new System.EventHandler(this.checkBox_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(9, 318);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(487, 8);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Value = 100;
            this.progressBar1.Visible = false;
            // 
            // textBox_Fullname
            // 
            this.textBox_Fullname.Enabled = false;
            this.textBox_Fullname.Location = new System.Drawing.Point(26, 85);
            this.textBox_Fullname.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Fullname.Name = "textBox_Fullname";
            this.textBox_Fullname.Size = new System.Drawing.Size(197, 20);
            this.textBox_Fullname.TabIndex = 0;
            this.textBox_Fullname.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Plné jméno uživatele";
            // 
            // textBox_Place
            // 
            this.textBox_Place.Enabled = false;
            this.textBox_Place.Location = new System.Drawing.Point(26, 189);
            this.textBox_Place.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Place.Name = "textBox_Place";
            this.textBox_Place.Size = new System.Drawing.Size(197, 20);
            this.textBox_Place.TabIndex = 1;
            this.textBox_Place.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 167);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Středisko";
            // 
            // textBox_Tel
            // 
            this.textBox_Tel.Enabled = false;
            this.textBox_Tel.Location = new System.Drawing.Point(301, 136);
            this.textBox_Tel.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Tel.Name = "textBox_Tel";
            this.textBox_Tel.Size = new System.Drawing.Size(197, 20);
            this.textBox_Tel.TabIndex = 1;
            this.textBox_Tel.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(285, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Telefon";
            // 
            // textBox_Mob
            // 
            this.textBox_Mob.Enabled = false;
            this.textBox_Mob.Location = new System.Drawing.Point(301, 189);
            this.textBox_Mob.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Mob.Name = "textBox_Mob";
            this.textBox_Mob.Size = new System.Drawing.Size(197, 20);
            this.textBox_Mob.TabIndex = 1;
            this.textBox_Mob.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(285, 167);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Mobil";
            // 
            // textBox_Title
            // 
            this.textBox_Title.Enabled = false;
            this.textBox_Title.Location = new System.Drawing.Point(26, 136);
            this.textBox_Title.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(197, 20);
            this.textBox_Title.TabIndex = 1;
            this.textBox_Title.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 114);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Pozice";
            // 
            // button_test
            // 
            this.button_test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_test.Location = new System.Drawing.Point(206, 329);
            this.button_test.Margin = new System.Windows.Forms.Padding(2);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(121, 24);
            this.button_test.TabIndex = 8;
            this.button_test.Text = "Otestovat funkčnost";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Visible = false;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 224);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Výstup z konzole:";
            // 
            // button_test2
            // 
            this.button_test2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_test2.Location = new System.Drawing.Point(331, 329);
            this.button_test2.Margin = new System.Windows.Forms.Padding(2);
            this.button_test2.Name = "button_test2";
            this.button_test2.Size = new System.Drawing.Size(74, 25);
            this.button_test2.TabIndex = 7;
            this.button_test2.Text = "vypsat data";
            this.button_test2.UseVisualStyleBackColor = true;
            this.button_test2.Visible = false;
            this.button_test2.Click += new System.EventHandler(this.TextBoxData_To_Console);
            // 
            // Form1
            // 
            this.AcceptButton = this.button_comfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 358);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBox_CardNumber);
            this.Controls.Add(this.checkBox_PreCard);
            this.Controls.Add(this.checkBox_Name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_CardNumber);
            this.Controls.Add(this.textBox_Mob);
            this.Controls.Add(this.textBox_Tel);
            this.Controls.Add(this.textBox_Title);
            this.Controls.Add(this.textBox_Place);
            this.Controls.Add(this.textBox_Fullname);
            this.Controls.Add(this.textBox_PreCard);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button_clean);
            this.Controls.Add(this.button_test2);
            this.Controls.Add(this.button_test);
            this.Controls.Add(this.button_comfirm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Card Writer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_comfirm;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_clean;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_PreCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox_Name;
        private System.Windows.Forms.CheckBox checkBox_PreCard;
        private System.Windows.Forms.TextBox textBox_CardNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_CardNumber;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox_Fullname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Place;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Tel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Mob;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_test2;
    }
}

