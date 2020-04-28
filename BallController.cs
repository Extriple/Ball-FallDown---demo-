using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour

{
    public GameObject partical;
    [SerializeField]
    private float speed;
    bool starter;
     bool gameOver;

    Rigidbody rb;

    
     void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        starter = false;
       
    }

    void Update()
    {
        if (!starter)
        {
            //Usatwiamy predkość dla kuli 
            if (Input.GetMouseButtonDown(0)){
                rb.velocity = new Vector3(speed, 0, 0);
                starter = true;
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.blue);

        //Jak daleko? 
        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            // Wartość y jest na - ponieważ kulka musi spadać w dół a nie lecieć w góre ;p
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;
        }
        

        //Po kliknięciu myszką kula zmienia kierunek poruszania się
        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }
    //Funckja odpowiedzialna za kierunek kuli 
    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0,0,speed);
        }
    }

    //Jeżeli piłka dotknie kwadratu to zniszczy go
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            //Włączamy partical system
           GameObject part =  Instantiate(partical, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(part, 2f);

            
        }

    }
}











//1.Ustawiamy kamere na tryb Alling with  View [ Game Object ] 
//2. Ustawiamy tarcie kuli na poziomie 0. Physics material 
//-----------------------//-------------------------------//
//3. Stwórz Partical System 