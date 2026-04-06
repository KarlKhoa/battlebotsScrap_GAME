using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BotDecorator : IBot
{
    protected IBot wrappedBot;

    public BotDecorator(IBot _bot)
    {
        wrappedBot = _bot;
    }

    public virtual void Move()
   {
        wrappedBot.Move();
   }
   public virtual void Turn()
   {
        wrappedBot.Turn();
   }

    public virtual void Activate1()
    {
        wrappedBot.Activate1();
    }
    public virtual void Activate2()
    {
        wrappedBot.Activate2();
    }
    public virtual void Activate3()
    {
        wrappedBot.Activate3();
    }
    public virtual void Activate4()
    {
        wrappedBot.Activate4();
    }

    public virtual void TakeDamage()
    {
        wrappedBot.TakeDamage();
    }
    public virtual void Die()
    {
        wrappedBot.Die();
    }
}
