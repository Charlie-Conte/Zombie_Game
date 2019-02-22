using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Week2_AITargetController : MonoBehaviour
{
    private enum AIState { ROAMING, FOLLOWING, TERMINATED };

    private List<GameObject> waypointList = new List<GameObject>();
    private int activeWaypoint = 0;
    private AICharacterControl characterController;
    private ThirdPersonCharacter thirdPersonCharacter;
    private AIState currentState = AIState.ROAMING;


    void Start()
    {
        characterController = GetComponent<AICharacterControl>();
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();

        waypointList.AddRange(GameObject.FindGameObjectsWithTag("Waypoint"));
        System.Random rand = new System.Random(System.DateTime.Now.Millisecond);
        waypointList = waypointList.OrderBy(x => rand.Next()).ToList();

    }

    void Update()
    {
        if (currentState == AIState.ROAMING)
        {
            characterController.SetTarget(waypointList[activeWaypoint].transform);
            
            if ((Vector3.Distance(characterController.target.transform.position, transform.position) < 4.0f))
            {
               
                activeWaypoint++;
                
                activeWaypoint %= waypointList.Count;
            }
        }


        
    }
}
