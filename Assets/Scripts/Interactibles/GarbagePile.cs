using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbagePile : Interactable
{

    private LevelInfo _levelInfo;
    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _levelInfo = LevelsManager.getLevelDetails(gameManager.levelNumber);
    }

    public override void Interact(Transform other, Interactable otherObject, GameObject origin)
    {
        int randomIndex = Random.Range(0, _levelInfo.trashItems.Count);

        TrashManager.TRASHTYPE newTrash = _levelInfo.trashItems[randomIndex];

        GameObject newPrefab = null;
        gameManager.trashtypePrefab.TryGetValue(newTrash, out newPrefab);

        if(newPrefab != null)
        {
            GameObject newItem = Instantiate(newPrefab, origin.transform);
            newItem.transform.SetParent(null);/*
            newItem.transform.position = origin.GetComponent<PlayerController>()._hand.transform.position;
            origin.GetComponent<PlayerController>().SetPickupItem(newItem);*/
        }
    }
}



