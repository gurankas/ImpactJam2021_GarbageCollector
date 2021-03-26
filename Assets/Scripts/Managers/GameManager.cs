using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float gameTime = 300f;
    private float _remainingTime;
    private float _slideValue;

    [HideInInspector]
    public int score;

    public Slider slidingBar;
    public Text scoreText;

    public int levelNumber = 0;

    public GameObject recyclableList, trashList, recipeCardPrefab;

    public void Start() {
        if(levelNumber == 0)
        populateReceipeList();

        _remainingTime = gameTime;
    }

    private void Update()
    {
        if(_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;

            _slideValue = _remainingTime / gameTime;

            slidingBar.value = _slideValue;
        } else
        {
            Debug.Log("Game Over");
        }

        scoreText.text = score.ToString();
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
