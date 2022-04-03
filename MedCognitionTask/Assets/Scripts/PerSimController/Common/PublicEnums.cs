using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PublicCommons
{
    // static room name for game
    public const string ROOMNAME = "ROOM1";
    // Prefab Name for generalresources 
    public enum ResourceItem
    {
        UIGenderItem,
        UIClinicalStateItem
    }
    public enum PanelType
    { 
    SelectGenderPanel,
    SelectClinicStatePanel
    }
}
