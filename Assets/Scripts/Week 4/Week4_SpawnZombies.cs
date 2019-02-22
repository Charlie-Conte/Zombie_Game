using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Week4_SpawnZombies : MonoBehaviour
{


    public int maxZombieCount = 5;
    int currentZombieCount = 0;
    private List<GameObject> waypointList;
    public List<GameObject> zombieList = new List<GameObject>();
    public GameObject zombiePrefab;
    private GameObject player;
    private float dTimer = 6f;
    private float lastTime;

    void Start()
    {
        waypointList = GameObject.FindGameObjectsWithTag("Waypoint").ToList();
        player = GameObject.FindGameObjectWithTag("Player");
        lastTime = Time.unscaledTime;
        
    }

    void Update()
    {
        player.transform.position = new Vector3(player.transform.position.x, -5.608388e-07f, player.transform.position.z);
        while (zombieList.Count < maxZombieCount && Time.unscaledTime > lastTime + dTimer)
        {



            waypointList = waypointList.OrderBy(c => Vector3.Distance(player.transform.position, c.transform.position)).ToList();




            zombieList.Add(Instantiate(zombiePrefab, waypointList[waypointList.Count - 1].transform.position, new Quaternion(), transform));
            lastTime = Time.time;

        }


    }
}

