﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkerMovement : MonoBehaviour {
	Transform player;
	UnityEngine.AI.NavMeshAgent nav;
	public float fieldOfView= 100f;
	Animator animator;
	private SphereCollider col;
	public bool seen;
	public float idleWalkRange = 10f;
	private Vector3 nextPosition;
	private float timer = 0f;
	public float randomRange = 10f;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
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

			// can see player?
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
			if (!seen){
				timer += Time.deltaTime;
				if (timer >= randomRange) {
					nextPosition = new Vector3 (transform.position.x + Random.Range (-1 * idleWalkRange, idleWalkRange), 
												transform.position.y,
												transform.position.z + Random.Range (-1 * idleWalkRange, idleWalkRange)
					);			
					nav.SetDestination (nextPosition);
					timer = 0f;
				}else{
					nav.SetDestination (nextPosition);
				}
			}
		} else {
			nav.SetDestination (player.transform.position);
			timer = 0f;
			float dist = Vector3.Distance(player.position, transform.position);
			if (dist <= nav.stoppingDistance + 1.2f) {
				animator.SetBool ("isNear", true);
			} else {
				animator.SetBool ("isNear", false);
			}

		}
	}
}
