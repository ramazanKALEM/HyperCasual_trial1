using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class LevelSpawner : MonoBehaviour
{
    public Transform Spawnkonum;
    public GameObject[] obstacleModel;
    [HideInInspector]
    GameObject[] obstaclePrefab = new GameObject[5];

    public GameObject winPrafab;
    private GameObject temobstacle, temobstacle2;

    public TextMeshProUGUI Indicator1;
    public TextMeshProUGUI Indicator2;

    float obstacleNumber;
    private int addNumber ;
    public int level ; 
    public int level2 ;





    private void Awake()
    {   
        addNumber = PlayerPrefs.GetInt("AddScore");
        level =  PlayerPrefs.GetInt("Level");
        level2 = PlayerPrefs.GetInt("Level2");
        RandomObstacleGenerator();
        for (obstacleNumber = 0; obstacleNumber >=  -level- addNumber; obstacleNumber -= 0.5f)
        {
            if (level <= 20)
            {
                temobstacle = Instantiate(obstaclePrefab[UnityEngine.Random.Range(0, 2)]);
                temobstacle.transform.eulerAngles = new Vector3(0, obstacleNumber * 8, 0);
                temobstacle.transform.eulerAngles += Vector3.up * 100;
                temobstacle.transform.parent = transform;      
            }
            else if (level < 20 && level <= 40)
            {
                temobstacle = Instantiate(obstaclePrefab[UnityEngine.Random.Range(2, 4)]);
                temobstacle.transform.parent = transform;
            }
            else if (level > 40 && level < 60)
            {
                temobstacle = Instantiate(obstaclePrefab[UnityEngine.Random.Range(2, 4)]);
                temobstacle.transform.parent = transform;
            }
            else if (75 >= level && level < 100)
            {
                temobstacle = Instantiate(obstaclePrefab[UnityEngine.Random.Range(3, 5)]);
                temobstacle.transform.parent = transform;
            }


            temobstacle.transform.position = new Vector3(Spawnkonum.position.x, obstacleNumber - 0.1f, Spawnkonum.position.z);
            temobstacle.transform.eulerAngles = new Vector3(0, obstacleNumber * 8, 0);
            if (obstacleNumber >= level * 0.3f && obstacleNumber <= level * 0.6f)
            {
                temobstacle.transform.eulerAngles = new Vector3(0, obstacleNumber * 8, 0);
                temobstacle.transform.eulerAngles += Vector3.up * 100;
            }
        }



        temobstacle2 = Instantiate(winPrafab);
        temobstacle2.transform.position = new Vector3(Spawnkonum.position.x, obstacleNumber - 0.5f, Spawnkonum.position.z);
        temobstacle2.transform.parent = transform;

        Indicator1.text = level.ToString();
        Indicator2.text = level2.ToString();
    }
    public void RandomObstacleGenerator()
    {
        int random = UnityEngine.Random.Range(0, 4);

        switch (random)
        {
            case 0:
                for (int i = 0; i < 5; i++) 
                {
                    obstaclePrefab[i] = obstacleModel[i];
                }

                break;
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    obstaclePrefab[i] = obstacleModel[i + 5];
                }
                break;
            case 2:
                for (int i = 0; i < 5; i++)
                {
                    obstaclePrefab[i] = obstacleModel[i + 10];
                }
                break;
            case 3:
                for (int i = 0; i < 5; i++)
                {
                    obstaclePrefab[i] = obstacleModel[i + 15];
                }
                break;
            //case 4:
            //    for (int i = 0; i < 5; i++)
            //    {
            //        obstaclePrefab[i] = obstacleModel[i + 20];
            //    }
            //    break;
            default:
                break;
        }

    }

    public void Nextlevel()
    {
        SceneManager.LoadScene(0); 
    }



    //Burası halledilecek
    public void LevelPlus()
    {
        PlayerPrefs.SetInt("AddScore", (addNumber + 1));
        level++;
        PlayerPrefs.SetInt("Level", level );
        PlayerPrefs.SetInt("Level2", (level2=  level  + 1));
        PlayerPrefs.Save();  
        //PlayerPrefs.DeleteAll();
    }
   


}