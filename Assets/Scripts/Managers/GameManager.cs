using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int levelNumber = 0;

    public GameObject recyclableList;
    public GameObject trashList;
    public GameObject recipeCardPrefab;

    public void Start() {
        populateReceipeList();
    }

    public void populateReceipeList()
    {
        LevelInfo levelInfo = LevelsManager.getLevelDetails(levelNumber);


        foreach (TrashManager.TRASHTYPE type in levelInfo.trashItems)
        {
            addCardDetail(type);
        }
    }


    public void addCardDetail(TrashManager.TRASHTYPE type)
    {
        TrashManager.itemDetails details = TrashManager.getDetails(type);
        GameObject content;
        if (details.category == TrashManager.TRASHCATS.RECYCLABLE)
        {
            content = recyclableList;
        }
        else
        {
            content = trashList;
        }

        GameObject _newCard = Instantiate(recipeCardPrefab, content.transform);
        _newCard.transform.GetChild(0).GetComponent<Image>().sprite = details.icon;
        _newCard.transform.GetChild(1).GetComponent<TMP_Text>().text = details.name;
    }
}
