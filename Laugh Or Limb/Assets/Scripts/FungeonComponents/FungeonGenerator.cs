using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungeonGenerator : MonoBehaviour
{
    public List<GameObject> components = new List<GameObject>();
    public int heightToGenerate = 20;
    [SerializeField] private GameObject assetIndicatorPrefab;
    [SerializeField] private List<GameObject> playerChoiceObstacles = new List<GameObject>();
    [SerializeField] private List<GameObject> otherObstacles = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartGeneration();
        }
    }

    private void StartGeneration()
    {
        GameObject go;
        FungeonComponent lastComponent = null;
        FungeonComponent currentComponent;
        for (int i = heightToGenerate; i > 0; i--)
        {
            go = Instantiate(components[0], transform);
            currentComponent = go.GetComponent<FungeonComponent>();
            if (lastComponent != null)
            {
                currentComponent.ConnectTo(lastComponent);
            }
            currentComponent.ConfigureAssetLocations(assetIndicatorPrefab);
            lastComponent = currentComponent;
        }
    }
}
