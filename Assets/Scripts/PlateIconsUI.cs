using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObj plateKitchenObj;
    [SerializeField] private Transform IconTem;

    private void Awake()
    {
        IconTem.gameObject.SetActive(false);
    }

    private void Start()
    {
        plateKitchenObj.OnIngredientAdded += PlateKitchenObj_OnIngredientAdded;
    }

    private void PlateKitchenObj_OnIngredientAdded(object sender, PlateKitchenObj.OnIngredientAddedEventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach(Transform child in transform)
        {
            if (child == IconTem) continue;
            Destroy(child.gameObject);
        }
        foreach(KitchenObjectSO kitchenObjectSO in plateKitchenObj.GetKitchenObjectSOList())
        {
            Transform IconTransform = Instantiate(IconTem, transform);
            IconTransform.gameObject.SetActive(true);
            IconTransform.GetComponent<PlateIconSingleUI>().SetKitchenObjectSO(kitchenObjectSO);
        }
    }
}
