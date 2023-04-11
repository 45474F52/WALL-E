namespace WALL_E.Model.Entityes.Employees
{
    internal sealed class Courier : Employee
    {
        public Courier(Positions position) : base(position) { }

        public override IEnumerable<string> JobDuties => new string[] { "Курьер" };
        
        public override string FullName => "Курьер";
    }
}