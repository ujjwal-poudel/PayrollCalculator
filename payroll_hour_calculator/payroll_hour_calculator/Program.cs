using System;

namespace payroll_hour_calculator
{
    // Creating payroll hour calulator
    // This program will take the number of hours, minutes and second and convert it to decimal hours
    // This programm will just give the decimal hours, for example is the number of hour is 1 hour 30 minutes and 30 seconds
    // The program will give the decimal hours of 1.5 hours
    internal class Program
    {
        static void Main(string[] args)
        {
            // Calling the DisplayPayrollInfo method
            DisplayPayrollInfo();
        }

        // Creating a method to display the payroll information
        public static void DisplayPayrollInfo()
        {
            // DateTime variable for current date
            DateTime currentDate = DateTime.Today;

            // Creating a variable to store the user input
            Time newTime = GetUserInput();

            // Displaying the payroll information
            Console.WriteLine($"\n\nPayroll Information Recorded at: {currentDate}\n" +
                $"Time in: {newTime.timeIn}\n" +
                $"Time out: {newTime.timeOut}\n\n" +
                newTime.ToString());
        }

        // Creating a method to get the user input
        public static Time GetUserInput()
        {
            // Creating a variable to store time in
            Console.Write("Enter the time in: ");
            string timeIn = Console.ReadLine();

            // Creating a variable to store time out
            Console.Write("Enter the time out: ");
            string timeOut = Console.ReadLine();

            // Creating a variable to store delivery mode
            Console.Write("\nEnter the delivery mode (1 for online, 2 for in person): ");
            int deliveryMode = Convert.ToInt32(Console.ReadLine());

            // Creating a variable to store hours
            Console.Write("Enter the number of hours: ");
            double hours = Convert.ToDouble(Console.ReadLine());

            // Creating a variable to store minutes
            Console.Write("Enter the number of minutes: ");
            double minutes = Convert.ToDouble(Console.ReadLine());

            // Creating a variable to store seconds
            Console.Write("Enter the number of seconds: ");
            double seconds = Convert.ToDouble(Console.ReadLine());

            return new Time(hours, minutes, seconds) 
            { 
                timeIn = timeIn, timeOut = timeOut, deliveryMode = (DeliveryMode)deliveryMode
            };
        }
    }

    // Creating enum for delivery mode
    enum DeliveryMode
    {
        // Creating enum values
        Online = 1, InPerson = 2
    }

    // Creating a class called Time
    // This class will take the number of hours, minutes and seconds and convert it to decimal hours
    class Time
    {
        // Creating private variables
        private double hours;
        private double minutes;
        private double seconds;

        // Creating a public variable for delivery mode
        public DeliveryMode deliveryMode;

        // public properties for time in and time out
        public string timeIn;
        public string timeOut;

        // Creating a constructor
        public Time(double hours, double minutes, double seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        // Creating public properties for hours, minutes and seconds
        // The getter and setter will be used to get and set the values of the private variables
        public double Hours
        {
            // The getter will return the value of the private variable
            get { return hours; }
            // The setter will set the value of the private variable
            set { hours = value; }
        }

        public double Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }

        public double Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        // Creating a method to calculate the total hours
        public double CalculateHours()
        {
            // This calculation will convert the hours, minutes and seconds to total decimal hours
            double totalHours = this.hours + (this.minutes / 60) + (this.seconds / 3600);
            // This will return the total hours every time the method is called

            // This will round the total hours to 2 decimal places
            totalHours = Math.Round(totalHours, 2);
            return totalHours;
        }

        // string override method to return the payroll information
        public override string ToString()
        {
            // This will return the payroll information in given format
            return $"\n##########In description##########\n" +
                $"Delivery Mode: {this.deliveryMode}\n" +
                $"Hours: {this.hours}\n" +
                $"Minutes: {this.minutes}\n" +
                $"Seconds: {this.Seconds}\n\n" +
                $"Total Hours in decimal: {CalculateHours()}";
        }
    }
}
