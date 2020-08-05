using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_L_Bojana_Backo
{
    public class PasswordValidation
    {
        int minUpper = 2;
        int minLength = 6;

        public bool PasswordOk(string password)
        {
            // get individual characters
            char[] characters = password.ToCharArray();

            // checking variables
            int upper = 0;
            int length = password.Length;

            // check the entered password
            foreach  (char enteredCharacter in characters)
            {
                if (char.IsUpper(enteredCharacter))
                {
                    upper = upper + 1;
                }
            }
            if (upper < minUpper || length < minLength)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
