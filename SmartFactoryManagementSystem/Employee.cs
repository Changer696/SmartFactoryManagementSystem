using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFactoryManagementSystem
{
    internal abstract class Employee
    {
        private string? name;

        private string? profesie;

        private DateTime HireDate;

        private int ore;
        

        public string? Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Ore
        {
            get { return ore; }
            set { ore = value; }
        }
        public DateTime hiredate
        {
            get { return hiredate; }
            set { hiredate = value; }
        }


        public string? Profesie
        {
            get { return profesie; }
            set { profesie = value; }
        }


        public Employee( string? name, DateTime HireDate,   string? profesie,int ore)
        {
            Name = name;
            Ore = ore;
            Profesie = profesie;
            hiredate = HireDate;
        }

        public abstract void Work();

        public abstract void Salarys();

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Domnul {name} lucreaza in companie ca {profesie} - angajat de la data: {HireDate}");
        }

    }

    internal class Director : Employee
    {   
        public Director(string? name, DateTime HireDate, string? profesie, int ore):base(name , HireDate, profesie,ore)
        { }

        public override void Work()
        {
            Console.WriteLine("Se asigură că liniile de producție uncționează la capacitate optimă, fără timpi morți");
        }

        public override void Salarys()
        {
            double  salary;
            Console.WriteLine("Salariul de baza a unui director este de 17.5 dolari pe ora");
            salary = 17.5 * Ore;
        }

        internal class  ProductionManager : Employee
        {
            public ProductionManager(string? name, DateTime HireDate, string? profesie, int ore) : base(name, HireDate, profesie, ore)
            { }

            public override void Work()
            {
                Console.WriteLine("Preia obiectivele de la director și le transpune în targeturi zilnice pentru echipe");
            }

            public override void Salarys()
            {
                double salary;
                Console.WriteLine("Salariul de baza a unui director este de 15.5 dolari pe ora");
                salary = 15.5 * Ore;
            }
        }

    

}

