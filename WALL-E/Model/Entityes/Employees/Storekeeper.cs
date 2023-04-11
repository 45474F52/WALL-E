namespace WALL_E.Model.Entityes.Employees
{
    internal sealed class Storekeeper : Employee
    {
        public Storekeeper(Positions position) : base(position) { }

        public override IEnumerable<string> JobDuties => new string[] { "Кладовщик" };
        
        public override string FullName => "Кладовщик";
    }
}