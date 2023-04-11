namespace WALL_E.Model.Entityes.Employees
{
    internal sealed class Cleaner : Employee
    {
        public Cleaner(Positions position) : base(position) { }

        public override IEnumerable<string> JobDuties => new string[] { "Уборщик" };

        public override string FullName => "Уборщик";
    }
}