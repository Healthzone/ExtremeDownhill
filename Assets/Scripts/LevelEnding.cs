using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using YG;

public class LevelEnding : MonoBehaviour
{
    public static UnityEvent OnLevelEnd = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("LevelEnded");
            YandexGame.savesData.unlockedLastLevel++;
            YandexGame.SaveProgress();
            OnLevelEnd.Invoke();
        }
    }

}
