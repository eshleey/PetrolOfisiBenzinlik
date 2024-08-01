using UnityEngine;

public class Connect : MonoBehaviour
{
    public Transform pumpObject;
    public Transform pointObject;
    public Tanker tanker;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pumpObject.SetParent(transform);
            pumpObject.localPosition = Vector3.zero;
            gameObject.GetComponent<Collider>().isTrigger = false;
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
            pumpObject.SetParent(pointObject);
            pumpObject.localPosition = Vector3.zero;

           
        }
    }


}
