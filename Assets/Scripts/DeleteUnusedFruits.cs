using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteUnusedFruits : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            Destroy(other.gameObject, .5f);
        }
        
    }
}
