using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Задача 18(а)
//Для шахматного поля размером МхМ найти наименьшее количество 1) ферзей 2) коней и их расстановку так,
//чтобы все поля доски, занятые фигурами оппонента, находились под ударом

namespace ChessBacktracking
{

    public class Cell
    {
        public bool isPlayer;      //является ли ферзем(конем)
        public bool isEnemy;       //является ли фигурой оппонента

        public Cell()
        {
            isPlayer = false;
            isEnemy = false;
        }
    }

    class Chess
    {
        public bool Queen = false;    //играем королевой или конем
        public int Size;
        public int minCount;      //миниальное количество наших фигур на доске
        int enemyCount;    //максимальное к-во фигур противника по умолчанию (по правилам шахмат их 16)
        public Cell[,] board;

        public Chess(int M, int choice)
        {
            if (choice == 1)
            {
                Queen = true;
            }
            minCount = M*M;
            Size = M;
            enemyCount = 7; //максимальное количество фигур противника для этой доски
            board = new Cell[M, M];
            int cE = 0;
            Random rnd = new Random();
            for (int i = 0; i < M; ++i)
            {
                for (int j = 0; j < M; ++j)
                {
                    board[i, j] = new Cell();
                    if ((cE < enemyCount) && (rnd.Next(0, 10) < 5)) //генерируем рандомное к-во фигур противника (до 16)
                    {
                        board[i, j].isEnemy = true;
                        cE++;
                    }
                }
            }
            enemyCount = cE;
        }

