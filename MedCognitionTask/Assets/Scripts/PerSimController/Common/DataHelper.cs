using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;
/// <summary>
/// Used for parsing data from Server To clinet.
/// </summary>
public class DataHelper 
{
    public PatientGender GetGender(string val)
    {
        return (PatientGender)System.Enum.Parse(typeof(PatientGender), val);
    }
    public PatientClinicIssueType GetPatientClinicIssue(string val)
    {
        return (PatientClinicIssueType)System.Enum.Parse(typeof(PatientClinicIssueType), val);
    }

    

}
