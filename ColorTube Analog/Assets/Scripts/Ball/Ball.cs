using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallInput))]
public class Ball : MonoBehaviour
{
    [SerializeField] private BallRotator _ballRotator;
    [SerializeField] private BallMover _ballMover;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;

    private BallInput _input;

    private void Start()
    {
        _input = GetComponent<BallInput>();
    }

    private void FixedUpdate()
    {
        _ballMover.Move(_ballMover.transform.position + _ballMover.transform.forward * _moveSpeed);
        _ballRotator.Rotate(_input.TryGetNextDirection() * _rotateSpeed * Time.fixedDeltaTime);
    }
}
