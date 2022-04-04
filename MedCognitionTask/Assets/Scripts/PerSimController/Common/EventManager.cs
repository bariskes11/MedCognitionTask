using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static PublicCommons;

public static class EventManager
{
    public static PanelInteraction OnSelectedItem = new PanelInteraction();
}

public class PanelInteraction : UnityEvent<PatientGender, PatientClinicIssueType>
{
}

