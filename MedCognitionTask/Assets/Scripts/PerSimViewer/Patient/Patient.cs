using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;

[RequireComponent(typeof(Animator))]
public class Patient : MonoBehaviour, IPatient
{

    #region Unity Fields
    [SerializeField]
    float timeoutPerLoop = .25F;
    [SerializeField]
    PatientGender gender;
    #endregion
    #region Public Fields
    public Transform Transform => this.gameObject.transform;
    public Animator Animator => this.GetComponent<Animator>();
    public PatientGender PatientGender => this.gender;

    #endregion
    
    [ContextMenu("Test Animation 1")]
    public void TestAnimation1()
    {
        SetAnimation(PatientClinicIssueType.CoughtingWithHands);
    }
    [ContextMenu("Test Animation 2")]
    public void TestAnimation2()
    {
        SetAnimation(PatientClinicIssueType.ModerateRespiratoryDistress);
    }
    [ContextMenu("Test Animation 3")]
    public void TestAnimation3()
    {
        SetAnimation(PatientClinicIssueType.SevereRespiratoryDistressOne);
    }
    [ContextMenu("Test Animation 4")]
    public void TestAnimation4()
    {
        SetAnimation(PatientClinicIssueType.SevereRespiratoryDistessTwo);
    }

    #region Public Methods
    public void SetAnimation(PatientClinicIssueType patientClinicIssueType)
    {
        if (patientClinicIssueType == PatientClinicIssueType.None) { return; }
        Debug.Log($"Current Anim {patientClinicIssueType} index {(int)patientClinicIssueType}");
        StartCoroutine(SetAnimCoroutine((int)patientClinicIssueType));
        //change animation to target with in 5 sec
    }
    #endregion
    #region Private Methods
    IEnumerator SetAnimCoroutine(int index)
    {
        float currentval = Animator.GetFloat(anim_MotionSwicher);
        float stepval = .2F; // value between steps
        float targetval = index * stepval; //gets target value
        Debug.Log($"Target Vall step:{stepval} animindex:{index} target: {targetval}");
        while (targetval != currentval)
        {
            // sets float valoe closer to target value
            currentval = Mathf.MoveTowards(currentval, targetval, timeoutPerLoop);
            Animator.SetFloat(anim_MotionSwicher, currentval);
            yield return new WaitForSecondsRealtime(timeoutPerLoop);
        }
        Animator.SetFloat(anim_MotionSwicher, targetval);

    }
    #endregion
}
