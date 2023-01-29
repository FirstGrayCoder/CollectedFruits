using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteUnusedFruits : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            Destroy(other.transform.parent.gameObject, .5f);
        }
        
    }
}
