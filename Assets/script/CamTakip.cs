using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTakip : MonoBehaviour
{
    private Vector3 cameraPos;
    private Transform player, win;
    private float cameraOffSet = 5f; 

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        player = FindAnyObjectByType<Player_Kontrol>().transform;
    }
    // Update is called once per frame
    void Update()
    {
      if (win == null) 
        {
            win = GameObject.Find("win(Clone)").GetComponent<Transform>();
        }
        if (transform.position.y > player.position.y && transform.position.y > win.position.y + cameraOffSet)
        {
            cameraPos = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x, cameraPos.y + 2 );
        }
    }
}
