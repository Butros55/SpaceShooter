using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private GameData gameData;

    private List<IDataPersistence> dataPersistencesObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake() {
        if(instance != null) {
            Debug.Log("Found more than one DataPersistanceManager in scene");
        }
        instance = this;
    }

    private void Start() {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName)
;       this.dataPersistencesObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame() {
        this.gameData = new GameData();
    }

    public void LoadGame() {
        this.gameData = dataHandler.Load();
        // if no data then load NewGame
        if(this.gameData == null) {
            Debug.Log("No Data was Found. Set data to defaults");
            NewGame();
        }
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects) {
            dataPersistenceObj.LoadData(gameData);

        Debug.Log("Loaded GameObjects " + gameData.ObjectPrefab.Count);
        Debug.Log("Loaded ObjectIndexes " + gameData.ObjectIndexes.Count);
        }
    }

    public void SaveGame() {
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects) {
            dataPersistenceObj.SaveData(ref gameData);
        }

        Debug.Log("Saved GameObjects " + gameData.ObjectPrefab.Count);
        Debug.Log("Loaded ObjectIndexes " + gameData.ObjectIndexes.Count);

        dataHandler.Save(gameData);
;    }

    private void OnApplicationQuit() {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects() {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistencesObjects);
    }
}
