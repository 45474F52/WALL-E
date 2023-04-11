namespace WALL_E.Model.Entityes.Employees
{
    internal sealed class Administrator : Employee
    {
        public Administrator(Positions position) : base(position) { }

        public override IEnumerable<string> JobDuties => new string[] { "Администратор" };

        public override string FullName => "Администратор";
    }
}