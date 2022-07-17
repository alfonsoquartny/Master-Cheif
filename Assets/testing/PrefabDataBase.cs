using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PrefabDataBase : MonoBehaviour
{

public static PrefabDataBase Instance { private set; get; }


    private void Awake()
    {
        Instance = this;
    }
    public List<PrefabItem> prefabItems = new List<PrefabItem>();

    public GameObject RequestPrefab(string Prefab_ID)
    {
        PrefabItem prefabItem = prefabItems.Where(p => p.Prefab_ID == Prefab_ID).First();
        return prefabItem.prefab_GameObject;
    }
}



[System.Serializable]
public class PrefabItem
{
    public GameObject prefab_GameObject;
    public string Prefab_ID;
}