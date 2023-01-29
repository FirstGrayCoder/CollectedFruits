using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFruitInBasket : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("TargetFruit"))
        {
            
            //other.isTrigger = false;

            Debug.Log("YEPP we here");
        }
    }

    public void OnTriggerExit(UnityEngine.Collider other)
    {
        if (other.CompareTag("TargetFruit"))
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Debug.Log("YEPP we in other here");
            //gameObject.GetComponent<Collider>().isTrigger = false;
            other.isTrigger = false;
        }
        
    }
}
