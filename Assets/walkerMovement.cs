using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkerMovement : MonoBehaviour {
	Transform player;
	UnityEngine.AI.NavMeshAgent nav;
	GameObject walker;
	public float fieldOfView= 100f;
	Animator animator;
	private SphereCollider col;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		walker = GameObject.FindGameObjectWithTag ("Enermy");
		animator = GetComponent<Animator>();
		col = GetComponent<SphereCollider> ();
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = player.transform.position - transform.position;
		float angle = Vector3.Angle (direction, transform.forward);

		if (angle < fieldOfView * 0.5f) {
			RaycastHit hit;
			Debug.DrawRay(transform.position + transform.up * 3, transform.forward * 1000f, Color.blue, Time.deltaTime, true);
			if (Physics.Raycast (transform.position + transform.up * 3, direction.normalized, out hit, col.radius)) {
				if (hit.collider.gameObject == player) {
					animator.SetBool ("isSeen", true);
					nav.SetDestination (player.transform.position);
				}
			}
		}
	}
}
