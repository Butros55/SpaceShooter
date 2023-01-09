using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public List<int> ObjectPrefab;
    public List<int> ObjectIndexes;
    public List <Vector3>ObjectPosition;
    public List<Quaternion> ObjectRotation;
    public int ObjectIndex;

    public GameData() {
        ObjectPrefab = new List<int>();
        ObjectIndexes = new List<int>();
        ObjectPosition = new List<Vector3>();
        ObjectRotation = new List<Quaternion>();
        ObjectIndex = 0;
    }
}
