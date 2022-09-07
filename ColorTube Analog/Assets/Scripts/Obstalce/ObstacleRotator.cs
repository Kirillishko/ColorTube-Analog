using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private Vector2 _speedRotateRange;

    private float _speedRotate;
    private float _direction;

    private void Start()
    {
        _speedRotate = Random.Range(_speedRotateRange.x, _speedRotateRange.y);
        _direction = Random.Range(0, 2) * 2 - 1;
    }

    private void FixedUpdate()
    {
        Rotate(_speedRotate, _direction);
    }

    private void Rotate(float speed, float direction)
    {
        Quaternion rotation = Quaternion.AngleAxis(direction * speed, Vector3.forward);
        transform.rotation *= rotation;
    }
}
