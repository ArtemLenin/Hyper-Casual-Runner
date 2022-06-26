using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private int _rotationAngle = 1;
    private float _y;
    private float _offset;

    [SerializeField] private float _amplitude = 0.1f;
    [SerializeField] private float _frequency = 1f;

    private void Start()
    {
        _y = transform.position.y;
        _offset = Random.Range(0, 1.5f);
    }
    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.y = _y + _amplitude * Mathf.Sin(_frequency * Time.time + _offset) + 0.5f;
        transform.position = position;
        transform.Rotate(Vector3.up * _rotationAngle);
    }
}