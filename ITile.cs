using UnityEngine;

public interface ITile
{
    Vector2Int Position { get; }

    void UpdateTile();

    TileSave CreateSave();

    void Initialize(TileSave tileSave, LevelParameters levelParameters);
}

