using GestorEmpleados.API.Models;
using Microsoft.EntityFrameworkCore;
using MiWebAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace MiWebAPI.Data
{
    public class EmpleadoData
    {

        private readonly string conexion;
        public EmpleadoData(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("CadenaSQL")!;
        }


        /// <summary>
        /// Consulta lista de empleados -------
        /// </summary>
        /// <returns></returns>
        public async Task<List<Compra>> GetCompra(string filtro)
        {
            List<Compra> lista = new List<Compra>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_selecciona", con);
                cmd.Parameters.AddWithValue("@Filtro", filtro);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Compra
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Producto = reader["Producto"].ToString(),                            
                            Cantidad = Convert.ToInt32(reader["Cantidad"]),
                            Precio = reader["Precio"].ToString(),
                            Total = Convert.ToInt32(reader["Total"]),
                            Subtotal = Convert.ToInt32(reader["Subtotal"]),
                            Cliente = reader["Cliente"].ToString()
                        });
                    }
                }
            }
            return lista;
        }


        /// <summary>
        /// Agrega un empleado
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public async Task<RespuestaDB> AddCompra(Compra objeto)
        {
            var resultado = new RespuestaDB();

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("sp_agregar_compra", con);
                cmd.Parameters.AddWithValue("@Producto", objeto.Producto);
                cmd.Parameters.AddWithValue("@Cantidad", objeto.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", objeto.Precio);
                cmd.Parameters.AddWithValue("@Total", objeto.Total);
                cmd.Parameters.AddWithValue("@Subtotal", objeto.Subtotal);
                cmd.Parameters.AddWithValue("@Cliente", objeto.Cliente);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        resultado.TipoError = Convert.ToInt32(reader["TipoError"]);
                        resultado.Mensaje = reader["Mensaje"].ToString();


                    }
                }
                
            }
            return resultado;
        }

        /// <summary>
        /// Actualiza un empleado
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public async Task<RespuestaDB> UpdateCompra(Compra objeto)
        {
            var resultado = new RespuestaDB();

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("sp_actualizar", con);
                cmd.Parameters.AddWithValue("@Id", objeto.Id);
                cmd.Parameters.AddWithValue("@Producto", objeto.Producto);
                cmd.Parameters.AddWithValue("@Cantidad", objeto.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", objeto.Precio);
                cmd.Parameters.AddWithValue("@Total", objeto.Total);
                cmd.Parameters.AddWithValue("@Subtotal", objeto.Subtotal);
                cmd.Parameters.AddWithValue("@Cliente", objeto.Cliente);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        resultado.TipoError = Convert.ToInt32(reader["TipoError"]);
                        resultado.Mensaje = reader["Mensaje"].ToString();


                    }
                }
                
            }
            return resultado;
        }

        /// <summary>
        /// Elimina un empleado
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public async Task<RespuestaDB> DeleteCompra(int Id)
        {
            var resultado = new RespuestaDB();

            using (var con = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("sp_eliminar", con);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        resultado.TipoError = Convert.ToInt32(reader["TipoError"]);
                        resultado.Mensaje = reader["Mensaje"].ToString();


                    }
                }

            }
            return resultado;
        }


    }
}
