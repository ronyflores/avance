using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
   public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            //Categorias

            var categoria1 = new Categoria();
            categoria1.Descripcion = "Accion y aventura";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Deportes";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Disparos";
            contexto.Categorias.Add(categoria3);

            var categoria4 = new Categoria();
            categoria4.Descripcion = "Educativos";
            contexto.Categorias.Add(categoria4);

            //Ciudades

            var ciudad1 = new Ciudad();
            ciudad1.Descripcion = "Tegucigalpa";
            contexto.Ciudades.Add(ciudad1);

            var ciudad2 = new Ciudad();
            ciudad2.Descripcion = "San Pedro Sula";
            contexto.Ciudades.Add(ciudad2);

            var ciudad3 = new Ciudad();
            ciudad3.Descripcion = "Progreso";
            contexto.Ciudades.Add(ciudad3);

            var ciudad4 = new Ciudad();
            ciudad4.Descripcion = "La Lima";
            contexto.Ciudades.Add(ciudad4);

            // Tipos

            var Tipo1 = new Tipo();
            Tipo1.Descripcion = "Consolas";
            contexto.Tipos.Add(Tipo1);

            var Tipo2 = new Tipo();
            Tipo2.Descripcion = "Videos Juegos";
            contexto.Tipos.Add(Tipo2);

            var Tipo3 = new Tipo();
            Tipo3.Descripcion = "Accesorios";
            contexto.Tipos.Add(Tipo3);

            base.Seed(contexto);
        }
    }
}
