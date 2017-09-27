using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Crud.Models
{
    public class EFUsuario
    {
        public string Criar(Usuario usuario)
        {
            SqlConnection conexao = new SqlConnection();
            var cryp = System.Text.Encoding.UTF8.GetBytes(usuario.Senha);
            usuario.Senha = System.Convert.ToBase64String(cryp);
            try
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = "INSERT INTO Usuario(Nome, Grupo_Id, Login, Senha, Status) VALUES (@nome, @grupo, @login, @senha, @status)";
                cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@grupo", usuario.GrupoId);
                cmd.Parameters.AddWithValue("@login", usuario.Login);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@status", usuario.Status);
                cmd.Connection.Open();
                cmd.ExecuteScalar();
                cmd.Connection.Close();
                return "ok";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
        }
        public string Alterar(Usuario usuario)
        {
            SqlConnection conexao = new SqlConnection();
            var cryp = System.Text.Encoding.UTF8.GetBytes(usuario.Senha);
            usuario.Senha = System.Convert.ToBase64String(cryp);
            try
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = "UPDATE Usuario SET Nome = @nome, Grupo_Id = @grupo, Login = @login, Senha = @senha, Status = @status WHERE Id = " + usuario.Id;
                cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@grupo", usuario.GrupoId);
                cmd.Parameters.AddWithValue("@login", usuario.Login);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@status", usuario.Status);
                cmd.Connection.Open();
                cmd.ExecuteScalar();
                cmd.Connection.Close();
                return "ok";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
        }
        public string Deletar(Usuario usuario)
        {
            SqlConnection conexao = new SqlConnection();
            try
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao;
                cmd.CommandText = "DELETE Usuario WHERE Id = "+ usuario.Id;
                cmd.Connection.Open();
                cmd.ExecuteScalar();
                cmd.Connection.Close();
                return "ok";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        public List<Usuario> Listar()
        {

            SqlConnection conexao = new SqlConnection();
            try
            {
                DataTable table = new DataTable();
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                SqlDataAdapter da = new SqlDataAdapter("SELECT u.Id, u.Nome, u.Login, u.Status, g.Nome FROM USUARIO as u JOIN GRUPO g ON (u.Grupo_Id = g.Id)", conexao);
                da.Fill(table);
                return table.AsEnumerable()
                    .Select(u => new Usuario
                    {
                        Id = (int)u["Id"],
                        Nome = u["Nome"].ToString(),
                        GrupoNome = u["Nome1"].ToString(),
                        Login = u["Login"].ToString(),                        
                        Status = (bool)u["Status"]

                    }).ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public Usuario Buscar(int id)
        {
            SqlConnection conexao = new SqlConnection();
            try
            {
                DataTable table = new DataTable();
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();
                SqlDataAdapter da = new SqlDataAdapter("SELECT u.Id, u.Nome, u.Login, u.Status, u.Grupo_Id, g.Nome FROM USUARIO as u JOIN GRUPO g ON (u.Grupo_Id = g.Id) WHERE u.Id = " + id, conexao);
                da.Fill(table);
                
                var usuario = table.AsEnumerable()
                    .Select(u => new Usuario
                    {
                        Id = (int)u["Id"],
                        Nome = u["Nome"].ToString(),
                        GrupoId = (int)u["Grupo_Id"],
                        GrupoNome = u["Nome1"].ToString(),
                        Login = u["Login"].ToString(),
                        Status = (bool)u["Status"]

                    }).Single();
                
                return usuario;





            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}