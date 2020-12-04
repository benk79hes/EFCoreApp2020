using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCoreApp2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var ctx = new WWWingsContext();

            var e = ctx.Database.EnsureCreated();

            if (e)
                Console.WriteLine("Database has been created !");
            else
                Console.WriteLine("exists already.");

            // on a la base de données

            DeleteAllBookings();

            DeleteAllPassengers();

            NewPilots();

            NewPassengers();

            //printFlightsWithJoin();

            //Console.WriteLine("---------------------------------");

            // printFlightsWithArg();

            Console.WriteLine("---------------------------------");

            // printFlightsWithLambda();

            NewFlights();

            NewBookings();

            printBookings();

            // vérifier dans la base de données ou sélectionner et afficher tous les vols ici
            //printFlights();

            UpdateFlights();

            DeleteFlights();
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

        private static void NewPassengers()
        {
            using (var ctx = new WWWingsContext())
            {
                Passenger p1 = new Passenger { Surname = "Hello", GivenName = "Jean", Weight = 58 };

                ctx.PassengerSet.Add(p1);

                Passenger p2 = new Passenger { Surname = "World", GivenName = "Pierre", Weight = 84 };

                ctx.PassengerSet.Add(p2);

                ctx.SaveChanges();
            }
        }

        private static void NewBookings()
        {
            using (var ctx = new WWWingsContext())
            {
                Flight f = ctx.FlightSet.Find(1);

                foreach (Passenger p in ctx.PassengerSet)
                {
                    // explicit loading
                    Booking b = new Booking { Flight = f, Passenger = p };
                    ctx.BookingSet.Add(b);
                }

                ctx.SaveChanges();
            }
        }

        private static void DeleteFlights()
        {
            using (var ctx = new WWWingsContext())
            {
                // supprimer
                // ...
                int key = (from flight in ctx.FlightSet select flight.FlightNo).Max();

                Console.WriteLine("supprime : {0}", key);

                Flight f = ctx.FlightSet.Find(key);

                ctx.FlightSet.Remove(f);

                ctx.SaveChanges();
            }
        }

        private static void DeleteAllBookings()
        {
            using (var ctx = new WWWingsContext())
            {
                ctx.Database.ExecuteSqlRaw("TRUNCATE TABLE [BookingSet]");
            }
        }

        private static void DeleteAllPassengers()
        {
            using (var ctx = new WWWingsContext())
            {
                ctx.Database.ExecuteSqlRaw("DELETE FROM [PassengerSet]");
            }
        }

        private static void UpdateFlights()
        {
            using (var ctx = new WWWingsContext())
            {
                // modifier
                // ...
                Flight f = ctx.FlightSet.First();

                f.Seats += 1;

                ctx.SaveChanges();
            }
        }

        private static void NewFlights()
        {
            using (var ctx = new WWWingsContext())
            {
                // insérer
                Console.WriteLine("Insérer un nouvel avion : ");
                // un simple objet en C#

                Pilot p = ctx.PilotSet.Find(1);
                Flight f = new Flight { Departure = "GVA", Destination = "LAX", Seats = 300 };
                f.Pilot = p;

                Flight f2 = new Flight { Departure = "LAX", Destination = "GVA", Seats = 300 };
                f2.Pilot = p;

                // on passe par le context pour accéder à la base de données
                ctx.FlightSet.Add(f);
                ctx.FlightSet.Add(f2);

                // on persiste le changement dans la base de données
                ctx.SaveChanges();
            }
        }

        private static void printFlightsWithLambda()
        {
            using (var ctx = new WWWingsContext())
            {
                var q2 = ctx.FlightSet.Where(f => f.Seats > 100 && f.Departure.StartsWith("C"));

                foreach (Flight flight in q2)
                {
                    Console.WriteLine("{0} {1} {2}", flight.Date, flight.Destination, flight.Seats);
                }
            }
        }

        private static void printFlightsWithArg()
        {
            using (var ctx = new WWWingsContext())
            {
                // SQL -> Linq
                var q1 = from f in ctx.FlightSet
                         where f.Seats > 100
                         && f.Departure.StartsWith("C")
                         select f;

                foreach (Flight flight in q1)
                {
                    Console.WriteLine("{0} {1} {2}", flight.Date, flight.Destination, flight.Seats);
                }
            }
        }

        private static void printFlights()
        {
            // on crée le contexte localement
            using (var ctx = new WWWingsContext())
            {
                // sélectionner et afficher tous les vols
                foreach (Flight flight in ctx.FlightSet)
                {
                    // explicit loading
                    ctx.Entry(flight).Reference(x => x.Pilot).Load();

                    Console.WriteLine("{0} {1} {2} {3}", 
                        flight.Date, flight.Destination, flight.Seats, flight.Pilot.Surname);
                }
            } // le contexte est libéré
        }


        private static void printFlightsWithJoin()
        {
            // on crée le contexte localement
            using (var ctx = new WWWingsContext())
            {
                var q = from f in ctx.FlightSet.Include(x => x.Pilot) select f;

                // sélectionner et afficher tous les vols
                foreach (Flight flight in q)
                {
                    Console.WriteLine("{0} {1} {2} {3}", 
                        flight.Date, flight.Destination, flight.Seats, flight.Pilot.Surname);
                }
            } // le contexte est libéré
        }

        private static void printBookings()
        {
            // on crée le contexte localement
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Bookings:");
            using (var ctx = new WWWingsContext())
            {
                var q = from b in ctx.BookingSet.Include(x => x.Passenger).Include(x => x.Flight) select b;

                // sélectionner et afficher tous les vols
                foreach (Booking booking in q)
                {
                    Console.WriteLine("Flight: {0} {1} - Name: {2}, {3}Kg", 
                        booking.Flight.Date, booking.Flight.Destination, booking.Passenger.Surname, booking.Passenger.Weight);
                }
            } // le contexte est libéré
        }
    }
}
