using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    private static List<itemDetails> _typeToCatMap = new List<itemDetails>();


    public struct itemDetails
    {
        public TRASHTYPE trashtype;
        public string name;
        public TRASHCATS category;
        public string description;
        public int pointsPositive;
        public int pointsNegative;
        public Sprite icon;

        public itemDetails(TRASHTYPE _trashtype,
        string _name,
        TRASHCATS _category,
        string _description,
        int _pointsPositive,
        int _pointsNegative)
        {
            trashtype = _trashtype;
            name = _name;
            category = _category;
            description = _description;
            pointsPositive = _pointsPositive;
            pointsNegative = _pointsNegative;

            icon = Resources.Load<Sprite>("Icons/icon_" + _trashtype);
        }
    }

    private static void populateList()
    {
        _typeToCatMap.Add(new itemDetails(TRASHTYPE.MILK, "Milk carton", TRASHCATS.RECYCLABLE, "Paper / Needs rinsing", 200, 100));
        _typeToCatMap.Add(new itemDetails(TRASHTYPE.MASON, "Mason jar", TRASHCATS.RECYCLABLE, "Glass / Needs rinsing", 200, 100));
        _typeToCatMap.Add(new itemDetails(TRASHTYPE.CEREAL, "Cereal box", TRASHCATS.RECYCLABLE, "Cardboard", 200, 100));
        _typeToCatMap.Add(new itemDetails(TRASHTYPE.SODA, "Soda can", TRASHCATS.RECYCLABLE, "Aluminum / Needs rinsing", 200, 100));
        _typeToCatMap.Add(new itemDetails(TRASHTYPE.NEWSPAPER, "Newspaper", TRASHCATS.RECYCLABLE, "Paper", 200, 100));

        _typeToCatMap.Add(new itemDetails(TRASHTYPE.PIZZA, "Empty pizza box", TRASHCATS.TRASH, "Cardboard", 200, 100));
        _typeToCatMap.Add(new itemDetails(TRASHTYPE.BANANA, "Banana peel", TRASHCATS.TRASH, "Fruit", 200, 100));
        _typeToCatMap.Add(new itemDetails(TRASHTYPE.STRAW, "Plastic straw", TRASHCATS.TRASH, "Plastic", 200, 100));
        _typeToCatMap.Add(new itemDetails(TRASHTYPE.BAG, "Grocery bag", TRASHCATS.TRASH, "Plastic", 200, 100));
        _typeToCatMap.Add(new itemDetails(TRASHTYPE.WRAP, "Cling wrap", TRASHCATS.TRASH, "Plastic", 200, 100));
    }


    public static itemDetails getDetails(TRASHTYPE type)
    {
        if (!(_typeToCatMap.Count > 0)) populateList();
        
        foreach(itemDetails details in _typeToCatMap)
        {
            if (details.trashtype.Equals(type))
            {
                return details;
            }
        }

        return new itemDetails();
    }

    public static TRASHCATS getCategory(TRASHTYPE type)
    {
        if (!(_typeToCatMap.Count > 0)) populateList();

        itemDetails details = getDetails(type);
        return details.category;
    }

    public enum TRASHTYPE
    {
        MILK,
        MASON,
        CEREAL,
        SODA,
        NEWSPAPER,
        PIZZA,
        BANANA,
        STRAW,
        BAG,
        WRAP
    }
    public enum TRASHCATS
    {
        RECYCLABLE,
        TRASH
    }
}
