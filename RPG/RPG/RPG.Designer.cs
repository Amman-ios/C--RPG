namespace RPG
{
    partial class RPG
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
            this.HitPointsMarker = new System.Windows.Forms.Label();
            this.GoldMarker = new System.Windows.Forms.Label();
            this.ExperienceMarker = new System.Windows.Forms.Label();
            this.LevelMarker = new System.Windows.Forms.Label();
            this.lblHitPoints = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HitPointsMarker
            // 
            this.HitPointsMarker.AutoSize = true;
            this.HitPointsMarker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HitPointsMarker.Location = new System.Drawing.Point(18, 20);
            this.HitPointsMarker.Name = "HitPointsMarker";
            this.HitPointsMarker.Size = new System.Drawing.Size(81, 20);
            this.HitPointsMarker.TabIndex = 0;
            this.HitPointsMarker.Text = "Hit Points:";
            // 
            // GoldMarker
            // 
            this.GoldMarker.AutoSize = true;
            this.GoldMarker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoldMarker.Location = new System.Drawing.Point(18, 46);
            this.GoldMarker.Name = "GoldMarker";
            this.GoldMarker.Size = new System.Drawing.Size(47, 20);
            this.GoldMarker.TabIndex = 1;
            this.GoldMarker.Text = "Gold:";
            // 
            // ExperienceMarker
            // 
            this.ExperienceMarker.AutoSize = true;
            this.ExperienceMarker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExperienceMarker.Location = new System.Drawing.Point(18, 74);
            this.ExperienceMarker.Name = "ExperienceMarker";
            this.ExperienceMarker.Size = new System.Drawing.Size(92, 20);
            this.ExperienceMarker.TabIndex = 2;
            this.ExperienceMarker.Text = "Experience:";
            // 
            // LevelMarker
            // 
            this.LevelMarker.AutoSize = true;
            this.LevelMarker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelMarker.Location = new System.Drawing.Point(18, 100);
            this.LevelMarker.Name = "LevelMarker";
            this.LevelMarker.Size = new System.Drawing.Size(50, 20);
            this.LevelMarker.TabIndex = 3;
            this.LevelMarker.Text = "Level:";
            this.LevelMarker.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblHitPoints
            // 
            this.lblHitPoints.AutoSize = true;
            this.lblHitPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHitPoints.Location = new System.Drawing.Point(110, 19);
            this.lblHitPoints.Name = "lblHitPoints";
            this.lblHitPoints.Size = new System.Drawing.Size(88, 20);
            this.lblHitPoints.TabIndex = 4;
            this.lblHitPoints.Text = "lblHitPoints";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGold.Location = new System.Drawing.Point(110, 45);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(58, 20);
            this.lblGold.TabIndex = 5;
            this.lblGold.Text = "lblGold";
            this.lblGold.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExperience.Location = new System.Drawing.Point(110, 73);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(103, 20);
            this.lblExperience.TabIndex = 6;
            this.lblExperience.Text = "lblExperience";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(110, 99);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(61, 20);
            this.lblLevel.TabIndex = 7;
            this.lblLevel.Text = "lblLevel";
            this.lblLevel.Click += new System.EventHandler(this.label8_Click);
            // 
            // RPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 651);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblHitPoints);
            this.Controls.Add(this.LevelMarker);
            this.Controls.Add(this.ExperienceMarker);
            this.Controls.Add(this.GoldMarker);
            this.Controls.Add(this.HitPointsMarker);
            this.Name = "RPG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPG";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HitPointsMarker;
        private System.Windows.Forms.Label GoldMarker;
        private System.Windows.Forms.Label ExperienceMarker;
        private System.Windows.Forms.Label LevelMarker;
        private System.Windows.Forms.Label lblHitPoints;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label lblLevel;
    }
}

