using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;
/// <summary>
/// Base Class common for all panels
/// </summary>
public class PanelBase : ScriptableObject
{
    public PanelType PanelType;
    public string PanelHeader;
}

/// <summary>
/// Gender Panel Data Template
/// </summary>
[Serializable]
public class GenderPanel
{
    public int ItemIndex;
    public string GenderText;
    public PatientGender gender;
}

/// <summary>
/// Clinic Issue Panel Data Template
/// </summary>
[Serializable]
public class ClinicIssue
{
    public int ItemIndex;
    public string ItemText;
    public PatientClinicIssueType ClinicIssueType;
}
