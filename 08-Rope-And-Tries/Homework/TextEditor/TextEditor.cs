using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TextEditor : ITextEditor
{
    private Trie<StringBuilder> users;
    private Trie<Stack<string>> cache;

    public TextEditor()
    {
        users = new Trie<StringBuilder>();
        cache = new Trie<Stack<string>>();
    }

    public void Login(string username)
    {
        users.Insert(username, new StringBuilder());
        cache.Insert(username, new Stack<string>());
    }

    public void Logout(string username)
    {
        users.Delete(username);
        cache.Delete(username);
    }

    public void Prepend(string username, string str)
    {
        this.Cache(username);

        this.Insert(username,0,str);
    }

    public void Insert(string username, int index, string str)
    {
        this.Cache(username);

        users.GetValue(username).Insert(index,str);
    }

    public void Substring(string username, int startIndex, int length)
    {
        this.Cache(username);

        users.GetValue(username).Remove(0,startIndex);
        users.GetValue(username).Remove(startIndex + length,users.GetValue(username).ToString().Length - startIndex + length);

    }

    public void Delete(string username, int startIndex, int length)
    {
        this.Cache(username);

        users.GetValue(username).Remove(startIndex,length);
    }

    public void Clear(string username)
    {
        this.Cache(username);
        users.GetValue(username).Clear();
    }


    public int Length(string username)
    {
        return users.GetValue(username).ToString().Length;
    }

    public string Print(string username)
    {
        return users.GetValue(username).ToString();
    }

    public void Undo(string username)
    {
        var undo = cache.GetValue(username);
        if (undo.Count == 0)
        {
            return;
        }

        users.Insert(username,new StringBuilder(undo.Pop()));

    }

    public IEnumerable<string> Users(string prefix = "")
    {
        return users.GetByPrefix(prefix);
    }

    private void Cache(string username)
    {
        cache.GetValue(username).Push(users.GetValue(username).ToString());
    }
}

