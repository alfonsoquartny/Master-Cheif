using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectTranslator : MonoBehaviour
{
    public static objectTranslator Instance { get; set; }
    private Transform newTransform;
    public float yFloat;
    public GameObject canvas;

    void Start()
    {
        Instance = this;
      
        Debug.Log(base.gameObject.name);
        Debug.Log(gameObject.transform.rotation.y);
        yFloat = PlayerPrefs.GetFloat(base.gameObject.name);
       
        gameObject.transform.Rotate(0, yFloat, 0);
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt(gameObject.name) == 1)
        {
            canvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        if (PlayerPrefs.GetInt(gameObject.name) == 0)
        {
            canvas.SetActive(true);
        }
    }

    public void DondurSag()
    {
        gameObject.transform.Rotate(0, +90, 0);
        yFloat = yFloat + 90;

        if (yFloat > 180)
        {
            yFloat = -90;
        }
    }

    public void DondurSol()
    {
        gameObject.transform.Rotate(0, -90, 0);
        yFloat = yFloat - 90;

        if (yFloat < -90)
        {
            yFloat = 180;
        }
    }

    public void Ok()
    {
        PlayerPrefs.SetInt(gameObject.name, 1);
        DataManager.Instance.SaveData();
        Debug.Log("KAYDEDILDI");


    }

    public void selected()
    {
        canvas.SetActive(true);
    }
}
