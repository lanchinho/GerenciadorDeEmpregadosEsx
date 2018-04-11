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
        EmpregadoDataAccessLayer empDal = new EmpregadoDataAccessLayer();

        [HttpGet]
        [Route("api/Empregado/GetAll")]
        public IEnumerable<Empregado> GetAll()
        {
            return empDal.GetEmpregados();
        }

        [HttpGet]
        [Route("api/Empregado/Details/{id}")]
        public Empregado Details(int id)
        {
            return empDal.GetEmpregadoDetails(id);
        }

        [HttpPost]
        [Route("api/Empregado/Create")]
        public int Create([FromBody] Empregado empregado)
        {
            return empDal.AddEmpregado(empregado);
        }


    }
}
