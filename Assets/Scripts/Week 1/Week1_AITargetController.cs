using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Week1_AITargetController : MonoBehaviour
{
    private AICharacterControl characterController;

    GameObject posToGo;
    void Start()
    {
        characterController = GetComponent<AICharacterControl>();
        posToGo = new GameObject();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(mouseRay, out rayHit))
            {
                Debug.Log(rayHit.collider.name);
                posToGo.transform.position = rayHit.point;
                characterController.SetTarget(posToGo.transform);
            }
        }
    }
}
