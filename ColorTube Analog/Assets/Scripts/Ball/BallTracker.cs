using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private BallMover _ball;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _offset;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, GetTargetPosition(), _speed * Time.fixedDeltaTime);
    }

    private Vector3 GetTargetPosition()
    {
        return new Vector3(_ball.transform.position.x + _offset.x, _ball.transform.position.y + _offset.y, _ball.transform.position.z + _offset.z);
    }
}
