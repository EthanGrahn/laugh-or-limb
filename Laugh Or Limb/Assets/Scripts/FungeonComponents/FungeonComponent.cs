using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungeonComponent : MonoBehaviour
{
    [SerializeField] private Transform topConnector;
    [SerializeField] private Transform bottomConnector;
    [SerializeField] private List<Transform> assetLocations = new List<Transform>();

    public void Start()
    {
        //Vector3 newPos = transform.position;
        //newPos = new Vector3(9.3f, transform.position.y, 7.3f);
        //transform.position = newPos;
    }

    public Vector3 GetConnectionPoint()
    {
        return bottomConnector.position;
    }

    public void ConnectTo(FungeonComponent other)
    {
        float connectY = other.GetConnectionPoint().y;
        Vector3 offset = transform.position;
        offset.y = connectY - 23f;
        //offset.y += transform.position.y + topConnector.localPosition.y;
        transform.position = offset;//other.GetConnectionPoint() - new Vector3(0, topConnector.localPosition.y, 0);
    }

    public void SetObstacleAtLocation(int location, GameObject prefab)
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = assetLocations[location].position + Vector3.back * 2;
    }

    public int GetAssetLocationCount()
    {
        return assetLocations.Count;
    }
}
