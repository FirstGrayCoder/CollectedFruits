using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorPartMoving : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] int speed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        int speed = GameManager.instance.SetSpeedForConveyor();
        rb.AddForce(speed * Time.deltaTime * -transform.forward);
    }

}
