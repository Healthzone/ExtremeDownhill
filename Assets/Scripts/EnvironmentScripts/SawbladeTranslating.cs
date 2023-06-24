using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SawbladeTranslating : MonoBehaviour
{
    private Transform sawbladeTransform;
    [SerializeField] float smooth;

    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;

    [SerializeField] private bool isReverseMoving = false;

    void Start()
    {
        sawbladeTransform = GetComponent<Transform>();
        sawbladeTransform.position = startPoint.position;
    }

    void Update()
    {
        if (!isReverseMoving)
        {
            sawbladeTransform.transform.position = Vector3.Lerp(sawbladeTransform.transform.position, endPoint.position, Time.deltaTime * smooth);
            if ((endPoint.localPosition - sawbladeTransform.transform.localPosition).magnitude < 1f)
                isReverseMoving = true;
        }
        else
        {
            sawbladeTransform.transform.position = Vector3.Lerp(sawbladeTransform.transform.position, startPoint.position, Time.deltaTime * smooth);
            if ((startPoint.localPosition - sawbladeTransform.transform.localPosition).magnitude < 1f)
                isReverseMoving = false;
        }
    }
}
