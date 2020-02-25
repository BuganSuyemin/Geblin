using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WallTile : MonoBehaviour, ITile
{
    private Vector2Int position;
    public Vector2Int Position { get => position; set => position = value; }


    private void Update()
    {
        transform.position = (Vector2)position;
    }

    public void UpdateTile()
    {
    }

    public void Initialize(Vector2Int _position)
    {
        position = _position;
    }

    public void Initialize(int x, int y)
    {
        position = new Vector2Int(x, y);
    }

    public void Initialize(TileSave tileSave, LevelParameters levelParameters)
    {
        var props = tileSave.properties;
        for (int i = 0; i < props.Count; i++)
        {
            if (props[i].Key == "x")
                position = new Vector2Int(Convert.ToInt32(props[i].Value), position.y);
            if (props[i].Key == "y")
                position = new Vector2Int(position.x, Convert.ToInt32(props[i].Value));
        }
    }

    public TileSave CreateSave()
    {
        var props = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("x", position.x.ToString()),
            new KeyValuePair<string, string>("y", position.y.ToString()),
        };

        return new TileSave("WallTile", props);
    }


}
