using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public enum Fruits
    {
        banana,
        apple,
        lemon,
        pear,
        peach

    }
    [Header("Task for Level")]
    public Fruits fruit;
    [SerializeField] int taskFruits;

    [SerializeField] GameObject[] particles;
    
    [SerializeField] GameObject conveyorSwitchOff;
    [SerializeField] GameObject winPanel;
    [SerializeField] bool isStopGame = false;

    public static GameManager instance;

    [SerializeField] int speedForConveyor;
    //[SerializeField] int maxFruits;

    [SerializeField] AnimatorController animController;
    [SerializeField] Animator animPoint;

    

    [Header ("UI")]
    [SerializeField] GameObject playButton;
    [SerializeField] TMP_Text taskText;
    [SerializeField] TMP_Text lifeCount;
    [SerializeField] GameObject textTask;
    [SerializeField] GameObject pointText;
    [SerializeField] GameObject lifeText;
    [SerializeField] int lifes = 4;
    [SerializeField] GameObject losePanel;

    [Header ("List of Fruits ")]
    [SerializeField] List<GameObject> fruitsObjects = new List<GameObject>();
    [SerializeField] GameObject convPartParent;
    [SerializeField] List<GameObject> fruitsInBusket = new List<GameObject>();
    [SerializeField] AudioController audioController;

    public void Awake()
    {

        playButton.SetActive(true);
        Time.timeScale = 0;
        isStopGame = false;
        if (instance == null)
        {
            instance = this;
            return;
        }
        Destroy(gameObject);
        
        
    }
    void Start()
    {
        lifeText.SetActive(false);
        losePanel.SetActive(false);
        textTask.SetActive(true);
        winPanel.SetActive(false);
        conveyorSwitchOff.SetActive(true);
        
        
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        lifeText.SetActive(true);
        lifeCount.text = lifes.ToString();
        playButton.SetActive(false);
        taskText.text = $"Collect {taskFruits} {fruit}";
    }

    public void LifeDecrease()
    {
        animPoint.Play("WrongFruit");
        if (lifes > 0) lifes--;
        lifeCount.text = lifes.ToString();
        if (lifes == 0)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void FruitInDaskDecrease()
    {
        taskFruits--;
        taskText.text = $"Collect {taskFruits} {fruit}";

    }

    public GameObject SpownFruits()
    {
        int randomFruit = Random.Range(0, fruitsObjects.Count);
        return fruitsObjects[randomFruit];
    }

    public int SetSpeedForConveyor()
    {
        //При збільшенні левела, збільшуємо швидкість
        //if {Level == 2 } speedForConveyor = 5 
        return speedForConveyor;
    }

    public void SetFruitToBasket(GameObject fruit)
    {
        
        fruitsInBusket.Add(fruit);
        animPoint.Play("PointAnim");
        if (fruitsInBusket.Count == taskFruits)
        {
            isStopGame = true;
            WinTime();
            Debug.Log("You Win");
        }
    }

    public void DeleteConvPart()
    {
        for (int i = 0; i < convPartParent.transform.childCount; i++)
        {
            Destroy(convPartParent.transform.GetChild(i).gameObject);
        }
        
    }

    public void WinTime()
    {
        DeleteFruitsOutBasket();
        
        animController.DancingOn();
        textTask.SetActive(false);
        conveyorSwitchOff.SetActive(false);
        StartCoroutine(OpenWinPanel());
        StartCoroutine(CameraMove());
        CameraToPlayer();
        DeleteConvPart();
    }
    
    public void CameraToPlayer() 
    {
        StartCoroutine(CameraMove());
    }

    IEnumerator CameraMove()
    {
        var camera = Camera.main;
        for (float i = camera.fieldOfView; i > 45; i--)
        {
            camera.fieldOfView--;
            for (int j = 0; j < 3; j++)
            {
                for (int y = 0; y < particles.Length; y++)
                {
                    particles[y].SetActive(true);
                }
            }
            yield return new WaitForSeconds(.005f);
        }
    }

    IEnumerator OpenWinPanel()
    {
        winPanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
    }

    public bool IsGameStop()
    {
        bool isStop = isStopGame;
        return isStop;
    }

    public void DeleteFruitsOutBasket()
    {
        for (int i = fruitsInBusket.Count; i > 0; i--)
        {
            Destroy(fruitsInBusket[i-1]);
        }
    }

    public void PlayWrongFruit()
    {
        audioController.PlayWrongFruit();
    }
}
