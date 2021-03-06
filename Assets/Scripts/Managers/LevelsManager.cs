using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelsManager : MonoBehaviour
{

    public static List<LevelInfo> allLevels = new List<LevelInfo>();




    private void Awake()
    {
        LevelInfo newLevel = new LevelInfo("Level 1", "Let's start with the basics! Remember how to dispose these materials, then press Play whenever you're ready.", 120f);
       // newLevel.addType(TrashManager.TRASHTYPE.MILK);
      //  newLevel.addType(TrashManager.TRASHTYPE.CEREAL);
        newLevel.addType(TrashManager.TRASHTYPE.MASON);
       // newLevel.addType(TrashManager.TRASHTYPE.SODA);
        newLevel.addType(TrashManager.TRASHTYPE.NEWSPAPER);

       // newLevel.addType(TrashManager.TRASHTYPE.PIZZA);
        newLevel.addType(TrashManager.TRASHTYPE.BANANA);
        newLevel.addType(TrashManager.TRASHTYPE.STRAW);
        newLevel.addType(TrashManager.TRASHTYPE.BAG);
        newLevel.addType(TrashManager.TRASHTYPE.WRAP);

        allLevels.Add(newLevel);

        newLevel = new LevelInfo("Level 2", "Learn how to dispose more types of materials!", 120f);
        newLevel.addType(TrashManager.TRASHTYPE.MILK);
        newLevel.addType(TrashManager.TRASHTYPE.CEREAL);
        newLevel.addType(TrashManager.TRASHTYPE.MASON);
        newLevel.addType(TrashManager.TRASHTYPE.SODA);
        newLevel.addType(TrashManager.TRASHTYPE.NEWSPAPER);

        newLevel.addType(TrashManager.TRASHTYPE.PIZZA);
        newLevel.addType(TrashManager.TRASHTYPE.BANANA);
        newLevel.addType(TrashManager.TRASHTYPE.STRAW);
        newLevel.addType(TrashManager.TRASHTYPE.BAG);
        newLevel.addType(TrashManager.TRASHTYPE.WRAP);

        allLevels.Add(newLevel);

        newLevel = new LevelInfo("Level 3", "This level is challenging!", 120f);
        newLevel.addType(TrashManager.TRASHTYPE.MILK);
        newLevel.addType(TrashManager.TRASHTYPE.CEREAL);
        newLevel.addType(TrashManager.TRASHTYPE.MASON);
        newLevel.addType(TrashManager.TRASHTYPE.SODA);
        newLevel.addType(TrashManager.TRASHTYPE.NEWSPAPER);

        newLevel.addType(TrashManager.TRASHTYPE.PIZZA);
        newLevel.addType(TrashManager.TRASHTYPE.BANANA);
        newLevel.addType(TrashManager.TRASHTYPE.STRAW);
        newLevel.addType(TrashManager.TRASHTYPE.BAG);
        newLevel.addType(TrashManager.TRASHTYPE.WRAP);

        allLevels.Add(newLevel);

    }


    public static LevelInfo getLevelDetails(int level)
    {
        return allLevels[level - 1];
    }
}


