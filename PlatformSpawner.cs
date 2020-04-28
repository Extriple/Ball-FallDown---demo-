using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    Vector3 lastPos;
    public GameObject Platform;
    public GameObject diamond;
    float size;
    public bool GameOver;
    void Start()
    {
        //Ustawiamy pozycje klocka
        lastPos = Platform.transform.position;
        size = Platform.transform.localScale.x;

        for(int i=0; i < 60; i++)
        {
            SpawnPlatforms();
        }
        //Co 0.2f funckja SpawnPlatforms bedzie odswieżana po upływie 2s.
        InvokeRepeating("SpawnPlatforms", 2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            //W przypadku gameover zatrzymuje resp klocków
            CancelInvoke("SpawnPlatforms");
        }
    }

    //Funkcja odpowiedzialna za automatyczne generowanie sie klocków zgodnie z załozeniami
    void SpawnPlatforms()
    {
        
        int rand = Random.Range(0, 7);
        if (rand < 3)
        {
            SpawnX();
        }else if(rand >= 3)
        {
            SpawnZ();
        }

    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        //Ostatnia pozycja jest tez nową pozycją  klocka
        lastPos = pos;

        Instantiate(Platform, pos, Quaternion.identity);
        //Generuje losowo kwadraty(punkty) do zbierania na trasie
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x,pos.y+1,pos.z), diamond.transform.rotation);
           
        }
    }
    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;

        Instantiate(Platform, pos, Quaternion.identity);
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
            
        }
    }
    
}
