using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
	public GameObject playerPrefab;
	public Transform[] spawnPoints;

	private void Start()
	{
		int randNum = Random.Range(0, spawnPoints.Length);
		Transform spawnPoint = spawnPoints[randNum];
		PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, Quaternion.identity);
	}

}
