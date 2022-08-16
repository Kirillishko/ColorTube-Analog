using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTests : MonoBehaviour
{
    public bool isRad;
    public GameObject Sphere;
    public float Degree;

    public Vector3 sinV;
    public Vector3 cosV;

    private void OnValidate()
    {
        float angleRad = Degree;

        if (isRad)
        {
            angleRad *= Mathf.Deg2Rad;
        }

        float sin = Mathf.Sin(angleRad);
        float cos = Mathf.Cos(angleRad);

        sinV = new Vector3(0, (float)sin, 0);
        cosV = new Vector3(0, (float)cos, 0);
    }

    private void Update()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(sinV, 0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(cosV, 0.5f);
    }
}
