using DAL.Model;
using Entities;
using Services.Cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UFP
{
    public class UsuarioDAL : IDAL<Entities.Usuario>
    {
        public Entities.Usuario Insert(Entities.Usuario entity)
        {
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_usuario_insert @nombre, @pass", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", entity.nombre);
                        cmd.Parameters.AddWithValue("@pass", entity.pass);
                        conn.Open();

                        entity.id = (int)cmd.ExecuteScalar();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public void Update(Entities.Usuario entity)
        {
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_usuario_update @nombre, @pass, @id", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre", entity.nombre);
                        cmd.Parameters.AddWithValue("@pass", entity.pass);
                        cmd.Parameters.AddWithValue("@id", entity.id);

                        conn.Open();

                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_usuario_delete @id", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", id);
                        conn.Open();

                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entities.Usuario GetById(int id)
        {
            Entities.Usuario usuario = new Entities.Usuario();

            using (var db = new DBGestion())
            {
                var list = (from u in db.Usuario
                            where u.id == id
                            select u).ToList();
                
                

                list.ForEach(o => usuario = new Entities.Usuario
                                                {
                                                    id = o.id,
                                                    nombre = o.nombre,
                                                    pass = o.pass
                                                });
            }

            return usuario;
        }
                
        public List<Entities.Usuario> List()
        {
            List<Entities.Usuario> listUsuarios = new List<Entities.Usuario>();

            using (var db = new DBGestion())
            {
                var list = (from u in db.Usuario
                            select u).ToList();

                list.ForEach(o => listUsuarios.Add(
                    new Entities.Usuario
                    { 
                        id = o.id,
                        nombre = o.nombre
                    }));
            }

            return listUsuarios;
        }


        public bool Login(Entities.Usuario entity)
        {
            try
            {
                using (SqlConnection conn = ConnectionBD.Instance().Conect())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_login @nombre, @pass", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@nombre",entity.nombre);
                        cmd.Parameters.AddWithValue("@pass", entity.pass);
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                LoginCache.idUser = reader.GetInt32(0);
                                LoginCache.nombreUser = reader.GetString(1);
                            }

                            return true;
                        }                            
                        else
                            return false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
