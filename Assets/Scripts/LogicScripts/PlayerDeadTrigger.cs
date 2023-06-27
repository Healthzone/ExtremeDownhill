using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using YG;

public class PlayerDeadTrigger : MonoBehaviour
{
    public static UnityEvent OnPlayerDead = new UnityEvent();
    private static bool isPlayerDead = false;


    public static bool IsPlayerDead { get => isPlayerDead; }

#if UNITY_EDITOR
    private Vector3 gizmoSize;
    private Vector3 gizmoCenter;
#endif

    private void Start()
    {
        isPlayerDead = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isPlayerDead)
        {
            Debug.Log("Player dead");
            isPlayerDead = true;

            OnPlayerDead.Invoke();
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        gizmoSize = GetComponent<BoxCollider>().size;
        gizmoCenter = GetComponent<BoxCollider>().center;
        Gizmos.color = Color.green;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawCube(gizmoCenter, gizmoSize);
    }

#endif




}
