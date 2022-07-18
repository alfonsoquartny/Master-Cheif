using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; set; }
    public ItemOB ItemOB;
    private void Start()
    {
        Instance = this;
        LoadData();

    }
    public void AddItem(GameObject obj)
    {
        Item item = new Item();
        item.prefabID = spawner.Instance.selectedObject;
        item.ItemID = item.prefabID + ItemOB.items.Count + ToString();
        obj.name = item.ItemID;
        item.position = obj.transform.position;//rotation da ekle
        ItemOB.items.Add(item);

    }
    public void RemoveItem(string itemId)
    {
        Item item = ItemOB.items.Where(p => p.ItemID == itemId).First();
        ItemOB.items.Remove(item);

    }
  
    public void SaveData()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ItemOB));
        FileStream stream = new FileStream(Application.dataPath + "/StreamFiles/Game_data.xml",FileMode.Create);
        xmlSerializer.Serialize(stream, ItemOB);
        stream.Close();
    }

    void LoadData()
    {
        if (!File.Exists(Application.dataPath + "/StreamFiles/Game_data.xml")) return;
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ItemOB));
        FileStream stream = new FileStream(Application.dataPath + "/StreamFiles/Game_data.xml", FileMode.Open);
      ItemOB=  xmlSerializer.Deserialize(stream)as ItemOB;
        stream.Close();

        foreach(Item item in ItemOB.items)
        {
            GameObject go =  Instantiate(PrefabDataBase.Instance.RequestPrefab(item.prefabID), item.position,Quaternion.identity);
            spawner.Instance.SelectingMode();
            go.name = item.ItemID;
        }
    }

}

[System.Serializable]
public class ItemOB
{
    public List<Item> items = new List<Item>(); 
}

[System.Serializable]
public class Item
{
    public string prefabID;
    public string ItemID;
    public Vector3 position;

}
