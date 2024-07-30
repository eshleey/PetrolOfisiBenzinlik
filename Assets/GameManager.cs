using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pointObject;   
    public GameObject connectObject;

    private bool isPointAttached = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point") && !isPointAttached)
        {
            AttachPointToCube();
        }
        else if (other.gameObject.CompareTag("Connect") && isPointAttached)
        {
            AttachPointToConnect();
        }
    }

    void AttachPointToCube()
    {
      
        pointObject.transform.SetParent(transform);
        isPointAttached = true;
        Debug.Log("Point nesnesi Cube'a ba�land�.");
    }

    void AttachPointToConnect()
    {
       
        pointObject.transform.SetParent(connectObject.transform);
        isPointAttached = false;
        Debug.Log("Point nesnesi Connect'e ba�land�.");
    }
}
