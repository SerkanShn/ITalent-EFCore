using ITalent_EFCore.Models;
using ITalent_EFCore.Enums;

//Tablolara ekleme yapıldı
using (var dbContext = new RestaurantContext())
{
    var title = new Title() { TitleName = "Garson", StartDate = DateTime.Now.AddDays(-5), EndDate = DateTime.Now.AddDays(10) };
    var location = new Location() { City = Cities.Kocaeli };
    var salary = new Salary() { SalaryAmount = 1000, PrizeAmount = 50 };
    var departments = new List<Department>() { new Department() { Name = "Musteri Hizmetleri", Description = "Musterilerle ilgili departmanın açıklaması" },
                                               new Department() { Name = "Vale Hizmetleri", Description = "Musterilerin araclariyla ilgili departmanın açıklaması" }};
    var employee = new Employee() { Name = "Serkan", Surname = "Sahin", Email = "serkansahin@gmail.com", Title = title, Location = location, Salary = salary, departments = departments };
    dbContext.Employees.Add(employee);


    var title2 = new Title() { TitleName = "Asci", StartDate = DateTime.Now.AddDays(-15), EndDate = DateTime.Now.AddDays(20) };
    var location2 = new Location() { City = Cities.Mugla };
    var salary2 = new Salary() { SalaryAmount = 3000, PrizeAmount = 20 };
    var departments2 = new List<Department>() { new Department() { Name = "Ascilik Hizmetleri", Description = "Yemeklerin yapımıyla ilgili departmanın açıklaması" } };
    var employee2 = new Employee() { Name = "Serukan", Surname = "Kartal", Email = "serukankartal@gmail.com", Title = title2, Location = location2, Salary = salary2, departments = departments2 };
    dbContext.Employees.Add(employee2);


    dbContext.SaveChanges();

}

//Var olan Ünvanda ve Departmanda yeni işçi alımı yapıldı
using (var dbContext = new RestaurantContext())
{

    var title2 = dbContext.Titles.Single(x => x.TitleName == "Garson");
    var department2 = dbContext.Departments.Single(x => x.Name == "Ascilik Hizmetleri");
    var location2 = new Location() { City = Cities.Ankara };
    var salary2 = new Salary() { SalaryAmount = 2000, PrizeAmount = 20 };
    var employee22 = new Employee() { Name = "Ahmet", Surname = "Mehmet", Email = "ahmetmehmet@gmail.com", Title = title2, Location = location2, Salary = salary2, departments = new List<Department> { department2 } };
    dbContext.Employees.Add(employee22);
    dbContext.SaveChanges();
}


//Garson Unvanı Baş Garson ünvanına yükseltildi.
using (var dbContext = new RestaurantContext())
{
    var titles = dbContext.Titles.Where(x=>x.TitleName=="Garson");
    foreach (var item in titles)
    {
        item.TitleName = "Bas Garson";
    }
    dbContext.SaveChanges();
}

//Ücretlere 2 kat oranında zam yapıldı.
using (var dbContext = new RestaurantContext())
{
    var salaries = dbContext.Salaries;
    foreach (var item in salaries)
    {
        item.SalaryAmount *= 2;
    }
    dbContext.SaveChanges();
}

//Baş Garsonlar veritabanından silindi
using (var dbContext = new RestaurantContext())
{
    var employees = dbContext.Employees.Where(x=>x.Title.TitleName=="Bas Garson").ToList();
    dbContext.Employees.RemoveRange(employees);
    dbContext.SaveChanges();
}


//İşçi Tablosundaki kişilerin verilerinin çekilmesi
using (var dbContext = new RestaurantContext())
{
    var products = dbContext.Employees.ToList();
    products.ForEach(x => Console.WriteLine(x.Name + " " + x.Surname + " " + x.Email));
}

//İşçi, Unvanlar ve Lokasyonlar tablosunun inner join ile birleştirildi.
using (var dbContext = new RestaurantContext())
{
    var products = dbContext.Employees.ToList();

    var result1 = (from e in dbContext.Employees
                   join t in dbContext.Titles on e.TitleId equals t.Id
                   join l in dbContext.Locations on e.LocationId equals l.Id into pfList
                   from pf in pfList.DefaultIfEmpty()
                   select new
                   {
                       Name = e.Name,
                       Surname = e.Surname,
                       Email = e.Email,
                       Title = t.TitleName,
                       TitleStart = (DateTime?)t.StartDate,
                       Location = pf.City,
                   }
             ).ToList();


    foreach (var item in result1)
    {
        Console.WriteLine($"Isim: {item.Name} Soyisim: {item.Surname} Email: {item.Email} Unvan: {item.Title} Baslangic: {item.TitleStart} Sehir: {item.Location}");
    }


}