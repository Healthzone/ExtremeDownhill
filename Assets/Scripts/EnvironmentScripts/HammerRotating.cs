using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerRotating : MonoBehaviour
{
    private Transform hammerTransform;
    [SerializeField] private float hammerRotatingSpeed;

    private void Start()
    {
        hammerTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        hammerTransform.Rotate(hammerRotatingSpeed * Time.deltaTime, 0f, 0f);
    }
}
