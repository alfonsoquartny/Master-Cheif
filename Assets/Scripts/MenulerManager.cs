using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenulerManager : MonoBehaviour
{

    public TMP_Text playerName;
    void Start()
    {
        playerName.text = PlayerPrefs.GetString("playerName");
        Debug.Log(PlayerPrefs.GetString("playerName"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void deletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
 
}
