using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;
public class PanelBase : ScriptableObject
{
    public PanelType PanelType;
    public string PanelHeader;
}
[CreateAssetMenu(fileName = "Panel", menuName = "Assets/Create/Create Clinic Issues Panel", order = 2)]
public class ClinicPanelData : PanelBase
{
    public List<ClinicIssue> ClinicPanelItems;
}

[CreateAssetMenu(fileName = "Panel", menuName = "Assets/Create/Create Gender Panel", order = 1)]
public class GenderPanelData : PanelBase
{
    public List<GenderPanel> GenderPanelItems;
}

[Serializable]
public class GenderPanel
{
    public int ItemIndex;
    public string GenderText;
    public PatientGender gender;
}


[Serializable]
public class ClinicIssue
{
    public int ItemIndex;
    public string ItemText;
    public PatientClinicIssueType ClinicIssueType;
}
