using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbagePile : Interactable
{

    private LevelInfo _levelInfo;
    private GameManager gameManager;

    public GameObject stinkyParticles;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _levelInfo = LevelsManager.getLevelDetails(gameManager.levelNumber);
    }

    public override void Interact(Transform other, Interactable otherObject, GameObject origin)
    {
        if (origin.GetComponent<PlayerController>()._currentPickupItem == null)
        {

            int randomTypeIndex = Random.Range(0, _levelInfo.trashItems.Count);
            int randomExtraIndex = Random.Range(-1, System.Enum.GetValues(typeof(Pickable.EXTRASTEPS)).Length);
            


            TrashManager.TRASHTYPE newTrash = _levelInfo.trashItems[randomTypeIndex];

            GameObject newPrefab = null;
            gameManager.trashtypePrefab.TryGetValue(newTrash, out newPrefab);

            if (newPrefab != null)
            {
                GameObject newItem = Instantiate(newPrefab, gameObject.transform);
                newItem.transform.localPosition = Vector3.zero;
                newItem.transform.SetParent(null);

                newItem.GetComponent<Pickable>().Interact(origin.GetComponent<PlayerController>()._hand, null, gameObject);
                newItem.GetComponent<Pickable>().Grounded = false;

                TrashManager.TRASHTYPE newTrashType = newItem.GetComponent<Pickable>().trashType;
                if (newTrashType.Equals(TrashManager.TRASHTYPE.CEREAL)
                    || newTrashType.Equals(TrashManager.TRASHTYPE.MILK)
                    || newTrashType.Equals(TrashManager.TRASHTYPE.PIZZA)
                    || newTrashType.Equals(TrashManager.TRASHTYPE.SODA))
                {
                    newItem.GetComponent<Pickable>().extraSteps.Add(Pickable.EXTRASTEPS.COMPRESSOR);
                }

                if (randomExtraIndex >= 0)
                {
                    if (!((Pickable.EXTRASTEPS)randomExtraIndex).Equals(Pickable.EXTRASTEPS.COMPRESSOR))
                    {
                        newItem.GetComponent<Pickable>().extraSteps.Add((Pickable.EXTRASTEPS)randomExtraIndex);
                        if (newItem.GetComponent<Pickable>().extraSteps.Contains(Pickable.EXTRASTEPS.SINK))
                        {
                            GameObject newStink = Instantiate(stinkyParticles, newItem.transform);
                            newStink.transform.localPosition = Vector3.zero;
                        }
                    }
                }

            }
        }
    }
}



