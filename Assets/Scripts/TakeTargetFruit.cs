using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;



public class TakeTargetFruit : MonoBehaviour
{
    [SerializeField] GameObject basket;
    [SerializeField] GameObject constraint;
    [SerializeField] float speed = 2f;
    [SerializeField] Transform constrStartPos;
    [SerializeField] GameObject boneParent;
    public static bool isInBasket = false;

    void Start()
    {
        constrStartPos = constraint.transform;
    }

    void FixedUpdate()
    {
        if(isInBasket)
        {
            constraint.transform.position = Vector3.Lerp(constraint.transform.position, basket.transform.position, Time.deltaTime * speed);
            
        }
    }

    public void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("TargetFruit"))
        {
            constraint.transform.position = other.transform.position;
            other.transform.SetParent(constraint.transform, true);
            isInBasket = true;
            
        }
    }
}
