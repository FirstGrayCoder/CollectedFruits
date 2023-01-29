using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBasket : MonoBehaviour
{
    [SerializeField] GameObject constraint;
    [SerializeField, HideInInspector] Vector3 startPosConstraint;
    [SerializeField] GameObject basketObject;

    public void Start()
    { 
        startPosConstraint = constraint.transform.position;
    }
    public void OnTriggerExit(UnityEngine.Collider other)
    {
        if (other.CompareTag("TargetFruit"))
        {
            GameManager.instance.SetFruitToBasket(other.gameObject); //Add fruit to List in Basket
            GameManager.instance.FruitInTaskDecrease();
            other.transform.SetParent(basketObject.transform, true);
            other.GetComponent<Rigidbody>().isKinematic = false;
            TakeTargetFruit.isInHand = false;
            
            //other.isTrigger = false;
            constraint.transform.position = startPosConstraint;
        }
    }

}
