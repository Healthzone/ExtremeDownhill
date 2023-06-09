using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindtubeRotating : MonoBehaviour
{
    private Transform windtubeTransform;
    [SerializeField] private float windtubeRotatingSpeed;

    private void Start()
    {
        windtubeTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        windtubeTransform.Rotate(0f, 0f, windtubeRotatingSpeed * Time.deltaTime);
    }
}
