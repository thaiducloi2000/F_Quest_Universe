using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField user_inputfield;
    public TMP_InputField password_inputfield;
    public GameObject Loginpanel;
    public GameObject Regiserpanel;
    public GameObject Attentionpanel;
    public TMP_Text TextAttention;
    public void SwitchScene()
    {
        Loginpanel.SetActive(false);
        Regiserpanel.SetActive(true);
    }

    public void checkLogin()
        
{
        if (user_inputfield.text == "" || password_inputfield.text == "")
        {
            Attentionpanel.SetActive(true);
            TextAttention.text = "No box can be left blank";
        }
        else if (!user_inputfield.text.Equals("LongDK") || !password_inputfield.text.Equals("1234"))
        {
            Attentionpanel.SetActive(true);
            TextAttention.text = "Wrong username or password";
        }
        else
        {
            SceneManager.LoadScene("GamePlay_Scene");
        }
    }
}
