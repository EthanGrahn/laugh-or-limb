using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CustomObjects/Fungeon Obstacle")]
public class FungeonObstacle : ScriptableObject
{
    public GameObject prefab;
    [Header("Allowable Positions")]
    [SerializeField] private bool positionOne = true;
    [SerializeField] private bool positionTwo = true;
    [SerializeField] private bool positionThree = true;
    [SerializeField] private bool positionFour = true;

    public List<bool> GetPositionArray()
    {
        List<bool> result = new List<bool>
        {
            positionOne,
            positionTwo,
            positionThree,
            positionFour
        };
        return result;
    }
}
