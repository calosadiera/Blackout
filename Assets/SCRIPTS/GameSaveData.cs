using System.Collections.Generic;

[System.Serializable]
public class Vector2Data
{
    public float x;
    public float y;
}

[System.Serializable]
public class GameSaveData
{
    public int level;
    public Vector2Data playerPos;
    public Vector2Data generatorPos;
    public List<Vector2Data> enemyPositions;
    public bool generatorActivated;
    public bool doorActive;
}