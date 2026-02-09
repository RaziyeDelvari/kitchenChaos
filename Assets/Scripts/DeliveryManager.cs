using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler OnRecipeSuccess;
    public event EventHandler OnRecipeFailed;

    public static DeliveryManager instance { get; private set; }

    [SerializeField] private RecipeListSO  recipeListSO;
    private List<RecipeSO> waitingRecipeList;


    private float spwanRecipeTimer;
    private float spwanRecipeTimerMax = 4f;
    private int waitingRecipeMax = 4;
    private int successRecipesAmount;


    private void Awake()
    {
        instance = this;
        waitingRecipeList = new List<RecipeSO>();
    }
    private void Update()
    {
        spwanRecipeTimer -= Time.deltaTime;
        if (spwanRecipeTimer <= 0f)
        {
            spwanRecipeTimer = spwanRecipeTimerMax;

            if (KitchenGameManager.Instance.IsGamePlying() && waitingRecipeList.Count <  waitingRecipeMax)
            {
                RecipeSO recipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
                Debug.Log(recipeSO.recipeName);

                waitingRecipeList.Add(recipeSO);


                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);

            }
        }

    }

    public void DeliveryRecipe(PlateKitchenObj plateKitchenObj)
    {
        for (int i = 0; i < waitingRecipeList.Count; i++)
        {
            RecipeSO waitingRecipeSO = waitingRecipeList[i];

            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObj.GetKitchenObjectSOList().Count)
            {
                // has the same number of ingredients
                bool plateContentMatchesRecipe = true;
                foreach (KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    // Cycling through all ingredients in  the Recipe
                    bool ingredientFound = false;
                    foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObj.GetKitchenObjectSOList())
                    {
                        if (plateKitchenObjectSO == recipeKitchenObjectSO)
                        {
                            // ingredient matches!
                            ingredientFound = true;
                            break;
                        }
                    }
                    if (!ingredientFound)
                    {
                        // this Recipe ingredent was not found on the plate
                        plateContentMatchesRecipe = false;
                    }

                }
                if (plateContentMatchesRecipe)
                {
                    // player deliverd the correct Recipe!

                    successRecipesAmount++;

                    waitingRecipeList.RemoveAt(i);

                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }
        // No matches Found
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);
        //Debug.Log("Player did not deliver a correct recipe!");

    }

    public List<RecipeSO> GetWaitingRecipeSOList()
    {
        return waitingRecipeList;
    }

    public int GetSuccessRecipesAmount()
    {
        return successRecipesAmount;
    }
}
