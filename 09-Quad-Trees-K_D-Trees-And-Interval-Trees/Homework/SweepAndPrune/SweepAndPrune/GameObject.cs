using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameObject
{
    public string Name { get; set; }
    public int X1 { get; set; }
    public int Y1 { get; set; }
    public int X2 { get; set; }
    public int Y2 { get; set; }

    public GameObject(string name, int x1, int y1)
    {
        Name = name;
        X1 = x1;
        Y1 = y1;

        X2 = X1 + 10;
        Y2 = Y1 + 10;
    }

    public void Move(int newX1, int newY1)
    {
        X1 = newX1;
        Y1 = newY1;

        X2 = X1 + 10;
        Y2 = Y1 + 10;
    }
}

