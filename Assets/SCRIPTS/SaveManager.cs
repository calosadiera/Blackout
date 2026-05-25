using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    private string savePath;

    void Awake()
    {
        Instance = this;
        savePath = Application.persistentDataPath + "/savegame.json";
    }

    public void SaveGame(int level, Transform player, Transform generator, List<Transform> enemies, bool generatorActivated, bool doorActive)
    {
        GameSaveData data = new GameSaveData();

        data.level = level;
        data.playerPos = new Vector2Data { x = player.position.x, y = player.position.y };
        data.generatorPos = new Vector2Data { x = generator.position.x, y = generator.position.y };
        data.generatorActivated = generatorActivated;
        data.doorActive = doorActive;

        data.enemyPositions = new List<Vector2Data>();
        foreach (Transform enemy in enemies)
        {
            data.enemyPositions.Add(new Vector2Data { x = enemy.position.x, y = enemy.position.y });
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game tersimpan di: " + savePath);
    }

    public GameSaveData LoadGame()
    {
        if (!File.Exists(savePath))
        {
            Debug.Log("File save tidak ditemukan.");
            return null;
        }

        string json = File.ReadAllText(savePath);
        GameSaveData data = JsonUtility.FromJson<GameSaveData>(json);
        return data;
    }
}