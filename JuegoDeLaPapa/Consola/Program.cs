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
            
            
            
            Random random = new Random();
            int dadosPorLanzar = 6;

            Console.WriteLine("Empieza el juego.");
            

            while(dadosPorLanzar > 1)
            {
                List<int> listaRandoms = new List<int>();

                for (int i = 0; i < 5; i++)
                {
                    listaRandoms.Add(random.Next(1, dadosPorLanzar));
                }

                ServicioWeb.Resultado resultado = serviceClient.ObtenerNumeros(listaRandoms.ToArray());
                dadosPorLanzar = resultado.DadosPorLanzar;

                foreach (var lista in listaRandoms)
                {
                    Console.WriteLine(lista);
                }

                Console.WriteLine($"Puntaje: {resultado.Puntaje}");
                Console.WriteLine($"Cantidad de dados que se vuelven a lanzar: {dadosPorLanzar}");
                Console.WriteLine(resultado.Descripcion);
                
            }

            Console.WriteLine("Fin");

            Console.ReadKey();
            

        }
    }
}
