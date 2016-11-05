using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create a Hello World Program 
namespace CAIT
{
    class Clocks
    {
         //Declaring variables
        public string timeInput,option;
        public string[] time;
        public int hoursToInt=0, minutesToInt=0, secondsToInt=0;
        public string hourOnColor,minuteOnColor, midColor, offColor, color;


    
        //method to set color scheme
        public void setColorScheme()
        {
            Console.WriteLine("\n                 =================BERLIN CLOCK================");
            Console.WriteLine("Select an Option (Enter 1 or 2) :");
            Console.WriteLine("1: Choose Default Color Scheme");
            Console.WriteLine("2: Choose your own Color Scheme");
            option = Console.ReadLine();
            if (option == "1")
            {
                setcolor("R");
                hourOnColor = getColor();
                setcolor("O");
                offColor = getColor();
                setcolor("Y");
                minuteOnColor = getColor();
                setcolor("R");
                midColor = getColor();
            }

            else if (option=="2")
            {
                Console.WriteLine("Please Enter the Hour ON color: ");
                color = Console.ReadLine();
                setcolor(color);
                hourOnColor = getColor();
                Console.WriteLine("Please Enter the Minute ON color: ");
                color = Console.ReadLine();
                setcolor(color);
                minuteOnColor = getColor();
                Console.WriteLine("Please Enter the mid-minute color: ");
                color = Console.ReadLine();
                setcolor(color);
                midColor = getColor();
                Console.WriteLine("Please Enter the OFF color:");
                color = Console.ReadLine();
                setcolor(color);
                offColor = getColor();



            }

            else
            {
                Console.WriteLine("Enter correct option");
                setColorScheme();
            }
        }

        //setting time by converting the string entered by the user
        public void setTime()
        { 
            
            Console.WriteLine("Please enter the time (hh:mm:ss) :");
            timeInput = Console.ReadLine();
            
            //Split String by setting delimiters and convert to int
            char[] deLimiters = { ':' ,' ',';' };  
            time = timeInput.Split(deLimiters);
            Int32.TryParse(time[0], out hoursToInt);
            Int32.TryParse(time[1], out minutesToInt);
            Int32.TryParse(time[2], out secondsToInt);

            //Check if time is in valid format
            if (hoursToInt > 23 || minutesToInt > 59 || secondsToInt > 59)
            {
                Console.WriteLine("PLEASE ENTER TIME IN CORRECT FORMAT !");
                setTime();
            }



        }

        //setter and getter methods for setting a color variable

        public string getColor()
        {
            return color; 
        }
        public void setcolor(string color)
        {
            this.color = char.ToString(color[0]);
        }

         
        
        //method to print the hours light patern
        public void printHours(string hours, int hourLimit, int slot)
        { 
            int  hoursLine1, hoursLine2;
            hoursLine1 = hoursToInt/ hourLimit;
            hoursLine2 = hoursToInt % hourLimit;
            
            for(int i=0; i < hoursLine1; i++)
            {
                Console.Write(hourOnColor);

            }

            for(int i = 0; i < slot-hoursLine1; i++)
            {
                Console.Write(offColor);

            }

            Console.Write("  ");

            for (int i = 0; i< hoursLine2; i++)
            {
                Console.Write(hourOnColor);
            }

            

            for (int i = 0; i < slot - hoursLine2; i++)
            {
                Console.Write(offColor);
            }

            Console.Write("  ");
            





        }

        //print the minutes light pattern
        public void printMinutes(string minutes, int minuteLimit, int slots1, int slots2)
        {
            //set variables according to time slots 
            int minutesLine1, minutesLine2;
            minutesLine1 = minutesToInt / minuteLimit;
            minutesLine2 = minutesToInt % minuteLimit;

            for (int i = 1; i <= minutesLine1; i++)
            {
                if (i % 3 != 0)
                {
                    Console.Write(minuteOnColor);
                }

                else
                {
                    Console.Write(midColor);
                }

            }

            for (int i = 0; i < slots1 - minutesLine1; i++)
            {
                Console.Write(offColor);

            }
            Console.Write("  ");

            for (int i = 0; i < minutesLine2; i++)
            {
                Console.Write(minuteOnColor);
            }


            for (int i = 0; i < slots2-minutesLine2; i++)
            {
                Console.Write(offColor);
            }

            Console.Write("  ");
           




        }

        //print the seconds light in Berlin Clock
        public void printSeconds(string seconds)
        {
            

            if (secondsToInt % 2 == 0)
                Console.Write(minuteOnColor);

            else
                Console.Write(offColor);

            Console.Write("  ");

        }

        //method to collectively print Mengenlenheur/ Berlin Clock Time
        public void setBerlinClkTime()
        {
            setColorScheme();
            setTime();
            Console.WriteLine("BERLIN CLOCK TIME:");

            printSeconds(time[2]);     //Change the parameters to customise the clock
            printHours(time[0], 5, 4); //Change the second and third parameter if you want to make changes to the clock
            printMinutes(time[1], 5, 11, 4); //Change parameters to customize the minutes pattern;
            Console.ReadLine();

        }

        //Test Clock
        public void unitTest()
        {
            string enterPattern;
            Console.Write(" This is a TEST !! Please enter the time as you wish to test");
            setBerlinClkTime();
            Console.Write("\n Enter the pattern which you expect seeing WITH DEFAULT COLOR SCHEME");
            enterPattern = Console.ReadLine();
            Console.Write("\n Output for the defualt color scheme must be:");
            Console.Write(enterPattern);
            Console.ReadLine();

        }

        
        
       
        
        // MAIN METHOD
        static void Main(string[] args)
        {
            int opt=1;
            Clocks c = new Clocks();

            do
             {

                 

                 //Calling methods in the right order

                 c.setBerlinClkTime();

                 //Ask if the user wants to exit or not
                 Console.Write("\n Do you want to input the time again? Press 1 to continue. Press any other number key to exit!: ");

                 opt = Convert.ToInt32(Console.ReadLine());

                 if (opt != 1)
                     opt = 2;
                 else
                     opt = 1;



             }

             //rerunning main method for making the user able to enter time again

             while (opt == 1);

             // c.unitTest();





        }
    }
}
