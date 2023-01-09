using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSpaceShipInGame : MonoBehaviour, IDataPersistence
{
    public GameObject[] objects;
    public void LoadData(GameData data) {
        foreach (int Index in data.ObjectIndexes) {
            Instantiate(objects[data.ObjectPrefab[Index]], (data.ObjectPosition[Index] * gameObject.transform.localScale.x) + gameObject.transform.position, data.ObjectRotation[Index], gameObject.transform);
        }
    }

    public void SaveData(ref GameData data) {
    }
}
