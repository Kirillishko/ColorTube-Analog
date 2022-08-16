using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotator : MonoBehaviour
{
    public void Rotate(float direction)
    {
        Quaternion rotation = Quaternion.AngleAxis(direction, Vector3.forward);
        transform.rotation *= rotation;
    }
}
