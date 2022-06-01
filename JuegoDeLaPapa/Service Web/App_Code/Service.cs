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
    const int indiceRepetidos = 6;
    static int[] arrayResultados = new int[indiceRepetidos] {0,0,0,0,0,0};
    static int suma = 0;
    public Resultado ObtenerNumeros(List<int> numeros)
    { 
        EncontrarIgualdades(numeros);
        
        return ResultadoJuego(resultado);
    }

    private int[] EncontrarIgualdades(List<int> numeros) 
    {
        arrayNumerosNuevos = numeros.ToArray();

        for (int i = 0; i < arrayNumerosNuevos.Length; i++)
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
        for (int i = 0; i < arrayResultados.Length; i++)
            {
            if (arrayResultados[i] <= 2)
            {
                suma += (i * arrayResultados[i]) + valor;
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
                        resultado.Descripcion = "Sos re capo negrazo.";
                    }
                    else
                    {
                        resultado.Puntaje = SumarResultados(-20);
                        resultado.Descripcion = "Sos re capo negrazo.";
                    }
                }
                break;

            case 2:
                {
                    resultado.Puntaje = SumarResultados(0);
                    resultado.Descripcion = "Sos re capo negrazo." ;
                }
                break;

            case 3:
                {
                    resultado.Puntaje = SumarResultados(0);
                    resultado.Descripcion = "Sos re capo negrazo.";
                }
                break;

            case 4:
                {
                    resultado.Puntaje = SumarResultados(0);
                    resultado.Descripcion = "Sos re capo negrazo.";
                }
                break;

            default:
                {
                    resultado.Puntaje = SumarResultados(0);
                    resultado.Descripcion = "Sos re capo negrazo.";
                }
                break;
        }

        return resultado;
    } 

}
