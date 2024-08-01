using UnityEngine;

public class Point : MonoBehaviour
{
    public Transform pumpTransform;
    public Transform playerTransform;
    public Tanker tanker;
    bool isVisited = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isVisited)
            {
                pumpTransform.transform.SetParent(playerTransform);
                pumpTransform.localPosition = Vector3.zero;
                isVisited = true;
            }
            else
            {
                pumpTransform.transform.SetParent(transform);
                pumpTransform.localPosition = Vector3.zero;
                isVisited = false;
            }
        }
    }

    private void Update()
    {
        if (tanker.fillAmount >= 0)
        {
            if (tanker.gasFilling)
            {
                gameObject.GetComponent<Collider>().isTrigger = false;
            }
            else
            {
                gameObject.GetComponent<Collider>().isTrigger = true;
            }
        }
        else if (tanker.fillAmount == 1)
        {
            gameObject.GetComponent<Collider>().isTrigger = false;
        }
    }
}

