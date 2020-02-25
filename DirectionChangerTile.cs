using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DirectionChangerTile : MonoBehaviour, ITile
{
    private Vector2Int position;
    private Direction direction;

    public Vector2Int Position { get => position; set => position = value; }
    public Direction Dir { get => direction; set => direction = value; }



    private void SetRotation()
    {
        switch (direction)
        {
            case Direction.UP:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case Direction.RIGHT:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Direction.DOWN:
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            case Direction.LEFT:
                transform.rotation = Quaternion.Euler(0, 0, 190);
                break;
            default:
                break;
        }
    }



    public void UpdateTile()
    {
    }

    private void Update()
    {
        transform.position = (Vector2)position;
    }

    public TileSave CreateSave()
    {
        var props = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("x", position.x.ToString()),
            new KeyValuePair<string, string>("y", position.y.ToString()),
            new KeyValuePair<string, string>("dir", ((int)direction).ToString()),
        };

        return new TileSave("DirectionChangerTile", props);
    }

    public void Initialize(Vector2Int _position, Direction _direction)
    {
        position = _position;
        direction = _direction;
        SetRotation();
    }

    public void Initialize(int x, int y, Direction _direction)
    {
        Initialize(new Vector2Int(x, y), _direction);
        SetRotation();
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
            if (props[i].Key == "dir")
                direction = (Direction)Convert.ToInt32(props[i].Value);
        }
        SetRotation();
    }
}
