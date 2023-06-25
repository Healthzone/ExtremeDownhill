using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPauseUIButtons : MonoBehaviour
{
    [SerializeField] private GameObject mobileUIButtonsGO;
    [SerializeField] private GameObject pcUIButtonsGO;
    void Start()
    {
        if(Application.isMobilePlatform)
        {
            pcUIButtonsGO.SetActive(false);
            mobileUIButtonsGO.SetActive(true);
        }
        else
        {
            pcUIButtonsGO.SetActive(true);
            mobileUIButtonsGO.SetActive(false);

        }
    }

   
}
