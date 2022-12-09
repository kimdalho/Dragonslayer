using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public InputField InputField;
    public Button buttn;
    public GameObject resetPanel;
    public GameObject disconectPanel;

    public void Awake()
    {

    }

    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    public void OnConnectedToServer()
    {
        PhotonNetwork.LocalPlayer.NickName= InputField.text;
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, null);
        Debug.Log("¿¬°á");
    }

    public override void OnJoinedRoom()
    {
        disconectPanel.gameObject.SetActive(false);
    }
    
}
