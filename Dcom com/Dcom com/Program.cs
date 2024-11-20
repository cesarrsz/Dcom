using System;

namespace InteractiveCOM_DCOM
{
    // Interfaz para el componente COM
    public interface IComComponent
    {
        string ProcessMessage(string input);
    }

    // Clase que implementa el componente COM
    public class ComComponent : IComComponent
    {
        public string ProcessMessage(string input)
        {
            return $"COM procesó tu mensaje: {input.ToUpper()}";
        }
    }

    // Simulación de DCOM
    public class DcomComponent
    {
        private readonly IComComponent _comComponent;

        public DcomComponent(IComComponent comComponent)
        {
            _comComponent = comComponent;
        }

        public void DistributeMessage(string message)
        {
            string processedMessage = _comComponent.ProcessMessage(message);
            Console.WriteLine($"[DCOM] Mensaje distribuido: {processedMessage}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Simulación interactiva de COM y DCOM ===");
            Console.WriteLine("1. Enviar mensaje a través de COM");
            Console.WriteLine("2. Enviar mensaje a través de DCOM");
            Console.WriteLine("3. Salir");

            // Crear instancias de los componentes
            IComComponent comComponent = new ComComponent();
            DcomComponent dcomComponent = new DcomComponent(comComponent);

            while (true)
            {
                Console.Write("\nSelecciona una opción (1-3): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Escribe un mensaje para COM: ");
                        string comMessage = Console.ReadLine();
                        Console.WriteLine($"[COM] Respuesta: {comComponent.ProcessMessage(comMessage)}");
                        break;

                    case "2":
                        Console.Write("Escribe un mensaje para DCOM: ");
                        string dcomMessage = Console.ReadLine();
                        dcomComponent.DistributeMessage(dcomMessage);
                        break;

                    case "3":
                        Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        break;
                }
            }
        }
    }
}
