using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using YG;

public class ResetSaveCloud : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGame.GetDataEvent += ResetSaveCloudData;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= ResetSaveCloudData;
    }

    void Start()
    {
        if (YandexGame.SDKEnabled)
            ResetSaveCloudData();

    }

    private void ResetSaveCloudData()
    {
        YandexGame.ResetSaveProgress();
    }


}
