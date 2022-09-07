using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObstacleView))]
public class Obstacle : MonoBehaviour
{
	[SerializeField] private Color _currentColor;
    [SerializeField] private Color _nextBallColor;

    private ObstacleView _view;

	private void Awake()
	{
		_view = GetComponent<ObstacleView>();
	}

    public void Init(Color currentColor, Color nextBallColor)
    {
        _currentColor = currentColor;
        _nextBallColor = nextBallColor;
        _view.SetColor(_currentColor);
    }

    public bool TryGetNextBallColor(ref Color ballColor)
    {
        bool colorsMatch = _currentColor == ballColor;

        if (colorsMatch) ballColor = _nextBallColor;
        return colorsMatch;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

