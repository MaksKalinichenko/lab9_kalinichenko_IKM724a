public class Employee
{
    public string Name { get; set; } = "";
    public string Position { get; set; } = "";
    public decimal Salary { get; set; }
    public int Experience { get; set; }

    public override string ToString()
    {
        return $"{Name} | {Position} | {Salary} грн | досвід: {Experience} р.";
    }
}