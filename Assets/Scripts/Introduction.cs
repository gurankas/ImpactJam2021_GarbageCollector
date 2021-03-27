using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{

    public int currentIndex;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
       // anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            PlayNextClip();

        }

    }

    public void PlayNextClip()
    {
        anim.Play("Intro" + currentIndex.ToString());
    }
}
