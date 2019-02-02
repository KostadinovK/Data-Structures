﻿using System;

public class Person
{
    public string Email { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Town { get; set; }

    public Person(string email, string name, int age, string town)
    {
        Email = email;
        Name = name;
        Age = age;
        Town = town;
    }
}
