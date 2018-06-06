namespace MarvelFlow.App.Views
{
    partial class WindowsBandeAnnonce
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowsBandeAnnonce));
            this.TeaserMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.TeaserMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // TeaserMediaPlayer
            // 
            this.TeaserMediaPlayer.Enabled = true;
            this.TeaserMediaPlayer.Location = new System.Drawing.Point(4, -8);
            this.TeaserMediaPlayer.Name = "TeaserMediaPlayer";
            this.TeaserMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("TeaserMediaPlayer.OcxState")));
            this.TeaserMediaPlayer.Size = new System.Drawing.Size(809, 458);
            this.TeaserMediaPlayer.TabIndex = 0;
            // 
            // WindowsBandeAnnonce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 451);
            this.Controls.Add(this.TeaserMediaPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WindowsBandeAnnonce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trailer";
            ((System.ComponentModel.ISupportInitialize)(this.TeaserMediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer TeaserMediaPlayer;
    }
}