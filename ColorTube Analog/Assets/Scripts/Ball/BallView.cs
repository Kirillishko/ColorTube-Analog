using UnityEngine;

[RequireComponent(typeof(Ball))]
[RequireComponent(typeof(MeshRenderer))]
public class BallView : MonoBehaviour
{
    private Ball _ball;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        _ball.ColorChanged += SetColor;
    }

    private void OnDisable()
    {
        _ball.ColorChanged -= SetColor;
    }

    public void SetColor(Color color)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();

        _meshRenderer.GetPropertyBlock(mpb);
        mpb.SetColor("_Color", color);
        _meshRenderer.SetPropertyBlock(mpb);
    }
}