        //ищет не находящиеся под ударом клетки противника 
        bool findUnattackedCell(int currCount, DataGridView dataGridView)
        {
            if (Queen)
            {
                for (int i = 0; i < Size; ++i)
                {
                    for (int j = 0; j < Size; ++j)
                    {
                        if (board[i, j].isEnemy && !AttackedByQ(i, j))
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Size; ++i)
                {
                    for (int j = 0; j < Size; ++j)
                    {
                        if (board[i, j].isEnemy && !AttackedByK(i, j))
                        {
                            return true;
                        }
                    }
                }
            }
            //если дошли сюда, все фигуры противника находятся под ударом, тогда это к-во установленных нами фигур минимально 
            //(иначе мы не дошли бы до этой функции)
            minCount = currCount;
            drawBoard(dataGridView);    //выводим доску
            return false;
        }
    

        public void placeFigure(int currCount, DataGridView dataGridView)
        {
            ////если текущее к-во наших фигур равно минимальному, то выход
            if (currCount == minCount || currCount > enemyCount) 
            {
                return;
            }
            //если есть свободные фигуры противника, то идем пробовать расставлять свои
            if (findUnattackedCell(currCount, dataGridView))
            {
                for (int i = 0; i < Size; ++i)
                    for (int j = 0; j < Size; ++j)
                    {
                        if (Queen)  //если играем ферзями
                        {
                            //если клетка пустая, то пробуем поставить ферзя
                            if (!board[i, j].isEnemy && !board[i, j].isPlayer)
                            {
                                //ставим ферзя 
                                board[i, j].isPlayer = true;

                                //увеличиваем счетчик ферзей и ищем дальше
                                placeFigure(currCount + 1, dataGridView);

                                //убираем ферзя, чтобы найти решение лучше
                                board[i, j].isPlayer = false;

                            }
                        }
                        else
                        {
                            //если клетка пустая, то пробуем поставить коня
                            if (!board[i, j].isEnemy && !board[i, j].isPlayer)
                            {
                                //ставим коня 
                                board[i, j].isPlayer = true;

                                //увеличиваем счетчик коней и ищем дальше
                                placeFigure(currCount + 1, dataGridView);

                                //убираем коня, чтобы найти решение лучше
                                board[i, j].isPlayer = false;

                            }
                        }

                    }
            }
        }


        bool AttackedByQ(int row, int col) //возвращает true, если клетка с фигурой атакована хотя бы одним ферзем
        {
            int i, j;
            //ищем ферзя в столбце
            for (i = 0; i < Size; ++i)
                if (board[i, col].isPlayer) 
                    return true;

            //ищем ферзя в строке 
            for (j = 0; j < Size; ++j)
                if (board[row, j].isPlayer)
                    return true;

            //ищем ферзя по всем диагоналям 
            for (i = 0; i < Size; ++i)
            {
                if ((row - i >= 0) && (col - i >= 0) && board[row - i, col - i].isPlayer)
                    return true;
                if ((row - i >= 0) && (col + i < Size) && board[row - i, col + i].isPlayer)
                    return true;
                if ((row + i < Size) && (col - i >= 0) && board[row + i, col - i].isPlayer)
                    return true;
                if ((row + i < Size) && (col + i < Size) && board[row + i, col + i].isPlayer)
                    return true;
            }

            //иначе клетка не под ударом 
            return false;
        }

        bool AttackedByK(int row, int col) //возвращает true, если клетка с фигурой атакована хотя бы одним конем
        {
            int i = 1; int j = 2;

            //обходим клетку буквой Г
            if ((row - i >= 0) && (col - j >= 0) && board[row - i, col - j].isPlayer)
                return true;
            if ((row - i >= 0) && (col + j < Size) && board[row - i, col + j].isPlayer)
                return true;
            if ((row + i < Size) && (col - j >= 0) && board[row + i, col - j].isPlayer)
                return true;
            if ((row + i < Size) && (col + j < Size) && board[row + i, col + j].isPlayer)
                return true;
            if ((row - j >= 0) && (col - i >= 0) && board[row - j, col - i].isPlayer)
                return true;
            if ((row - j >= 0) && (col + i < Size) && board[row - j, col + i].isPlayer)
                return true;
            if ((row + j < Size) && (col - i >= 0) && board[row + j, col - i].isPlayer)
                return true;
            if ((row + j < Size) && (col + i < Size) && board[row + j, col + i].isPlayer)
                return true;

            //иначе клетка не под ударом 
            return false;
        }

        //рисует доску 8х8, закрашивая поставленные под удар фигуры противника (для удобства)
        public void drawBoard(DataGridView dataGridView1)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "1";
            col1.Width = 25;
            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "2";
            col2.Width = 25;
            DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "3";
            col3.Width = 25;
            DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "4";
            col4.Width = 25;
            DataGridViewColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "5";
            col5.Width = 25;
            DataGridViewColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "6";
            col6.Width = 25;
            DataGridViewColumn col7 = new DataGridViewTextBoxColumn();
            col7.HeaderText = "7";
            col7.Width = 25;
            DataGridViewColumn col8 = new DataGridViewTextBoxColumn();
            col8.HeaderText = "8";
            col8.Width = 25;
            dataGridView1.Columns.AddRange(col1, col2, col3, col4, col5, col6, col7, col8);

            DataGridViewCell cell;
            DataGridViewRow row;
            for (int i = 0; i < Size; ++i)
            {
                row = new DataGridViewRow();
                for (int j = 0; j < Size; ++j)
                {
                    cell = new DataGridViewTextBoxCell();

                    if (board[i, j].isEnemy)
                    {
                        cell.Value = "\u265F";   //зачеркнем клетки, где стоят фигуры противника
                        cell.Style.BackColor = System.Drawing.Color.Pink;
                        row.Cells.Add(cell);
                    }
                    else
                    if (board[i, j].isPlayer) //так обозначим нашу фигуру
                    {
                        if (Queen)
                        {
                            cell.Value = "\u2655";
                        }
                        else
                        {
                            cell.Value = "\u2658";
                        }
                        cell.Style.BackColor = System.Drawing.Color.LightBlue;
                        row.Cells.Add(cell);
                    }
                    else
                    {
                        cell.Value = " ";   //пустая клетка
                        row.Cells.Add(cell);
                    }
                }
                dataGridView1.Rows.Add(row);
            }
        }
    }
}
