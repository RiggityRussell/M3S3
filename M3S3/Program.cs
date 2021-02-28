using FinchAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FInchRussell
{
    class Program
    {
        // **********************************************************************
        // *Title:              Finch M3S2                                      *    
        // *Application Type:   Console, Finch                                  *
        // *Author:             Arlt, Russell                                   *
        // *Description:        Application that gathers data using the Finch   *
        // *Date Created:       2/26/2021                                       *
        // *Date Revised:       Constantly                                      *
        // **********************************************************************

        #region MAIN
        /// <summary>
        /// The first screen
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMainMenuScreen();
        }
        #endregion

        #region SET THEME
        /// <summary>
        /// The beautiful colors of screen and text.
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.White;
        }
        #endregion

        #region DISPLAY MENU SCREEN
        /// <summary>
        /// Main Menu Screen
        /// </summary>
        static void DisplayMainMenuScreen()
        {
            //
            //  MAIN MENU
            //
            Console.CursorVisible = true;
            bool quitApplication = false;
            string menuChoice;
            //This creates a new Finch object
            Finch Reznor = new Finch();

            do
            {
                DisplayHeader("\tWelcome to the Finch Menu!");
                Console.WriteLine("\n\t\ta) Connect Finch Robot named Reznor");
                Console.WriteLine("\t\tb) Talent Show");
                Console.WriteLine("\t\tc) Data Recorder");
                Console.WriteLine("\t\td) Alarm System");
                Console.WriteLine("\t\te) User Programming");
                Console.WriteLine("\t\tf) Disconnect Finch Robot");
                Console.WriteLine("\t\tq) Quit");
                Console.Write("\t\t\tEnter your choice Please:");
                menuChoice = Console.ReadLine().ToLower();

                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(Reznor);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(Reznor);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(Reznor);
                        break;

                    case "d":
                        AlarmSystemDisplayMenuScreen(Reznor);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(Reznor);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(Reznor);
                        break;

                    case "q":
                        DisplayClosingScreen(Reznor);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine("\t\nPlease enter a letter for the menu choice");
                        DisplayContinuePromt();
                        break;
                }
            } while (!quitApplication);
        }
        #endregion

        #region USER PROGRAMMING DISPLAY MENU SCREEN
        /// <summary>
        /// Secret area. NO GO
        /// </summary>
        /// <param name="Reznor"></param>
        static void UserProgrammingDisplayMenuScreen(Finch Reznor)
        {
            DisplayHeader("You shouldn't be here yet!");

            Console.WriteLine("\n\t\tThis part of the program is still under construction! Please return later!");
            Console.WriteLine("OK love you byeeeeeeeeeeeeeeeeeeee");

            DisplayContinuePromt();
        }
        #endregion

        #region TALENT SHOW DISPLAY MENU SCREEN
        /// <summary>
        /// Our beautiful Finch makes music and lights and dances.
        /// </summary>
        /// <param name="Reznor"></param>
        static void TalentShowDisplayMenuScreen(Finch Reznor)
        {
            Console.CursorVisible = true;

            bool quitTalentShow = false;
            string menuChoice;

            do
            {
                DisplayHeader("Talent Show Time!");
                Console.WriteLine("\n\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing it up");
                Console.WriteLine("\tq) Return to Main Menu");
                Console.Write("\t\tEnter Choice Please:");
                menuChoice = Console.ReadLine().ToLower();

                DisplayContinuePromt();

                switch (menuChoice)
                {
                    case "a":
                        LightAndSound(Reznor);
                        break;

                    case "b":
                        DanceMenu(Reznor);
                        break;

                    case "c":
                        MixItUpMenu(Reznor);
                        break;

                    case "q":
                        DisplayMenuPrompt("Main");
                        quitTalentShow = true;
                        break;

                    default:
                        Console.WriteLine("\t\nPlease enter a letter for the menu choice");
                        DisplayContinuePromt();
                        break;
                }
            } while (!quitTalentShow);
        }
        #endregion

        #region DATA RECORDER DISPLAY MENU SCREEN
        /// <summary>
        /// The data recorder display
        /// </summary>
        /// <param name="Reznor"></param>
        static void DataRecorderDisplayMenuScreen(Finch Reznor)
        {
            // record temps and put them in array, then go back and display that array. 
            // We have to talk with user, ask how many data points they want to gather, time between those.
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0; // double because we ask for seconds.
            double[] temperatures = null;

            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayHeader("Data Recorder Menu!");
                Console.WriteLine("\n\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\te) Light Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice Please:");
                menuChoice = Console.ReadLine().ToLower();

                DisplayContinuePromt();

                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetTemperatureData(numberOfDataPoints, dataPointFrequency, Reznor);
                        break;

                    case "d":
                        DataRecorderDisplayData(temperatures);
                        break;

                    case "e":
                        GetLightData(Reznor);
                        break;

                    case "f":

                        break;

                    case "q":
                        DisplayMenuPrompt("Data Recorder");
                        quitMenu = true;
                        break;
                }
            } while (!quitMenu);

        }
        #endregion

        #region DATA RECORDER DISPLAY DATA
        /// <summary>
        /// Shows Data
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayData(double[] temperatures)
        {
            DisplayHeader("Show Your Data");

            DataRecorderDisplayTable(temperatures);

            DisplayContinuePromt();
        }
        #endregion

        #region DATA RECORDER DISPLAY TABLE
        /// <summary>
        /// The Display Table, got that celsius to fahrenheit!
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayTable(double[] temperatures)
        {
            //
            // display table headers below.
            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temp".PadLeft(15)
                );
            Console.WriteLine(
                "-----------".PadLeft(15) +
                "-----------".PadLeft(15)
                );

            //
            // display table data below.
            for (int index = 0; index < temperatures.Length; index++)
            {
                // find celcius data
                double fahrenheit = ConvertCelsiusToFahrenheit(temperatures[index]);


                Console.WriteLine(
                    (index + 1).ToString().PadLeft(15) +
                    fahrenheit.ToString("n2").PadLeft(15) + "°F"
              );
            }
        }
        #endregion

        #region CONVERT CELSIUS TO FAHRENHEIT
        /// <summary>
        /// Method exclusively for Converting Celsius to Fahrenheit
        /// </summary>
        /// <param name="celsius"></param>
        /// <returns></returns>
        static double ConvertCelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }
        #endregion

        #region DATA RECORDER DISPLAY GET TEMPERATURE DATA
        /// <summary>
        /// How we get the data from the user. 
        /// </summary>
        /// <param name="numberOfDataPoints"></param>
        /// <param name="dataPointFrequency"></param>
        /// <param name="Reznor"></param>
        /// <returns>Temperatures</returns>
        static double[] DataRecorderDisplayGetTemperatureData(int numberOfDataPoints, double dataPointFrequency, Finch Reznor)
        {
            double[] temperatures = new double[numberOfDataPoints];

            DisplayHeader("Get Data");

            Console.WriteLine($"\tNumber of data points: {numberOfDataPoints}");
            Console.WriteLine($"\t\nData point frequency: {dataPointFrequency}");
            Console.WriteLine("\n\tReznor is ready to begin recording the temperature data.");
            DisplayContinuePromt();
            // Set up a loop that will gather the data,
            // We need to get temp reading from finch,
            // echo reading back to user,
            // add that reading to element in array,
            // put a wait in, so it doesn't fly through very quickly.

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = Reznor.getTemperature();
                Console.WriteLine($"\tReading {index + 1}: {temperatures[index].ToString("n2")}");// .ToString("n2") will make it have only 2 decimal places.
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                Reznor.wait(waitInSeconds);
            }

            DisplayContinuePromt();
            DisplayHeader("Get Data");

            Console.WriteLine("\t\nTable of Temperatures\n");

            DataRecorderDisplayTable(temperatures);

            DisplayContinuePromt();

            return temperatures;
        }
        #endregion

        #region DATA RECORDER DISPLAY GET DATA POINT FREQUENCY
        /// <summary>
        /// get the frequency of data points from user
        /// </summary>
        /// <returns>frequency of data points</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double dataPointFrequency;


            DisplayHeader("Data Point Frequency");

            Console.Write("\tEnter the frequency you would like to revieve data points: ");

            // instead of using Console.Readline(); ^ we declare it in the double.TryParse section below.
            // validate user input

            double.TryParse(Console.ReadLine(), out dataPointFrequency);

            DisplayContinuePromt();

            return dataPointFrequency;
        }
        #endregion

        #region DATA RECORDER DISPLAY GET NUMBER OF DATA POINTS
        /// <summary>
        /// Gets the number of data points from user
        /// </summary>
        /// <returns>number of data points</returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            string userResponse;

            DisplayHeader("Number of Data Points");

            Console.Write("\tPlease enter a number of times you would like to receive data: ");
            userResponse = Console.ReadLine();

            // validate user input


            int.TryParse(userResponse, out numberOfDataPoints);

            DisplayContinuePromt();

            return numberOfDataPoints;
        }
        #endregion

        #region GET  AND DISPLAY LIGHT DATA
        /// <summary>
        /// This is just for getting light data in an array
        /// </summary>
        /// <param name="Reznor"></param>
        /// <returns> The reading of both amounts of light!</returns>
        public static int[] GetLightData(Finch Reznor)
        {
            DisplayHeader("Reznor will see how much light is nearby!");
            DisplayContinuePromt();

            int[] lightSensor = Reznor.getLightSensors();


            for (int index = 0; index < lightSensor.Length; index++)
            {
                Console.WriteLine($"\tHere we go!  {lightSensor[index]}");
            }

            DisplayContinuePromt();

            return lightSensor;
            //int leftLight;
            //leftLight = Reznor.getLeftLightSensor();
            //    Console.WriteLine($"SHOW ME LIGHT {leftLight}");
            //    Console.ReadKey();


        }
        #endregion

        #region DANCE MENU  
        /// <summary>
        /// Dance Party!
        /// </summary>
        /// <param name="Reznor"></param>
        static void DanceMenu(Finch Reznor)
        {
            Console.CursorVisible = false;

            DisplayHeader("Lets DANCE!");
            Console.WriteLine("\n\tReznor will now dance for you!");
            DisplayContinuePromt();
            Reznor.setMotors(100, 100);
            Reznor.wait(3000);
            Reznor.setMotors(100, -100);
            Reznor.wait(3000);
            Reznor.setMotors(0, 0);
            Reznor.setMotors(-100, 100);
            Reznor.wait(3000);
            Reznor.setMotors(0, 0);

            Console.WriteLine("Wow! What incredibly inspired moves! Jealous much?");
            DisplayMenuPrompt("Talent Show");
        }
        #endregion

        #region MIX IT UP
        /// <summary>
        /// Moving and lights!
        /// </summary>
        /// <param name="Reznor"></param>
        static void MixItUpMenu(Finch Reznor)
        {
            Console.CursorVisible = false;

            DisplayHeader("Lets get silly up in here! Dancing! Light show! Music!\n");
            DisplayContinuePromt();

            Reznor.setLED(50, 100, 200);
            Reznor.noteOn(263);
            Reznor.setMotors(-100, 100);
            Reznor.wait(2000);
            Reznor.setMotors(0, 0);
            Reznor.setLED(100, 200, 0);
            Reznor.noteOn(138);
            Reznor.setMotors(100, -100);
            Reznor.wait(2000);
            Reznor.setLED(0, 50, 255);
            Reznor.noteOn(800);
            Reznor.setMotors(100, 100);
            Reznor.wait(2000);
            Reznor.setMotors(0, 0);
            Reznor.setLED(10, 20, 50);
            Reznor.noteOn(138);
            Reznor.setMotors(30, -30);
            Reznor.wait(2000);
            Reznor.setLED(50, 100, 200);
            Reznor.noteOn(263);
            Reznor.setMotors(-100, 100);
            Reznor.wait(2000);
            Reznor.setMotors(0, 0);
            Reznor.setLED(100, 200, 0);
            Reznor.noteOn(138);
            Reznor.setMotors(100, -100);
            Reznor.wait(2000);
            Reznor.setLED(0, 50, 255);
            Reznor.noteOn(800);
            Reznor.setMotors(100, 100);
            Reznor.wait(2000);
            Reznor.setMotors(0, 0);
            Reznor.setLED(10, 20, 50);
            Reznor.noteOn(138);
            Reznor.setMotors(30, -30);
            Reznor.wait(2000);
            Reznor.noteOff();
            Reznor.setLED(0, 0, 0);

            Console.WriteLine("Wow, wasn't that something!");

            DisplayMenuPrompt("Talent Show");

            //for (int allTheThings = 0; allTheThings < 1000 ; allTheThings ++)
            //{
            //    Reznor.setLED(30, 74, 100);
            //    Reznor.noteOn(allTheThings * 20);
            //    Reznor.setMotors(allTheThings, allTheThings);
            //    Reznor.setLED(100, 50, 60);
            //}
        }
        #endregion

        #region LIGHT AND SOUND
        /// <summary>
        /// A for loop to create light and sound
        /// </summary>
        /// <param name="Reznor"></param>
        static void LightAndSound(Finch Reznor)
        {
            Console.CursorVisible = false;

            DisplayHeader("Light and Sound Time!");

            Console.WriteLine("\n\tReznor will now scream and glow rapidly!");
            DisplayContinuePromt();
            for (int lightSound = 0; lightSound < 500; lightSound++)
            {
                Reznor.setLED(lightSound, 0, lightSound);
                Reznor.noteOn(lightSound * 50);
            }
            Reznor.setLED(0, 0, 0);
            DisplayMenuPrompt("Talent Show");
        }
        #endregion

        #region ALARM SYSTEM DISPLAY MENU SCREEN
        /// <summary>
        /// Probably be a real loud one here.
        /// </summary>
        /// <param name="Reznor"></param>
        static void AlarmSystemDisplayMenuScreen(Finch Reznor)
        {
            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThresholdValue = 0;
            int timeToMonitor = 0;
                   
            do
            {
                DisplayHeader("Alarm Menu!");
                Console.WriteLine("\n\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Minimum/Maximum Threshold Value");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice Please:");
                menuChoice = Console.ReadLine().ToLower();

                DisplayContinuePromt();

                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = LightAlarmSetSensorsToMonitor();
                        break;

                    case "b":
                        rangeType = LightAlarmSetRangeType();
                        break;

                    case "c":
                        minMaxThresholdValue = LightAlarmSetMinMaxThresholdValue(rangeType, Reznor);
                        break;

                    case "d":
                        timeToMonitor = LightAlarmSetTimeToMonitor();
                        break;

                    case "e":
                        LightAlarmSetAlarm(Reznor, sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor);
                        break;

                    case "f":

                        break;

                    case "q":
                        DisplayMenuPrompt("Data Recorder");
                        quitMenu = true;
                        break;
                }
            } while (!quitMenu);
        }
        #endregion

        #region LIGHT ALARM SET ALARM
        static void LightAlarmSetAlarm(Finch Reznor, string sensorsToMonitor, string rangeType, int minMaxThresholdValue, int timeToMonitor)
        {
            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            int currentLightSensorValue = 0;

            DisplayHeader("Set Alarm");

            Console.WriteLine($"\tSensors to monitor: {sensorsToMonitor}");
            Console.WriteLine("\tRange Type: {0}", rangeType);
            Console.WriteLine("\tMin/Max threshold value: " + minMaxThresholdValue);
            Console.WriteLine($"\tTime to monitor: {timeToMonitor}\n");

            Console.WriteLine("\tPress any key to begin monitoring!\n");
            Console.ReadKey();

            while (secondsElapsed < timeToMonitor && !thresholdExceeded)
            {
                switch (sensorsToMonitor)
                {
                    case "left":
                        currentLightSensorValue = Reznor.getLeftLightSensor();
                        break;

                    case "right":
                        currentLightSensorValue = Reznor.getRightLightSensor();
                        break;

                    case "both":
                        currentLightSensorValue = (Reznor.getRightLightSensor() + Reznor.getLeftLightSensor()) / 2;
                        break;
                }

                switch (rangeType)
                {
                    case "minimum":
                        if (currentLightSensorValue < minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                    case "maximum":
                        if (currentLightSensorValue > minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;
                }

                Reznor.wait(1000);
                secondsElapsed++;
            }

            if (thresholdExceeded)
            {
                Console.WriteLine($"The {rangeType} threshold value of {minMaxThresholdValue} was exceeded by the current light sensor value of {currentLightSensorValue}.");
            }
            else
            {
                Console.WriteLine($"The {rangeType} threshold value {minMaxThresholdValue} was not exceeded.");
            }

            DisplayMenuPrompt("Light Alarm");
        }
        #endregion


        #region LIGHT ALARM SET MIN MAX THRESHOLD VALUE

        static int LightAlarmSetMinMaxThresholdValue(string rangeType, Finch Reznor)
        {
            int minMaxThresholdValue;

            DisplayHeader("Min/Max Threshold Value");

            Console.WriteLine($"\tLeft light sensor ambient value: {Reznor.getLeftLightSensor()}");
            Console.WriteLine($"\tRight light sensor ambient value: {Reznor.getRightLightSensor()}\n");
            
            // validate value
            Console.WriteLine($"\tEnter the {rangeType} light sensor value: \n");
            int.TryParse(Console.ReadLine(), out minMaxThresholdValue);

            // echo value back to user

            DisplayMenuPrompt("Light Alarm");

            return minMaxThresholdValue;
        }
        #endregion

        #region LIGHT ALARM SET TIME TO MONITOR

        static int LightAlarmSetTimeToMonitor()
        {
            int timeToMonitor;

            DisplayHeader("Time to Monitor");

            // validate value
            Console.WriteLine($"\tTime to Monitor: \n");
            int.TryParse(Console.ReadLine(), out timeToMonitor);

            // echo value back to user

            DisplayMenuPrompt("Light Alarm");

            return timeToMonitor;
        }
        #endregion

        #region LIGHT ALARM SET SENSORS TO MONITOR
        static string LightAlarmSetSensorsToMonitor()
        {
            string sensorsToMonitor;

            DisplayHeader("Sensors to Monitor");

            Console.WriteLine("\tWhich sensors would you like to monitor? [left, right, both]");
            sensorsToMonitor = Console.ReadLine();

            DisplayMenuPrompt("Light Alarm");

            return sensorsToMonitor;
        }
        #endregion

        #region LIGHT ALARM SET RANGE TYPE
        static string LightAlarmSetRangeType()
        {
            string rangeType;

            DisplayHeader("Range Type");

            Console.WriteLine("\tRange Type [minimum, maximum]");
            rangeType = Console.ReadLine();

            DisplayMenuPrompt("Light Alarm");

            return rangeType;
        }
        #endregion



        #region DISPLAY CONNECT FINCH ROBOT
        /// <summary>
        /// This is how the FInch connects to the application
        /// </summary>
        /// <param name="Reznor"></param>
        /// <returns>That the finch is connected</returns>
        static bool DisplayConnectFinchRobot(Finch Reznor)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayHeader("Connect Finch Robot");

            Console.WriteLine("\n\nThe application is going to connect with Reznor now. Please don't remove the cord!");

            DisplayContinuePromt();

            //This connects it, this Finch is named Reznor.
            robotConnected = Reznor.connect();


            while (robotConnected)
            {
                Reznor.setLED(100, 0, 100);
                Reznor.noteOn(400);
                Reznor.wait(1000);
                Reznor.noteOff();
                Reznor.setLED(0, 0, 0);
                Console.WriteLine("Hooray! Reznor is ready to party now!");
                Console.ReadKey();
                break;

            }


            if (!(robotConnected))
            {
                Console.WriteLine("WARNING FAILURE TO CONNECT WARNING! Press any key to escape");
                Console.ReadKey();
            }
            return robotConnected;
            //use while loop to connect and confirm to the Finch Robot
            //Return a bool value indicating if the connection was successful
        }
        #endregion

        #region DISPLAY MENU PROMPT
        /// <summary>
        /// Our menu calling method
        /// </summary>
        /// <param name="menuName"></param>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine($"\n\tPress any key to go back to the {menuName} Menu");
            Console.ReadKey();
        }
        #endregion

        #region DISPLAY DISCONNECT FINCH ROBOT
        /// <summary>
        /// How we disconnect the Finchy
        /// </summary>
        /// <param name="Reznor"></param>
        //RUSSELL YOU CHANGED BOOL TO VOID ON DISPLAYDISCONNECTFINCHROBOT
        static void DisplayDisconnectFinchRobot(Finch Reznor)
        {
            DisplayHeader("Disconnect Finch Robot named Reznor");

            Console.WriteLine("Done already!? Well Reznor will disconnect now. Please be patient!");
            Reznor.disConnect();
            Console.WriteLine("Our Finch friend Reznor has been disconnected.");

            DisplayContinuePromt();

        }
        #endregion

        #region DISPLAY WELCOME SCREEN
        /// <summary>
        /// VELCOME TO OUR APPLICATION
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine("\n\t\tRussells Finch Control!\n");

            DisplayContinuePromt();

        }
        #endregion

        #region DISPLAY CLOSING SCREEN
        /// <summary>
        /// GOODBYE TIME
        /// </summary>
        /// <param name="Reznor"></param>
        static void DisplayClosingScreen(Finch Reznor)
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine("\n\t\tThanks for playing with Reznor!\n");

            DisplayContinuePromt();
        }
        #endregion

        #region DISPLAY HEADER
        /// <summary>
        /// Method called to display a header
        /// </summary>
        /// <param name="headerText"></param>
        static void DisplayHeader(string headerText)
        {

            // DisplayHeader will return whatever is in the writeline in the app above.
            Console.Clear();
            Console.WriteLine("\n\t\t\n" + headerText);

        }
        #endregion

        #region DISPLAY CONTINUE PROMPT
        /// <summary>
        /// A readkey method
        /// </summary>
        static void DisplayContinuePromt()
        {   //
            // pause for user
            //
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue!\n");
            Console.ReadKey();
        }
        #endregion
    }
}
