
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

    #region Unity Methods
    private void Start()
    {
        EventManager.OnClientGenderSet.AddListener(GenderSet);
    }
    #endregion
    #region Private Methods
    void GenderSet(PatientGender gender)
    {
#if UNITY_EDITOR
        if (patients == null)
        {
            Debug.Log($"Patiens Aren't set!!");
        }
#endif
        var patient = patients.Where(x => x.GetComponent<IPatient>().PatientGender == gender).FirstOrDefault();
        Debug.Log($" Event Has Been Called for Gender {gender}");
        GameObject gmobj = Instantiate(patient.gameObject,spawnPoint);
        gmobj.transform.position = Vector3.zero;
        connectingCanvas.SetActive(false);
    }

    #endregion
}
