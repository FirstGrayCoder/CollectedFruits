
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class FruitController : MonoBehaviour //IPointerClickHandler
{
    public enum Fruits
    {
        banana,
        apple,
        lemon,
        pear,
        peach

    }

    [SerializeField] Fruits targetFruit;
    [SerializeField] Fruits fruit;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject linkToFruit;
    [SerializeField] GameObject basket;
    [SerializeField] int speed = 5;

    [Header("For touches")]
    [SerializeField] GameObject selectedFruit;
    [SerializeField] Fruits selectedFruit2;
    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask maskFruit;
    [SerializeField] public static bool isTargetFruit =  false;

    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        basket = GameObject.FindGameObjectWithTag("Basket");
        mainCamera = Camera.main;
    }
    void Start()
    {
        //rb.isKinematic = true;
        targetFruit = (Fruits)gameManager.GetComponent<GameManager>().fruit;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 50f, maskFruit))
            {
                if(hitInfo.collider.CompareTag("Fruit"))
                {
                    selectedFruit = hitInfo.collider.gameObject;
                    selectedFruit2 = selectedFruit.GetComponent<FruitController>().fruit;
                    if (targetFruit == selectedFruit2)
                    {
                        selectedFruit.tag = "TargetFruit";
                        isTargetFruit = true;
                    }
                    else 
                    {
                        Handheld.Vibrate();
                        GameManager.instance.PlayWrongFruit();
                        GameManager.instance.LifeDecrease();
                        //Debug.Log("UPS");
                    }
                }
                
            }
        }
    }


}
