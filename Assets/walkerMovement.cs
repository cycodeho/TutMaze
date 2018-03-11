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
	public bool seen;

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
		if (!seen) {
			Vector3 direction = player.transform.position - transform.position;
			float angle = Vector3.Angle (direction, transform.forward);

			if (angle < fieldOfView * 0.5f) {
				RaycastHit hit;

				Vector3 gunDirectionVector = new Vector3 (transform.position.x, player.transform.position.y, transform.position.z);

				//Debug.DrawRay (gunDirectionVector, direction.normalized * 1000f, Color.blue, Time.deltaTime, true);
				if (Physics.Raycast (gunDirectionVector, direction.normalized, out hit, col.radius)) {
					if (hit.collider.gameObject.tag == "Player") {
						animator.SetBool ("isSeen", true);
						nav.SetDestination (player.transform.position);
						seen = true;
					}
				}
			}
		} else {
			nav.SetDestination (player.transform.position);

			float dist = Vector3.Distance(player.position, transform.position);
			if (dist <= nav.stoppingDistance + 1.2f) {
				animator.SetBool ("isNear", true);
			} else {
				animator.SetBool ("isNear", false);
			}

		}
	}
}
