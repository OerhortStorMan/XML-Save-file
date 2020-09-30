using System;
using System.IO;
using System.Xml.Serialization;

namespace XML_Save_file
{
    class Program
    {
        static XmlSerializer serializer = new XmlSerializer(typeof(Savefile));
        static FileStream myFile = File.Open("Savefile.xml", FileMode.OpenOrCreate);


        static void Main(string[] args)
        {
           
            System.Console.WriteLine("Välkommen till 'skapa din egna kock'-spelet.");

            bool correctInput = false;
            while (!correctInput)
            {
                System.Console.WriteLine("Vill du [A] skapa en ny save file eller [B] öppna en befintlig?");
                string createOrOpenAnswer = Console.ReadLine();

                createOrOpenAnswer = createOrOpenAnswer.ToLower();

                if (createOrOpenAnswer == "a")
                {
                    CharacterCreator();
                    OpenCharacter();
                    correctInput = true;
                }
                else if (createOrOpenAnswer == "b")
                {
                    OpenCharacter();
                    correctInput = true;

                }
                else
                {
                    System.Console.WriteLine("Ge ett giltigt svar, tack.");
                }
            }
        }

        static void CharacterCreator()
        {
            Console.Clear();
            Savefile player1 = new Savefile();

            System.Console.WriteLine("Vad ska din karaktär heta?");
            player1.name = Console.ReadLine();
            
            System.Console.WriteLine("Hur mycket movement speed?");
            string movementInput = Console.ReadLine();
            //här så kan jag bool success till tryparsen om jag vill och se så det blir rätt men orkar inte
            int.TryParse(movementInput, out int movementInt);
            player1.movementSpeed = movementInt;

            System.Console.WriteLine("Hur mycket health ska din karaktär ha?");
            string healthInput = Console.ReadLine();
            int.TryParse(healthInput, out int healthInt);
            player1.health = healthInt;

            serializer.Serialize(myFile, player1);

            
        }

        static void OpenCharacter()
        {
            
            FileStream Savefile = File.OpenRead("Savefile.xml");

            Savefile player1 = (Savefile) serializer.Deserialize(myFile);
            
            //skriv xml info i console
        }
    }
}
