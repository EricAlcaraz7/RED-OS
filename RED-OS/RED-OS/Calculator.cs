// Calculator.cs

using System;

namespace CosmosKernel1
{
    public static class Calculator
    {
        public static void Ejecutar()
        {
            try
            {
                GraphicsManager.WriteLine("");
                GraphicsManager.WriteLine("===== CALCULADORA =====");
                GraphicsManager.WriteLine("Operacions:");
                GraphicsManager.WriteLine("+  -  *  /");
                GraphicsManager.WriteLine("");

                GraphicsManager.WriteLine("Escriu el primer numero:");
                string aText = InputManager.ReadLine();

                GraphicsManager.WriteLine("Escriu l'operacio:");
                string op = InputManager.ReadLine();

                GraphicsManager.WriteLine("Escriu el segon numero:");
                string bText = InputManager.ReadLine();

                double a = Convert.ToDouble(aText);
                double b = Convert.ToDouble(bText);

                double result = 0;

                switch (op)
                {
                    case "+":
                        result = a + b;
                        break;

                    case "-":
                        result = a - b;
                        break;

                    case "*":
                        result = a * b;
                        break;

                    case "/":
                        if (b == 0)
                        {
                            GraphicsManager.WriteLine("Error: Divisio per zero.");
                            Sound.ErrorSound();
                            return;
                        }

                        result = a / b;
                        break;

                    default:
                        GraphicsManager.WriteLine("Operacio invalida.");
                        Sound.ErrorSound();
                        return;
                }

                GraphicsManager.WriteLine("");
                GraphicsManager.WriteLine("Resultat: " + result);
                GraphicsManager.WriteLine("=======================");
                GraphicsManager.WriteLine("");

                Sound.SuccessSound();
            }
            catch
            {
                GraphicsManager.WriteLine("Error a la calculadora.");
                Sound.ErrorSound();
            }
        }
    }
}