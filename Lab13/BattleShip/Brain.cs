using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public enum CellState
    {
        empty,
        busy,
        striked,
        missed,
        killed,
        aura
    }


    public delegate void MyDelegate(CellState[,] map);

    class Brain
    {
        public ShipType[] st = { ShipType.D4, ShipType.D3, ShipType.D3, ShipType.D2,
                          ShipType.D2, ShipType.D2, ShipType.D1,
                          ShipType.D1, ShipType.D1,
                          ShipType.D1
        };

        public int stIndex = -1;

        CellState[,] map = new CellState[10, 10];
        List<Ship> units = new List<Ship>();
        
        ShipPoint shipPoint = new ShipPoint();
        MyDelegate invoker;
        public Brain(MyDelegate invoker)
        {
            this.invoker = invoker;
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    map[i, j] = CellState.empty;
                }
            }
            invoker.Invoke(map);
        }

        public int ShipKilledCount = 10;
        public bool Process2(string msg)
        {
            bool successShoot = false;

            string[] val = msg.Split('_');
            int i = int.Parse(val[0]);
            int j = int.Parse(val[1]);

            switch (map[i, j])
            {
                case CellState.empty:
                    map[i, j] = CellState.missed;
                    SoundPlayer sound = new SoundPlayer(@"C:\Users\Islam\Desktop\mermaid (5).wav");
                    sound.Play();
                    break;
                case CellState.aura:
                    map[i, j] = CellState.missed;
                    SoundPlayer sound1 = new SoundPlayer(@"C:\Users\Islam\Desktop\mermaid (5).wav");
                    sound1.Play();
                    break;
                case CellState.busy:
                    map[i, j] = CellState.striked;
                    successShoot = true;

                    int index = -1;
                    for (int k = 0; k < units.Count; ++k)
                    {
                        foreach (ShipPoint p in units[k].body)
                        {
                            if (p.X == i && p.Y == j)
                            {
                                index = k;
                                break;
                            }
                        }
                        if (index != -1)
                        {
                            break;
                        }

                    }

                    if (index != -1)
                    {
                        bool killed = true;

                        foreach (ShipPoint p in units[index].body)
                        {
                            if (map[p.X, p.Y] != CellState.striked)
                            {
                                killed = false;
                                break;
                            }
                        }

                        if (killed)
                        {
                            ShipKilledCount--;
                            foreach (ShipPoint p in units[index].body)
                            {
                                
                                map[p.X, p.Y] = CellState.killed;
                                AfterKill(p.X, p.Y);
                               
                            }
                            
                        }
                    }

                    break;
                case CellState.striked:
                    break;
                case CellState.missed:
                    break;
                case CellState.killed:
                    break;
                default:
                    break;
            }

            invoker.Invoke(map);
            return successShoot;
        }

        public void Process(string msg)
        {
            string[] val = msg.Split('_');
            int i = int.Parse(val[0]);
            int j = int.Parse(val[1]);
            Point p = new Point(i, j);

            ShipPlacement(p);

        }

        private bool IsGoodCell(int i, int j)
        {
            if (i < 0 || i > 9) return false;
            if (j < 0 || j > 9) return false;
            return map[i, j] == CellState.empty;
        }
        private bool IsGoodSrtiked(int i, int j)
        {
            if (i < 0 || i > 9) return false;
            if (j < 0 || j > 9) return false;
            return map[i, j] == CellState.aura;
        }

        private bool IsGoodLocated(Ship ship)
        {
            bool res = true;

            foreach (ShipPoint p in ship.body)
            {
                if (!IsGoodCell(p.X, p.Y))
                {
                    res = false;
                    break;
                }
            }

            return res;
        }


        private void MarkCell(int i, int j)
        {
            map[i, j] = CellState.busy;
        }

        private void MarkLocation(Ship ship)
        {
            foreach (ShipPoint p in ship.body)
            {
                MarkCell(p.X, p.Y);
                MarkAura(p.X, p.Y);
            }
            
        }
        public void AfterKill(int x,int y)
        {
            if (IsGoodSrtiked(x+1,y)  )
            {
                map[x + 1, y] = CellState.missed;
            }
             if (IsGoodSrtiked(x - 1, y))
            {
                map[x - 1, y] = CellState.missed;
            }
             if (IsGoodSrtiked(x, y + 1))
            {
                map[x, y + 1] = CellState.missed;
            }
             if (IsGoodSrtiked(x, y - 1))
            {
                map[x, y - 1] = CellState.missed;
            }
             if (IsGoodSrtiked(x + 1, y + 1))
            {
                map[x + 1, y + 1] = CellState.missed;
            }
             if (IsGoodSrtiked(x + 1, y - 1))
            {
                map[x + 1, y - 1] = CellState.missed;
            }
             if (IsGoodSrtiked(x - 1, y + 1))
            {
                map[x - 1, y + 1] = CellState.missed;
            }
             if (IsGoodSrtiked(x - 1, y - 1))
            {
                map[x - 1, y - 1] = CellState.missed;
            }
        }
        public void MarkAura(int x,int y)
        {
            if (IsGoodCell(x + 1, y))
            {
                map[x + 1, y] = CellState.aura;
            }
            if (IsGoodCell(x -1, y))
            {
                map[x - 1, y] = CellState.aura;
            }
             if (IsGoodCell(x , y + 1))
            {
                map[x , y + 1] = CellState.aura;
            }
             if (IsGoodCell(x , y-1))
            {
                map[x , y-1] = CellState.aura;
            }
             if (IsGoodCell(x + 1, y+1))
            {
                map[x + 1, y + 1] = CellState.aura;
            }
             if (IsGoodCell(x + 1, y-1))
            {
                map[x + 1, y-1] = CellState.aura;
            }
             if (IsGoodCell(x - 1, y+1))
            {
                map[x - 1, y + 1] = CellState.aura;
            }
             if (IsGoodCell(x- 1, y-1))
            {
                map[x - 1, y-1] = CellState.aura;
            }
        }


        public void ShipPlacement(Point p)
        {
            if (stIndex + 1 < st.Length)
            {
                stIndex++;
                Ship ship = new Ship(p, st[stIndex]);
                if (IsGoodLocated(ship))
                {
                    units.Add(ship);
                    MarkLocation(ship);
                    invoker.Invoke(map);
                }
                else
                {
                    stIndex--;
                }
            }
        }
    }
}
