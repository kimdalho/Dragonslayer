using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    public static NetworkManager instance;
    public InputField InputField;
    public Button buttn;
    public GameObject resetPanel;
    public GameObject disconectPanel;

    public void Awake()
    {
        if(instance == null)
            instance = this;  

        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }

    public void Connect() => PhotonNetwork.ConnectUsingSettings();

     public override void OnConnectedToMaster()
    {
        PhotonNetwork.LocalPlayer.NickName = InputField.text;
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, null);
        Debug.Log("연결");
    }

/*    public override void OnConnectedToServer()
    {
        PhotonNetwork.LocalPlayer.NickName = InputField.text;
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, null);
        Debug.Log("연결");
    }*/

    public override void OnJoinedRoom()
    {
        disconectPanel.gameObject.SetActive(false);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("ㅠㅓ킹");
    }
}
