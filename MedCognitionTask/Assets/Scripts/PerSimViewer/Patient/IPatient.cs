using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;

public interface IPatient 
{
    PatientGender PatientGender { get; }
    Transform Transform { get; }
    Animator Animator { get; }
    void SetAnimation(PatientClinicIssueType patientClinicIssueType);
}
