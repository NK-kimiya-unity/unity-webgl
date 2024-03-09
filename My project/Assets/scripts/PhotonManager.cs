using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine.Networking;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public static PhotonManager instance;
    public GameObject loadingPanel;
    public Text loadingText;
    public GameObject buttons;

    public GameObject createRoomPanel;
    public Text enterRoomName;

    public GameObject roomPanel;
    public Text roomName;

    public GameObject errorPanel;
    public Text errorText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CloseMenuUI();
        loadingPanel.SetActive(true);
        loadingText.text = "ネットワークに接続中";
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    void CloseMenuUI()
    {
        loadingPanel.SetActive(false);
        buttons.SetActive(false);
        createRoomPanel.SetActive(false);
        roomPanel.SetActive(false);
         errorPanel.SetActive(false);
    }

    public void LobbyMenuDisplay()
    {
        CloseMenuUI();
        buttons.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        loadingText.text = "ロビーへの参加";
    }

    public override void OnJoinedLobby()
    {
        LobbyMenuDisplay();
    }

    public void OpenCreateRoomPanel()
    {
        CloseMenuUI();
        createRoomPanel.SetActive(true);
    }

    public void CreateRoomButton()
    {
        if (!string.IsNullOrEmpty(enterRoomName.text))
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 6;
            PhotonNetwork.CreateRoom(enterRoomName.text, options);
            CloseMenuUI();
            loadingText.text = "ルーム作成中";
            loadingPanel.SetActive(true);
        }
    }

     public override void OnJoinedRoom()
    {
        CloseMenuUI();
        roomPanel.SetActive(true);
        roomName.text = PhotonNetwork.CurrentRoom.Name;
    }

    public void LeavRoom()
    {
        PhotonNetwork.LeaveRoom();
        CloseMenuUI();
        loadingText.text = "退出中";
        loadingPanel.SetActive(true);
    }

    public override void OnLeftRoom()
    {
        LobbyMenuDisplay();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "ルームの作成に失敗しました" + message;
        CloseMenuUI();
        errorPanel.SetActive(true);
    }
}