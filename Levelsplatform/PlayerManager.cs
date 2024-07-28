using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    int characterIndex;
    public CinemachineVirtualCamera VCam;
 private void Awake()
 {
characterIndex=PlayerPrefs.GetInt("Selectat",0);
GameObject player=Instantiate(playerPrefabs[characterIndex], Vector3.zero,Quaternion.identity);
VCam.m_Follow=player.transform;

 }


}
