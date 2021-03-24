using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashClass
{
    public TRASHCAT category;
    public TRASHTYPE type;

    public TrashClass(TRASHTYPE _type)
    {
        if(_type == TRASHTYPE.MILK ||
        _type == TRASHTYPE.MASON ||
        _type == TRASHTYPE.CEREAL ||
        _type == TRASHTYPE.SODA ||
        _type == TRASHTYPE.NEWSPAPER)
        {
            category = TRASHCAT.RECYCLABLE;
        } else
        {
            category = TRASHCAT.TRASH;
        }
        type = _type;
    }

    public enum TRASHCAT
    {
        RECYCLABLE,
        TRASH
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
}
