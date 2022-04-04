
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static PublicCommons;
public class ViewerManager : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    GameObject connectingCanvas;
    [SerializeField]
    List<Patient> patients;
    [SerializeField]
    Transform spawnPoint;
    #endregion

    #region Fields
    GameObject currentPatient;
    #endregion
    #region Unity Methods
    private void Start()
    {
        connectingCanvas.SetActive(true);
#if UNITY_EDITOR
        if (patients == null)
        {
            Debug.Log($"Patiens Aren't set!!");
        }
#endif
        EventManager.OnClientGenderSet.AddListener(GenderSet);
        EventManager.OnClinicIssueChange.AddListener(ClinicIssueSet);
    }
    [ContextMenu("Create Man")]
    void TestGender()
    {
        GenderSet(PatientGender.Male);
    }
    #endregion
    #region Private Methods
    public void GenderSet(PatientGender gender)
    {
       connectingCanvas.SetActive(false);
        Debug.Log($" Event Has Been Called for Gender {gender}");
        if (this.spawnPoint.GetComponentInChildren<IPatient>() != null) // destrot previus patient
        {
            Destroy(this.spawnPoint.GetComponentInChildren<IPatient>().Transform.gameObject);
        }
        var patient = patients.Where(x => x.GetComponent<IPatient>().PatientGender == gender).FirstOrDefault();
        
        currentPatient = Instantiate(patient.gameObject, spawnPoint);
        currentPatient.transform.position = Vector3.zero;
        
    }
    void ClinicIssueSet(PatientClinicIssueType clinicIssue)
    {
        if (clinicIssue == PatientClinicIssueType.None) { return; }
        currentPatient.GetComponent<IPatient>().SetAnimation(clinicIssue);
    }
    #endregion
}
