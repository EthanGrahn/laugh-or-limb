using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FungeonGenerator : MonoBehaviour
{
    public static FungeonGenerator Instance;

    public List<GameObject> components = new List<GameObject>();
    public int heightToGenerate = 20;
    [SerializeField] private GameObject assetIndicatorPrefab;
    private FungeonObstacle[] playerChoiceObstacles;
    private FungeonObstacle[] otherObstacles;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
            return;
        }

        playerChoiceObstacles = Resources.LoadAll<FungeonObstacle>("PlayerObstacles");
        otherObstacles = Resources.LoadAll<FungeonObstacle>("NonPlayerObstacles");
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
            for (int j = 3; j >= 0; j--)
            {
                GameObject obstacle = GetRandomObstacleForPosition(j, true);
                if (obstacle != null)
                    currentComponent.SetObstacleAtLocation(j, obstacle);
            }
            lastComponent = currentComponent;
        }
    }

    private GameObject GetRandomObstacleForPosition(int position, bool isPlayerObstacle = false)
    {
        FungeonObstacle[] validObstacles;
        if (isPlayerObstacle)
            validObstacles = playerChoiceObstacles.Where(x => x.GetPositionArray()[position] == true).ToArray();
        else
            validObstacles = otherObstacles.Where(x => x.GetPositionArray()[position] == true).ToArray();

        if (validObstacles.Length == 0)
            return null;
        return validObstacles[UnityEngine.Random.Range(0, validObstacles.Length)].prefab;
    }
}
