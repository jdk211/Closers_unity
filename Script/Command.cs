using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command{
    public virtual void Execute(Actor actor) { }
}

public class CommandAttack : Command
{
    public override void Execute(Actor actor)
    {
        actor.Attack();
    }
}

public class CommandSkill1 : Command
{
    public override void Execute(Actor actor)
    {
        actor.Skill1();
    }
}