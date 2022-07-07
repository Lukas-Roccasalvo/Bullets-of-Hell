using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singelton
{
    public static Singelton self;

    public int score;
    public bool running;
    public int health;
    public bool usedAbility;
    public float softTime;

    private Singelton()
    {
    }

    public static Singelton getInstance()
    {
        if(self == null)
        {
            self = new Singelton();
            Singelton.softReset();
        }
        return self;
    }

    public static void softReset()
    {
        getInstance().score = 0;
        getInstance().running = true;
        getInstance().health = 3;
        getInstance().usedAbility = false;
        getInstance().softTime = 0f;
    }
}
