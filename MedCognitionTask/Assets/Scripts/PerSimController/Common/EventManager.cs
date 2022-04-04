using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static PublicCommons;
/// <summary>
/// Anykind of event can be added to this manager and
/// Listeners can invoke events.
/// </summary>
public static class EventManager
{
    /// <summary>
    /// Creates events for any interaction in panel 
    /// </summary>
    public static PanelInteraction OnSelectedItem = new PanelInteraction();
}

public class PanelInteraction : UnityEvent<PatientGender, PatientClinicIssueType>
{
}

