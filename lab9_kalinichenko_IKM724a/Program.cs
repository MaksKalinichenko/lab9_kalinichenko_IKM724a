using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var employees = new List<Employee>
{
    new Employee { Name = "Олександр Коваленко", Position = "Розробник",   Salary = 85000, Experience = 8 },
    new Employee { Name = "Марія Шевченко",      Position = "Розробник",   Salary = 72000, Experience = 6 },
    new Employee { Name = "Андрій Бондаренко",   Position = "Розробник",   Salary = 45000, Experience = 3 },
    new Employee { Name = "Ірина Мельник",       Position = "Тестувальник", Salary = 38000, Experience = 4 },
    new Employee { Name = "Олег Ткаченко",       Position = "Розробник",   Salary = 95000, Experience = 10 },
    new Employee { Name = "Наталія Кравченко",   Position = "Менеджер",    Salary = 70000, Experience = 7 },
    new Employee { Name = "Дмитро Олійник",      Position = "Тестувальник", Salary = 42000, Experience = 5 },
    new Employee { Name = "Світлана Лисенко",    Position = "Дизайнер",    Salary = 50000, Experience = 4 },
    new Employee { Name = "Віктор Мороз",        Position = "Розробник",   Salary = 60000, Experience = 5 },
    new Employee { Name = "Юлія Попенко",        Position = "Менеджер",    Salary = 65000, Experience = 5 }
};

Console.WriteLine(" Усі працівники: ");
foreach (var e in employees)
    Console.WriteLine(e);

Console.WriteLine("\n=== 1) Розробники з досвідом > 5 років ===");
var seniorDevs = employees.Where(e => e.Position == "Розробник" && e.Experience > 5);
foreach (var e in seniorDevs)
    Console.WriteLine(e);

Console.WriteLine("\n=== 2) Сортування за зарплатою (зростання) ===");
var sortedBySalary = employees.OrderBy(e => e.Salary);
foreach (var e in sortedBySalary)
    Console.WriteLine(e);

Console.WriteLine("\n=== 3) Середня зарплата ===");
decimal avgSalary = employees.Average(e => e.Salary);
Console.WriteLine($"Середня зарплата: {avgSalary:F2} грн");

Console.WriteLine("\n=== 4) Кількість працівників на посадах ===");
var byPosition = employees.GroupBy(e => e.Position);
foreach (var group in byPosition)
    Console.WriteLine($"{group.Key}: {group.Count()}");

Console.WriteLine("\n=== Проєкція: імена та зарплати ===");
var short_ = employees.Select(e => new { e.Name, e.Salary });
foreach (var item in short_)
    Console.WriteLine($"{item.Name} - {item.Salary} грн");

Console.WriteLine("\n=== Сортування: посада, потім зарплата за спаданням ===");
var multiSorted = employees.OrderBy(e => e.Position).ThenByDescending(e => e.Salary);
foreach (var e in multiSorted)
    Console.WriteLine(e);

Console.WriteLine("\n=== Агрегація ===");
Console.WriteLine($"Мінімальна зарплата: {employees.Min(e => e.Salary)} грн");
Console.WriteLine($"Максимальна зарплата: {employees.Max(e => e.Salary)} грн");
Console.WriteLine($"Фонд зарплат: {employees.Sum(e => e.Salary)} грн");

Console.WriteLine("\n=== Квантифікація ===");
Console.WriteLine($"Є працівники з досвідом > 9 років: {employees.Any(e => e.Experience > 9)}");
Console.WriteLine($"Усі отримують понад 30000 грн: {employees.All(e => e.Salary > 30000)}");

var projects = new List<(string Position, string Project)>
{
    ("Розробник", "Backend"),
    ("Тестувальник", "QA"),
    ("Дизайнер", "UI/UX")
};
Console.WriteLine("\n=== З'єднання ===");
var joined = employees.Join(projects, e => e.Position, p => p.Position,
    (e, p) => new { e.Name, p.Project });
foreach (var item in joined)
    Console.WriteLine($"{item.Name} - проєкт {item.Project}");