using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LevelSerializer
{
    public void SerializeLevel(Level level, string fileName)
    {
        var directoryPath = Directory.GetCurrentDirectory() + @"\Assets\Levels\";
        var levelPath = Path.Combine(directoryPath, fileName);

        var levelSave = level.CreateSave();
        var formatter = new BinaryFormatter();

        var fs = new FileStream(levelPath, FileMode.OpenOrCreate);

        formatter.Serialize(fs, levelSave);

        fs.Close();
    }

    public LevelSave DeserializeLevel(string fileName)
    {
        var directoryPath = Directory.GetCurrentDirectory() + @"\Assets\Levels\";
        var levelPath = Path.Combine(directoryPath, @"1");

        var fs = new FileStream(levelPath, FileMode.OpenOrCreate);
        var formatter = new BinaryFormatter();

        var save = (LevelSave)formatter.Deserialize(fs);

        fs.Close();

        return save;
    }
}
