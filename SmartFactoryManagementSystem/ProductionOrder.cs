using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;

namespace SmartFactoryManagementSystem
{
    enum ProductionStatus
    {
        completed,
        canceled,
        inProgress
    }

    internal class ProductionOrder
    {
        public int id;
        public string? unitati;
        public int nrUnitati;
        ProductionStatus status;
        public int cantitateMax;
        public int cantitateProdusa ;

        public string Unitati {  get; private set; }
        public int NrUnitati {  get; private set; }

        public int CantitateMax {  get; private set; }

        public int CantitateProdusa {  get; private set; }

        public int Id { get; private set; }

        
        public ProductionOrder ( string unitati,int nrUnitati,int cantitateMax)
        {
            Id = id;
            Unitati = unitati;
            NrUnitati = nrUnitati;
            CantitateMax = cantitateMax;
            CantitateProdusa = 0;

        }
        
        public void InregistreazaProductie()
        {
            if(NrUnitati <= 0)
            {
                Console.WriteLine("Nu poti introduce un numar negativ");
                return;
            }

            if (status == ProductionStatus.completed)
            {
                Console.WriteLine("Comanda este deja finalizata");
                return;
            }
            CantitateProdusa += NrUnitati;

            if (CantitateProdusa > CantitateMax)
            {
                CantitateProdusa = CantitateMax;
                status = ProductionStatus.completed;
                Console.WriteLine($"Comanda {id} este completa ");
            }
            else
            {
                status = ProductionStatus.inProgress;
                Console.WriteLine($"Comanda {id} este inca in progres:{CantitateProdusa}/{CantitateMax}");
            }  
        }

        public void Anuleaza()
        {
            if(status ==  ProductionStatus.completed)
            {
                Console.WriteLine("Nu poti anula o comanda deja completa");
                return;
            }
            status = ProductionStatus.canceled;
            Console.WriteLine($"Comanda {id} a fost anulata");
        }

        public void Afisare()
        {
            Console.WriteLine($"Comanda {id}-{Unitati}-{nrUnitati}-{status}");
        }
    }
}
