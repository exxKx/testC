using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Colliadable
{

    protected bool collected;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "player")
            OnColllect();
    }

    protected virtual void OnColllect()
    {
        collected = true;
    }


}
