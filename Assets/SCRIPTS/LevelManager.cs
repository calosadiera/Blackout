using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int currentLevel;
    public Transform player;
    public Transform generator;
    public List<Transform> enemies;
    public DoorController door;
    public bool generatorActivated;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5)) Save();
        if (Input.GetKeyDown(KeyCode.F9)) Load();
    }

    public void Save()
    {
        bool doorActive = door.gameObject.activeSelf;
        SaveManager.Instance.SaveGame(currentLevel, player, generator, enemies, generatorActivated, doorActive);
    }

    public void Load()
    {
        GameSaveData data = SaveManager.Instance.LoadGame();
        if (data == null) return;

        player.position = new Vector2(data.playerPos.x, data.playerPos.y);
        generator.position = new Vector2(data.generatorPos.x, data.generatorPos.y);

        generatorActivated = data.generatorActivated;
        door.SetDoorState(data.doorActive);

        generator.GetComponent<GeneratorSystem>().SetActivated(data.generatorActivated);

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].position = new Vector2(data.enemyPositions[i].x, data.enemyPositions[i].y);
        }
    }
}