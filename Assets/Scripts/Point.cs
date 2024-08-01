using UnityEngine;

public class Point : MonoBehaviour
{
    public Transform pumpObject;
    public Transform playerObject;
    public Tanker _tanker;




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pumpObject.transform.SetParent(playerObject);
            pumpObject.localPosition = Vector3.zero;

            gameObject.GetComponent<Collider>().isTrigger = false;
        }

    }



}

