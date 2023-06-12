using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelectionCar : MonoBehaviour
{
    private Transform windtubeTransform;
    [SerializeField] private float carRotatingSpeed;

    private void Start()
    {
        windtubeTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        windtubeTransform.Rotate(0f, carRotatingSpeed * Time.deltaTime, 0f);
    }
}
