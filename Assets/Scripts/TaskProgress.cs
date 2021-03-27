using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskProgress : MonoBehaviour
{
    public float taskDuration = 10f; 
    public Slider slider;
    private float timePassed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void OnEnable()
    {
        timePassed = 0;
        slider.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timePassed < taskDuration)
        {
            timePassed += Time.deltaTime;
        }

        slider.value = 1f - (timePassed / taskDuration);

        if (slider.value == 0)
        {
            this.transform.parent.gameObject.SetActive(false);
        } 
    }
}
