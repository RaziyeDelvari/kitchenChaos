using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ContainerCounter : BaseCounter{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public event EventHandler OnPlayerGrabbedObject;



    public override void Interact(Player player)
    {
        // with this logic we just have one tomato, cheese, etc. on a counter not infinite number of them. we just spawn it when kitchen object is null
        if (!player.HasKitchenObject())
        {

            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
 ;

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        
                
        }

    }



}
