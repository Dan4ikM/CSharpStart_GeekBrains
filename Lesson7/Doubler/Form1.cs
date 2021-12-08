using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doubler
{
    /// <summary>
    /// 1.а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
    /// 
    /// б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок.
    /// Игрок должен получить это число за минимальное количество ходов.
    /// 
    /// в) * Добавить кнопку «Отменить», которая отменяет последние ходы.
    /// Используйте библиотечный обобщенный класс System.Collections.Generic.Stack<int> Stack.
    ///
    /// Вся логика игры должна быть реализована в классе с удвоителем.
    /// </summary>
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int computerNumber;
        private int userNumber;
        private int commandsCount;
        private int minMovesCount;
        private int currentMovesCount;
        private Stack<int> moves;

        public Form1()
        {
            InitializeComponent();

            moves = new Stack<int>();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            UpdateGameState(userNumber *= 0, random.Next(1,50));
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (!CanMove())
                return;
            moves.Push(1);
            UpdateGameState(++userNumber);
            CheckGameState();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (!CanMove())
                return;
            moves.Push(0);
            UpdateGameState(userNumber *= 2);
            UpdateMultiplyCommandCount(commandsCount+1);
            CheckGameState();
        }

        private void UpdateGameState(int userNumber)
        {
            lbUserNumber.Text = $"Текущее число: {userNumber}";
            currentMovesCount++;
        }

        private void UpdateGameState(int userNumber, int computerNumber)
        {
            UpdateGameState(userNumber);
            UpdateMultiplyCommandCount(0);
            this.computerNumber = computerNumber;
            CalculateMinMovesCount();
            lbComputerNumber.Text = $"Получите число: {computerNumber}";
        }

        private void CalculateMinMovesCount()
        {
            minMovesCount = 0;
            currentMovesCount = 0;
            for (int i = computerNumber; i > 0;)
            {
                i = i % 2 == 0 ? i / 2 : --i;
                minMovesCount++;
            }
        }

        private void UpdateMultiplyCommandCount(int newCount)
        {
            commandsCount = newCount;
            lbCounterMultiplyCommands.Text = $"Количество удвоений: {commandsCount}";
        }

        private bool CanMove()
        {
            //Check Minimun Moves
            if (minMovesCount <= currentMovesCount)
            {
                MessageBox.Show("Вы сделали слишком много ходов!", "Удвоитель",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else if(computerNumber < userNumber)
            {
                MessageBox.Show("Вы получили слишком большое число!", "Удвоитель",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        private void CheckGameState()
        {
            
            //CheckWin
            if (computerNumber == userNumber)
            {
                MessageBox.Show("Вы успешно завершили игру", "Удвоитель",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Желаете сыграть еще раз?", "Удвоитель", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UpdateGameState(userNumber *= 0, random.Next(50));
                }
                else
                {
                    Close();
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            UpdateGameState(userNumber *= 0, random.Next(50));
            MessageBox.Show($"Должны получить число:{ computerNumber}","Удвоитель");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (moves.Count == 0)
                MessageBox.Show("Вы ещё не сделали ход!", "Удвоитель", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (moves.Pop() == 0)
                {
                    userNumber /= 2;
                    UpdateMultiplyCommandCount(--commandsCount);
                }
                else 
                { 
                    --userNumber; 
                }

                --currentMovesCount;
                UpdateGameState(userNumber);
                --currentMovesCount;
                //Потому что добавляю один ход внутри метода
            }
        }
    }
}
