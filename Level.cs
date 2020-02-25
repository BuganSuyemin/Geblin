using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private TileGrid grid;
    private PlayerTile player;
    
    private int tick;
    private int updateTick = 20;

    public LevelSave CreateSave()
    {
        var list = new List<TileSave>();
        for (int i = 0; i < grid.Tiles.Count; i++)
            list.Add(grid.Tiles[i].CreateSave());

        return new LevelSave(grid.Size.x, grid.Size.y, player.CreateSave(), list);
    }

    public LevelParameters GetParameters()
    {
        return new LevelParameters(grid, updateTick);
    }

    public void Initialize(TileGrid _grid, PlayerTile _player)
    {
        grid = _grid;
        player = _player;
        player.transform.parent = this.transform;
        for (int i = 0; i < grid.Tiles.Count; i++)
            ((Component)grid.Tiles[i]).transform.parent = this.transform;
    }

    public void ClearLevel()
    {
        Destroy(player.gameObject);
        for (int i = 0; i < grid.Tiles.Count; i++)
            Destroy(((Component)grid.Tiles[i]).gameObject);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (tick == updateTick)
        {
            tick = 0;

            UpdateGameLogic();
        }
        tick++;
    }

    private void UpdateGameLogic()
    {
        player.UpdateTile();
        foreach (var tile in grid.Tiles)
        {
            tile.UpdateTile();
        }
    }
}
