using EsXEmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsXEmployeeManager.Controllers
{
    public class EmpregadoController : Controller
    {
        IEmpregadoDataAccessLayer _empregadoDAL; 

        public EmpregadoController(IEmpregadoDataAccessLayer empregadoDAL)
        {
            _empregadoDAL = empregadoDAL;
        }

        [HttpGet]
        [Route("api/Empregado/GetAll")]
        public IEnumerable<Empregado> GetAll()
        {
            return _empregadoDAL.GetEmpregados();
        }

        [HttpGet]
        [Route("api/Empregado/Details/{id}")]
        public Empregado Details(int id)
        {
            return _empregadoDAL.GetEmpregadoDetails(id);
        }

        [HttpPost]
        [Route("api/Empregado/Create")]
        public int Create([FromBody] Empregado empregado)
        {
            return _empregadoDAL.AddEmpregado(empregado);
        }


    }
}
