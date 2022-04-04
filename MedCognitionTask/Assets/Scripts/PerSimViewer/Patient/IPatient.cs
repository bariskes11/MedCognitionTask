using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;

// Main interface for getting data from patient
public interface IPatient 
{
    PatientGender PatientGender { get; }
    Transform Transform { get; }
    Animator Animator { get; }
    void SetAnimation(PatientClinicIssueType patientClinicIssueType);
}
