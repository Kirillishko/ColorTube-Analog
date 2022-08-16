using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleView : MonoBehaviour
{
    public void SetColor(Color color)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.GetPropertyBlock(mpb);
        mpb.SetColor("_Color", color);
        meshRenderer.SetPropertyBlock(mpb);
    }
}
