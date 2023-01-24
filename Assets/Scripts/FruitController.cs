
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

    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        basket = GameObject.FindGameObjectWithTag("Basket");
        mainCamera = Camera.main;
    }
    void Start()
    {
        targetFruit = (Fruits)gameManager.GetComponent<GameManager>().fruit;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 500f, maskFruit))
            {
                selectedFruit = hitInfo.collider.gameObject;
                selectedFruit2 = selectedFruit.GetComponent<FruitController>().fruit;
                if (targetFruit == selectedFruit2)
                {
                    selectedFruit.transform.position = Vector3.Lerp(selectedFruit.transform.position, basket.transform.position, Time.deltaTime * speed);
                    selectedFruit.transform.SetParent(basket.transform, false);
                    GameManager.instance.SetFruitToBasket(selectedFruit); //Add fruit to List in Basket
                } 
            }
        }
    }


}
