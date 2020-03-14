namespace Uno
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.currentCard = new System.Windows.Forms.Label();
            this.player1 = new System.Windows.Forms.Label();
            this.player2 = new System.Windows.Forms.Label();
            this.tableCard = new System.Windows.Forms.Button();
            this.turn = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.alert = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currentCard
            // 
            this.currentCard.Location = new System.Drawing.Point(11, 137);
            this.currentCard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentCard.Name = "currentCard";
            this.currentCard.Size = new System.Drawing.Size(107, 17);
            this.currentCard.TabIndex = 1;
            this.currentCard.Text = "Aktuelle Karte";
            // 
            // player1
            // 
            this.player1.AutoSize = true;
            this.player1.Location = new System.Drawing.Point(8, 359);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(48, 13);
            this.player1.TabIndex = 39;
            this.player1.Tag = "";
            this.player1.Text = "Spieler 1";
            // 
            // player2
            // 
            this.player2.AutoSize = true;
            this.player2.Location = new System.Drawing.Point(8, 525);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(48, 13);
            this.player2.TabIndex = 40;
            this.player2.Tag = "";
            this.player2.Text = "Spieler 2";
            // 
            // tableCard
            // 
            this.tableCard.Location = new System.Drawing.Point(11, 156);
            this.tableCard.Margin = new System.Windows.Forms.Padding(2);
            this.tableCard.Name = "tableCard";
            this.tableCard.Size = new System.Drawing.Size(86, 128);
            this.tableCard.TabIndex = 41;
            this.tableCard.UseVisualStyleBackColor = true;
            // 
            // turn
            // 
            this.turn.AutoSize = true;
            this.turn.Location = new System.Drawing.Point(115, 156);
            this.turn.Name = "turn";
            this.turn.Size = new System.Drawing.Size(76, 13);
            this.turn.TabIndex = 42;
            this.turn.Text = "Spieler ist dran";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(14, 23);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 43;
            this.btnNewGame.Text = "Neues Spiel";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // alert
            // 
            this.alert.AutoSize = true;
            this.alert.Location = new System.Drawing.Point(118, 190);
            this.alert.Name = "alert";
            this.alert.Size = new System.Drawing.Size(0, 13);
            this.alert.TabIndex = 44;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 23);
            this.button1.TabIndex = 45;
            this.button1.Text = "Keine Karte möglich";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnNoChance);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(86, 515);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 23);
            this.button2.TabIndex = 46;
            this.button2.Text = "Keine Karte möglich";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnNoChance);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1505, 680);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.alert);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.turn);
            this.Controls.Add(this.tableCard);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.currentCard);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Label currentCard;
        private System.Windows.Forms.Label player1;
        private System.Windows.Forms.Label player2;
        private System.Windows.Forms.Button tableCard;
        private System.Windows.Forms.Label turn;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label alert;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

