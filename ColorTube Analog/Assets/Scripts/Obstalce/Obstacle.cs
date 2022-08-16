using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObstacleView))]
public class Obstacle : MonoBehaviour
{
	private Color _currentColor;
    private Color _nextBallColor;

    private ObstacleView _view;

	private void Awake()
	{
		_view = GetComponent<ObstacleView>();
	}

    public void Init(Color currentColor, Color nextBallColor)
    {
        _currentColor = currentColor;
        _nextBallColor = nextBallColor;
    }
}

