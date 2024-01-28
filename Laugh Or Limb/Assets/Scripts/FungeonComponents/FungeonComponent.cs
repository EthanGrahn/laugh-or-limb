using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungeonComponent : MonoBehaviour
{
    [SerializeField] private Transform topConnector;
    [SerializeField] private Transform bottomConnector;
    [SerializeField] private List<Transform> assetLocations = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetConnectionPoint()
    {
        return bottomConnector.position;
    }

    public void ConnectTo(FungeonComponent other)
    {
        transform.position = other.GetConnectionPoint();
    }

    public void ConfigureAssetLocations(GameObject prefab)
    {
        GameObject go;
        foreach (Transform t in assetLocations)
        {
            go = Instantiate(prefab);
            go.transform.position = t.position + Vector3.back * 2;
        }
    }
}
