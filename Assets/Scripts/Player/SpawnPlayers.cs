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
    public float minX2, maxX2;

    void Start()
    {
        Vector3 randomPosition = randomPosition = new Vector3(Random.Range(minX, maxX), 0.2f, Random.Range(minZ, maxZ));

        float randomNumber = Random.Range(0, 3);
        if (randomNumber == 1)
        {
            randomPosition = new Vector3(Random.Range(minX, maxX), 0.2f, Random.Range(minZ, maxZ));
        } else { 
            randomPosition = new Vector3(Random.Range(minX2, maxX2), 0.2f, Random.Range(minZ, maxZ));
        }
        //PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        
        GameObject temp = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity); //*

        if (temp.GetComponent<PhotonView>().IsMine)
        {
            Debug.Log("Hello there");
            temp.GetComponent<PlayerMovement>().SetJoysticks(Instantiate(cameraPrefab, randomPosition, Quaternion.identity)); //*
        }
    }
}