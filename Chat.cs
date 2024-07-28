using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class Chat : MonoBehaviour
{
    public InputField inputField;
    public GameObject Message;
    public void SendMessage()
    {
       GetComponent<PhotonView>().RPC("GetMessage", RpcTarget.All, inputField.text); 
    }
    [PunRPC]
    public void GetMessage(string ReceiveMessage)
    {
Instantiate(Message, Vector3.zero, Quaternion.identity, Content.transform);
Message.GetComponent<Message>().MyMessage.text=ReceiveMessage;
    }
}
