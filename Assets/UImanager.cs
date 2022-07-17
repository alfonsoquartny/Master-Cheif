using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{

    public void changeSelectedObject(string _id)
    {
        spawner.Instance.selectedObject = _id;
    }
}
