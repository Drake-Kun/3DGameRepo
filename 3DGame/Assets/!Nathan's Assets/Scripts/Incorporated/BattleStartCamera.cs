using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartCamera: MonoBehaviour {

    public GameObject cameraStart;
    public GameObject cameraFinish;

    public float moveSpeed;
    public float rotateSpeed;

	void Start () {
        transform.position = cameraStart.transform.position;
        transform.rotation = cameraStart.transform.rotation;
	}
	
	void Update () {

        Vector3 moveDirection = new Vector3(cameraFinish.transform.position.x - transform.position.x, cameraFinish.transform.position.y - transform.position.y, cameraFinish.transform.position.z - transform.position.z);
        moveDirection.Normalize();
        GetComponent<Rigidbody>().velocity = moveDirection * moveSpeed;

        if (transform.position.z > -11)
        {
            moveSpeed = 0;
            GameObject.Find("Main Camera").GetComponent<TurnBasedCombatStateMachine>().AntiNull();
        }

        if (transform.rotation.x > cameraFinish.transform.rotation.x)
        {
            transform.Rotate(Vector3.left * Time.deltaTime * rotateSpeed);
        }
    }
}
