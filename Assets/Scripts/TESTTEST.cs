using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTTEST : MonoBehaviour
{
    public GameObject firstCube;
    public GameObject secondCube;
    public GameObject fruit;
    // Start is called before the first frame update
    public void ChangeParent()
    {
        fruit.transform.SetParent(secondCube.transform);
        fruit.GetComponent<Rigidbody>().isKinematic = false;
    }
    public void ChangeParent2()
    {
        fruit.transform.SetParent(firstCube.transform);

        fruit.GetComponent<Rigidbody>().isKinematic = true;
    }

}
