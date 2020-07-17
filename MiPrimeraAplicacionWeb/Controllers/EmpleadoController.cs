using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimeraAplicacionWeb.Models;


namespace MiPrimeraAplicacionWeb.Controllers
{
    public class EmpleadoController : Controller
    {
        List<SelectListItem> ListaContrato = new List<SelectListItem>();

        // GET: Empleado


        public ActionResult Index()
        {
            List<EmpleadoCLS> ListEmpleado = null;

            using (var bd = new BDPasajeEntities())
            {
               
                ListEmpleado = (from empleado in bd.Empleado
                                join tipoUsuario in bd.TipoUsuario on empleado.IIDTIPOUSUARIO equals tipoUsuario.IIDTIPOUSUARIO
                                join tipoContrato in bd.TipoContrato on empleado.IIDTIPOCONTRATO equals tipoContrato.IIDTIPOCONTRATO
                                select new EmpleadoCLS
                                {
                                    iidEmpleado = empleado.IIDEMPLEADO,
                                    nombre = empleado.NOMBRE,
                                    apPaterno =empleado.APPATERNO,
                                    apMaterno = empleado.APMATERNO,
                                    nombreTipoUsuario= tipoUsuario.NOMBRE,
                                    nombreTipoContrato = tipoContrato.NOMBRE,
                                    fechaContrato = (DateTime) empleado.FECHACONTRATO
                                    



                                }).ToList();                
                                
            }
            ListarCombox();
                return View(ListEmpleado);
        }
        
        public ActionResult Agregar()
        {
            
            ListarCombox();
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(EmpleadoCLS recibo)
        {
            
         
           
            if (!ModelState.IsValid)
            {
                ListarCombox();
                return View(recibo);
            }
            using(var bd= new BDPasajeEntities())
            {
                Empleado oEmpleado = new Empleado();
                oEmpleado.NOMBRE = recibo.nombre;
                oEmpleado.APPATERNO = recibo.apPaterno;
                oEmpleado.APMATERNO = recibo.apMaterno;

                oEmpleado.FECHACONTRATO = recibo.fechaContrato;
                oEmpleado.SUELDO = recibo.sueldo;
                oEmpleado.IIDTIPOUSUARIO = recibo.iidtipoUsuario;
                oEmpleado.IIDTIPOCONTRATO = recibo.iidtipoContrato;
                oEmpleado.IIDSEXO = recibo.iidtipoSexo;
                oEmpleado.BHABILITADO = 1;

                bd.Empleado.Add(oEmpleado);
                bd.SaveChanges();

            }

            return RedirectToAction("Index");
        }


        //Métodos para llenar los formularios

        // Método para el combobox de Sexo.
        public void listarComboSexo()
        {
            //AGREGAR
            List<SelectListItem> ListaSexo;

            using(var bd = new BDPasajeEntities())
            {
                ListaSexo = (from sexo in bd.Sexo
                             where sexo.BHABILITADO==1
                             select new SelectListItem
                             {
                                 Text = sexo.NOMBRE,
                                 Value = sexo.IIDSEXO.ToString()

                             }).ToList();

                ListaSexo.Insert(0,new SelectListItem { Text = "--Seleccione Sexo--", Value ="" });

                SelectList lstSexo = new SelectList(ListaSexo, "Value", "text");

                ViewBag.listaSexo = lstSexo;
                

            }

            

        }

        // Método para el combobox de Tipo Contrato.
        public void listarComboContrato()
        {
            //AGREGAR
            
            using (var bd = new BDPasajeEntities())
            {
                ListaContrato = (from contrato in bd.TipoContrato
                             where contrato.BHABILITADO==1
                             select new SelectListItem
                             {
                                 Text = contrato.NOMBRE,
                                 Value = contrato.IIDTIPOCONTRATO.ToString()

                             }).ToList();

                ListaContrato.Insert(0, new SelectListItem { Text = "--Seleccione Contrato--", Value = "" });

                SelectList lstContrato = new SelectList(ListaContrato, "value", "text");

                ViewBag.lstContrato = lstContrato;


            }



        }

        // Método para el combobox de Tipo Usuario.
        public void listarComboTipoUsuario()
        {
            //AGREGAR
            List<SelectListItem> ListaUsuario;

            using (var bd = new BDPasajeEntities())
            {
                ListaUsuario = (from tipoUsuario in bd.TipoUsuario
                                 where tipoUsuario.BHABILITADO==1
                                 select new SelectListItem
                                 {
                                     Text = tipoUsuario.NOMBRE,
                                     Value = tipoUsuario.IIDTIPOUSUARIO.ToString()

                                 }).ToList();

                ListaUsuario.Insert(0, new SelectListItem { Text = "--Seleccione Tipo Usuario--", Value = "" });

                SelectList lstUsuario = new SelectList(ListaUsuario, "value", "text");
                ViewBag.ListaTipoUsuario = lstUsuario;


            }



        }

        //Método General para listar todos los Combox
        public void ListarCombox()
        {
            listarComboSexo();
            listarComboContrato();
            listarComboTipoUsuario();
        }
    }
}