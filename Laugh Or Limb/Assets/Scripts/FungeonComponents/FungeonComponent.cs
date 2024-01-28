using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungeonComponent : MonoBehaviour
{
    [SerializeField] private Transform topConnector;
    [SerializeField] private Transform bottomConnector;
    [SerializeField] private List<Transform> assetLocations = new List<Transform>();

    public Vector3 GetConnectionPoint()
    {
        return bottomConnector.position;
    }

    public void ConnectTo(FungeonComponent other)
    {
        transform.position = other.GetConnectionPoint();
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
