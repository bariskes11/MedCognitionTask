using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static PublicCommons;

public static class EventManager
{
    public static PanelInteraction OnSelectedItem = new PanelInteraction();
    public static ClientGenderSet OnClientGenderSet = new ClientGenderSet();
    public static ClientClinicIssueChange OnClinicIssueChange = new ClientClinicIssueChange();
}

public class PanelInteraction : UnityEvent<PatientGender, PatientClinicIssueType>
{
}
public class ClientGenderSet : UnityEvent<PatientGender>
{
}
public class ClientClinicIssueChange : UnityEvent<PatientClinicIssueType>
{
}
