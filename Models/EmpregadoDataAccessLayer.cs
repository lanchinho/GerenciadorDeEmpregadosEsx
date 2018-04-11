using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsXEmployeeManager.Models
{
    public class EmpregadoDataAccessLayer
    {
        //TODO: POr minha connection string aqui...
        string connectionString = @"Data Source=PC-GUILHERME;Initial Catalog=DB_Empregado;Integrated Security=True";

        public IEnumerable<Empregado> GetEmpregados()
        {
            try
            {
                List<Empregado> empregadoList = new List<Empregado>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetEmpregados", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Empregado empregado = new Empregado();

                        empregado.Id = Convert.ToInt32(reader["ID"]);
                        empregado.Nome = reader["Nome"].ToString();
                        empregado.SalarioBruto = Convert.ToDecimal(reader["SalarioBruto"]);
                        empregado.SalarioLiquido = Convert.ToDecimal(reader["SalarioLiquido"]);
                        empregado.FaixaImposto = reader["FaixaImposto"].ToString();

                        empregadoList.Add(empregado);
                    }

                    con.Close();
                }

                return empregadoList;
            }
            catch
            {
                throw;
            }


        }

        public int AddEmpregado (Empregado empregado)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmpregado", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nome", empregado.Nome);
                    cmd.Parameters.AddWithValue("@SalarioBruto", empregado.SalarioBruto);

                    decimal salarioLiquido = empregado.CalculaSalarioLiquido();

                    cmd.Parameters.AddWithValue("@SalarioLiquido", salarioLiquido);
                    cmd.Parameters.AddWithValue("@FaixaImposto", empregado.FaixaImposto);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return 1;
            }
            catch
            {
                throw;
            }
            
        }

        public Empregado GetEmpregadoDetails (int id)
        {
            try
            {
                Empregado empregado = new Empregado();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM Empregado WHERE ID = " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        empregado.Id = Convert.ToInt32(reader["ID"]);
                        empregado.Nome = reader["Nome"].ToString();
                        empregado.SalarioBruto = Convert.ToDecimal(reader["SalarioBruto"]);
                        empregado.SalarioLiquido = Convert.ToDecimal(reader["SalarioLiquido"]);
                        empregado.FaixaImposto = reader["FaixaImposto"].ToString();
                    }
                }

                return empregado;
            }
            catch
            {
                throw;
            }
        }
    }
}

