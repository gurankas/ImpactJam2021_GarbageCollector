using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo
{
    public string title;
    public string description;
    public int gameTime;

    public List<TrashManager.TRASHTYPE> trashItems = new List<TrashManager.TRASHTYPE>();


    public LevelInfo(string _title, string _desc, int _gameTime)
    {
        title = _title;
        description = _desc;
        gameTime = _gameTime;
    }

    public void addType(TrashManager.TRASHTYPE type)
    {
        trashItems.Add(type);

    }
}
