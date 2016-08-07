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
	public partial class Form1 : Form
	{
		private CheckBox[] square = new CheckBox[64];
		private Promotion promotion;
		private uint white, black;
		private int passer;
		private player now;
		private readonly int SQUARESIZE = 40;
		private readonly Color DARK = Color.SlateGray, LIGHT = Color.WhiteSmoke, SEL = Color.Gold;
		private enum piece { BK, WK, BQ, WQ, BN, WN, BB, WB, BR, WR, BP, WP, NA };
		private enum player { WHITE, BLACK };
		private piece[] board = new piece[64];
		private bool enPass, BKmove, WKmove, BRmove, WRmove;
		private int checkIndex;

		public Form1()
		{
			InitializeComponent();
			Text = "Chess";
			white = black = 1800;
			whiteTurn.Visible = false;
			blackTurn.Visible = false;
			whiteClock.Text = "" + white / 60 + ":" + white % 60;
			blackClock.Text = "" + black / 60 + ":" + black % 60;
			promotion = new Promotion();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < 64; i++)
			{
				square[i] = new CheckBox();
				square[i].Size = new Size(SQUARESIZE, SQUARESIZE);
				square[i].AutoSize = false;
				square[i].Location = new Point(12 + (i % 8) * SQUARESIZE, 12 + (i / 8) * SQUARESIZE);
				square[i].Appearance = Appearance.Button;
				square[i].FlatStyle = FlatStyle.Flat;
				square[i].Visible = true;
				if (((i / 8) % 2 == 0 && i % 2 == 1) || ((i / 8) % 2 == 1 && i % 2 == 0))
				{
					square[i].BackColor = DARK;
				}
				else
				{
					square[i].BackColor = LIGHT;
				}
				square[i].ImageList = chessIcon;
				square[i].Tag = i;
				square[i].Enabled = false;
				square[i].Click += BoardClick;
				Controls.Add(square[i]);
			}
			GameSet();
			RefreshBoard();
		}

		private void changePlayer()
		{
			now = now == player.WHITE ? player.BLACK : player.WHITE;
			if (now == player.WHITE)
			{
				whiteTurn.Visible = true;
				blackTurn.Visible = false;
			}
			else
			{
				whiteTurn.Visible = false;
				blackTurn.Visible = true;
			}
		}

		private void castling(int from, int to)
		{
			if (board[from] == piece.WK && to > from)
			{
				board[to] = board[from];
				board[from] = piece.NA;
				board[61] = piece.WR;
				board[63] = piece.NA;
			}
			else if (board[from] == piece.WK && to < from)
			{
				board[to] = board[from];
				board[from] = piece.NA;
				board[59] = piece.WR;
				board[56] = piece.NA;
			}
			else if (board[from] == piece.BK && to > from)
			{
				board[to] = board[from];
				board[from] = piece.NA;
				board[5] = piece.BR;
				board[7] = piece.NA;
			}
			else
			{
				board[to] = board[from];
				board[from] = piece.NA;
				board[3] = piece.BR;
				board[0] = piece.NA;
			}
		}

		private void BoardClick(object sender, EventArgs e)
		{
			int index = int.Parse(((CheckBox)sender).Tag.ToString());
			if (index == checkIndex)
			{
				setHint(-1);
				square[index].Checked = false;
				checkIndex = -1;
			}
			else
			{
				if ((board[index] == piece.NA) && (checkIndex == -1))
				{
					square[index].Checked = false;
				}
				else if ((board[index] != piece.NA) && (checkIndex == -1))
				{
					if ((now == player.WHITE && (int)board[index] % 2 == 1) || (now == player.BLACK && (int)board[index] % 2 == 0))
					{
						checkIndex = index;
						setHint(index);
					}
					else
					{
						square[index].Checked = false;
					}
				}
				else if ((board[index] == piece.NA) && (checkIndex >= 0))
				{
					if (Movable(checkIndex, index))
					{
						enPass = false;
						checkPass(checkIndex,index);
						BKmove = board[checkIndex] == piece.BK;
						WKmove = board[checkIndex] == piece.WK;
						BRmove = board[checkIndex] == piece.BR;
						WRmove = board[checkIndex] == piece.WR;
						if (isPass(checkIndex, index))
						{
							if (board[index + 8] != piece.NA && !isSameColor(index, index + 8))
							{
								board[index + 8] = piece.NA;
							}
							else
							{
								board[index - 8] = piece.NA;
							}
						}
						if ((board[checkIndex] == piece.WK || board[checkIndex] == piece.BK) && Math.Abs(checkIndex - index) == 2)
						{
							castling(checkIndex, index);
						}
						else
						{
							board[index] = board[checkIndex];
							board[checkIndex] = piece.NA;
						}
						changePlayer();
					}
					setHint(-1);
					square[index].Checked = false;
					square[checkIndex].Checked = false;
					checkIndex = -1;
				}
				else
				{
					if (!isSameColor(index, checkIndex))
					{
						if (Movable(checkIndex, index))
						{
							enPass = false;
							BKmove = board[checkIndex] == piece.BK;
							WKmove = board[checkIndex] == piece.WK;
							BRmove = board[checkIndex] == piece.BR;
							WRmove = board[checkIndex] == piece.WR;
							board[index] = board[checkIndex];
							board[checkIndex] = piece.NA;
							changePlayer();
							square[index].Checked = false;
							checkIndex = -1;
						}
						else
						{
							square[index].Checked = false;
							square[checkIndex].Checked = false;
							checkIndex = -1;
						}
						setHint(-1);
					}
					else
					{
						square[checkIndex].Checked = false;
						setHint(index);
						checkIndex = index;
					}
				}
			}
			if (square[index].Checked)
			{
				square[index].BackColor = SEL;
			}
			else
			{
				if (((index / 8) % 2 == 0 && index % 2 == 1) || ((index / 8) % 2 == 1 && index % 2 == 0))
				{
					square[index].BackColor = DARK;
				}
				else
				{
					square[index].BackColor = LIGHT;
				}
			}
			square[index].Focus();
			RefreshBoard();
			if (board[index] == piece.WP && index / 8 == 0)
			{
				changePlayer();
				promotion.player = 1;
				promotion.ShowDialog(this);
				board[index] = (piece)promotion.choose;
				changePlayer();
				RefreshBoard();
			}
			else if (board[index] == piece.BP && index / 8 == 7)
			{
				changePlayer();
				promotion.player = 0;
				promotion.ShowDialog(this);
				board[index] = (piece)promotion.choose;
				changePlayer();
				RefreshBoard();
			}
		}

		private bool isPass(int from, int to)
		{
			if (board[from] == piece.WP || board[from] == piece.BP)
			{
				int fromRow = from / 8, fromCol = from % 8, toRow = to / 8, toCol = to % 8;
				return Math.Abs(fromRow - toRow) == 1 && Math.Abs(fromCol - toCol) == 1;
			}
			return false;
		}

		private void checkPass(int from, int to)
		{
			if ((board[from] == piece.BP || board[from] == piece.WP) && Math.Abs(to / 8 - from / 8) == 2)
			{
				if (board[from] == piece.WP)
				{
					if (board[to - 1] == piece.BP)
					{
						enPass = true;
						passer = to;
					}
					else if (board[to + 1] == piece.BP)
					{
						enPass = true;
						passer = to;
					}
					else
					{
						enPass = false;
					}
				}
				else
				{
					if (board[to - 1] == piece.WP)
					{
						enPass = true;
						passer = to;
					}
					else if (board[to + 1] == piece.WP)
					{
						enPass = true;
						passer = to;
					}
					else
					{
						enPass = false;
					}
				}
			}
		}

		private bool isNotBlock(int from, int to, int fromRow, int fromCol, int toRow, int toCol, bool vertical, bool horizontal, bool diagonal)
		{
			switch (board[from])
			{
				case piece.BK:
				case piece.WK:
					return board[(from + to) / 2] == piece.NA;
				case piece.BB:
				case piece.WB:
					for (int row = fromRow, col = fromCol; ; )
					{
						if (toRow - fromRow < 0)
						{
							row--;
						}
						else
						{
							row++;
						}
						if (toCol - fromCol < 0)
						{
							col--;
						}
						else
						{
							col++;
						}
						if ((row == toRow || col == toCol) && !isSameColor(from, to))
						{
							return true;
						}
						if (board[row * 8 + col] != piece.NA)
						{
							return false;
						}
						if (row == toRow || col == toCol)
						{
							return true;
						}
					}
				case piece.BR:
				case piece.WR:
					if (vertical)
					{
						for (int row = fromRow; ; )
						{
							if (toRow - fromRow < 0)
							{
								row--;
							}
							else
							{
								row++;
							}
							if ((row == toRow) && !isSameColor(from, to))
							{
								return true;
							}
							if (board[row * 8 + fromCol] != piece.NA)
							{
								return false;
							}
							if (row == toRow)
							{
								return true;
							}
						}
					}
					else
					{
						for (int col = fromCol; ; )
						{
							if (toCol - fromCol < 0)
							{
								col--;
							}
							else
							{
								col++;
							}
							if ((col == toCol) && !isSameColor(from, to))
							{
								return true;
							}
							if (board[fromRow * 8 + col] != piece.NA)
							{
								return false;
							}
							if (col == toCol)
							{
								return true;
							}
						}
					}
				case piece.BQ:
				case piece.WQ:
					if (diagonal)
					{
						for (int row = fromRow, col = fromCol; ; )
						{
							if (toRow - fromRow < 0)
							{
								row--;
							}
							else
							{
								row++;
							}
							if (toCol - fromCol < 0)
							{
								col--;
							}
							else
							{
								col++;
							}
							if ((row == toRow || col == toCol) && !isSameColor(from,to))
							{
								return true;
							}
							if (board[row * 8 + col] != piece.NA)
							{
								return false;
							}
							if (row == toRow || col == toCol)
							{
								return true;
							}
						}
					}
					else if (vertical)
					{
						for (int row = fromRow; ; )
						{
							if (toRow - fromRow < 0)
							{
								row--;
							}
							else
							{
								row++;
							}
							if ((row == toRow) && !isSameColor(from, to))
							{
								return true;
							}
							if (board[row * 8 + fromCol] != piece.NA)
							{
								return false;
							}
							if (row == toRow)
							{
								return true;
							}
						}
					}
					else
					{
						for (int col = fromCol; ; )
						{
							if (toCol - fromCol < 0)
							{
								col--;
							}
							else
							{
								col++;
							}
							if ((col == toCol) && !isSameColor(from, to))
							{
								return true;
							}
							if (board[fromRow * 8 + col] != piece.NA)
							{
								return false;
							}
							if (col == toCol)
							{
								return true;
							}
						}
					}
				case piece.BP:
				case piece.WP:
					for (int row = fromRow; ; )
					{
						if (toRow - fromRow < 0)
						{
							row--;
						}
						else
						{
							row++;
						}
						if (board[row * 8 + fromCol] != piece.NA)
						{
							return false;
						}
						if (row == toRow)
						{
							return true;
						}
					}
				default:
					return false;
			}
		}

		private bool Movable(int from, int to)
		{
			int fromRow = from / 8, fromCol = from % 8, toRow = to / 8, toCol = to % 8;
			bool diagonal = Math.Abs(fromRow - toRow) == Math.Abs(fromCol - toCol);
			bool vertical = (fromCol - toCol) == 0;
			bool horizontal = (fromRow - toRow) == 0;
			bool castleMove = horizontal && Math.Abs(fromCol - toCol) == 2 && board[to] == piece.NA;
			bool adjacent = Math.Abs(fromRow - toRow) <= 1 && Math.Abs(fromCol - toCol) <= 1;
			bool horse = Math.Abs(fromRow - toRow) > 0 && Math.Abs(fromCol - toCol) > 0 && (Math.Abs(fromRow - toRow) + Math.Abs(fromCol - toCol) == 3);
			bool pawn = ((fromRow == 1 || fromRow == 6) && vertical && Math.Abs(fromRow - toRow) <= 2) || (vertical && Math.Abs(fromRow - toRow) == 1);
			bool pawnEat = Math.Abs(fromRow - toRow) == 1 && Math.Abs(fromCol - toCol) == 1;
			switch (board[from])
			{
				case piece.BK:
				case piece.WK:
					if (adjacent)
					{
						return !isSameColor(from, to);
					}
					else if (castleMove)
					{
						return isNotBlock(from, to, fromRow, fromCol, toRow, toCol, vertical, horizontal, diagonal);
					}
					else
					{
						return false;
					}
				case piece.BB:
				case piece.WB:
					if (diagonal)
					{
						return isNotBlock(from, to, fromRow, fromCol, toRow, toCol, vertical, horizontal, diagonal);
					}
					else
					{
						return false;
					}
				case piece.BQ:
				case piece.WQ:
					if (diagonal || vertical || horizontal)
					{
						return isNotBlock(from, to, fromRow, fromCol, toRow, toCol, vertical, horizontal, diagonal);
					}
					else
					{
						return false;
					}
				case piece.BR:
				case piece.WR:
					if (vertical || horizontal)
					{
						return isNotBlock(from, to, fromRow, fromCol, toRow, toCol, vertical, horizontal, diagonal);
					}
					else
					{
						return false;
					}
				case piece.BN:
				case piece.WN:
					if (horse)
					{
						return !isSameColor(from, to);
					}
					else
					{
						return false;
					}
				case piece.BP:
					if (pawn && fromRow - toRow < 0)
					{
						return isNotBlock(from, to, fromRow, fromCol, toRow, toCol, vertical, horizontal, diagonal);
					}
					else if (pawnEat && (board[to] != piece.NA || enPass) && fromRow - toRow < 0)
					{
						if (enPass)
						{
							Console.WriteLine(to);
							return to - 8 == passer || (board[to] != piece.NA && !isSameColor(from, to));
						}
						else
						{
							return !isSameColor(from, to);
						}
					}
					else
					{
						return false;
					}
				case piece.WP:
					if (pawn && fromRow - toRow > 0)
					{
						return isNotBlock(from, to, fromRow, fromCol, toRow, toCol, vertical, horizontal, diagonal);
					}
					else if (pawnEat && (board[to] != piece.NA || enPass) && fromRow - toRow > 0)
					{
						if (enPass)
						{
							Console.WriteLine(to);
							return to + 8 == passer || (board[to] != piece.NA && !isSameColor(from, to));
						}
						else
						{
							return !isSameColor(from, to);
						}
					}
					else
					{
						return false;
					}
				default:
					return false;
			}
		}

		private void setHint(int index)
		{
			for (int i = 0; i < 64; i++)
			{
				if (i == index)
				{
					continue;
				}
				else
				{
					if (index >= 0 && Movable(index, i))
					{
						square[i].BackColor = SEL;
					}
					else
					{
						if (((i / 8) % 2 == 0 && i % 2 == 1) || ((i / 8) % 2 == 1 && i % 2 == 0))
						{
							square[i].BackColor = DARK;
						}
						else
						{
							square[i].BackColor = LIGHT;
						}
					}
				}
			}
		}

		private bool isSameColor(int a,int b)
		{
			if ((int)board[a] == 12 || (int)board[b] == 12)
			{
				return false;
			}
			else if (((int)board[a] + (int)board[b]) % 2 == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void GameSet()
		{
			BKmove = WKmove = BRmove = WRmove = false;
			board[0] = piece.BR;
			board[1] = piece.BN;
			board[2] = piece.BB;
			board[3] = piece.BQ;
			board[4] = piece.BK;
			board[5] = piece.BB;
			board[6] = piece.BN;
			board[7] = piece.BR;
			for (int i = 8; i < 16; i++)
			{
				board[i] = piece.BP;
			}
			for (int i = 16; i < 48; i++)
			{
				board[i] = piece.NA;
			}
			for (int i = 48; i < 56; i++)
			{
				board[i] = piece.WP;
			}
			board[56] = piece.WR;
			board[57] = piece.WN;
			board[58] = piece.WB;
			board[59] = piece.WQ;
			board[60] = piece.WK;
			board[61] = piece.WB;
			board[62] = piece.WN;
			board[63] = piece.WR;
			checkIndex = -1;
		}

		private void RefreshBoard()
		{
			for (int i = 0; i < 64; i++)
			{
				square[i].Checked = false;
				switch (board[i])
				{
					case piece.WR:
						square[i].ImageKey = "WhiteRook.png";
						break;
					case piece.WQ:
						square[i].ImageKey = "WhiteQueen.png";
						break;
					case piece.WP:
						square[i].ImageKey = "WhitePawn.png";
						break;
					case piece.WN:
						square[i].ImageKey = "WhiteKnight.png";
						break;
					case piece.WK:
						square[i].ImageKey = "WhiteKing.png";
						break;
					case piece.WB:
						square[i].ImageKey = "WhiteBishop.png";
						break;
					case piece.BR:
						square[i].ImageKey = "BlackRook.png";
						break;
					case piece.BQ:
						square[i].ImageKey = "BlackQueen.png";
						break;
					case piece.BP:
						square[i].ImageKey = "BlackPawn.png";
						break;
					case piece.BN:
						square[i].ImageKey = "BlackKnight.png";
						break;
					case piece.BK:
						square[i].ImageKey = "BlackKing.png";
						break;
					case piece.BB:
						square[i].ImageKey = "BlackBishop.png";
						break;
					default:
						square[i].ImageKey = "";
						break;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			white = black = 1800;
			now = player.WHITE;
			whiteTurn.Visible = true;
			for (int i = 0; i < 64; i++)
			{
				square[i].Enabled = true;
			}
			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (now == player.WHITE)
			{
				white--;
				whiteClock.Text = "" + white / 60 + ":" + white % 60;
			}
			else
			{
				black--;
				blackClock.Text = "" + black / 60 + ":" + black % 60;
			}
		}
	}
}
