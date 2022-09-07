using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private List<ObstacleRotator> _obstacleTemplates;
    [SerializeField] private List<Color> _colors;
    [SerializeField] private int _obstacleCount;
    [SerializeField] private int _distanceBetweenObstacles;

    private void Start()
    {
        Color prevBallColor = _colors[Random.Range(0, _colors.Count)];

        Move(_distanceBetweenObstacles * _obstacleCount);

        for (int i = 0; i < _obstacleCount; i++)
        {
            prevBallColor = Spawn(GetRandomObstacle(_obstacleTemplates), transform.position, prevBallColor);
            Move(-_distanceBetweenObstacles);
        }

        _ball.SetColor(prevBallColor);

        //Destroy(gameObject);
    }

    private Color Spawn(ObstacleRotator obstacleRotator, Vector3 spawnPos, Color prevBallColor)
    {
        Quaternion rotation = obstacleRotator.transform.rotation;
        rotation.z = Random.rotation.z;

        var element = Instantiate(obstacleRotator, spawnPos, rotation);
        Obstacle[] obstacles = element.GetComponentsInChildren<Obstacle>();

        List<Color> allColors = new List<Color>();
        allColors.AddRange(_colors);

        List<Color> newBallColorSelection = new List<Color>();

        for (int i = 0; i < obstacles.Length; i++)
        {
            Color obstacleColor = allColors[Random.Range(0, allColors.Count)];
            obstacles[i].Init(obstacleColor, prevBallColor);

            allColors.Remove(obstacleColor);
            newBallColorSelection.Add(obstacleColor);
        }

        Color nextBallColor = newBallColorSelection[Random.Range(0, newBallColorSelection.Count)];
        return nextBallColor;
    }

    private void Move(int distanceZ)
    {
        Vector3 nextPos = transform.position;
        nextPos.z += distanceZ;
        transform.position = nextPos;
    }

    private ObstacleRotator GetRandomObstacle(List<ObstacleRotator> obstacleTemplates)
    {
        return obstacleTemplates[Random.Range(0, obstacleTemplates.Count)];
    }

    private void SetColors(ObstacleRotator obstacleRotator)
    {

    }

}
