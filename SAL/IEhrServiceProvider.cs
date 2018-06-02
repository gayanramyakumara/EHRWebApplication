using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAL
{
    public interface IEhrServiceProvider
    {
        /// <summary>
        /// validate login credentials of patient member
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>PatientID</returns>
        int CheckPatientLogin(Credentials credentials);

        /// <summary>
        /// validate login credentials of staff member
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>StaffID</returns>
        int CheckStaffLogin(Credentials credentials);

        /// <summary>
        /// Deactivate patient
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        bool DeletePatient(int patientId);

        /// <summary>
        /// Get patient by PatientId or PIn
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Patient GetPatient(string value);

        /// <summary>
        /// Get patient by PatientId
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Patient GetPatientById(int patientId);

        /// <summary>
        /// Get patient by PIN
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        Patient GetPatientByPin(string pin);

        /// <summary>
        /// Get Patient Collection
        /// </summary>
        /// <returns></returns>
        List<Patient> GetPatientCollection();

        /// <summary>
        /// Insert/Update patinet and return full atient objact
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        Patient SavePatient(Patient patient);
    }
}
