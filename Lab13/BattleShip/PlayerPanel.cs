using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    enum PanelPosition
    {
        Left,
        Right
    }

    public enum PlayerType
    {
        Human,
        Bot
    }
    class PlayerPanel:Panel
    {
        public Brain brain;
        int cellW = 25;
       public   PanelPosition panelPosition ;
        public PlayerType playerType;
        TurnDelegate tDelegate;
        Random rnd1 = new Random(Guid.NewGuid().GetHashCode());
        Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
       public  Color BusyColor;

        public PlayerPanel(PanelPosition panelPosition, PlayerType playerType, TurnDelegate tDelegate,Color BusyColor)
        {
            this.playerType = playerType;
            this.panelPosition = panelPosition;
            this.tDelegate = tDelegate;
            this.BusyColor = BusyColor;
            Initialize();

            switch (panelPosition)
            {
                case PanelPosition.Left:
                    //RndH();
                    break;
                case PanelPosition.Right:
                    RndB();
                    break;
                default:
                    break;
            }
        }
      public void RndB()
        {
            while (brain.stIndex < brain.st.Length - 1)
            {
                int row = rnd2.Next(0, 10);
                int column = rnd2.Next(0, 10);
                string msg = string.Format("{0}_{1}", row, column);
                brain.Process(msg);
            }
        }
        public void RndH()
        {
            
                while (brain.stIndex < brain.st.Length - 1)
                {
                    int row = rnd2.Next(0, 10);
                    int column = rnd2.Next(0, 10);
                    string msg = string.Format("{0}_{1}", row, column);
                    brain.Process(msg);
                }
            
        }
        private void Initialize()
        {
            this.Location = new Point(cellW + 5, cellW + 10);

            if (panelPosition == PanelPosition.Right)
            {
                this.Location = new Point(cellW * 10 + cellW +100, cellW + 10);
            }

            this.BackColor = SystemColors.ActiveCaption;
            this.Size = new Size(cellW * 10, cellW * 10);

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Button btn = new Button();
                    btn.Name = i + "_" + j;
                    btn.Click += Btn_Click;
                    btn.Size = new Size(cellW, cellW);
                    btn.Location = new Point(i * cellW, j * cellW);
                    this.Controls.Add(btn);
                }
            }

            brain = new Brain(ChangeButton);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (brain.stIndex < brain.st.Length - 1)
            {
                brain.Process(btn.Name);
            }
            else
            {
                if (!brain.Process2(btn.Name))
                {
                    tDelegate.Invoke();
                }
            }
        }

        private void ChangeButton(CellState[,] map)
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Color colorToFill = Color.White;
                    bool isEnabled = true;

                    switch (map[i, j])
                    {
                        case CellState.empty:
                            colorToFill = Color.White;
                            break;
                        case CellState.busy:

                            colorToFill = BusyColor;
                            break;
                        case CellState.striked:
                            colorToFill = Color.Yellow;
                            isEnabled = false;
                            break;
                        case CellState.missed:
                            colorToFill = Color.Gray;
                            isEnabled = false;
                            break;
                        case CellState.aura:
                            

                            break;
                        case CellState.killed:
                            colorToFill = Color.Red;
                            isEnabled = false;
                            break;
                        default:
                            break;
                    }
                   
                    this.Controls[10 * i + j].BackColor = colorToFill;
                    this.Controls[10 * i + j].Enabled = isEnabled;
                }
            }


        }
    }
}
