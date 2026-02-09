using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;




    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no kitchen object here
            if (player.HasKitchenObject())
            {
                // Player is carry8ing something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Player not carrying something
            }
        }
        else
        {
            // There is a kitchen object here
            if (player.HasKitchenObject())
            {
                // Player carrying something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObj plateKitchenObj))
                {
                    // player is holding a plate


                    if (plateKitchenObj.TryAddIngrediente(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();

                    } // we are adding the ingredient to the plate



                }
                else {
                    // player i snot carrying a plate but something else
                    if (GetKitchenObject().TryGetPlate(out PlateKitchenObj platekitchenObj)) //here we are checking the counter
                    {
                        //counter is holding a plate
                        if (platekitchenObj.TryAddIngrediente(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf() ;
                        }
                    }
                }
            }
            else
            {
                // Player not carrying something
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }


    }




}
