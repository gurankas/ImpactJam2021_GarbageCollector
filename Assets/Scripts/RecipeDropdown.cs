using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDropdown : MonoBehaviour
{
    public GameObject scrollView;
    public GameObject scrollContent;

    private bool _opened;

    public void openRecipes()
    {
        if (!_opened)
        {
            scrollView.transform.Translate(new Vector3(0, -((RectTransform)scrollContent.transform).rect.height, 0));
            _opened = true;
        } else
        {
            scrollView.transform.Translate(new Vector3(0, ((RectTransform)scrollContent.transform).rect.height, 0));
            _opened = false;
        }
    }
}
