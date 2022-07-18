using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectTranslator : MonoBehaviour
{

    private Transform newTransform;
    public float yFloat;
    public GameObject canvas;

    void Start()
    {
        if (PlayerPrefs.GetInt(gameObject.name) == 1)
        {
            Destroy(canvas);
        }
        Debug.Log(base.gameObject.name);
        Debug.Log(gameObject.transform.rotation.y);
        yFloat = PlayerPrefs.GetFloat(base.gameObject.name);
       
        gameObject.transform.Rotate(0, yFloat, 0);
    }

    // Update is called once per frame
    void Update()
    {
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
        Destroy(canvas);
        PlayerPrefs.SetInt(gameObject.name, 1);
        DataManager.Instance.SaveData();
        Debug.Log("KAYDEDILDI");


    }
}
