using UnityEngine;

public class DragObject : MonoBehaviour
{
    public bool isDragging = false;
    private Camera mainCamera;
    private Vector3 offset;
    public Transform gazPompasi;  // Hortumun ucunu temsil eden Transform
    public Transform hortumUc;
    public LineRenderer lineRenderer;  // Çizgiyi çizen LineRenderer bileþeni
    public GameObject pompaHortumu;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    isDragging = true;
                    offset = transform.position - hit.point;

                    // LineRenderer'ýn baþlangýç noktasýný ayarla
                    if (lineRenderer != null)
                    {
                        lineRenderer.SetPosition(0, hortumUc.position);
                        lineRenderer.positionCount = 2;  // Çizgi iki noktadan oluþur
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            pompaHortumu.SetActive(false);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, transform.position);
            float distance;
            if (plane.Raycast(ray, out distance))
            {
                Vector3 point = ray.GetPoint(distance);
                transform.position = point + offset;
                gazPompasi.position = point;  // Hortumun ucunu güncelle

                // LineRenderer'ýn hedef noktasýný güncelle
                if (lineRenderer != null)
                {
                    lineRenderer.SetPosition(1, hortumUc.transform.position);
                }
            }
        }
    }
}


