using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento; // lanza eventos cuando se va a terminar la ejecucion del programa
            //siempre y cuando el flujo sea normal es decir sin lanzar excepciones. esto
            //funciona como un delegado
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(2000, 1000, 1); // sobrecargar el metodo con una expresion lambda
            // para que le sume algo mas al metodo

            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            //Printer.Beep(10000, cantidad: 10);
            //ImpimirCursosEscuela(engine.Escuela);
            Dictionary<int, string> dicccionario = new Dictionary<int, string>();

            dicccionario.Add(10, "JuanK");

            dicccionario.Add(23, "Lorem Ipsum");

            foreach (var keyValPair in dicccionario) // KeyValPair es par llave valor
            {
                WriteLine($"Key: {keyValPair.Key} Valor: {keyValPair.Value}");
                //para devolver un valor especifico del diccionario lo busco por su llave 
                //Ejemplo: WriteLine(diccionario[23]); le estoy diciendo que acceda al diccionario
                // y me traiga el resultado de la key 23
                // Las llaves del diccionario pueden ser int, string float y son unicas, se puede modificar su valor
                
            }

            var dictmp = engine.GetDiccionarioObjetos();

            engine.ImprimirDiccionario(dictmp, true);

        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Beep(3000, 1000, 3);
            Printer.WriteTitle("SALIÓ");
        }

        private static void ImpimirCursosEscuela(Escuela escuela)
        {

            Printer.WriteTitle("Cursos de la Escuela");


            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre  }, Id  {curso.UniqueId}");
                }
            }
        }
    }
}
