using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpown : MonoBehaviour
{
    [SerializeField] Transform spownPosition;
    [SerializeField] static GameObject fruit;

    void Start()
    {
        GameObject fruitPrefab = GameManager.instance.SpownFruits();
        GameObject conveyorPart = Instantiate(fruitPrefab, spownPosition.position, Quaternion.identity, this.transform);

        fruit = conveyorPart; //for understanding whitch child need to remove
    }
}
