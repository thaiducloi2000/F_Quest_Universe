using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Attention : MonoBehaviour
{
    public GameObject Attentionpanel;
    // Start is called before the first frame update
    public void ok()
    {
        Attentionpanel.SetActive(false);
    }
}
