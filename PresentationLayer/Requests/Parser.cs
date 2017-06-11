using System.Windows.Controls;

namespace PresentationLayer
{
    static class Parser
    {
        //run until the user insert int-string (only numbers)
        public static int ReadIntString(TextBox userInput, Label userOutput)
        {
            int Output = -1;
            string input = TirmSpaces(userInput.Text);
            if (!CheckedIntInput(input))
            {
                userInput.Text = "";
                if(userOutput != null)
                    userOutput.Content = "Please insert just integer chars";
            }
            else
            {
                try
                {
                    Output = int.Parse(input);
                }
                catch
                {
                    userInput.Text = "";
                    if (userOutput != null)
                        userOutput.Content = "Please insert just integer chars";
                }
            }
            return Output;
        }

        //This function delete every appearance of space
        private static string TirmSpaces(string input)
        {
            int i = 0;
            while (i < input.Length)
            {
                if (input[i] == (int)' ')
                {
                    int j = i + 1;
                    while (j < input.Length && input[j] == (int)' ')
                        j++;
                    input = input.Substring(0, i) + input.Substring(j);
                }
                i++;
            }
            return input;
        }

        //scan the string to find out if it can be parse to int
        private static bool CheckedIntInput(string input)
        {
            bool output = true;
            int i = 0;
            while (i < input.Length & output)
            {
                if (input[i] < (int)'0' | input[i] > (int)'9')
                    output = false;
                i++;
            }

            return output;
        }
    }
}
