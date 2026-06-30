using System;
using System.Collections.Generic;
using System.Text;

namespace SmartFactoryManagementSystem
{
    enum EmployeeStatus
    {
        Working,
        Relaxed,
        Vacation
    }
    internal abstract class Employee
    {
        private string? name;
        private EmployeeStatus? status;

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


        public Employee(string? name, DateTime HireDate, string? profesie, int ore)
        {
            Name = name;
            Ore = ore;
            Profesie = profesie;
            hiredate = HireDate;
            status = EmployeeStatus.Working;
        }


        public abstract void Work();

        public abstract void Salarys();

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Domnul {name} lucreaza in companie ca {profesie} - angajat la data: {HireDate}");
        }

    }

    internal class Director : Employee
    {
        private int nrMasiniDefecte;
        private decimal profitLuna;

        public int NrMasini 
        {
            get { return NrMasini; }
            set
            {
                if (NrMasini < 0)
                {
                    Console.WriteLine("NU ESTE POSIBIL SA AVEM NR DE MASINI NEGATIV!");
                }
                nrMasiniDefecte = value;
            }
        }

        public decimal ProfitLuna
        {
            get { return profitLuna; }
            set { profitLuna = value; }

        }


        public Director(string? name, DateTime HireDate, string? profesie, int ore,int nrMasiniDefecte,decimal profitLuna) : base(name, HireDate, profesie, ore)
        {
            NrMasini = nrMasiniDefecte;
            ProfitLuna= profitLuna;
        }

        private void AnalizeazaDocumentele()
        {
            Console.WriteLine("---Documente Analizate---");
            Console.WriteLine($"Numarul de masini defecte: {NrMasini}");
            Console.WriteLine($"Profitul din aceasta luna: {profitLuna} EURO");
        }

        private void Profit()
        {
            if(profitLuna >= 30000)
            {
                Console.WriteLine("Compania este stabila financiar ,ne putem gandi si la alte investitii");
            }
            else
            {
                Console.WriteLine("Compania este in declin ,daca se mentine acest profit lunar trebuie sa cautam solutii sa taiem din costuri");
            }
        }

        private void DecizieMasinarii()
        {
            if(nrMasiniDefecte >= 3)
            {
                Console.WriteLine("Anuntati Machine Operatorul despre probleme si respectati decizia lui,oprim productia sau inca producem");
            }
            else if(nrMasiniDefecte>0 || nrMasiniDefecte<=2)
            {
                Console.WriteLine("Anunta imediat mecanicul sa se ocupe de ele,ne incetineste productia");
            }
            else
            {
                Console.WriteLine("Totul este sub control,fabrica functioneaza in parametrii");
            }
        }


        public override void Work()
        {
            AnalizeazaDocumentele();
            Profit();
            DecizieMasinarii();
            
        }

        public override void Salarys()
        {
            double salary;
            Console.WriteLine("Salariul de baza a unui director este de 17.5 dolari pe ora");
            salary = 17.5 * Ore;
        }
    }

        internal class ProductionManager : Employee
        {
        private int Add;
        private string? Item;


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
