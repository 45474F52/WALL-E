namespace WALL_E.Model.Entityes.Employees
{
    internal sealed class Security : Employee
    {
        public Security(Positions position) : base(position) { }

        public override IEnumerable<string> JobDuties => new string[] { "Охранник" };
        
        public override string FullName => "Охранник";
    }
}