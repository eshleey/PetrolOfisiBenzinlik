using UnityEngine;

public class Connect : MonoBehaviour
{
    public Transform pumpTransform;
    public Transform pointTransform;
    public Tanker tanker;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pump"))
        {
            other.transform.SetParent(transform);
            other.transform.localPosition = Vector3.zero;
            tanker.GasStartFilling();
        }
    }

    private void Update()
    {
        if (tanker.fillAmount == 0)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
        else if (tanker.fillAmount == 1)
        {
            tanker.GasStopFilling();
            pumpTransform.SetParent(pointTransform);
            pumpTransform.localPosition = Vector3.zero;
            gameObject.GetComponent<Collider>().isTrigger = false;
        }
        else
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }
}
