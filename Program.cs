using System.ComponentModel;
using System.Text.RegularExpressions;
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

        // Check DeviceQauntity
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
        // change the colour of the error Message.
        static void DisplayErrorMessage(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //generate the Catagory Menu
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
        // OneDevice start

        static void OneDevice()
        {
            int catergory = deviceChoice("catergory", deviceType);


            string deviceName = CheckName();

            float deviceCost = checkFloat(1, 10000);

            int deviceQauntity = checkInt(1, 100);

            Console.Clear();

            Console.WriteLine(",--.                                                                 ,---.                 \n" +
"|  |,--,--,  ,---. ,--.,--.,--.--. ,--,--.,--,--,  ,---. ,---.      /  O  \\  ,---.  ,---. \n" +
"|  ||      \\(  .-' |  ||  ||  .--'' ,-.  ||      \\| .--'| .-. :    |  .-.  || .-. || .-. | \n" +
"|  ||  ||  |.-'  `)'  ''  '|  |   \\ '-'  ||  ||  |\\ `--.\\   --.    |  | |  || '-' '| '-' ' \n" +
 "`--'`--''--'`----'  `----' `--'    `--`--'`--''--' `---' `----'    `--' `--'|  |-' |  |-'  \n");


            Console.WriteLine($"Device Name: {deviceName}");
            Console.WriteLine($"Device Type: {deviceType[catergory - 1]}");
            Console.WriteLine($"Device individual Cost: {deviceCost}");
            Console.WriteLine($"Device Qaunity: {deviceQauntity}");

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

            // Device devaluation algo

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

            Console.WriteLine($"device(s) code: {ID}");




        }
        static string CheckName()
        {
            while (true)
            {
                Console.WriteLine("Enter the device brand name");

                string name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[a-zA-Z0-100]+$"))
                {
                    name = name.ToUpper();

                    return name;
                }
                DisplayErrorMessage("ERROR: You must enter a name");


            }
        }

        static float checkFloat(int min, int max)
        {


            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the individual cost of this device");


                    float userFloat = (float)Convert.ToDecimal(Console.ReadLine());

                    if (userFloat >= min && userFloat <= max)
                    {
                        return userFloat;
                    }

                    DisplayErrorMessage($"INVALID INTERGER, PLEASE ONLY ENTER NUMBERS BETWEEN {min} & {max}");

                }
                catch
                {
                    DisplayErrorMessage($"INVALID INTERGER, PLEASE ONLY ENTER NUMBERS BETWEEN {min} & {max}");
                }
            }
        }

        static int checkInt(int min, int max)
        {


            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the quantity cost of this device");


                    int userInt = (int)Convert.ToDecimal(Console.ReadLine());

                    if (userInt >= min && userInt <= max)
                    {
                        return userInt;
                    }

                    DisplayErrorMessage($"Enter the Qauntity of this device {min} & {max}");

                }
                catch
                {
                    DisplayErrorMessage($"Enter the Qauntity of this device {min} & {max}");
                }
            }
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

        // Check proceed method​
        static string CheckProcced()
        {
            while (true)
            {
                Console.WriteLine("Press <ENTER> to add another device or press 'x' to exit");

                string checkProceed = Console.ReadLine();
                checkProceed = checkProceed.ToUpper();

                if (checkProceed.Equals("") || checkProceed.Equals("X"))
                {
                    
                    
                    return checkProceed;
                }
                DisplayErrorMessage("ERROR Invalid choice,Press <ENTER> to add another device or press 'x' to exit ");


            }
        }








        static void Main(string[] args)
        {
            // Display App Title.

            Console.WriteLine(",--.                                                                 ,---.                 \n" +
       "|  |,--,--,  ,---. ,--.,--.,--.--. ,--,--.,--,--,  ,---. ,---.      /  O  \\  ,---.  ,---. \n" +
       "|  ||      \\(  .-' |  ||  ||  .--'' ,-.  ||      \\| .--'| .-. :    |  .-.  || .-. || .-. | \n" +
       "|  ||  ||  |.-'  `)'  ''  '|  |   \\ '-'  ||  ||  |\\ `--.\\   --.    |  | |  || '-' '| '-' ' \n" +
       "`--'`--''--'`----'  `----' `--'    `--`--'`--''--' `---' `----'    `--' `--'|  |-' |  |-'  \n" +
       "                                                                            `--'   `--'    \n");
            string proceed = "";
            while (proceed.Equals(""))
            {
                OneDevice();
                proceed = CheckProcced();
            }
            

        }
    }
}