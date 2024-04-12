using System.Xml.Linq;

namespace SchoolInsuancelog
{
    internal class Program
    {
        //Global Variables
        static List<string> deviceType = new List<string>()
        {
            "Desktop", "Laptop", "Tablet/Phone", "Other"
        };


        //Methods and Functions
        static int CheckInt(string question, int min, int max)
        {

            while (true)
            {
                try
                {
                    Console.WriteLine(question);



                    int userInt = Convert.ToInt32(Console.ReadLine());

                    if (userInt >= min && userInt <= max)
                    {
                        return userInt;
                    }

                    DisplayErrorMessage($"ERROR: You have entered an invalid integer, You must enter an integer between {min} and {max}");
                }
                catch
                {
                    DisplayErrorMessage($"ERROR: You have entered an invalid integer, You must enter an integer between {min} and {max}");
                }

            }
        }
        static void DisplayErrorMessage(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.White;
        }


        static string GenerateMenu(string menutType, List<string> listData)
        {


            string menu = $"Select the {menutType}:\n";

            for (int loop = 0; loop < listData.Count; loop++)
            {
                menu += $"{loop + 1}. {listData[loop]}\n";
            }
            return menu;
        }

        static int deviceChoice(string menuType, List<string> deviceType)
        {



            string menu = GenerateMenu(menuType, deviceType);




            return CheckInt(menu, 1, deviceType.Count);




        }


        static void OneDevice()
        {
            int catergory = deviceChoice("catergory", deviceType);

            Console.WriteLine("Enter the device brand name");
            string deviceName = Console.ReadLine();

            Console.WriteLine("Enter the individual cost of this device");
            float deviceCost = (float)Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the Qauntity of this device");
            int deviceQauntity = Convert.ToInt32(Console.ReadLine());

            string ID = GenerateID(deviceName);

            float InsuranceCalculated = 0;

            if (deviceQauntity > 5)
            {
                InsuranceCalculated = 5 * deviceCost;
                InsuranceCalculated += (deviceQauntity - 5) * deviceCost * 0.90f;

            }
            else
            {
                InsuranceCalculated = 5 * deviceCost;

            }



            // declare the initial value of the product
            double initialValue = deviceCost;

            // declare the monthly devaluation rate
            double monthlyDevaluationRate = 0.05;

            // Initialize the current value with the initial value
            double currentValue = initialValue;

            // Calculate the devaluation for 6 months
            for (int month = 1; month <= 6; month++)
            {
                // Calculate the devaluation for the current month
                double devaluation = currentValue * monthlyDevaluationRate;

                // Update the current value for the next month
                currentValue -= devaluation;

                // Print the devaluation for the current month
                Console.WriteLine($"Month {month}: Devaluation = {devaluation:C2}, Indivdiual Current Value = {currentValue:C2}");
            }

            // calculate a final balance including the total value of ALL devices

            double totalValue = currentValue * deviceQauntity;

            // Print the final value after 6 months
            Console.WriteLine($"Your total device(s) value after 6 months: {totalValue:C2}");




        }


        // GenerateID() Method.
        static string GenerateID(string deviceName)
        {
            int charCountDevice = 3;

            if (deviceName.Length < 3)
            {
                charCountDevice = deviceName.Length;
            }

            string id = deviceName.Substring(0, charCountDevice) + DateTime.Now.ToString("d/M/yyyy");

            return id;
        }

        // Device devaluation algo


        




        static void Main(string[] args)
        {
            // Local Variables
        

            // Label app algo.
            // Display App Title.

            // devaluation period 6 month algo

            

            Console.WriteLine(",--.                                                                 ,---.                 \n" +
       "|  |,--,--,  ,---. ,--.,--.,--.--. ,--,--.,--,--,  ,---. ,---.      /  O  \\  ,---.  ,---. \n" +
       "|  ||      \\(  .-' |  ||  ||  .--'' ,-.  ||      \\| .--'| .-. :    |  .-.  || .-. || .-. | \n" +
       "|  ||  ||  |.-'  `)'  ''  '|  |   \\ '-'  ||  ||  |\\ `--.\\   --.    |  | |  || '-' '| '-' ' \n" +
       "`--'`--''--'`----'  `----' `--'    `--`--'`--''--' `---' `----'    `--' `--'|  |-' |  |-'  \n" +
       "                                                                            `--'   `--'    \n");


            OneDevice();

            Console.WriteLine("Press <Enter> to continue");
            Console.ReadLine();
            Console.Clear();


           
        }
    }
}









