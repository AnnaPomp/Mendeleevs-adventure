using System.Collections;
using System.Collections.Generic;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TMP_InputField nameInputField;
    public TMP_Text buttonText;
public void OnClickConnectButton()
{
    PhotonNetwork.NickName=nameInputField.text;
    PhotonNetwork.ConnectUsingSettings();
    buttonText.text="Connecting...";
}
public override void OnConnectedToMaster()
{
    StreamChatBehaviour.instance.GetOnCreateClient(nameInputField.text);
    PhotonNetwork.JoinLobby();
}
public override void OnJoinedLobby()
{
    
}
}
