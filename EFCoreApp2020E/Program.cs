using System;

namespace EFCoreApp2020E
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("VS Fly system has been launched");

            var ctx = new WWWingsContext();

            Console.WriteLine("Checking if database exists...");
            var e = ctx.Database.EnsureCreated();

            if (!e)
            {
                Console.WriteLine("Database already exists, you can use it from Web API project");
                return;
            }

            Console.WriteLine("Database has been created, populating with test data");


            NewPilots();
            NewFlights();
            NewPassengers();
            NewBooking();


            Console.WriteLine("Database populated with test data");

        }



        private static void NewPilots()
        {
            using (var ctx = new WWWingsContext())
            {
                Pilot p1 = new Pilot { Surname = "Bono", GivenName = "Jean", Salary = 23000 };

                ctx.PilotSet.Add(p1);

                Pilot p2 = new Pilot { Surname = "Tilde", GivenName = "Pierre", Salary = 4800 };

                ctx.PilotSet.Add(p2);

                ctx.SaveChanges();
            }
        }

        

        private static void NewFlights()
        {
            
            using (var ctx = new WWWingsContext())
            {

                // on passe par le context pour accéder à la base de données
                ctx.FlightSet.Add(new Flight { Departure = "GVA", Destination = "LAX", Seats = 50, BasePrice = 200, PilotId = 1 });
                ctx.FlightSet.Add(new Flight { Departure = "GVA", Destination = "LAX", Seats = 20, BasePrice = 150, PilotId = 1 });
                ctx.FlightSet.Add(new Flight { Departure = "GVA", Destination = "Lausanne", Seats = 2, BasePrice = 50, PilotId = 2 });

                // on persiste le changement dans la base de données
                ctx.SaveChanges();
            }
        }





        public static void NewPassengers()
        {
            using (var ctx = new WWWingsContext())
            {
                Passenger p1 = new Passenger() { GivenName = "Igor", Surname = "Rsjt", Weight = 9 };
                ctx.Add(p1);

                Passenger p2 = new Passenger() { GivenName = "Toto", Surname = "Keller", Weight = 10 };
                ctx.Add(p2);

                Passenger p3 = new Passenger() { GivenName = "Anne", Surname = "Hanggg", Weight = 8 };
                ctx.Add(p3);

                Passenger p4 = new Passenger() { GivenName = "Sonia", Surname = "Chu", Weight = 6 };
                ctx.Add(p4);


                ctx.SaveChanges();
            }
        }


        public static void NewBooking()
        {
            using (var ctx = new WWWingsContext())
            {
                ctx.BookingSet.Add(new Booking { FlightNo = 1, PassengerID = 1, PricePaid = 50 });
                ctx.BookingSet.Add(new Booking { FlightNo = 1, PassengerID = 2, PricePaid = 40 });
                ctx.BookingSet.Add(new Booking { FlightNo = 2, PassengerID = 3, PricePaid = 50 });
                ctx.BookingSet.Add(new Booking { FlightNo = 2, PassengerID = 4, PricePaid = 90 });
                ctx.SaveChanges();
            }
        }


    }
}
