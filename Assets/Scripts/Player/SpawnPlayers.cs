using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject cameraPrefab; //*

    public float minX, maxX;
    public float minZ, maxZ;

    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 0.8f, Random.Range(minZ, maxZ));
        //PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        
        GameObject temp = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity); //*

        if (temp.GetComponent<PhotonView>().IsMine)
        {
            Debug.Log("Hello there");
            temp.GetComponent<PlayerMovement>().SetJoysticks(Instantiate(cameraPrefab, randomPosition, Quaternion.identity)); //*
        }
    }
}