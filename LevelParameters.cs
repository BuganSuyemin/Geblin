using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelParameters  
{
    public TileGrid Grid;
    public int TickTime;

    public LevelParameters(TileGrid grid, int tickTime)
    {
        Grid = grid;
        TickTime = tickTime;
    }
}
