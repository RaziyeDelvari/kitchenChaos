using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlateCounter : BaseCounter 
{


    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;

    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int spawnPlateCount;
    private int spawnPlateCountMax = 4;

    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;
            if (KitchenGameManager.Instance.IsGamePlying() && spawnPlateCount < spawnPlateCountMax)
            {
                spawnPlateCount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
        
    }

    public override void Interact(Player player)
    {
        if(!player.HasKitchenObject())
        {
            // player is empty handed
            if (spawnPlateCount > 0)
            { //there is at least one plate
                spawnPlateCount--;

                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }

}
