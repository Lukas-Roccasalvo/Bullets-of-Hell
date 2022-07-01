using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singelton
{
    public static Singelton self;
    public int score = 0;
    public bool running = true;
    public int health = 3;

    private Singelton()
    {
    }

    public static Singelton getInstance()
    {
        if(self == null)
        {
            self = new Singelton();
        }
        return self;
    }
}
