namespace WALL_E.Model.Entityes.Employees
{
    internal sealed class Operator : Employee
    {
        public Operator(Positions position) : base(position) { }

        public override IEnumerable<string> JobDuties => new string[] { "Оператор 1С" };
        
        public override string FullName => "Оператор 1С";
    }
}