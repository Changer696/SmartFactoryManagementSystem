using System;

using System.Collections.Generic;

using System.ComponentModel.Design;

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

        string? id;

        private string? name;

        private EmployeeStatus? status;



        private string? profesie;



        private DateTime HireDate;



        private int ore;



        public string? Id

        {

            get { return id; }

            set { id = value; }

        }

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





        public Employee(string? id, string? name, DateTime HireDate, string? profesie, int ore)

        {

            Id = id;

            Name = name;

            Ore = ore;

            Profesie = profesie;

            hiredate = HireDate;

            status = EmployeeStatus.Working;

        }





        public abstract void Work();



        public abstract void Salaries();



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





        public Director(string? id, string? name, DateTime HireDate, string? profesie, int ore, int nrMasiniDefecte, decimal profitLuna) : base(id, name, HireDate, profesie, ore)

        {

            NrMasini = nrMasiniDefecte;

            ProfitLuna = profitLuna;

        }



        private void AnalizeazaDocumentele()

        {

            Console.WriteLine("---Documente Analizate---");

            Console.WriteLine($"Numarul de masini defecte: {NrMasini}");

            Console.WriteLine($"Profitul din aceasta luna: {profitLuna} EURO");

        }



        private void Profit()

        {

            if (profitLuna >= 30000)

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

            if (nrMasiniDefecte >= 3)

            {

                Console.WriteLine("Anuntati Machine Operatorul despre probleme si respectati decizia lui,oprim productia sau inca producem");

            }

            else if (nrMasiniDefecte > 0 || nrMasiniDefecte <= 2)

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



        public override void Salaries()

        {

            double salary;

            Console.WriteLine("Salariul de baza a unui director este de 23.5 dolari pe ora");

            salary = 23.5 * Ore;

        }

    }



    internal class ProductionManager : Employee

    {

        private int Add;

        private string? Item;





        public ProductionManager(string? id, string? name, DateTime HireDate, string? profesie, int ore) : base(id, name, HireDate, profesie, ore)

        { }





        public override void Work()

        {

            Console.WriteLine("Preia obiectivele de la director și le transpune în targeturi zilnice pentru echipe");

        }



        public override void Salaries()

        {

            double salary;

            Console.WriteLine("Salariul de baza a unui director este de 16.5 dolari pe ora");

            salary = 16.5 * Ore;

        }





    }



    internal class Engineer : Employee

    {

        private bool inovatie;

        public bool inovation

        {

            get { return inovatie; }

            set { inovatie = value; }



        }





        public Engineer(string? id, string? name, DateTime HireDate, string? profesie, int ore) : base(id, name, HireDate, profesie, ore)

        { }



        private void Inovatie()

        {

            Console.WriteLine("Lucreaza la o noua jucarie care sa interactioneze cu un copil");

            if (inovatie == true)

            {



                Console.WriteLine("Au reusit sa aduca proiectul la sfartit si o sa primeasca o marire de salariu ");



            }

            else

            {

                Console.WriteLine("Inca lucreaza la jucarie...");

            }

        }

        public override void Work()

        {

            Console.WriteLine("Se ocupa pe partea de proiectare");

            Inovatie();

        }



        public override void Salaries()

        {

            double salary;

            if (inovatie == true)

            {



                Console.WriteLine("Salariul de baza a unui inginer este de 21.5 dolari pe ora");

                salary = 21.5 * Ore;

            }



            else

            {

                Console.WriteLine("Salariul de baza a unui inginer este de 18.5 dolari pe ora");

                salary = 18.5 * Ore;

            }

        }



    }



    internal class Tehniocian : Employee

    {







        public Tehniocian(string? id, string? name, DateTime HireDate, string? profesie, int ore) : base(id, name, HireDate, profesie, ore)

        { }





        public override void Work()

        {

            Console.WriteLine("Tehnicianl se ocupa cu mentenanta aparatelor");

        }



        public override void Salaries()

        {

            double salary;

            Console.WriteLine("Salariul de baza a unui director este de 15.5 dolari pe ora");

            salary = 15.5 * Ore;

        }





    }



    internal class MachineOperator : Employee

    {







        public MachineOperator(string? id, string? name, DateTime HireDate, string? profesie, int ore) : base(id, name, HireDate, profesie, ore)

        { }





        public override void Work()

        {

            Console.WriteLine("Setează, pornește și supraveghează mașinile care fabrică produsele.");

        }



        public override void Salaries()

        {

            double salary;

            Console.WriteLine("Salariul de baza a unui director este de 15.5 dolari pe ora");

            salary = 15.5 * Ore;

        }





    }

    internal class WareHouseOperator : Employee

    {







        public WareHouseOperator(string? id, string? name, DateTime HireDate, string? profesie, int ore) : base(id, name, HireDate, profesie, ore)

        { }





        public override void Work()

        {

            Console.WriteLine("Gestionează stocurile de materii prime și de produse finite.");

        }



        public override void Salaries()

        {

            double salary;

            Console.WriteLine("Salariul de baza a unui director este de 13.5 dolari pe ora");

            salary = 15.5 * Ore;

        }





    }



    internal class SalesAgent : Employee

    {







        public SalesAgent(string? id, string? name, DateTime HireDate, string? profesie, int ore) : base(id, name, HireDate, profesie, ore)

        { }





        public override void Work()

        {

            Console.WriteLine("Aduce bani în companie prin vânzarea produselor fabricate.");

        }



        public override void Salaries()

        {

            double salary;

            Console.WriteLine("Salariul de baza a unui director este de 14.5 dolari pe ora");

            salary = 14.5 * Ore;

        }



        public void SellProduct(Factory factory, string productName, int quantity)

        {

            Console.WriteLine($"\n[Agent {Name}] Inițiază vânzarea pentru {quantity}x {productName}...");



            // Factory.ProcessSale aplică Regula 14 (verifică dacă produsul există și dacă e suficient stoc)

            bool saleSuccess = factory.ProcessSale(productName, quantity);



            if (saleSuccess)

            {

                Console.WriteLine($"[Agent {Name}] Vânzarea s-a încheiat cu succes!");

            }

            else

            {

                Console.WriteLine($"[Agent {Name}] Vânzarea a picat. Regulile de business nu permit vânzarea.");

            }

        }



    }



    internal class Accountant : Employee

    {







        public Accountant(string? id, string? name, DateTime HireDate, string? profesie, int ore) : base(id, name, HireDate, profesie, ore)

        { }





        public override void Work()

        {

            Console.WriteLine("Ține evidența clară a tuturor veniturilor și cheltuielilor fabricii.");

        }



        public override void Salaries()

        {

            double salary;

            Console.WriteLine("Salariul de baza a unui director este de 16.5 dolari pe ora");

            salary = 16.5 * Ore;

        }





    }



















}

