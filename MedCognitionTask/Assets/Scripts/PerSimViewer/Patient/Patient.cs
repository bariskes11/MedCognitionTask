using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;

[RequireComponent(typeof(Animator))]
public class Patient : MonoBehaviour, IPatient
{

    #region Unity Fields
    [SerializeField]
    PatientGender gender;
    #endregion
    #region Public Fields
    public Transform Transform => this.gameObject.transform;
    public Animator Animator => this.GetComponent<Animator>();
    public PatientGender PatientGender => this.gender;

    public void SetAnimation(PatientClinicIssueType patientClinicIssueType)
    {
        //TO DO change animation to target with in 5 sec
    }
    #endregion


}
