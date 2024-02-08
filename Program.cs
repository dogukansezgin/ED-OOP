// Engin Demiroğ: Canlı Yayın 2 : C# & JAVA Nesne Yönelimli Programlama
// https://youtu.be/H3QOQRh8cgk

// Bellek; Stack / Heap

// Customer customer = new Customer(); // örneğini oluşturmak, instance oluşturmak, instance creation

//IoC Container
CustomerManager customerManager = new CustomerManager(new Customer(), new TeacherCreditManager()); // dependency injection
customerManager.GiveCredit();




// interface ; 1 'class', 1'den fazla 'interface'i implemente edebilir.
interface ICreditManager 
{
    void Calculate();

    //DRY: do not repeat yourself - abstract class
    void Save();
}
abstract class BaseCreditManager : ICreditManager
{
    public abstract void Calculate();

    public virtual void Save()
    {
        Console.WriteLine("Kaydedildi");
    }
}

class TeacherCreditManager : BaseCreditManager, ICreditManager
{
    public override void Calculate()
    {
        Console.WriteLine("Öğretmen kredisi verildi");
    }

    public override void Save()
    {
        // kodlar
        Console.WriteLine("Öğretmen verisi");
        base.Save();
        // kodlar
    }

}

class MilitaryCreditManager : BaseCreditManager, ICreditManager
{
    public override void Calculate()
    {
        Console.WriteLine("Asker kredisi verildi");
    }

}

// SOLID prensipleri
class Customer
{
    public Customer()
    {
        Console.WriteLine("Müşteri nesnesi başlatıldı");
    }
    public int Id { get; set; }
    public string City { get; set; }

}
// inheritance ; 1 'class', sadece 1 'class'/'abstract class' inherit edebilir.
class Person : Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
}

class Company : Customer
{
    public string CompanyName { get; set; }
    public string TaxNumber { get; set; }
}

// Katmanlı mimariler

class CustomerManager
{
    private Customer _customer;
    private ICreditManager _creditManager;

    // encapsulation
    public CustomerManager(Customer customer, ICreditManager creditManager) // polymorphism
    {
        _customer = customer;
        _creditManager = creditManager;
    }

    public void Save()
    {
        Console.WriteLine("Müşteri kaydedildi");
    }
    public void Delete()
    {
        Console.WriteLine("Müşteri silindi ");
    }
    public void GiveCredit()
    {
        _creditManager.Calculate();
        Console.WriteLine("Kredi verildi");
        _creditManager.Save();
    }
}