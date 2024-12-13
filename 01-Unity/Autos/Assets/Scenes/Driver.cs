using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float steerSpeed = 3f;
    [SerializeField] float moveSpeed = 5f;
/*
    private float speed = 0.1f;
    private float angle = 0.0f;
    private float radius = 5.0f;*/
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // angle += speed * Time.deltaTime;
        
       float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
       float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0, -steerAmount);
        transform.Translate(0,moveAmount,0);
        /*
        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;
        
        transform.position = new Vector3(x,y,transform.position.z);
        */
    }
}
