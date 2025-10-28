namespace WinFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            resultsTxtBx = new TextBox();
            resultsBtn = new Button();
            clearBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            comboBox6 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox7 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            comboBox5 = new ComboBox();
            comboBox8 = new ComboBox();
            comboBox9 = new ComboBox();
            comboBox10 = new ComboBox();
            SuspendLayout();
            // 
            // resultsTxtBx
            // 
            resultsTxtBx.Location = new Point(72, 296);
            resultsTxtBx.Name = "resultsTxtBx";
            resultsTxtBx.Size = new Size(267, 23);
            resultsTxtBx.TabIndex = 3;
            // 
            // resultsBtn
            // 
            resultsBtn.Location = new Point(593, 41);
            resultsBtn.Name = "resultsBtn";
            resultsBtn.Size = new Size(75, 23);
            resultsBtn.TabIndex = 4;
            resultsBtn.Text = "Results";
            resultsBtn.UseVisualStyleBackColor = true;
            resultsBtn.Click += GetResults;
            // 
            // clearBtn
            // 
            clearBtn.Location = new Point(689, 41);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(75, 23);
            clearBtn.TabIndex = 5;
            clearBtn.Text = "Clear";
            clearBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 45);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 6;
            label1.Text = "Pocket 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(282, 45);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 7;
            label2.Text = "Pocket 2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 123);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 8;
            label3.Text = "Flop";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 261);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 12;
            label4.Text = "Results";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Hearts", "Spades", "Diamonds", "Clubs" });
            comboBox1.Location = new Point(28, 85);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 13;
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Items.AddRange(new object[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" });
            comboBox6.Location = new Point(158, 85);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(121, 23);
            comboBox6.TabIndex = 18;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" });
            comboBox2.Location = new Point(409, 85);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 19;
            // 
            // comboBox7
            // 
            comboBox7.FormattingEnabled = true;
            comboBox7.Items.AddRange(new object[] { "Hearts", "Spades", "Diamonds", "Clubs" });
            comboBox7.Location = new Point(285, 85);
            comboBox7.Name = "comboBox7";
            comboBox7.Size = new Size(121, 23);
            comboBox7.TabIndex = 20;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Hearts", "Spades", "Diamonds", "Clubs" });
            comboBox3.Location = new Point(31, 164);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 21;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Hearts", "Spades", "Diamonds", "Clubs" });
            comboBox4.Location = new Point(282, 164);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(121, 23);
            comboBox4.TabIndex = 22;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Items.AddRange(new object[] { "Hearts", "Spades", "Diamonds", "Clubs" });
            comboBox5.Location = new Point(536, 164);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(121, 23);
            comboBox5.TabIndex = 23;
            // 
            // comboBox8
            // 
            comboBox8.FormattingEnabled = true;
            comboBox8.Items.AddRange(new object[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" });
            comboBox8.Location = new Point(158, 164);
            comboBox8.Name = "comboBox8";
            comboBox8.Size = new Size(121, 23);
            comboBox8.TabIndex = 24;
            // 
            // comboBox9
            // 
            comboBox9.FormattingEnabled = true;
            comboBox9.Items.AddRange(new object[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" });
            comboBox9.Location = new Point(409, 164);
            comboBox9.Name = "comboBox9";
            comboBox9.Size = new Size(121, 23);
            comboBox9.TabIndex = 25;
            // 
            // comboBox10
            // 
            comboBox10.FormattingEnabled = true;
            comboBox10.Items.AddRange(new object[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" });
            comboBox10.Location = new Point(663, 164);
            comboBox10.Name = "comboBox10";
            comboBox10.Size = new Size(121, 23);
            comboBox10.TabIndex = 26;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox10);
            Controls.Add(comboBox9);
            Controls.Add(comboBox8);
            Controls.Add(comboBox5);
            Controls.Add(comboBox4);
            Controls.Add(comboBox3);
            Controls.Add(comboBox7);
            Controls.Add(comboBox2);
            Controls.Add(comboBox6);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(clearBtn);
            Controls.Add(resultsBtn);
            Controls.Add(resultsTxtBx);
            Name = "MainForm";
            Text = "PokerOdds";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private TextBox resultsTxtBx;
        private Button resultsBtn;
        private Button clearBtn;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
        private ComboBox comboBox6;
        private ComboBox comboBox2;
        private ComboBox comboBox7;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private ComboBox comboBox5;
        private ComboBox comboBox8;
        private ComboBox comboBox9;
        private ComboBox comboBox10;
    }
}