namespace Chess
{
	partial class Promotion
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
			this.queen = new System.Windows.Forms.RadioButton();
			this.bishop = new System.Windows.Forms.RadioButton();
			this.knight = new System.Windows.Forms.RadioButton();
			this.rook = new System.Windows.Forms.RadioButton();
			this.buttonOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// queen
			// 
			this.queen.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
			this.queen.Location = new System.Drawing.Point(12, 12);
			this.queen.Name = "queen";
			this.queen.Size = new System.Drawing.Size(40, 70);
			this.queen.TabIndex = 0;
			this.queen.TabStop = true;
			this.queen.UseVisualStyleBackColor = true;
			this.queen.Click += new System.EventHandler(this.queen_Click);
			// 
			// bishop
			// 
			this.bishop.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bishop.Location = new System.Drawing.Point(58, 12);
			this.bishop.Name = "bishop";
			this.bishop.Size = new System.Drawing.Size(40, 70);
			this.bishop.TabIndex = 1;
			this.bishop.TabStop = true;
			this.bishop.UseVisualStyleBackColor = true;
			this.bishop.Click += new System.EventHandler(this.queen_Click);
			// 
			// knight
			// 
			this.knight.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
			this.knight.Location = new System.Drawing.Point(104, 12);
			this.knight.Name = "knight";
			this.knight.Size = new System.Drawing.Size(40, 70);
			this.knight.TabIndex = 2;
			this.knight.TabStop = true;
			this.knight.UseVisualStyleBackColor = true;
			this.knight.Click += new System.EventHandler(this.queen_Click);
			// 
			// rook
			// 
			this.rook.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
			this.rook.Location = new System.Drawing.Point(150, 12);
			this.rook.Name = "rook";
			this.rook.Size = new System.Drawing.Size(40, 70);
			this.rook.TabIndex = 3;
			this.rook.TabStop = true;
			this.rook.UseVisualStyleBackColor = true;
			this.rook.Click += new System.EventHandler(this.queen_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(58, 97);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(91, 24);
			this.buttonOK.TabIndex = 4;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// Promotion
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(199, 133);
			this.ControlBox = false;
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.rook);
			this.Controls.Add(this.knight);
			this.Controls.Add(this.bishop);
			this.Controls.Add(this.queen);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Promotion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Promotion";
			this.Load += new System.EventHandler(this.Promotion_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RadioButton queen;
		private System.Windows.Forms.RadioButton bishop;
		private System.Windows.Forms.RadioButton knight;
		private System.Windows.Forms.RadioButton rook;
		private System.Windows.Forms.Button buttonOK;
	}
}