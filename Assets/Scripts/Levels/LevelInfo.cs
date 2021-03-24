using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo
{
    public string title;
    public string description;

    public List<TrashManager.TRASHTYPE> trashItems = new List<TrashManager.TRASHTYPE>();


    public LevelInfo(string _title, string _desc)
    {
        title = _title;
        description = _desc;
    }

    public void addType(TrashManager.TRASHTYPE type)
    {
        trashItems.Add(type);

    }
}
