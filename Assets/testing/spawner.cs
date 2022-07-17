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
        switchMode();
        Building();
    }


    void switchMode()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("1");
            buildMode = BuildMode.Building;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("1");
            buildMode = BuildMode.Free;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("1");
            buildMode = BuildMode.Selecting;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("1");
            buildMode = BuildMode.Deleting;
        }
    }

    void Building()
    {
        if (buildMode != BuildMode.Building) return;

        if (isRayHiting())
        {
            if (PointerHit.collider.tag == "Water" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(PrefabDataBase.Instance.RequestPrefab(selectedObject), PointerHit.point, Quaternion.identity);
            }
        }
    }

   bool isRayHiting()
    {
        PointerRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(PointerRay, out PointerHit);
    }
}
