// InputManager.cs

using Cosmos.System;

namespace CosmosKernel1
{
    public static class InputManager
    {
        public static string ReadLine()
        {
            string input = "";

            while (true)
            {
                if (KeyboardManager.TryReadKey(out KeyEvent key))
                {
                    // ENTER
                    if (key.Key == ConsoleKeyEx.Enter)
                    {
                        GraphicsManager.WriteLine("REDos> " + input);

                        return input;
                    }

                    // BACKSPACE
                    if (key.Key == ConsoleKeyEx.Backspace)
                    {
                        if (input.Length > 0)
                        {
                            input = input.Substring(
                                0,
                                input.Length - 1
                            );
                        }
                    }
                    else
                    {
                        if (key.KeyChar != '\0')
                        {
                            input += key.KeyChar;
                        }
                    }

                    GraphicsManager.RenderInput(input);
                }
            }
        }
    }
}