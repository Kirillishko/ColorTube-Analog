using UnityEngine;
using System;

[RequireComponent(typeof(BallInput))]
public class Ball : MonoBehaviour
{
    [SerializeField] private BallRotator _ballRotator;
    [SerializeField] private BallMover _ballMover;
    [SerializeField] private Color _color;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;

    private BallInput _input;

    public Action<Color> ColorChanged;
    public Action BallDestroyed;

    private void Start()
    {
        ColorChanged?.Invoke(_color);
        _input = GetComponent<BallInput>();
    }

    private void FixedUpdate()
    {
        _ballMover.Move(_ballMover.transform.position + _ballMover.transform.forward * _moveSpeed);
        _ballRotator.Rotate(_input.TryGetNextDirection() * _rotateSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            if (obstacle.TryGetNextBallColor(ref _color))
            {
                ColorChanged?.Invoke(_color);
                obstacle.Destroy();
            }
            else
            {
                BallDestroyed?.Invoke();
                Destroy(gameObject);
            }
        }
    }

    public void SetColor(Color color)
    {
        _color = color;
        ColorChanged?.Invoke(_color);
    }

}
