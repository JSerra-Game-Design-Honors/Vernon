using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerItem : MonoBehaviourPunCallbacks
{
    public TMP_Text playerName;

    public Image backgroundImage;
    public Color highlightColor;

    Player player;

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();


    //public float timeBetweenUpdates = 1.5f;
    //float nextUpdateTime;

    //figure out how to enable just your own toggles
    public List<Toggle> playerToggleList = new List<Toggle>();


    private void Start()
    {
        backgroundImage = GetComponent<Image>();
        /*
        foreach (Toggle tog in playerToggleList)
        {
            tog.interactable = true;
        }
        */
    }

    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        //UpdatePlayerItem(player);
    }

    public void ApplyLocalChanges()
    {
        backgroundImage.color = highlightColor;
        //also figure out how to only access your own augment toggles
        foreach (Toggle tog in playerToggleList)
        {
            tog.interactable = true;
        }


    }

    public void OnClickedToggle()
    {
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if(player == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }

    }

    void UpdatePlayerItem(Player player)
    {
        //if(player.CustomProperties.ContainsKey("something for the toggles"))
        //playerProperties["something for toggle"] = (int)player.CustomProperties["something for toggle"];
        //else {
        //playerProperties["something for toggle"] = 0
        //}
    }


}
