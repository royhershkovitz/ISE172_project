using System.Windows.Controls;
using AlgoTrading;

namespace PresentationLayer
{
    public static class Parser
    {
        // get a TextBox and a label    
        // if the text is string that stroes int chars - retruen the parsed value, 
        // else delete the 'userInput' text box and write in the userOutput the problem
        public static int ReadIntString(TextBox userInput, Label userOutput)
        {
            int Output = -1;
            if (userInput.Text == "")
                userOutput.Content = "some fields are empty";
            else
            {
                Output = ReadIntString(userInput.Text);
                if (Output == -1)
                {
                    userInput.Text = "";
                    if (userOutput != null)
                        userOutput.Content = "Please insert just integer chars";
                }
            }            
            return Output;
        }

        //parse int string with non int chars
        public static int ReadIntString(string userInput)
        {
            int Output = -1;
            string input = TirmSpaces(userInput);
            if (CheckedIntInput(input))
            {
              try
              {
                    Output = int.Parse(input);
              }
              catch
              {
                    LogHelper.GetLogger().Fatal("This input did not ditected : " + input);
              }
            }
            //System.Diagnostics.Trace.WriteLine(Output + " " + input);
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
            if (input.Length == 0)
                output = false;
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
