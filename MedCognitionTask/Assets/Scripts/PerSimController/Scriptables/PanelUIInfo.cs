using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;

[CreateAssetMenu(fileName = "Panel", menuName = "Assets/Create/Create Panel", order = 1)]
public class PanelUIInfo : ScriptableObject
{
    public PanelType PanelType;
    public string PanelHeader;
    public string[] PanelItemList;
}
