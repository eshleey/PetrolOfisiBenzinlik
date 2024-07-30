using UnityEngine;

public class DragObject : MonoBehaviour
{
    public Transform gazPompasi;  // Hortumun ucunu temsil eden Transform
    public Transform hortumUc;
    public LineRenderer lineRenderer;  // Çizgiyi çizen LineRenderer bileþeni
    public GameObject pompaHortumu;

    void Update()
    {
        lineRenderer.SetPosition(1, hortumUc.transform.position);
    }
}


