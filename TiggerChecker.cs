using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Jezeli kulka najedzie na kafelek, wowczas podloga sie zapadnie
     void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Ball")
        {
            //Funkcja oblicza czas po jakim ma odpasc podloga
            Invoke("FallDown", 0.5f);
            FallDown();
        }
    }
    void FallDown()
    {
        //Jezeli kulka najedzie na kafelek to włączy się  grawitacja podczas odpadania podłogi
        GetComponentInParent<Rigidbody>().useGravity = true;
        //Wyłączamy siły działające na kaflki
        GetComponentInParent<Rigidbody>().isKinematic = false;
        //Jezeli kulka najedzie na platfome to kafelek ulegnie zniszczeniu po 2s.
        Destroy(transform.parent.gameObject, 2f);
    }
}
