using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSceneMovement : MonoBehaviour {

    public Vector3 startPosition;
    public GameObject targetUnit;

    public float moveSpeed;
    public bool home;
    
	void Start ()
    {
        startPosition = gameObject.transform.position;
	}
	
	void Update ()
    {
        if (targetUnit != null)
        {
            Vector3 targetPosition = targetUnit.transform.position;
            Vector3 moveDirection = new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y, targetPosition.z - transform.position.z);

            moveDirection.Normalize();
            GetComponent<Rigidbody>().velocity = moveDirection * moveSpeed;

            Vector3 targetDirection = new Vector3(targetUnit.transform.position.x - transform.position.x, targetUnit.transform.position.z - transform.position.z);
            if (targetDirection.magnitude < 0.3f)
            {
                home = false;
                targetUnit = null;
            }
        }

        else
        {
            Vector3 homeDirection = new Vector3(startPosition.x - transform.position.x, startPosition.z - transform.position.z);
            if (homeDirection.magnitude < 0.3f)
            {
                //we've arrived home
                home = true;
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                targetUnit = GameObject.Find("FriendlyUnit1");
            }
            else
            {
                //go home
                homeDirection.Normalize();
                GetComponent<Rigidbody>().velocity = homeDirection * moveSpeed;
            }
        }
    }
}
