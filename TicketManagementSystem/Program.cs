using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem
{
    internal class Program
    {
        class TicketQueue
        {
            static int max = 100;
            string[] tickets = new string[max];
            int front;
            int rear;

            public TicketQueue()
            {
                front = -1;
                rear = -1;
            }

            public bool isEmpty()
            {
                return (front == -1 && rear == -1);
            }

            public bool isFull()
            {
                return (rear == max - 1);
                //{
                //    Console.WriteLine("Ticket Queue is full.");
                //    return true;
                //}
                //return false;
            }

            public bool addTicket(string Ticket)
            {
                if (isFull())
                {
                    Console.WriteLine("Ticket Queue is full.");
                    return false;
                }
                else if (isEmpty())
                {
                    front = 0;
                    rear = 0;
                    tickets[rear] = Ticket;
                    Console.WriteLine($"Ticket {Ticket} added successfully!");
                    return true;
                }
                else
                {
                    rear = rear + 1;
                    tickets[rear] = Ticket;
                    Console.WriteLine($"Ticket {Ticket} added successfully!");
                    return true;
                }
            }

            public void processTicket()
            {
                if (isEmpty())
                {
                    Console.WriteLine("No tickets to process!");
                    return;
                }
                else if(front == rear)
                {
                    Console.WriteLine($"Processed last ticket{tickets[front]}");
                    front = rear = -1;
                }
                else
                {
                    Console.WriteLine($"Processed and removed ticket{tickets[front]}");
                    front = front + 1;
                }
            }

            public void viewNextTicket()
            {
                if (isEmpty())
                {
                    Console.WriteLine("No tickets waiting for processing.");
                    return;
                }
                Console.WriteLine($"Next ticket to process: {tickets[front]}");
            }

            public void displayTickets()
            {
                if (isEmpty())
                {
                    Console.WriteLine("No tickets available!");
                    return;
                }

                Console.WriteLine("Current tickets in system: ");
                for(int i = front; i < rear; i++)
                {
                    Console.WriteLine($"{tickets[i]}");
                }
                Console.WriteLine($"Total tickets: {rear - front + 1}");
            }
        }
        static void Main(string[] args)
        {
            TicketQueue queue = new TicketQueue();

            Console.WriteLine("Customer support Ticketing System");

            Console.WriteLine("Adding tickets:");
            queue.addTicket("Login Issue");
            queue.addTicket("Password Reset");
            queue.addTicket("Payment Problem");
            queue.addTicket("Account locked");
            queue.displayTickets();

            Console.WriteLine("Viewing next Ticket:");
            queue.viewNextTicket();

            Console.WriteLine("Processing two tickets:");
            queue.processTicket();
            queue.processTicket();
            queue.displayTickets();

        }
    }
}
