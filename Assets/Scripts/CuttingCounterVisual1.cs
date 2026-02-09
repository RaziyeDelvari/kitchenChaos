using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual1 : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private CuttingCounter cuttingCounter;

    private const string CUT = "Cut";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        cuttingCounter.OnCut += CuttingCounter_OnCut;
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        animator.SetTrigger(CUT);
    }


}
