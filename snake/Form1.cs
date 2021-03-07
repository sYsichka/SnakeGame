using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();
        int maxXPos;
        int maxYPos;

        public Form1()
        {
            InitializeComponent();
            new Settings();

            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();
            maxXPos = pbCanvas.Size.Width / Settings.Width;
            maxYPos = pbCanvas.Size.Height / Settings.Width;
            StartGame();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void StartGame()
        {
            label3.Visible = false;
            new Settings();
            Snake.Clear();
            Circle head = new Circle();
            Random random = new Random();
            head.X = 10;
            head.Y = 5;
            Snake.Add(head);

            label1.Text = Settings.Score.ToString();
            GenerateFood();
        }
        private void GenerateFood()
        {
            Random random = new Random();

            food = new Circle();
            food.X = random.Next(0, maxXPos);

            food.Y = random.Next(0, maxYPos);
        }
        private void UpdateScreen(object sender, EventArgs e)
        {

        }
        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Settings.GameOver)
            {
                Brush snakeColor;

                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                        snakeColor = Brushes.Black;
                    else
                        snakeColor = Brushes.Red;

                    canvas.FillEllipse(snakeColor,
                        new Rectangle(Snake[i].X * Settings.Width, Snake[i].Y * Settings.Height, Settings.Width, Settings.Height));
                }
                canvas.FillEllipse(Brushes.Blue,
                       new Rectangle(Snake[].X * Settings.Width, Snake[].Y * Settings.Height, Settings.Width, Settings.Height));
            }
        }

        private void MovePlayer()
        {

        }
        private void Die()
        {
            Settings.GameOver = true;
        }
        private void Eat()
        {
            Circle eatenFood = new Circle();
            eatenFood.X = Snake[Snake.Count - 1].X;
            eatenFood.Y = Snake[Snake.Count - 1].Y;

            Snake.Add(eatenFood);


            Settings.Score += Settings.Points;
            Label3.Text = Settings.Score.ToString();

            GenerateFood
    }
    }

}

