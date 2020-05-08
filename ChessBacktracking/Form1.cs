using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessBacktracking
{
    public partial class Form1 : Form
    {
        const int M = 8;
        Chess chessGame;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }        

        private void button1_Click(object sender, EventArgs e)
        {
            chessGame = new Chess(M, 1);
            chessGame.drawBoard(boardBefore);
            chessGame.placeFigure(0, boardAfter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chessGame = new Chess(M, 2);
            chessGame.drawBoard(boardBefore);
            MessageBox.Show("Расставляем фигуры");
            chessGame.placeFigure(0, boardAfter);
            minOutput.Text = "Минимальное количество фигур, требующееся для покрытия: " + chessGame.minCount;
        }
    }
}