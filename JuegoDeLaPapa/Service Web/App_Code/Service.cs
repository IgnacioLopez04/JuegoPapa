using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    private int[] arrayNumerosDados = new int[] { 1, 2, 3, 4, 5, 6 };
    static int[] arrayNumerosNuevos = new int[] { };
    const int indiceRepetidos = 7;
    static int[] arrayResultados = new int[indiceRepetidos] {0,0,0,0,0,0,0};
    static int suma = 0;
    public Resultado ObtenerNumeros(List<int> numeros)
    {
        Resultado resultado = new Resultado();

        EncontrarIgualdades(numeros);

        return ResultadoJuego(resultado);
    }

    private int[] EncontrarIgualdades(List<int> numeros) 
    {
        arrayNumerosNuevos = numeros.ToArray();

        for (int i = 0; i < indiceRepetidos - 1; i++)
        {
            for (int j = 0; j < arrayNumerosNuevos.Length; j++)
            {
                if (arrayNumerosDados[i] == arrayNumerosNuevos[j])
                {
                    arrayResultados[arrayNumerosDados[i] - 1] += 1;
                }
            }

            if(arrayResultados[i] >= 2)
            {
                arrayResultados[indiceRepetidos - 1] += arrayResultados[i];
            }
        }

        return arrayResultados;
    }

    private int SumarResultados(int valor)
    {
        return suma + valor;
    }
    private int SumarResultados()
    {
        for (int i = 0; i < arrayResultados.Length - 1; i++)
        {
            if (arrayResultados[i] >= 2)
            {
                suma += ((i + 1) * arrayResultados[i]);
            }
        }

        return suma;
    }

    private Resultado ResultadoJuego(Resultado resultado)
    {

        switch (arrayResultados[indiceRepetidos - 1])
        {
            case 0:
                {
                    if (arrayNumerosNuevos.ToList().Contains(1) && !arrayNumerosNuevos.ToList().Contains(6) || arrayNumerosNuevos.ToList().Contains(6) && !arrayNumerosNuevos.ToList().Contains(1))
                    {
                        resultado.Puntaje = SumarResultados(20);
                        resultado.Descripcion = "Ganaste. Volve a lanzar.";
                        resultado.DadosPorLanzar = 5;
                    }
                    else
                    {
                        resultado.Puntaje = SumarResultados(-20);
                        resultado.Descripcion = "Perdiste.";
                        resultado.DadosPorLanzar = 0;
                    }
                }
                break;

            case 2:
                {
                    resultado.Puntaje = SumarResultados();
                    resultado.Descripcion = "Ganaste. Volve a lanzar.";
                    resultado.DadosPorLanzar = 3;
                }
                break;

            case 3:
                {
                    resultado.Puntaje = SumarResultados();
                    resultado.Descripcion = "Ganaste. Volve a lanzar.";
                    resultado.DadosPorLanzar = 2;
                }
                break;

            case 4:
                {
                    resultado.Puntaje = SumarResultados();
                    resultado.Descripcion = "Perdiste pero sumaste puntos.";
                    resultado.DadosPorLanzar = 1;
                }
                break;

            case 5:
                {
                    resultado.Puntaje = SumarResultados();
                    resultado.Descripcion = "Ganaste. Volve a lanzar.";
                    resultado.DadosPorLanzar = 0;
                }
                break;

            default:
                {
                    resultado.Puntaje = SumarResultados();
                    resultado.Descripcion = "Perdiste";
                }
                break;
        }

        return resultado;
    } 

}
