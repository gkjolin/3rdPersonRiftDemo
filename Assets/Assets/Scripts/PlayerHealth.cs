﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public GameObject respawnPoint;
	Animator animator;
	PlayerMover playerMover;

	void Awake () {
		animator = GetComponent<Animator> ();
		playerMover = GetComponent<PlayerMover>();
	}

	public void Knocked(GameObject knocker) {
		if (!playerMover.isBeingKnocked) {
			animator.SetTrigger("IsKnockedDown");
			playerMover.Knocked(knocker);
		}
	}

    public void Respawn() {
		playerMover.isBeingKnocked = true;
		animator.SetTrigger("IsLieDown");
		this.transform.position = respawnPoint.transform.position;
		this.transform.rotation = respawnPoint.transform.rotation;
		this.transform.Rotate(Vector3.up, -90);
	}
	
	public void SetRespawnPoint(GameObject respawnPoint) {
		this.respawnPoint = respawnPoint;
	}
}
