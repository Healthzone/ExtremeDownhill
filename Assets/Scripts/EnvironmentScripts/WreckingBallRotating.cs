using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallRotating : MonoBehaviour
{
    private Transform wreckingBallTransform;
    [SerializeField] private float wreckingBallRotatingSpeed;

    private void Start()
    {
        wreckingBallTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        wreckingBallTransform.Rotate(0f, 0f, wreckingBallRotatingSpeed * Time.deltaTime);
    }
}
