using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pointObject;   
    public GameObject connectObject;

    private bool isPointAttached = false;
    private GameObject attachedTo;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == pointObject && !isPointAttached)
        {
           
            AttachPointToCube();
        }
        else if (other.gameObject == connectObject && isPointAttached)
        {
          
            AttachPointToConnect();
        }
    }

    void AttachPointToCube()
    {
      
        pointObject.transform.SetParent(transform);
        isPointAttached = true;
        attachedTo = gameObject;
        Debug.Log("Point nesnesi Cube'a baðlandý.");
    }

    void AttachPointToConnect()
    {
       
        pointObject.transform.SetParent(connectObject.transform);
        isPointAttached = false;
        Debug.Log("Point nesnesi Connect'e baðlandý.");
    }
}
