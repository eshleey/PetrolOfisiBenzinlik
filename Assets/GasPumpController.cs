using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    public LineRenderer lineRenderer;  // LineRenderer bileþeni
    public Transform startPoint;  // Çizginin baþlangýç noktasý

    void Start()
    {
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 2;  // Çizgi iki noktadan oluþur
            lineRenderer.SetPosition(0, startPoint.position);  // Baþlangýç noktasýný ayarla
            lineRenderer.SetPosition(1, startPoint.position);  // Hedef noktasýný baþlangýç noktasýna ayarla
        }
    }
}
