using System;

namespace Сапьёр
//0 -empty
//1-8 - mines around
//9 - mine
{
    public class cGen
    {
        Random rng = new Random();
        int[,] field;
        int maxMines;
        public cGen(int N, int Y)
        {
            field = new int[N, N];
            maxMines = Y;
        }
        bool checkEmpty()
        {
            bool res = false;
            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 9)
                    {
                        res = false;
                        int l = i - 1;
                        if (l < 0) l = 0;
                        int r = i + 1;
                        if (r >= field.GetLength(0)) r = field.GetLength(0) - 1;

                        int u = j - 1;
                        if (u < 0) u = 0;
                        int d = j + 1;
                        if (d >= field.GetLength(1)) d = field.GetLength(1) - 1;
                        for (int i1 = l; i1 <= r; i1++)
                            for (int j1 = u; j1 <= d; j1++)
                            {
                                if (field[i1, j1] == 0)
                                {
                                    res = true;
                                    break;
                                }
                            }
                        if (res == false)
                        {
                            return false;
                        }      
                    }
                }
            return true;
        }
        void plantMines()
        {
            for (int i = 0; i < maxMines;)
            {
                int x = rng.Next(0, field.GetLength(0));
                int y = rng.Next(0, field.GetLength(1));
                if (field[x, y] == 9) continue;
                field[x, y] = 9;
                if (checkEmpty() == false)
                {
                    field[x, y] = 0;
                    if (checkEmpty() == false)
                    {
                        field[x, y] = 0;
                        continue;
                    }
                }
                i++;
            }
        }
        public void calculateCells()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 0)
                    {
                        int l = i - 1;
                        if (l < 0) l = 0;
                        int r = i + 1;
                        if (r >= field.GetLength(0)) r = field.GetLength(0) - 1;

                        int u = j - 1;
                        if (u < 0) u = 0;
                        int d = j + 1;
                        if (d >= field.GetLength(1)) d = field.GetLength(1) - 1;
                        int sum = 0;
                        for (int i1 = l; i1 <= r; i1++)
                        {
                            for (int j1 = u; j1 <= d; j1++)
                            {
                                if (field[i1, j1] == 9) sum++;
                                field[i, j] = sum;
                            }
                        }      
                    }
                }
            }      
        }

        public void generate()
        {
            plantMines();
            calculateCells();
        }

        public int getCell(int i, int j)
        {
            return field[i, j];
        }
        void reveal(int i, int j)
        {
            if (i < field.GetLength(0)) reveal(i + 1, j);
            if (j < field.GetLength(1)) reveal(i, j + 1);
            if (i > 0) reveal(i - 1, j);
            if (j > 0) reveal(i, j - 1);
        }

    }
}
