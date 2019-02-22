using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Week3_AITargetController : MonoBehaviour
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
        switch (currentState)
        {
            case AIState.ROAMING:
                characterController.SetTarget(waypointList[activeWaypoint].transform);

                if ((Vector3.Distance(characterController.target.transform.position, transform.position) < 3.0f))
                {

                    activeWaypoint++;

                    activeWaypoint %= waypointList.Count;
                }

                if (IsPlayerSeen())
                {
                    currentState = AIState.FOLLOWING;
                }
                break;

            case AIState.FOLLOWING:
                characterController.SetTarget(GameObject.FindGameObjectWithTag("Player").transform);
                if (!IsPlayerSeen())
                {
                    currentState = AIState.ROAMING;
                }
                break;

            case AIState.TERMINATED:

                break;

            default:
                break;
        }


    }

    protected bool IsPlayerSeen()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;


        if (Vector3.Angle(transform.forward, playerPos - transform.position) <= 45f)
        {
            LayerMask layerMask = LayerMask.NameToLayer("Enemy");

            RaycastHit rayHit;

            
            if (Physics.Raycast(transform.position + new Vector3(0f, 0.5f, 0f), playerPos - transform.position, out rayHit, Mathf.Infinity, layerMask))
            {
             
                return (rayHit.collider.tag.Equals("Player"));
            }
        }
        return false;
    }

    public void kill()
    {
        this.GetComponent<Week3_ZombieAnimationController>().toDie = true;
        this.GetComponent<NavMeshAgent>().enabled = false; 
        this.GetComponent<AICharacterControl>().enabled = false; 


        foreach (Collider thisCollider in GetComponentsInChildren<Collider>())
        {
            thisCollider.enabled = true;
        }
        this.GetComponent<Collider>().enabled = false;

        Destroy(gameObject, 7.0f); 
        this.currentState = AIState.TERMINATED;
    }
}