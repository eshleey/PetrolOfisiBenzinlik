using UnityEngine;

public class Point : MonoBehaviour
{
    public Transform pumpObject;
    public Transform playerObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pumpObject.transform.SetParent(playerObject);
            gameObject.GetComponent<Collider>().isTrigger = false;
        }
    }
}

