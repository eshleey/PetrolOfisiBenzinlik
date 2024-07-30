using UnityEngine;

public class WaterFillController : MonoBehaviour
{
    public GameObject waterObject; // Su nesnesi
    [Range(0, 1)]
    public float fillAmount = 1.0f; // 0 ile 1 aras�nda bir de�er (1 = tam dolu, 0 = bo�)

    private Vector3 initialScale;
    private Vector3 initialPosition;

    void Start()
    {
        if (waterObject != null)
        {
            initialScale = waterObject.transform.localScale;
            initialPosition = waterObject.transform.localPosition;
        }
    }

    void Update()
    {
        if (waterObject != null)
        {
            // fillAmount'a g�re su nesnesinin y�ksekli�ini ayarla
            waterObject.transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z * fillAmount);

            // fillAmount'a g�re su nesnesinin pozisyonunu ayarla ki su yukar�dan azals�n
            float adjustedY = initialPosition.y - (initialScale.y * (1 - fillAmount) / 2);
            waterObject.transform.localPosition = new Vector3(initialPosition.x, adjustedY, initialPosition.z);
        }
    }
}

