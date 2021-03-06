using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class InfoWindow : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text description;

    public GameObject cardDetailPrefab;
    public GameObject contentRecylable;
    public GameObject contentTrash;
    public GameObject playButton;


    public void addCardDetail(TrashManager.TRASHTYPE type)
    {
        TrashManager.itemDetails details = TrashManager.getDetails(type);

        GameObject content;
        if (details.category == TrashManager.TRASHCATS.RECYCLABLE)
        {
            content = contentRecylable;
        }
        else
        {
            content = contentTrash;
        }

        GameObject _newCard = Instantiate(cardDetailPrefab, content.transform);
        _newCard.transform.GetChild(0).GetComponent<Image>().sprite = details.icon;
        _newCard.transform.GetChild(1).GetComponent<TMP_Text>().text = details.name;
        _newCard.transform.GetChild(2).GetComponent<TMP_Text>().text = details.description;
    }


    public void CloseWindow()
    {
        for (int i = 0; i < contentRecylable.transform.childCount; i++)
        {
            Destroy(contentRecylable.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < contentTrash.transform.childCount; i++)
        {
            Destroy(contentTrash.transform.GetChild(i).gameObject);
        }

        this.gameObject.SetActive(false);
    }

}
