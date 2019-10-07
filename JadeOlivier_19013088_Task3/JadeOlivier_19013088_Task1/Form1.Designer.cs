namespace JadeOlivier_19013088_Task1
{
    partial class frmBattlefield
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
            this.lblMap = new System.Windows.Forms.Label();
            this.lblRound = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.rtxProgress = new System.Windows.Forms.RichTextBox();
            this.battleTimer = new System.Windows.Forms.Timer(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMap.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMap.Location = new System.Drawing.Point(21, 54);
            this.lblMap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(2, 26);
            this.lblMap.TabIndex = 0;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.Location = new System.Drawing.Point(9, 4);
            this.lblRound.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(30, 31);
            this.lblRound.TabIndex = 1;
            this.lblRound.Text = "0";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(853, 11);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(109, 41);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(853, 54);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(109, 44);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // rtxProgress
            // 
            this.rtxProgress.Location = new System.Drawing.Point(531, 11);
            this.rtxProgress.Margin = new System.Windows.Forms.Padding(2);
            this.rtxProgress.Name = "rtxProgress";
            this.rtxProgress.Size = new System.Drawing.Size(307, 745);
            this.rtxProgress.TabIndex = 4;
            this.rtxProgress.Text = "";
            // 
            // battleTimer
            // 
            this.battleTimer.Interval = 1000;
            this.battleTimer.Tick += new System.EventHandler(this.battleTimer_Tick);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(856, 175);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 39);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRead
            // 
            this.btnRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.Location = new System.Drawing.Point(856, 218);
            this.btnRead.Margin = new System.Windows.Forms.Padding(2);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(106, 39);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // frmBattlefield
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 767);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtxProgress);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.lblMap);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmBattlefield";
            this.Text = "Battlefield";
            this.Load += new System.EventHandler(this.frmBattlefield_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.RichTextBox rtxProgress;
        private System.Windows.Forms.Timer battleTimer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRead;
    }
}

