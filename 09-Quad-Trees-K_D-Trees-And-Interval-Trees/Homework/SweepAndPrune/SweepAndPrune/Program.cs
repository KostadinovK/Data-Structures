using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        List<GameObject> objects = new List<GameObject>();

        string line = Console.ReadLine();

        while (line != "start")
        {
            string[] tokens = line.Split().ToArray();
            if (tokens[0] == "add")
            {
                GameObject obj = new GameObject(tokens[1], int.Parse(tokens[2]), int.Parse(tokens[3]));
                if (!objects.Contains(obj))
                {
                    objects.Add(obj);
                }
            }

            line = Console.ReadLine();
        }

        objects.Sort((x,y) => x.X1.CompareTo(y.X1));
        line = Console.ReadLine();

        int ticks = 1;
        while (line != "end")
        {
            string[] tokens = line.Split().ToArray();
            if (tokens[0] == "move")
            {
                GameObject obj = GetObject(objects, tokens[1]);

                obj?.Move(int.Parse(tokens[2]), int.Parse(tokens[3]));

                objects.Sort((x,y) => x.X1.CompareTo(y.X1));
            }

            CheckForCollisions(ticks, objects);

            ticks++;
            line = Console.ReadLine();
        }
    }

    private static void CheckForCollisions(int ticks, List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            for (int j = i + 1; j < objects.Count; j++)
            {
                if (objects[i].X2 < objects[j].X1)
                {
                    break;
                }

                if (objects[i].Y1 <= objects[j].Y2 && objects[i].Y2 >= objects[j].Y1)
                {
                    Console.WriteLine($"({ticks}) {objects[i].Name} collides with {objects[j].Name}");
                }
            }
        }
    }

    private static GameObject GetObject(List<GameObject> objects, string name)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (name == objects[i].Name)
            {
                return objects[i];
            }
        }

        return null;
    }
}

