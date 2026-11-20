namespace MiniProjectAStar
{
    partial class MainForm
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
            this.btnFindPath = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTravelDis = new System.Windows.Forms.Label();
            this.btnRdmMaze = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFindPath
            // 
            this.btnFindPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindPath.Location = new System.Drawing.Point(945, 492);
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(117, 39);
            this.btnFindPath.TabIndex = 0;
            this.btnFindPath.Text = "Find Path";
            this.btnFindPath.UseVisualStyleBackColor = true;
            this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(945, 552);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(117, 35);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblTravelDis
            // 
            this.lblTravelDis.AutoSize = true;
            this.lblTravelDis.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTravelDis.Location = new System.Drawing.Point(746, 168);
            this.lblTravelDis.Name = "lblTravelDis";
            this.lblTravelDis.Size = new System.Drawing.Size(226, 32);
            this.lblTravelDis.TabIndex = 1;
            this.lblTravelDis.Text = "Travel Distance: ";
            // 
            // btnRdmMaze
            // 
            this.btnRdmMaze.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRdmMaze.Location = new System.Drawing.Point(714, 492);
            this.btnRdmMaze.Name = "btnRdmMaze";
            this.btnRdmMaze.Size = new System.Drawing.Size(191, 35);
            this.btnRdmMaze.TabIndex = 0;
            this.btnRdmMaze.Text = "Random Maze";
            this.btnRdmMaze.UseVisualStyleBackColor = true;
            this.btnRdmMaze.Click += new System.EventHandler(this.btnRdmMaze_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 620);
            this.Controls.Add(this.lblTravelDis);
            this.Controls.Add(this.btnRdmMaze);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFindPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A* Grid PathFinding Visualization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindPath;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblTravelDis;
        private System.Windows.Forms.Button btnRdmMaze;
    }
}