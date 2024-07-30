using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    public LineRenderer lineRenderer;  // LineRenderer bile�eni
    public Transform startPoint;  // �izginin ba�lang�� noktas�

    void Start()
    {
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 2;  // �izgi iki noktadan olu�ur
            lineRenderer.SetPosition(0, startPoint.position);  // Ba�lang�� noktas�n� ayarla
            lineRenderer.SetPosition(1, startPoint.position);  // Hedef noktas�n� ba�lang�� noktas�na ayarla
        }
    }
}
