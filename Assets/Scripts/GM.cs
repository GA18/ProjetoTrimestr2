﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

	public static GM instance = null;

	public float yMinLive = -8f;
	public Transform spawnPoint;
	public GameObject playerPrefab;

	PlayerControler player;

	public float timeToRespawn = 2f;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		}
	}

	void Start () {
		if(player == null) {
			RespawnPlayer();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null) {
			GameObject obj = GameObject.FindGameObjectWithTag("Player");
			if (obj != null) {
				player = obj.GetComponent<PlayerControler>();
			}

		}
	}
	public void RespawnPlayer() {
		Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

	}

	public void KillPlayer () {
		if (player != null) {
			Destroy(player.gameObject);
			Invoke("RespawnPlayer", timeToRespawn);
		}
	}
}
