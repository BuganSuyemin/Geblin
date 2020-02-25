using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LevelSave
{
    public int width;
    public int height;
    public TileSave player;
    public List<TileSave> tiles;


    public LevelSave(int _width, int _height, TileSave _player, List<TileSave> _tiles)
    {
        width = _width;
        height = _height;
        player = _player;
        tiles = _tiles;
    }
}
