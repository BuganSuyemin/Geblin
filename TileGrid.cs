using System.Collections.Generic;
using UnityEngine;

public class TileGrid
{
    private List<ITile> tiles = new List<ITile>();
    private Vector2Int size;

    public List<ITile> Tiles { get => tiles; set => tiles = value; }
    public Vector2Int Size { get => size; set => size = value; }

    

    public ITile TileAt(Vector2Int position)
    {
        foreach (var tile in tiles)
            if (tile.Position == position)
                return tile;
        return null;
    }
    
    public ITile TileAt(int x, int y)
    {
        return TileAt(new Vector2Int(x, y));
    }

    public bool IsAllowedPos(Vector2Int position)
    {
        return position.x >= 0 && position.y >= 0 && position.x < size.x && position.y < size.y;
    }

    public void AddTile(ITile tile)
    {
        tiles.Add(tile);
    }

    public TileGrid(int width, int height)
    {
        size = new Vector2Int(width, height);
    }

    public TileGrid(Vector2Int _size)
    {
        size = _size;
    }
}

