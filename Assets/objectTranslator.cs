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
        yFloat = Obje.transform.rotation.y;

    }

    public void DondurSol()
    {
        Obje.transform.Rotate(0, -90, 0);
        yFloat = Obje.transform.rotation.y;


    }

    public void Ok()
    {
        PlayerPrefs.SetFloat(gameObject.name,yFloat);
    }
}
