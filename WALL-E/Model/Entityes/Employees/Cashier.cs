namespace WALL_E.Model.Entityes.Employees
{
    internal sealed class Cashier : Employee
    {
        public Cashier(Positions position) : base(position) { }

        public override IEnumerable<string> JobDuties => new string[] { "Кассир" };

        public override string FullName => "Кассир";
    }
}