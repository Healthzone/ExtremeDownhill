using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using YG;

public class LevelEnding : MonoBehaviour
{
    public static UnityEvent OnLevelEnd = new UnityEvent();
    private bool isLevelEnded = false;

    private Transform plumbBobTransform;
    [SerializeField] private float plumbBobRotatingSpeed = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isLevelEnded)
        {
            Debug.Log("LevelEnded");
            isLevelEnded = true;

            if (Convert.ToInt32(SceneManager.GetActiveScene().name) == YandexGame.savesData.unlockedLastLevel)
            {
                YandexGame.savesData.unlockedLastLevel++;
                YandexGame.SaveProgress();
                Debug.Log($"Level {YandexGame.savesData.unlockedLastLevel} unlocked");
            }
            OnLevelEnd.Invoke();
        }
    }



    private void Start()
    {
        plumbBobTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        plumbBobTransform.Rotate(0f, 0f, plumbBobRotatingSpeed * Time.deltaTime);
    }
}
