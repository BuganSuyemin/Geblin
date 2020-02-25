using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTile : MonoBehaviour, ITile
{
    private Vector2Int position;
    private Vector2Int prevPosition;
    private bool moving;
    private Direction direction;
    private TileGrid grid;

    public Vector2Int Position { get => position; set => position = value; }


    private void Update()
    {
        transform.position = (Vector2)position;
    }

    public void UpdateTile()
    {
        prevPosition = position;
        if (moving)
        {
            switch (direction)
            {
                case Direction.UP:
                    position += Vector2Int.up;
                    break;
                case Direction.RIGHT:
                    position += Vector2Int.right;
                    break;
                case Direction.DOWN:
                    position += Vector2Int.down;
                    break;
                case Direction.LEFT:
                    position += Vector2Int.left;
                    break;
                default:
                    break;
            }
        }

        if (!grid.IsAllowedPos(position))
            StopMovement();

        if (grid.TileAt(position) is WallTile)
            StopMovement();

        if (grid.TileAt(position) is DirectionChangerTile)
            direction = (grid.TileAt(position) as DirectionChangerTile).Dir;
    }

    public void StartMovement(Direction _direction)
    {
        if (!moving)
        {
            direction = _direction;
            moving = true;
        }
    }

    private void StopMovement()
    {
        position = prevPosition;
        moving = false;
    }

    public TileSave CreateSave()
    {
        var props = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("x", position.x.ToString()),
            new KeyValuePair<string, string>("y", position.y.ToString()),
        };

        return new TileSave("PlayerTile", props);
    }

    public void Initialize(Vector2Int _position, TileGrid _grid)
    {
        position = _position;
        grid = _grid;
    }

    public void Initialize(int x, int y, TileGrid _grid)
    {
        position = new Vector2Int(x, y);
        grid = _grid;
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
        grid = levelParameters.Grid;
    }
}
