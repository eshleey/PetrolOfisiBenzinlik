using UnityEngine;

public class Pump : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform hoseTip;

    private void Start()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, hoseTip.position);
    }

    private void Update()
    {
        lineRenderer.SetPosition(1, hoseTip.position);
    }
}
