using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class ClientesBL
    {
        Contexto _contexto2;
       public BindingList<Cliente> ListaClientes { get; set; }
        public ClientesBL()
        {
            _contexto2 = new Contexto();
            ListaClientes = new BindingList<Cliente>();
        }
        
        public BindingList<Cliente> obtenerClientes()
        {
            _contexto2.Clientes.Load();
            ListaClientes = _contexto2.Clientes.Local.ToBindingList();

            return ListaClientes;
        }

        public void CancelarCambios() 
        {
            foreach(var item in _contexto2.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }


        public Resultado2 GuardarCliente(Cliente cliente)
        {
            var resultado = Validar(cliente);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }
            _contexto2.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarCliente()
        {
            var nuevocliente = new Cliente();
            ListaClientes.Add(nuevocliente);
        }

        public bool EliminarCliente(int id)
        {
            foreach (var cliente in ListaClientes)
            {
                if (cliente.Id == id)
                {
                    ListaClientes.Remove(cliente);
                    _contexto2.SaveChanges();
                    return true;
                }
            }

            return false;
        }
         
        private Resultado2 Validar(Cliente cliente)
        {
            var resultado = new Resultado2();
            resultado.Exitoso = true;

            if (cliente == null)
            {
                resultado.Mensaje = "Agregue un cliente valido";
                resultado.Exitoso = false;

                return resultado;
            }

            if (string.IsNullOrEmpty(cliente.Nombre) == true )
            {
                resultado.Mensaje = "Ingrese Nombres y Apellidos";
                resultado.Exitoso = false;
            }
                        
            if (string.IsNullOrEmpty(cliente.Direccion) == true)
            {
                resultado.Mensaje = "Ingrese Direccion Completa";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(cliente.Telefono) == true)
            {
                resultado.Mensaje = "Ingrese el numero de Telefono";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(cliente.Correo) == true)
            {
                resultado.Mensaje = "Ingrese el Correo electronico";
                resultado.Exitoso = false;
            }

            if (cliente.CiudadId==0)
            {
                resultado.Mensaje = "Ingrese una ciudad";
                resultado.Exitoso = false;
            }
            

            return resultado;
        }

    }
        public class Cliente
    {
        public int Id { get; set; }
        public string Nombre  { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int CiudadId { get; set; }
        public Ciudad  Ciudad { get; set; }
        public byte[] Foto { get; set; }
        public bool Activo { get; set; }
       

    }

    public class Resultado2
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
        }
