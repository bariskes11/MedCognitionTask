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
