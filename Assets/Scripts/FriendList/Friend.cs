using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public GameObject FriendListPanel;
    public void openFriendList()
    {
        FriendListPanel.SetActive(true);
    }
    public void closeFriendList()
    {
        FriendListPanel.SetActive(false);
    }
}
