    using System.Collections;
    using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
    using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player_Kontrol : MonoBehaviour
    {
        public Rigidbody rb;
        bool carpma = false;
        public int zıpla = 0;

        public GameObject FireShield;
        [SerializeField] LevelSpawner levelSpawner;
        [SerializeField] GameUI gameUI;
        float currenTime;
        bool incincible;

    [SerializeField]
    AudioClip win,  destory, inDestroy, dead, jump;

    public int currentObstacleNumber;
    public int totalObstacleNumber;

    private int temasDegisken;

    public Image incincibleslider;
    public GameObject incincibleOBJ;

        public enum PlayerState
        {
            Prepare,
            Playing,
            Died,
            Finish

        }
        [HideInInspector]
        public PlayerState playerState = PlayerState.Prepare;

        void Start()
        {

        totalObstacleNumber = FindObjectsOfType<ObstackleConroler>().Length;

    }
    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentObstacleNumber = 0;
    }
    void Update()
        { if (playerState == PlayerState.Playing)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    carpma = true;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    carpma = false;
                }
                if (incincible)
                {
                    currenTime -= Time.deltaTime * .35f;
                    if (!FireShield.activeInHierarchy)
                    {
                        FireShield.SetActive(true);
                    }
                }
                else
                {
                    if (FireShield.activeInHierarchy)
                    {
                        FireShield.SetActive(false);
                    }
                    if (carpma)
                    {
                        currenTime += Time.deltaTime * 0.8f;
                    }
                    else
                    {
                        currenTime -= Time.deltaTime * 0.5f;
                    }
                    if (currenTime >= 1)
                    {
                        incincible = true;
                        currenTime = 1;
                    }
                    else if (currenTime <= 0)
                    {
                        incincible = false;
                    }
                    if (carpma)
                    {
                        currenTime += Time.deltaTime * 0.8f;
                    }
                    else
                    {
                        currenTime -= Time.deltaTime * 0.5f;
                    }
                }

                if (currenTime >= 0.15f || incincibleslider.color == Color.red)
            {
                incincibleOBJ.SetActive(true);
            }
                else
            {
                incincibleOBJ.SetActive(false); 
            }




                if (currenTime >= 1)
                {
                    incincible = true;
                    currenTime = 1;
                    incincibleslider.color = Color.red;
                }
                else if (currenTime <= 0)
                {
                    incincible = false;
                    currenTime = 0;
                    incincibleslider.color = Color.white;
                }

           if (  incincibleOBJ.activeInHierarchy )
            {
                incincibleslider.fillAmount = currenTime / 1;
            }

            }

            /*if (playerState == PlayerState.Prepare)
            {
                if (Input.GetMouseButton(0))
                    playerState = PlayerState.Playing;

            }*/

            if (playerState == PlayerState.Finish)
            {
            if (Input.GetMouseButton(0))
            {
                levelSpawner.LevelPlus();
                levelSpawner.Nextlevel();
            }
            }

        }
        // ShatterAllObstacles

        public void shatterObstacles()
        {
            if (incincible)
            {
            ScorManager.instance.AddScore(1);
            }
            else
            {
            ScorManager.instance.AddScore(2);
            }
        }

        void FixedUpdate()
        {
            if (playerState == PlayerState.Playing)
                if (carpma == true)
                    rb.velocity = new Vector3(0, -100 * Time.fixedDeltaTime * 7, 0);

        }
    private void OnCollisionEnter(Collision collision)
        {
        temasDegisken++;
            if (!carpma)
            {
                rb.velocity = new Vector3(0, 50 * Time.deltaTime * zıpla, 0);
            }
            else
            {
                if (incincible)
                {
                    if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "plane")
                    {
                        collision.transform.parent.GetComponent<ObstackleConroler>().ShatterAllObstacle();
                        shatterObstacles();
                        SoundManager.instance.PlaySoundFx(inDestroy , 0.5f);
                    currentObstacleNumber++;
                }
                }
            else
            {
                if (collision.gameObject.tag == "enemy")
                {
                    collision.transform.parent.GetComponent<ObstackleConroler>().ShatterAllObstacle();
                    shatterObstacles();
                    currentObstacleNumber++;
                }
                else if (collision.gameObject.tag == "plane")

                {
                    ScorManager.instance.RessetScore();
                    SoundManager.instance.PlaySoundFx(dead, 0.5f);
                }
            }

            FindObjectOfType<GameUI>().LevelSliderFiil(currentObstacleNumber / (float)totalObstacleNumber);
             
            if (collision.gameObject.tag == "Finish" && playerState == PlayerState.Playing)
                {
                    playerState = PlayerState.Finish;
                    SoundManager.instance.PlaySoundFx(win, 0.5f);
            }
             }
      
        }

    

    private void OnCollisionStay(Collision collision)
        {

         GameUI gameUI  = collision.gameObject.GetComponent<GameUI>();

        if (!carpma || collision.gameObject.tag == "Finish")
            {

            rb.velocity = new Vector3(0, 50 * Time.deltaTime * zıpla, 0);
            SoundManager.instance.PlaySoundFx(jump, 0.5f);
        }
       }
    }

