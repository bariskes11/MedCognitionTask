using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static PublicCommons;

public static class EventManager
{
    public static PatientGenderInteraction OnSelectedGender = new PatientGenderInteraction();
}

public class PatientGenderInteraction : UnityEvent<PatientGender, PanelType>
{

}
