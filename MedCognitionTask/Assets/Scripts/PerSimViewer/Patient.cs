﻿using System.Collections;
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
    public Transform Transform => this.Transform;
    public Animator Animator => this.GetComponent<Animator>();
    public PatientGender patientGender => this.gender;
    #endregion
}