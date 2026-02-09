using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private GameObject hasProgressObject; // because unity does not show the intefaces so we added a gameobject

    private IHasProgress hasProgress;
    private void Start()
    {
        hasProgress = hasProgressObject.GetComponent<IHasProgress>();
        if (hasProgress == null)
        {
            Debug.LogError("this game object" + hasProgressObject + "has no component that implement IHasProgress!");
        }


        hasProgress.OnProgressChanged += CuttingCounter_OnProgressChanged;
        barImage.fillAmount = 0f;

        Hide();
    }

    private void CuttingCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;

        if (barImage.fillAmount == 0f || barImage.fillAmount == 1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }


}
