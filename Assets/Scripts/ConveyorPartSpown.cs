using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorPartSpown : MonoBehaviour
{
    [SerializeField] Transform spownPosition;
    [SerializeField] Transform conveyorPartParent;

    [SerializeField] GameObject conveyorPartPrefab;

    void Start()
    {
        StartCoroutine(SpownConveyorPart());
    }

    public IEnumerator SpownConveyorPart()
    {
        yield return new WaitForSeconds(.5f);
        GameObject conveyorPart = Instantiate(conveyorPartPrefab, spownPosition.position, Quaternion.identity, conveyorPartParent);
    }

    public void OnTriggerExit(Collider other)
    {
        //call spown method
        bool isStop = GameManager.instance.IsGameStop();
        if (other.isTrigger && !isStop)
        {
            StartCoroutine(SpownConveyorPart());
        }
    }
}
