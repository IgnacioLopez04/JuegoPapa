using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Consola
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServicioWeb.ServiceClient serviceClient = new ServicioWeb.ServiceClient();
            ServicioWeb.Resultado resultado = new ServicioWeb.Resultado();
            
            List<int> listaRandoms = new List<int>();
            Random random = new Random();

            Console.WriteLine("Empieza el juego.");
            
            for(int i = 0; i < 5; i++)
            {
                listaRandoms.Add(random.Next(1, 7));
            }

            serviceClient.ObtenerNumeros(listaRandoms.ToArray());
            Console.WriteLine(resultado.Puntaje);
            Console.WriteLine(resultado.Descripcion);

            Console.WriteLine("Fin");

            Console.ReadKey();
            

        }
    }
}
