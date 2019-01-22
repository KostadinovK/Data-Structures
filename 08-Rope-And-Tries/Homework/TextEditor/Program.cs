using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        TextEditor editor = new TextEditor();
        Dictionary<string, bool> users = new Dictionary<string, bool>();

        string line = Console.ReadLine();
        Regex regex = new Regex("\"(.*)\"");
        while (line != "end")
        {
            string[] tokens = line.Split().ToArray();
            Match match = regex.Match(line);

            switch (tokens[0])
            {
                case "login":
                    users[tokens[1]] = true;
                    editor.Login(tokens[1]);
                    break;
                case "logout":
                    users[tokens[1]] = false;
                    editor.Logout(tokens[1]);
                    break;
                case "users":
                    if (tokens.Length == 2)
                    {
                        editor.Users();
                    }
                    else
                    {
                        editor.Users(tokens[2]);
                    }

                    break;
            }

            if (!(users.ContainsKey(tokens[0]) && users[tokens[0]]))
            {
                line = Console.ReadLine();
                continue;
            }

            switch (tokens[1])
            {
                case "insert":
                    editor.Insert(tokens[0], int.Parse(tokens[2]), match.Groups[1].Value);
                    break;
                case "prepend":
                    editor.Prepend(tokens[0], match.Groups[1].Value);
                    break;
                case "substring":
                    editor.Substring(tokens[0],int.Parse(tokens[2]),int.Parse(tokens[3]));
                    break;
                case "delete":
                    editor.Delete(tokens[0],int.Parse(tokens[2]),int.Parse(tokens[3]));
                    break;
                case "clear":
                    editor.Clear(tokens[0]);
                    break;
                case "length":
                    Console.WriteLine(editor.Length(tokens[0]));
                    break;
                case "print":
                    Console.WriteLine(editor.Print(tokens[0]));
                    break;
                case "undo":
                    editor.Undo(tokens[0]);
                    break;
            }

            line = Console.ReadLine();
        }
    }
}
