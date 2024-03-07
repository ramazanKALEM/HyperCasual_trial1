using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Direk_Takip : MonoBehaviour
{
    public Transform Target;
    public bool collision1 = false;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            collision1 = true;
            //Debug.Log("De�di");
        }
    }
    private void Update()
    {

        if (collision1 == false)
        {
            transform.position = new Vector3(transform.position.x, Target.position.y, transform.position.z);
        }
    else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }

}

