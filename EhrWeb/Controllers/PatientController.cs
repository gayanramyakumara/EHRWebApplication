using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EhrWeb.Models;
using EhrWeb.ViewModels;
using BLL.BLLDocuments;
using BLL.BLLInterfaces;
using BusinessEntity;
using Utility;
using System.Web.Http;

namespace EhrWeb.Controllers
{
    public class PatientController : Controller
    {
        IPatientDocument _document = new PatientDocument();

        // POST: Patient
        [System.Web.Http.HttpPost]
        public ActionResult Patient([FromBody]int? usertype)
        {
            try
            {
                Session["UserTypeID"] = usertype;
                int patientId = usertype==2? (int)Session["UserID"]: UtilityLibrary.GetValueInt(Session["PatientID"], 0);
                PatientModel model = new PatientModel();
                if (usertype == (int)CommonUnit.UserType.Patient)
                {
                    Patient result = _document.GetPatientById(patientId);
                    model = Mappings.MapPatient(result);
                    return View("Patient", model);
                }
                else if (usertype == (int)CommonUnit.UserType.Staff)
                {
                    return View("Patient", model);
                }
                else
                {
                    ViewBag.Error = "User type is invalid !";
                    return RedirectToAction("Login", "Login", CommonUnit.UserType.Staff);
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "User type is invalid !";
                return RedirectToAction("Login", "Login", CommonUnit.UserType.Staff);
            }
        }

        /*
        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
        [System.Web.Http.HttpPost]
        public ActionResult Details(int id, FormCollection collection)
        {
            return View();
        }*/

        // GET: Patient/Create
        public ActionResult Create()
        {
            PatientModel model = new PatientModel();
            model.Address = new AddressModel();
            return View("Patient", model);
        }

        // POST: Patient/Save
        [System.Web.Http.HttpPost]
        public ActionResult Save(PatientModel patientModel)
        {
            try
            {
                Patient patient = _document.SavePatient(Mappings.MapPatient(patientModel));
                if (patient != null)
                {
                    //PatientModel model = Mappings.MapPatient(patient);
                    //return View("Patient", model);
                    Session["PatientID"] = patient.PatientId;
                }
                return RedirectToAction("Patient","Patient",new { usertype= (int)Session["UserTypeID"] });
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Patient/Edit/5
        /*public ActionResult Edit(int id)
        {
            try
            {
                PatientModel model = new PatientModel();
                Patient result = _document.GetPatientById(id);
                model = Mappings.MapPatient(result);
                return View("Patient", model);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }*/

        // POST: Patient/Edit/5
        [System.Web.Http.HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Patient patient = _document.GetPatientById(id);
                PatientModel model = Mappings.MapPatient(patient);
                return View("Patient", model);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: Patient/Delete/5
        [System.Web.Http.HttpPost]
        public ActionResult Delete([FromBody]int id)
        {
            try
            {
                bool deleted = _document.DeletePatient(id);
                return RedirectToAction("PatientList","Patient");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /*
        // POST: Patient/Delete/5
        [System.Web.Http.HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                bool deleted = _document.DeletePatient(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        */

        // GET: Patient/GetCollection
        public ActionResult PatientList()
        {
            try
            {
                List<Patient> col = _document.GetPatientCollection();
                PatientListViewModel model = new PatientListViewModel();
                model.PatientCollection = col;
                return View("PatientList", model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "User type is invalid !"+Environment.NewLine+ ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
