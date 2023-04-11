namespace WALL_E.Model.Entityes.Employees
{
    internal sealed class Director : Employee
    {
        public Director(Positions position) : base(position) { }

        public override IEnumerable<string> JobDuties => new string[]
        {
            "Директор",
            "",
            "",
            "Крутой чел"
        };
        
        public override string FullName => "Директор";
    }
}