

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class ProveedoresBL
    {
        Contexto _contexto;
        public BindingList<Proveedor> ListaProveedores { get; set; }
        public ProveedoresBL()
        {
            _contexto = new Contexto();
            ListaProveedores = new BindingList<Proveedor>();

            
        }
        public BindingList<Proveedor> obtenerProveedores()
        {
            _contexto.Proveedores.Load();
            ListaProveedores = _contexto.Proveedores.Local.ToBindingList();
            return ListaProveedores;
        }
        public Resultado3 GuardarProveedor(Proveedor proveedor)
        {
            var resultado = Validar(proveedor);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }
            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarProveedor()
        {
            var nuevoProveedor = new Proveedor();
            ListaProveedores.Add(nuevoProveedor);
        }

        public bool EliminarProveedor(int id)
        {
            foreach (var proveedor in ListaProveedores)
            {
                if (proveedor.Id == id)
                {
                    ListaProveedores.Remove(proveedor);
                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        private Resultado3 Validar(Proveedor proveedor)
        {
            var resultado = new Resultado3();
            resultado.Exitoso = true;

            if (proveedor == null)
            {
                resultado.Mensaje = "Agregue un proveedor valido";
                resultado.Exitoso = false;

                return resultado;
            }

            if (string.IsNullOrEmpty (proveedor.Nombre)== true)
            {
                resultado.Mensaje = "ingrese el nombre del proveedor";
                resultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(proveedor.Telefono) == true)
            {
                resultado.Mensaje = "ingrese el de telefono";
                resultado.Exitoso = false;

            }

            if (string.IsNullOrEmpty(proveedor.Correo) == true)
            {
                resultado.Mensaje = "ingrese el correo electronico";
                resultado.Exitoso = false;

            }

            if (string.IsNullOrEmpty(proveedor.Direccion) == true)
            {
                resultado.Mensaje = "ingrese la direccion completa";
                resultado.Exitoso = false;

            }
            return resultado;
        }
    }
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    }

    public class Resultado3
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }


}
