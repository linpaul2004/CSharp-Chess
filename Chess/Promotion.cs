using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
	public partial class Promotion : Form
	{

		internal int player, choose;
		
		public Promotion()
		{
			InitializeComponent();
		}

		private void Promotion_Load(object sender, EventArgs e)
		{
			queen.ImageList = ((Form1)Owner).chessIcon;
			bishop.ImageList = ((Form1)Owner).chessIcon;
			knight.ImageList = ((Form1)Owner).chessIcon;
			rook.ImageList = ((Form1)Owner).chessIcon;
			queen.Checked = true;
			if (player == 0)
			{
				queen.ImageIndex = 4;
				bishop.ImageIndex = 0;
				knight.ImageIndex = 2;
				rook.ImageIndex = 5;
			}
			else
			{
				queen.ImageIndex = 10;
				bishop.ImageIndex = 6;
				knight.ImageIndex = 8;
				rook.ImageIndex = 11;
			}
		}

		private void queen_Click(object sender, EventArgs e)
		{
			RadioButton Sender = (RadioButton)sender;
			switch (Sender.ImageIndex)
			{
				case 4:
					choose = 2;
					break;
				case 0:
					choose = 6;
					break;
				case 2:
					choose = 4;
					break;
				case 5:
					choose = 8;
					break;
				case 10:
					choose = 3;
					break;
				case 6:
					choose = 7;
					break;
				case 8:
					choose = 5;
					break;
				case 11:
					choose = 9;
					break;
				default:
					choose = 0;
					break;
			}
		}
	}
}
