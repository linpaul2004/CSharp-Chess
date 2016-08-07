namespace Chess
{
	partial class Form1
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
		/// 修改這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.chessIcon = new System.Windows.Forms.ImageList(this.components);
			this.whiteTurn = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.blackTurn = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.blackClock = new System.Windows.Forms.Label();
			this.whiteClock = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// chessIcon
			// 
			this.chessIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("chessIcon.ImageStream")));
			this.chessIcon.TransparentColor = System.Drawing.Color.Transparent;
			this.chessIcon.Images.SetKeyName(0, "BlackBishop.png");
			this.chessIcon.Images.SetKeyName(1, "BlackKing.png");
			this.chessIcon.Images.SetKeyName(2, "BlackKnight.png");
			this.chessIcon.Images.SetKeyName(3, "BlackPawn.png");
			this.chessIcon.Images.SetKeyName(4, "BlackQueen.png");
			this.chessIcon.Images.SetKeyName(5, "BlackRook.png");
			this.chessIcon.Images.SetKeyName(6, "WhiteBishop.png");
			this.chessIcon.Images.SetKeyName(7, "WhiteKing.png");
			this.chessIcon.Images.SetKeyName(8, "WhiteKnight.png");
			this.chessIcon.Images.SetKeyName(9, "WhitePawn.png");
			this.chessIcon.Images.SetKeyName(10, "WhiteQueen.png");
			this.chessIcon.Images.SetKeyName(11, "WhiteRook.png");
			// 
			// whiteTurn
			// 
			this.whiteTurn.AutoSize = true;
			this.whiteTurn.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.whiteTurn.Location = new System.Drawing.Point(339, 299);
			this.whiteTurn.Name = "whiteTurn";
			this.whiteTurn.Size = new System.Drawing.Size(136, 32);
			this.whiteTurn.TabIndex = 0;
			this.whiteTurn.Text = "WHITE turn";
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(338, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(2, 380);
			this.label2.TabIndex = 1;
			// 
			// blackTurn
			// 
			this.blackTurn.AutoSize = true;
			this.blackTurn.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.blackTurn.Location = new System.Drawing.Point(339, 9);
			this.blackTurn.Name = "blackTurn";
			this.blackTurn.Size = new System.Drawing.Size(135, 32);
			this.blackTurn.TabIndex = 2;
			this.blackTurn.Text = "BLACK turn";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(345, 154);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(130, 35);
			this.button1.TabIndex = 3;
			this.button1.Text = "START";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// blackClock
			// 
			this.blackClock.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.blackClock.Location = new System.Drawing.Point(345, 41);
			this.blackClock.Name = "blackClock";
			this.blackClock.Size = new System.Drawing.Size(130, 23);
			this.blackClock.TabIndex = 4;
			this.blackClock.Text = "0:0";
			this.blackClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// whiteClock
			// 
			this.whiteClock.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.whiteClock.Location = new System.Drawing.Point(344, 277);
			this.whiteClock.Name = "whiteClock";
			this.whiteClock.Size = new System.Drawing.Size(130, 23);
			this.whiteClock.TabIndex = 5;
			this.whiteClock.Text = "0:0";
			this.whiteClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 341);
			this.Controls.Add(this.whiteClock);
			this.Controls.Add(this.blackClock);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.blackTurn);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.whiteTurn);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label whiteTurn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label blackTurn;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label blackClock;
		private System.Windows.Forms.Label whiteClock;
		private System.Windows.Forms.Timer timer1;
		internal System.Windows.Forms.ImageList chessIcon;

	}
}

