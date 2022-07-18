using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public static spawner Instance { private set; get; }
    Ray PointerRay;
    RaycastHit PointerHit;

    public string selectedObject;


    public GameObject BuildingPrefab;
    enum BuildMode { Building, Selecting, Free, Deleting } [SerializeField] BuildMode buildMode = new BuildMode();

    private void Awake()
    {
        Instance = this;   
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Building();
        DeleteItem();

    }


    public void selectMode()
    {

        if (buildMode != BuildMode.Selecting)
            return;
            if (PointerHit.collider.tag == "Building" && Input.GetKeyDown(KeyCode.Mouse0))
            {
            PlayerPrefs.SetInt(PointerHit.collider.name, 0);
            objectTranslator.Instance.selected();
            }
            if (PointerHit.collider.tag == "Water" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                objectTranslator.Instance.Ok();
            }
    }
    public void deleteMode()
    {
        buildMode = BuildMode.Deleting;
    }
    public void BuildingMode()
    {
        buildMode = BuildMode.Building;

    }
    public void  SelectingMode()
    {
        buildMode = BuildMode.Selecting;

    }
    void Building()
    {
        if (buildMode != BuildMode.Building) return;

        if (isRayHiting())
        {
            if (PointerHit.collider.tag == "Water" && Input.GetKeyDown(KeyCode.Mouse0))
            {
            GameObject OBJ=    Instantiate(PrefabDataBase.Instance.RequestPrefab(selectedObject), PointerHit.point, Quaternion.identity);
                DataManager.Instance.AddItem(OBJ);
            
            }
        }
    }

    void DeleteItem()
    {
        if (buildMode != BuildMode.Deleting) return;

        if (isRayHiting())
        {
            if (PointerHit.collider.tag == "Building" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                DataManager.Instance.RemoveItem(PointerHit.collider.gameObject.name);
                Destroy(PointerHit.collider.gameObject);
                DataManager.Instance.SaveData();
            }
        }
    }


   bool isRayHiting()
    {
        PointerRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(PointerRay, out PointerHit);
    }
}
