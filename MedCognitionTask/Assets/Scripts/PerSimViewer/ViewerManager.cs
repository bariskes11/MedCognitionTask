
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static PublicCommons;
using TMPro;

public class ViewerManager : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    GameObject connectingCanvas;
    [SerializeField]
    List<Patient> patients;
    [SerializeField]
    Transform spawnPoint;
    // for detecting  current animation name (test)
    [SerializeField]
    TextMeshProUGUI txtCurrentAnimName;
    #endregion
    #region Fields
    GameObject currentPatient;
    #endregion
    #region Unity Methods
    private void Start()
    {
        txtCurrentAnimName.text = string.Empty;
        connectingCanvas.SetActive(true);
        #if UNITY_EDITOR
        if (patients == null)
        {
            Debug.Log($"Patiens Aren't set!!");
        }
        #endif
    }
    #endregion
    #region Public Methods
    /// <summary>
    /// Creates Patient in Viewers scene
    /// </summary>
    /// <param name="gender"></param>
    public void GenderSet(PatientGender gender)
    {
        if (gender == PatientGender.None) { return; }
        connectingCanvas.SetActive(false);
        if (this.spawnPoint.GetComponentInChildren<IPatient>() != null) // destrot previus patient
        {
            Destroy(this.spawnPoint.GetComponentInChildren<IPatient>().Transform.gameObject);
        }
        var patient = patients.Where(x => x.GetComponent<IPatient>().PatientGender == gender).FirstOrDefault();
        currentPatient = Instantiate(patient.gameObject, spawnPoint);
        currentPatient.transform.position = Vector3.zero;
    }
    /// <summary>
    /// Sets Animation based on clinic Issue
    /// </summary>
    /// <param name="clinicIssue"></param>
    public void ClinicIssueSet(PatientClinicIssueType clinicIssue)
    {
        txtCurrentAnimName.text = $"Current Animation Name  : {clinicIssue} ";
        if (clinicIssue == PatientClinicIssueType.None) { return; }
        currentPatient.GetComponent<IPatient>().SetAnimation(clinicIssue);
    }
    #endregion
}
