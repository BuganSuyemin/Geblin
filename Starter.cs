using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;


public class Starter : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject directionChangerPrefab;

    [SerializeField] private List<GameObject> tilePrefabs = new List<GameObject>();

    [SerializeField] private Sprite innerBackground;
    [SerializeField] private Sprite outerBackground;
    [SerializeField] private Sprite Border;

    private Camera mainCamera;

    private CameraPlacer cameraPlacer;
    private BackgroundCreator backgroundCreator;
    private LevelSerializer levelSerializer;

    private int margin = 10;
    [SerializeField] Vector2Int size = new Vector2Int(7, 8);

    private Level level;


    private void Start()
    {
        mainCamera = Camera.main;
        backgroundCreator = new BackgroundCreator(innerBackground, outerBackground, Border, size, mainCamera);
        cameraPlacer = new CameraPlacer(mainCamera, size, margin);
        levelSerializer = new LevelSerializer();

        CreateTestLevel();
    }

    public void ClearLevel()
    {
        level.ClearLevel();
    }

    public void SerializeLevel()
    {
        levelSerializer.SerializeLevel(level, @"1");
    }

    public void CreateLevel()
    {
        var levelSave = levelSerializer.DeserializeLevel(@"1");
        level = new GameObject("Root").AddComponent<Level>();

        var grid = new TileGrid(levelSave.width, levelSave.height);

        var player = Instantiate(PlayerPrefab).GetComponent<PlayerTile>();
        level.Initialize(grid, player);
        var levelParams = level.GetParameters();
        player.Initialize(levelSave.player, levelParams);

        for (int i = 0; i < levelSave.tiles.Count; i++)
        {
            var tileSave = levelSave.tiles[i];
            for (int j = 0; j < tilePrefabs.Count; j++)
            {
                if (tilePrefabs[j].GetComponent<ITile>().GetType().Name == tileSave.tileName)
                {
                    var tile = Instantiate(tilePrefabs[j]).GetComponent<ITile>();
                    tile.Initialize(tileSave, levelParams);
                    grid.AddTile(tile);
                }
            }
        }
    }

    private void CreateTestLevel()
    {

        var l = new GameObject("Root").AddComponent<Level>();
        level = l;
        var p = Instantiate(PlayerPrefab).GetComponent<PlayerTile>();
        var grid = new TileGrid(size);
        p.Initialize(1, 4, grid);

        var w = Instantiate(wallPrefab).GetComponent<WallTile>();
        w.Initialize(4, 3);
        grid.AddTile(w);

        var dch = Instantiate(directionChangerPrefab).GetComponent<DirectionChangerTile>();
        dch.Initialize(1, 6, Direction.DOWN);
        grid.AddTile(dch);

        l.Initialize(grid, p);
    }

    private void Update()
    {

        GameObject[] g = FindObjectsOfType<GameObject>();

        foreach (var item in g)
        {
            if (item.name == "BG")
                Destroy(item);
        }
        cameraPlacer.SetCamera();
        // backgroundCreator.SetBackground();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)size / 2 - new Vector2(0.5f, 0.5f), (Vector2)size);
    }
}
