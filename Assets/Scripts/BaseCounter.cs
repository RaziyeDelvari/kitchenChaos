using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{


    public static event EventHandler OnAnyObjectPlacedHere; //we make the event ststic so every copy uses that

    [SerializeField] private Transform counterTop;

    private KitchenObject kitchenObject;

    public static void ResetStaticData()
    {
        OnAnyObjectPlacedHere = null; //this will clear all the listeners
    }



    // virtual keyword allows the children to inherit thr method
    public virtual void Interact(Player player)
    {
        Debug.Log("BaseCounter.Interact()!");
    }
    public virtual void InteractAlternate(Player player)
    {
       // Debug.Log("BaseCounter.InteractAlternate()!");
    }



    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTop;
    }

    

     public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        if (kitchenObject != null)
        {
            OnAnyObjectPlacedHere?.Invoke(this, EventArgs.Empty);
        }
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
