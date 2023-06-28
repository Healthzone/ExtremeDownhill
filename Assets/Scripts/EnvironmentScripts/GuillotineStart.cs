using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuillotineStart : MonoBehaviour
{
    [SerializeField] private Transform bladeTransform;

    [SerializeField] private float startDelay;
    private bool isStarted;

    [SerializeField] float smooth;

    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;


    [SerializeField] private bool isReverseMoving = false;

    void Start()
    {
        bladeTransform.position = new Vector3(bladeTransform.position.x, startPoint.position.y, bladeTransform.position.z);
        StartCoroutine(WaitSomeTime());
    }

    private IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(startDelay);
        isStarted = true;
    }

    void Update()
    {
        if (isStarted)
        {
            if (!isReverseMoving)
            {
                bladeTransform.transform.position = Vector3.Lerp(bladeTransform.transform.position, endPoint.position, Time.deltaTime * smooth);
                if ((endPoint.localPosition - bladeTransform.transform.localPosition).magnitude < 1f)
                    isReverseMoving = true;
            }
            else
            {
                bladeTransform.transform.position = Vector3.Lerp(bladeTransform.transform.position, startPoint.position, Time.deltaTime * smooth);
                if ((startPoint.localPosition - bladeTransform.transform.localPosition).magnitude < 1f)
                    isReverseMoving = false;
            }
        }
    }
}
