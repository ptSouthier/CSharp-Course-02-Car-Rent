using RentCars.Types;

namespace RentCars.Models;

public class Rent
{
    public Vehicle Vehicle { get; set; }
    public Person Person { get; set; }
    public int DaysRented { get; set; }
    public double Price { get; set; }
    public RentStatus Status { get; set; }

    //10 - Crie o construtor de `Rent` seguindo as regras de negócio
    public Rent(Vehicle vehicle, Person person, int daysRented)
    {
        Vehicle = vehicle;
        Person = person;
        DaysRented = daysRented;

        if (Person is PhysicalPerson)
        {
            Price = Vehicle.PricePerDay * daysRented;
        }
        else if(Person is LegalPerson)
        {
            double fullPrice = Vehicle.PricePerDay * daysRented;
            double discount = fullPrice * 0.10;
            Price = fullPrice - discount;
        }

        Status = RentStatus.Confirmed;
        Vehicle.IsRented = true;
        Person.Debit = Price;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Cancel()
    {
        Status = RentStatus.Canceled;
    }

    //11 - Implemente os métodos de `cancelar` e `finalizar` um aluguel
    public void Finish()
    {
        Status = RentStatus.Finished;
    }
}