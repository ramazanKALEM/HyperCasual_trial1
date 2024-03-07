using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private Rigidbody Rigidbody;
    private MeshRenderer meshRenderer;
    private Collider Collider; 
    private ObstackleConroler obstackleConroler;
    void Start()
    {
        
    }
    private void Awake()
    {
      Rigidbody = GetComponent<Rigidbody>();
      meshRenderer = GetComponent<MeshRenderer>();
      Collider = GetComponent<Collider>();
      obstackleConroler = transform.parent.GetComponent<ObstackleConroler>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void Shatter()
    {

        Rigidbody.isKinematic = false;
        Collider.enabled = false;

        Vector3 forcePoint = transform.parent.position;
        float parentXPos = transform.parent.position.x;
        float xPos = meshRenderer.bounds.center.x;

        Vector3 subDriction = (parentXPos - xPos < 0) ? Vector3.right : Vector3.left;
        Vector3 Driction = (Vector3.up * 1.5f + subDriction).normalized;


        float force = Random.Range(20, 35);
        float tork = Random.Range(110, 180);

        Rigidbody.AddForceAtPosition(Driction* force, forcePoint, ForceMode.Impulse);
        Rigidbody.AddTorque(Vector3.left * tork);
        Rigidbody.velocity = Vector3.down;
    }
}

