using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectTranslator : MonoBehaviour
{


    public GameObject Obje;
    public float yFloat;
    void Start()
    {
        Debug.Log(gameObject.name);
        Debug.Log(Obje.transform.rotation.y);
      yFloat= PlayerPrefs.GetFloat(gameObject.name);

        Obje.transform.Rotate(0, yFloat, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DondurSag()
    {
        Obje.transform.Rotate(0, +90, 0);
        yFloat = yFloat + 90;

        if (yFloat > 180)
        {
            yFloat = -90;
        }
    }

    public void DondurSol()
    {
        Obje.transform.Rotate(0, -90, 0);
        yFloat = yFloat - 90;

        if (yFloat < -90)
        {
            yFloat = 180;
        }
    }

    public void Ok()
    {
        Debug.Log("KAYDEDILDI");
        PlayerPrefs.SetFloat(gameObject.name,yFloat);
    }
}
