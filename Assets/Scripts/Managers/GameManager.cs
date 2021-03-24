using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int levelNumber = 0;

    public GameObject recipeContent;
    public GameObject recipeCardPrefab;

    public void OnEnable() {
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

        GameObject _newCard = Instantiate(recipeCardPrefab, recipeContent.transform);
        _newCard.transform.GetChild(0).GetComponent<Image>().sprite = details.icon;
        _newCard.transform.GetChild(1).GetComponent<TMP_Text>().text = details.name;
    }
}
