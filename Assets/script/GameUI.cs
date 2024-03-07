using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    public Image levelSlider;
    public Image curentLevelImg;
    public Image nextLevelImg;

    public TextMeshProUGUI Indicator1;
    public TextMeshProUGUI Indicator2;

    public Material playerMat;

    public GameObject settingBTN;
    public GameObject allBTN;
    public GameObject soundONBTN;
    public GameObject soundOFFBTN;


    private Player_Kontrol player;
    //level2 burada barınyor 
    private int level2;

    [SerializeField] private GameObject homeUI;
    [SerializeField] private GameObject gameUI;


    public bool buttonSetttingBool;

    public void Awake()
    {   
        //Indicator1.text = FindObjectOfType<LevelSpawner>().level.ToString();
        //Indicator2.text = FindObjectOfType<LevelSpawner>().level2.ToString();
    }
    void Start()
    {
        player = FindAnyObjectByType<Player_Kontrol>();

        playerMat = FindAnyObjectByType<Player_Kontrol>().transform.GetChild(0).GetComponent<MeshRenderer>().material;

        levelSlider.transform.parent.GetComponent<Image>().color = playerMat.color + Color.gray;
        curentLevelImg.color = playerMat.color;
        nextLevelImg.color = playerMat.color;

        soundONBTN.GetComponent<Button>().onClick.AddListener((() => SoundManager.instance.ONOF()));
        soundOFFBTN.GetComponent<Button>().onClick.AddListener((() => SoundManager.instance.ONOF()));
    }

   
    void Update()
    {
       

        if (Input.GetMouseButtonDown(0) && !IgnoreUI() && player.playerState == Player_Kontrol.PlayerState.Prepare)
        {
            player.playerState = Player_Kontrol.PlayerState.Playing;
            homeUI.SetActive(false);
            gameUI.SetActive(true);
        }

        if(SoundManager.instance.sound)
        {
            soundONBTN.SetActive(true);
            soundOFFBTN.SetActive(false);
        }
        else
        {
            soundONBTN.SetActive(false);
            soundOFFBTN.SetActive(true);
        }
    }

    public bool IgnoreUI()
    {  
        PointerEventData pointerEventData=new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData,raycastResults);

        for (int i=0; i < raycastResults.Count; i++)
        {
            if (raycastResults[i].gameObject.GetComponent<ignoreGameUI>() != null)
            {
                raycastResults.RemoveAt(i);
                i--;
            }
        }
        return raycastResults.Count > 0;
    }
    public void LevelSliderFiil(float fillAmount)
    {
       levelSlider.fillAmount = fillAmount;
    }

    public void settingShow()
    {
        buttonSetttingBool = !buttonSetttingBool;
        allBTN.SetActive(buttonSetttingBool);
        
    }
    public void Indicator()
    {
       Indicator1.text = FindObjectOfType<LevelSpawner>().level.ToString();
       Indicator2.text = FindObjectOfType<LevelSpawner>().level2.ToString();
    }
}
