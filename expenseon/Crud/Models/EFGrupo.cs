using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Crud.Models
{
    public class EFGrupo
    {
        public List<Grupo> Listar()
        {
            SqlConnection conexao = new SqlConnection();
            try
            {
                DataTable table = new DataTable();
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM GRUPO", conexao);
                da.Fill(table);
                return table.AsEnumerable()
                    .Select(g => new Grupo
                    {
                        Id = (int)g["Id"],
                        Nome = g["Nome"].ToString()


                    }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}