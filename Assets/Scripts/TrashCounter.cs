using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{

    public static event EventHandler OnObjectTrashed; // we have just one trash bin but made it static


    new public static void ResetStaticData()
    {
        OnObjectTrashed = null; //this will clear all the listeners
    }
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
            OnObjectTrashed?.Invoke(this, EventArgs.Empty);
        }
    }
}
