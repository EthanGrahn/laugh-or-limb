using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FungeonGenerator : MonoBehaviour
{
    public static FungeonGenerator Instance;

    public List<GameObject> components = new List<GameObject>();
    public int heightToGenerate = 20;
    [SerializeField] private GameObject bottomComponent;
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

    private void OnLevelWasLoaded(int level)
    {
        if (Instance != this)
            return;

        string sceneName = SceneManager.GetSceneByBuildIndex(level).name;
        if (sceneName == "TheFungeon")
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
            go = Instantiate(components[UnityEngine.Random.Range(0, components.Count)]);
            currentComponent = go.GetComponent<FungeonComponent>();
            if (lastComponent != null)
            {
                currentComponent.ConnectTo(lastComponent);
            }
            int assetLocationCount = currentComponent.GetAssetLocationCount();
            int playerObstacleCount = Mathf.Max(assetLocationCount / 2, 1);
            int otherObstacleCount = assetLocationCount - playerObstacleCount;
            List<bool> isPlayerObstacle = new List<bool>();
            for (int j = playerObstacleCount; j > 0; j--)
            {
                isPlayerObstacle.Add(true);
            }
            for (int j = otherObstacleCount; j > 0; j--)
            {
                isPlayerObstacle.Add(false);
            }
            //isPlayerObstacle = isPlayerObstacle.OrderBy(x => UnityEngine.Random.Range(0, 1)).ToList();
            var k = UnityEngine.Random.Range(0, 6);
            List<bool> temp = new List<bool>();
            switch(k)
            {
                case 0:
                    temp.Add(false);
                    temp.Add(true);
                    temp.Add(true);
                    temp.Add(false);
                    break;
                case 1:
                    temp.Add(false);
                    temp.Add(true);
                    temp.Add(false);
                    temp.Add(true);
                    break;
                case 2:
                    temp.Add(true);
                    temp.Add(false);
                    temp.Add(false);
                    temp.Add(true);
                    break;
                case 3:
                    temp.Add(false);
                    temp.Add(false);
                    temp.Add(true);
                    temp.Add(true);
                    break;
                case 4:
                    temp.Add(true);
                    temp.Add(false);
                    temp.Add(true);
                    temp.Add(false);
                    break;
                case 5:
                    temp.Add(true);
                    temp.Add(true);
                    temp.Add(false);
                    temp.Add(false);
                    break;
            }
            isPlayerObstacle = temp;
            for (int j = currentComponent.GetAssetLocationCount() - 1; j >= 0; j--)
            {
                GameObject obstacle = GetRandomObstacleForPosition(j, isPlayerObstacle[j]);
                if (obstacle != null)
                    currentComponent.SetObstacleAtLocation(j, obstacle);
            }
            lastComponent = currentComponent;
        }
        go = Instantiate(bottomComponent);
        go.GetComponent<FungeonComponent>().ConnectTo(lastComponent);
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