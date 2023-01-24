using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    [SerializeField] FruitsSpown fruit;
    [SerializeField] GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        fruit = GetComponent<FruitsSpown>();
    }
}
