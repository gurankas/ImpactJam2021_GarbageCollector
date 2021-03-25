using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MotherNature : MonoBehaviour
{
    public Text text;
    public Color positiveColor, negativeColor;
    public Image speechBubble, arrow, character;

    private Sprite normal, happy, angry, worried;
    private Animator anim;

    // possible responses if player puts item in correct bin
    private Dictionary<string, Mood> positive_feedback = new Dictionary<string, Mood>()
    {
        {"Awesome job!", Mood.HAPPY},
        {"Thanks for saving our planet!", Mood.HAPPY},
        {"You're doing great!", Mood.HAPPY},
        {"Perfect!", Mood.HAPPY},
        {"You're doing so much better than those wasteful humans!", Mood.HAPPY},
        {"Thank you so much!", Mood.HAPPY}
    };

    // possible responses if player puts a TRASH item in the RECYCLE
    private Dictionary<string, Mood> recycle_negative_feedback = new Dictionary<string, Mood>()
    {
        {"Whoops!", Mood.WORRIED},
        {"Oh, no!", Mood.WORRIED},
        {"Ugh.", Mood.ANGRY},
        {"That could contaminate everything!", Mood.ANGRY},
        {"That's not supposed to go there.", Mood.WORRIED },
        {"Try again next time.", Mood.WORRIED},
        {"You can do better than that!", Mood.ANGRY}

    };

    // possible responses if player puts a RECYCLE item in the TRASH
    private Dictionary<string, Mood> trash_negative_feedback = new Dictionary<string, Mood>()
    {
        {"Whoops!", Mood.WORRIED},
        {"Oh, no!", Mood.WORRIED},
        {"Ugh.", Mood.ANGRY},
        {"You can do better than that!", Mood.ANGRY},
        {"Try again next time.", Mood.WORRIED},
        { "We don't have enough space in our landfills!", Mood.ANGRY},
        { "How wasteful.", Mood.WORRIED},
    };




    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        happy = Resources.Load<Sprite>("MotherNature/mothernature_happy");
        worried = Resources.Load<Sprite>("MotherNature/mothernature_worried");
        angry = Resources.Load<Sprite>("MotherNature/mothernature_angry");
        normal = Resources.Load<Sprite>("MotherNature/mothernature_normal");

       // GivePositiveFeedback();
       // GiveRecycleNegativeFeedback();
    }


    void OnEnable()
    {
        anim.Play("FadeIn");
    }



    // Update is called once per frame
    void Update()
    {

    }

    // Use when player is correct
    public void GivePositiveFeedback()
    {
        // select random feedback message
        int index = Random.Range(0, positive_feedback.Count - 1);
        text.text = positive_feedback.ElementAt(index).Key;
        UpdateAppearance(true, positive_feedback.ElementAt(index).Value);
    }

    // Use when player puts a TRASH item in the RECYCLE
    public void GiveNegativeFeedbackOnTrash()
    {
        // select random feedback message
        int index = Random.Range(0, recycle_negative_feedback.Count - 1);
        text.text = recycle_negative_feedback.ElementAt(index).Key;
        UpdateAppearance(false, recycle_negative_feedback.ElementAt(index).Value);
    }

    // Use when player puts a RECYCLE item in the TRASH
    public void GiveNegativeFeedbackOnRecycle()
    {
        // select random feedback message
        int index = Random.Range(0, trash_negative_feedback.Count - 1);
        text.text = trash_negative_feedback.ElementAt(index).Key;
        UpdateAppearance(false, trash_negative_feedback.ElementAt(index).Value);
    }

    public void UpdateAppearance(bool isPositive, Mood mood)
    {
        if (isPositive)
        {
            speechBubble.color = positiveColor;
            arrow.color = positiveColor;
        }
        else
        {
            speechBubble.color = negativeColor;
            arrow.color = negativeColor;
        }

        if (mood == Mood.HAPPY)
        {
            character.sprite = happy;
        }
        else if (mood == Mood.WORRIED)
        {
            character.sprite = worried;

        }
        else if (mood == Mood.ANGRY)
        {
            character.sprite = angry;
        }
        else
        {
            character.sprite = normal;
        }

    }
}

public enum Mood
{
    NORMAL,
    HAPPY,
    WORRIED,
    ANGRY,
}
