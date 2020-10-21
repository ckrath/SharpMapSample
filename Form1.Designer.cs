namespace SharpMapSample
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
            this.mapBox1 = new SharpMap.Forms.MapBox();
            this.btnPan = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnLayerExtent = new System.Windows.Forms.Button();
            this.btnZoomWindow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mapBox1
            // 
            this.mapBox1.ActiveTool = SharpMap.Forms.MapBox.Tools.None;
            this.mapBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mapBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.mapBox1.CustomTool = null;
            this.mapBox1.FineZoomFactor = 10D;
            this.mapBox1.Location = new System.Drawing.Point(12, 41);
            this.mapBox1.MapQueryMode = SharpMap.Forms.MapBox.MapQueryType.LayerByIndex;
            this.mapBox1.Name = "mapBox1";
            this.mapBox1.QueryGrowFactor = 5F;
            this.mapBox1.QueryLayerIndex = 0;
            this.mapBox1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mapBox1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mapBox1.ShowProgressUpdate = false;
            this.mapBox1.Size = new System.Drawing.Size(486, 397);
            this.mapBox1.TabIndex = 0;
            this.mapBox1.Text = "mapBox1";
            this.mapBox1.WheelZoomMagnitude = -2D;
            // 
            // btnPan
            // 
            this.btnPan.Location = new System.Drawing.Point(12, 12);
            this.btnPan.Name = "btnPan";
            this.btnPan.Size = new System.Drawing.Size(75, 23);
            this.btnPan.TabIndex = 1;
            this.btnPan.Text = "Pan";
            this.btnPan.UseVisualStyleBackColor = true;
            this.btnPan.Click += new System.EventHandler(this.btnPan_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(93, 12);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(75, 23);
            this.btnZoomIn.TabIndex = 2;
            this.btnZoomIn.Text = "ZoomIn";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(174, 12);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(75, 23);
            this.btnZoomOut.TabIndex = 3;
            this.btnZoomOut.Text = "ZoomOut";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnLayerExtent
            // 
            this.btnLayerExtent.Location = new System.Drawing.Point(336, 12);
            this.btnLayerExtent.Name = "btnLayerExtent";
            this.btnLayerExtent.Size = new System.Drawing.Size(75, 23);
            this.btnLayerExtent.TabIndex = 4;
            this.btnLayerExtent.Text = "LayerExtent";
            this.btnLayerExtent.UseVisualStyleBackColor = true;
            this.btnLayerExtent.Click += new System.EventHandler(this.btnLayerExtent_Click);
            // 
            // btnZoomWindow
            // 
            this.btnZoomWindow.Location = new System.Drawing.Point(255, 12);
            this.btnZoomWindow.Name = "btnZoomWindow";
            this.btnZoomWindow.Size = new System.Drawing.Size(75, 23);
            this.btnZoomWindow.TabIndex = 5;
            this.btnZoomWindow.Text = "ZoomWin";
            this.btnZoomWindow.UseVisualStyleBackColor = true;
            this.btnZoomWindow.Click += new System.EventHandler(this.btnZoomWindow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 450);
            this.Controls.Add(this.btnZoomWindow);
            this.Controls.Add(this.btnLayerExtent);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.btnPan);
            this.Controls.Add(this.mapBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private SharpMap.Forms.MapBox mapBox1;
        private System.Windows.Forms.Button btnPan;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnLayerExtent;
        private System.Windows.Forms.Button btnZoomWindow;
    }
}

