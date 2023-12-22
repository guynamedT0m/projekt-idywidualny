namespace projekt_idywidualny
{
    public partial class Form1 : Form
    {
        const int N = 15;


        int[,] Cells = new int[N, N];

        int playerTurn = 1;

        int GameOver = 0;
        int i0;
        int j0;
        int WhatLine = 0;

        public Form1()
        {
            InitializeComponent();

            //Cells[7, 9] = 1; //krzyzyk
            //Cells[0, 0] = 1;
            //Cells[N - 1, N - 1] = 1;
            //Cells[6, 6] = 2; //kolko
            //Cells[9, 7] = 2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int w = pictureBox1.Width / N;



            for (int i = 0; i < N + 1; i++)
            {
                g.DrawLine(Pens.Black, 0 + w * i, 0, 0 + w * i, pictureBox1.Height);
                g.DrawLine(Pens.Black, 0, 0 + w * i, pictureBox1.Width, 0 + w * i);
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (Cells[i, j] == 1)
                    {
                        g.DrawLine(Pens.Black, i * w, j * w, i * w + w, j * w + w);
                        g.DrawLine(Pens.Black, i * w + w, j * w, i * w, j * w + w);
                    }

                    if (Cells[i, j] == 2)
                    {
                        g.DrawEllipse(Pens.Black, i * w, j * w, w, w);
                    }

                }
            }

            //if (GameOver > 0)
            {
                //System.Windows.Forms.MessageBox.Show("you win");
                //g.DrawLine(Pens.Black, i0 * w, j0 * w + w / 2, i0 * w + 5 * w, j0 * w + w / 2);
            }

            if (WhatLine == 1)
            {
                g.DrawLine(Pens.Red, i0 * w, j0 * w + w / 2, i0 * w + 5 * w, j0 * w + w / 2);
            }

            if (WhatLine == 2)
            {
                g.DrawLine(Pens.Red, i0 * w + w / 2, j0 * w, i0 * w + w / 2, j0 * w + 5 * w);
            }
            if (WhatLine == 3)
            {
                g.DrawLine(Pens.Red, i0 * w, j0 * w, i0 * w + (141 * 4)/100 *w , j0 * w + (141 * 4)/100 *w);
            }

            if (WhatLine == 4)
            {
                g.DrawLine(Pens.Red, i0 * w, j0 * w + w, i0 * w + (141 * 4)/100 * w, j0 * w - (141 * 4)/100 * w + w);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int w = pictureBox1.Width / N;

            int x = e.X;
            int y = e.Y;

            int i = x / w;
            int j = y / w;

            if (GameOver > 0)
            {
                return;
            }

            if (i >= N || j >= N)
            {
                return;
            }

            if (Cells[i, j] == 1 || Cells[i, j] == 2)
            {
                return;
            }



            Cells[i, j] = playerTurn;
            for (int k = -4; k <= 1; k++)
            {
                if (
                    i >= -k && i < N - k && Cells[i + k, j] == playerTurn && 
                    i > -k - 1 && i < N - k - 1 && Cells[i + k + 1, j] == playerTurn &&
                    i > -k - 2 && i < N - k - 2 && Cells[i + k + 2, j] == playerTurn &&
                    i > -k - 3 && i < N - k - 3 && Cells[i + k + 3, j] == playerTurn &&
                    i > -k - 4 && i < N - k - 4 && Cells[i + k + 4, j] == playerTurn)
                {
                    GameOver = playerTurn;
                    i0 = i + k;
                    j0 = j;
                    WhatLine = 1;

                }

                if (
                    j >= -k && j < N - k && Cells[i, j + k] == playerTurn &&
                    j > -k - 1 && j < N - k - 1 && Cells[i, j + k + 1] == playerTurn &&
                    j > -k - 2 && j < N - k - 2 && Cells[i, j + k + 2] == playerTurn &&
                    j > -k - 3 && j < N - k - 3 && Cells[i, j + k + 3] == playerTurn &&
                    j > -k - 4 && j < N - k - 4 && Cells[i, j + k + 4] == playerTurn)
                {
                    GameOver = playerTurn;
                    i0 = i;
                    j0 = j + k;
                    WhatLine = 2;

                }

                if (
                    j >= -k && j < N - k && i >= -k && i < N - k && Cells[i + k, j + k] == playerTurn &&
                    j > -k - 1 && j < N - k - 1 && i > -k - 1 && i < N - k - 1 && Cells[i + k + 1, j + k + 1] == playerTurn &&
                    j > -k - 2 && j < N - k - 2 && i > -k - 2 && i < N - k - 2 && Cells[i + k + 2, j + k + 2] == playerTurn &&
                    j > -k - 3 && j < N - k - 3 && i > -k - 3 && i < N - k - 3 && Cells[i + k + 3, j + k + 3] == playerTurn &&
                    j > -k - 4 && j < N - k - 4 && i > -k - 4 && i < N - k - 4 && Cells[i + k + 4, j + k + 4] == playerTurn)
                {
                    GameOver = playerTurn;
                    i0 = i + k;
                    j0 = j + k;
                    WhatLine = 3;

                }

                if (     //daje error dla j=11, i = 4++
                    j > k + 0 && j < N + k + 0 && i > -k - 0 && i < N - k - 0 && Cells[i + k + 0, j - k - 0] == playerTurn &&
                    j > k + 1 && j < N + k + 1 && i > -k - 1 && i < N - k - 1 && Cells[i + k + 1, j - k - 1] == playerTurn &&
                    j > k + 2 && j < N + k + 2 && i > -k - 2 && i < N - k - 2 && Cells[i + k + 2, j - k - 2] == playerTurn &&
                    j > k + 3 && j < N + k + 3 && i > -k - 3 && i < N - k - 3 && Cells[i + k + 3, j - k - 3] == playerTurn &&
                    j > k + 4 && j < N + k + 4 && i > -k - 4 && i < N - k - 4 && Cells[i + k + 4, j - k - 4] == playerTurn)
                {
                    GameOver = playerTurn;
                    i0 = i + k;
                    j0 = j - k;
                    WhatLine = 4;

                }



            }


            //if (i < N - 1 && Cells[i + 1, j] == playerTurn && i < N - 2 && Cells[i + 2, j] == playerTurn && i < N - 3 && Cells[i + 3, j] == playerTurn && i < N - 4 && Cells[i + 4, j] == playerTurn)
            //{
            //    GameOver = playerTurn;
            //    i0 = i;
            //    j0 = j;

            //}
            //if (i > 0 - 1 && Cells[i - 1, j] == playerTurn && i < N - 1 && Cells[i + 1, j] == playerTurn && i < N - 2 && Cells[i + 2, j] == playerTurn && i < N - 3 && Cells[i + 3, j] == playerTurn)
            //{
            //    GameOver = playerTurn;
            //    i0 = i-1;
            //    j0 = j;
            //}
            //if (i > 0 - 2 && Cells[i - 2, j] == playerTurn && i > 0 - 1 && Cells[i - 1, j] == playerTurn && i < N - 1 && Cells[i + 1, j] == playerTurn && i < N - 2 && Cells[i + 2, j] == playerTurn)
            //{
            //    GameOver = playerTurn;
            //    i0 = i;
            //    j0 = j;
            //}

            if (playerTurn == 1)
            {
                playerTurn = 2;
            }

            else
            {
                playerTurn = 1;
            }



            pictureBox1.Invalidate();
            pictureBox2.Invalidate();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameOver = 0;
            playerTurn = 1;
            WhatLine = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Cells[i, j] = 0;

                }
            }
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (playerTurn > 0 && playerTurn < 2)
            {
                g.DrawLine(Pens.Black, 0, 0, pictureBox2.Width, pictureBox2.Height);
                g.DrawLine(Pens.Black, 0, pictureBox2.Height, pictureBox2.Width, 0);
            }

            if (playerTurn > 1)
            {
                g.DrawEllipse(Pens.Black, 0, 0, pictureBox2.Width, pictureBox2.Height);
            }

        }
    }
}