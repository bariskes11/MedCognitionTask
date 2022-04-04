using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;

/// <summary>
/// Manages Patients animations and data
/// </summary>
[RequireComponent(typeof(Animator))]
public class Patient : MonoBehaviour, IPatient
{
    #region Unity Fields
    //speed of animation change
    [SerializeField]
    float timeoutPerLoop = .001F;
    [SerializeField]
    PatientGender gender;
    #endregion
    #region Public Fields
    public Transform Transform => this.gameObject.transform;
    public Animator Animator => this.GetComponent<Animator>();
    public PatientGender PatientGender => this.gender;
    #endregion
    #region Public Methods
    public void SetAnimation(PatientClinicIssueType patientClinicIssueType)
    {
        if (patientClinicIssueType == PatientClinicIssueType.None) { return; }
        Debug.Log($"Current Anim {patientClinicIssueType} index {(int)patientClinicIssueType}");
        StartCoroutine(SetAnimCoroutine((int)patientClinicIssueType));
    }
    #endregion
    #region Private Methods
    /// <summary>
    /// Slowly switches between animations.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    IEnumerator SetAnimCoroutine(int index)
    {
        float currentval = Animator.GetFloat(anim_MotionSwicher);
        float stepval = .2F; // value between steps
        float targetval = index * stepval; //gets target value
        while (targetval != currentval)
        {
            // sets float value closer to target value
            currentval = Mathf.MoveTowards(currentval, targetval, timeoutPerLoop);
            Animator.SetFloat(anim_MotionSwicher, currentval);
            yield return new WaitForSecondsRealtime(timeoutPerLoop);
        }
        Animator.SetFloat(anim_MotionSwicher, targetval);
    }
    #endregion
}
