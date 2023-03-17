using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ProfilePanel;
    public void openProfile()
    {
        ProfilePanel.SetActive(true);
    }
    public void closeProfile()
    {
        ProfilePanel.SetActive(false);
    }
}
