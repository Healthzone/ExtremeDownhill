using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeRotating : MonoBehaviour
{
    private Transform sawbladeTransform;
    [SerializeField] private float sawbladeRotatingSpeed;

    private void Start()
    {
        sawbladeTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        sawbladeTransform.Rotate(0f, 0f, sawbladeRotatingSpeed * Time.deltaTime);
    }
}
