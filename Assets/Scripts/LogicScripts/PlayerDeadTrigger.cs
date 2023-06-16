using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using YG;

public class PlayerDeadTrigger : MonoBehaviour
{
    public static UnityEvent OnPlayerDead = new UnityEvent();
    private bool isPlayerDead = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isPlayerDead)
        {
            Debug.Log("Player dead");
            isPlayerDead = true;

            OnPlayerDead.Invoke();
        }
    }


}
