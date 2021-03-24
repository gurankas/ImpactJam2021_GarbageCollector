using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelsManager : MonoBehaviour
{

    public static List<LevelInfo> allLevels = new List<LevelInfo>();




    private void Awake()
    {
        LevelInfo newLevel = new LevelInfo("Level 1", "Interesting lore of first level");
        newLevel.addType(TrashManager.TRASHTYPE.MILK);
        newLevel.addType(TrashManager.TRASHTYPE.BAG);
        newLevel.addType(TrashManager.TRASHTYPE.MASON);
        newLevel.addType(TrashManager.TRASHTYPE.STRAW);
        newLevel.addType(TrashManager.TRASHTYPE.WRAP);

        allLevels.Add(newLevel);

        newLevel = new LevelInfo("Level 2", "Interesting lore of second level");
        newLevel.addType(TrashManager.TRASHTYPE.MILK);

        allLevels.Add(newLevel);

        newLevel = new LevelInfo("Level 3", "Interesting lore of third level");
        newLevel.addType(TrashManager.TRASHTYPE.BAG);

        allLevels.Add(newLevel);

    }


    public static LevelInfo getLevelDetails(int level)
    {
        return allLevels[level - 1];
    }
}


