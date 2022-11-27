namespace Dictionaries_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Encrypt and decrypt a message using a Dictionary
            // as the key/value storage system
            List<char> letters = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 
                'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 
                't', 'u', 'v', 'w', 'x', 'y', 'z' };

            Dictionary<char, char> cipher = new Dictionary<char, char>();

            List<bool> numberUsed = new List<bool>();

            for (int i = 0; i < 26; i++)
            {
                numberUsed.Add(false);
            }

            Random rand = new Random();
            int randNum;
            int counter = 0;

            // Construct our cipher dictionary using randon numbers
            foreach (char letter in letters)
            {
                randNum = rand.Next(26);

                while (numberUsed[randNum] == true)
                {
                    randNum = rand.Next(26);
                }
                 
                numberUsed[randNum] = true;

                cipher.Add(letters[counter], letters[randNum]);

                counter++;
            }

            // Encrypt a message using the dictionary cipher
            string myMessage = "Scissors";
            string mySecretMessage = string.Empty;

            Console.WriteLine($"The message you want to encrypt is: {myMessage}");
            Console.WriteLine();

            foreach (char letter in myMessage)
            {
                mySecretMessage = mySecretMessage + cipher[Char.ToLower(letter)];
            }

            Console.WriteLine($"The encrypted message is: {mySecretMessage}");
            Console.WriteLine();

            // Decrypt the message using the dictionary cipher
            Console.WriteLine($"The message you want to decrypt is: {mySecretMessage}");
            Console.WriteLine();

            myMessage = string.Empty;

            foreach (char letter in mySecretMessage)
            {
                myMessage += cipher.First(x => x.Value == letter).Key;
            }

            Console.WriteLine($"The decrypted message is: {myMessage}");
            Console.WriteLine();
        }
    }
}