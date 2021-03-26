using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonLoader : MonoBehaviour
{
    public Object levelSelectorScene;
    public GameObject levelInfoWindow;

    public Animator introObject;


    public void loadLevelSelector()
    {
        SceneManager.LoadScene(levelSelectorScene.name);
    }


    public void loadLevel(int level)
    {
        if(level == -1)
        {
            SceneManager.LoadScene("LevelTest");

        } else
        {
            SceneManager.LoadScene("Level" + level);

        }
    }

    public void showLevel(int level)
    {
        LevelInfo levelInfo = LevelsManager.getLevelDetails(level);

        levelInfoWindow.GetComponent<InfoWindow>().title.text = levelInfo.title;
        levelInfoWindow.GetComponent<InfoWindow>().description.text = levelInfo.description;

        UnityEngine.Events.UnityAction buttonCallback = () => loadLevel(level);
        Button playButton = levelInfoWindow.GetComponent<InfoWindow>().playButton.GetComponent<Button>();
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(buttonCallback);


        foreach (TrashManager.TRASHTYPE type in levelInfo.trashItems)
        {
            levelInfoWindow.GetComponent<InfoWindow>().addCardDetail(type);
        }

        levelInfoWindow.SetActive(true);
    }

    public void closeLevelWindow()
    {
        levelInfoWindow.SetActive(false);
    }

    public void skipIntro()
    {
        introObject.speed = 0f;
        introObject.Play("Intro0", 0, 10f);
    }
}
