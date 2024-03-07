using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine.Networking;

//photonViewと、PUNが呼び出すことのできるすべてのコールバック/イベントを提供します。使用したいイベント/メソッドをオーバーライドしてください。
public class PhotonManager : MonoBehaviourPunCallbacks
{
    //よく見るドキュメントページ
    //https://doc-api.photonengine.com/ja-jp/pun/current/class_photon_1_1_pun_1_1_photon_network.html
    //https://doc-api.photonengine.com/ja-jp/pun/current/class_photon_1_1_pun_1_1_mono_behaviour_pun_callbacks.html
    //https://doc-api.photonengine.com/ja-jp/pun/current/namespace_photon_1_1_realtime.html

    public static PhotonManager instance;//static
    public GameObject loadingPanel;//ロードパネル
    public Text loadingText;//ロードテキスト
    public GameObject buttons;//ボタン


    public GameObject createRoomPanel;//ルーム作成パネル
    public Text enterRoomName;//入力されたルーム名テキスト
    // APIエンドポイントURL
    string apiUrl = "http://127.0.0.1:8080/api/get-avatar-number/";
    string user_number = "";
    public InputField inputField;

    private void Awake()
    {
        instance = this;//格納
    }


    void Start()
    {
        //StartCoroutine(PostAvatarNumber());
        //メニューをすべて閉じる
        CloseMenuUI();

        //ロードパネルを表示してテキスト更新
        loadingPanel.SetActive(true);
        loadingText.text = "ネットワークに接続中...";

        //ネットワークに接続しているのか確認
        if (!PhotonNetwork.IsConnected)
        {
            //最初に設定したPhotonServerSettingsファイルの設定に従ってPhotonに接続
            PhotonNetwork.ConnectUsingSettings();
        }
    }


    /// <summary>
    /// 一旦すべてを非表示にする
    /// </summary>
    void CloseMenuUI()//なぜ作るのか：UI切り替えが非常に楽だから
    {
        loadingPanel.SetActive(false);//ロードパネル非表示

        buttons.SetActive(false);//ボタン非表示

        createRoomPanel.SetActive(false);//ルーム作成パネル
    }



    //継承元のメソッドでは「virtual」のキーワード
    //継承先では「override」のキーワード
    /// <summary>
    /// クライアントがMaster Serverに接続されていて、マッチメイキングやその他のタスクを行う準備が整ったときに呼び出されます
    /// </summary>
    public override void OnConnectedToMaster()//
    {

        PhotonNetwork.JoinLobby();//マスターサーバー上で、デフォルトロビーに入ります

        loadingText.text = "ロビーへの参加...";//テキスト更新

    }


    /// <summary>
    /// マスターサーバーのロビーに入るときに呼び出されます。
    /// </summary>
    public override void OnJoinedLobby()//
    {

        LobbyMenuDisplay();//
        CreateRoom();

    }


    //ロビーメニュー表示(エラーパネル閉じる時もこれ)
    public void LobbyMenuDisplay()
    {
        CloseMenuUI();
        buttons.SetActive(true);
    }

    //タイトルの部屋作成ボタン押下時に呼ぶ：UIから呼び出す
    //public void OpenCreateRoomPanel()
    //{
       // CloseMenuUI();
        //createRoomPanel.SetActive(true);
    //}

    //部屋作成ボタン押下時に呼ぶ：UIから呼び出す
    public void CreateRoom()
    {
            //ルームのオプションをインスタンス化して変数に入れる 
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 6;// プレイヤーの最大参加人数の設定（無料版は20まで。1秒間にやり取りできるメッセージ数に限りがあるので10以上は難易度上がる）

            //ルームを作る(ルーム名：部屋の設定)
            PhotonNetwork.CreateRoom("lifenenct", options);


            CloseMenuUI();//メニュー閉じる
            loadingText.text = "ルーム作成中...";
            loadingPanel.SetActive(true);
    }

    //API連携
    // UnityからPOSTリクエストを送るための関数
    IEnumerator PostAvatarNumber()
    {
        // リクエストボディを作成
        WWWForm form = new WWWForm();
        form.AddField("userid", user_number);

        // UnityWebRequestを使ってPOSTリクエストを送信
        using (UnityWebRequest www = UnityWebRequest.Post(apiUrl, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete! Response: " + www.downloadHandler.text);
            }
        }
    }

    public void ZeroButton()
    {
        user_number += "0"; // 文字を追加
        Debug.Log(user_number);
        UpdateInputFieldText(user_number);
    }
    public void OneButton()
    {
        user_number += "1"; // 文字を追加
        Debug.Log(user_number);
        UpdateInputFieldText(user_number);
    }

    public void TwoButton()
    {
        user_number += "2"; // 文字を追加
        Debug.Log(user_number);
        UpdateInputFieldText(user_number);
    }

    public void ThreeButton()
    {
        user_number += "3"; // 文字を追加
        Debug.Log(user_number);
        UpdateInputFieldText(user_number);
    }

    public void FourButton()
    {
        user_number += "4"; // 文字を追加
        Debug.Log(user_number);
        UpdateInputFieldText(user_number);
    }

    public void FiveButton()
    {
        user_number += "5"; // 文字を追加
        Debug.Log(user_number);
        UpdateInputFieldText(user_number);
    }

    public void SixButton()
    {
        user_number += "6"; // 文字を追加
        Debug.Log(user_number);
        UpdateInputFieldText(user_number);
    }

    public void SevenButton()
    {
        user_number += "7"; // 文字を追加
        Debug.Log(user_number);
        UpdateInputFieldText(user_number);
    }

    public void EightButton()
    {
        user_number += "8"; // 文字を追加
        Debug.Log(user_number);
        UpdateInputFieldText(user_number);
    }

    public void NineButton()
    {
        user_number += "9"; // 文字を追加
        Debug.Log(user_number);
        UpdateInputFieldText(user_number);
    }

    public void DeleteButton()
    {
       if (inputField != null && inputField.text.Length > 0)
        {
            // InputFieldのテキストから最後の1文字を削除
            user_number = user_number.Substring(0, inputField.text.Length - 1);
        }
        Debug.Log(user_number);
        UpdateInputFieldText(user_number);
    }
    public void UpdateInputFieldText(string newText)
    {
        if (inputField != null)
        {
            inputField.text = newText; // InputFieldのテキストを新しい内容で更新
        }
    }

     public void ApiPostButton()
    {
        StartCoroutine(PostAvatarNumber());
    }

}