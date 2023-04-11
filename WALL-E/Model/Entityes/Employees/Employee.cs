namespace WALL_E.Model.Entityes.Employees
{
    /// <summary>
    /// Базовый класс сотрудников
    /// </summary>
    internal abstract class Employee
    {
        protected Employee(Positions position) => Position = position;

        /// <summary>
        /// Полное имя сотрудника
        /// </summary>
        public abstract string FullName { get; }

        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public Positions Position { get; }

        /// <summary>
        /// Должностные обязанности
        /// </summary>
        public abstract IEnumerable<string> JobDuties { get; }
    }

    /// <summary>
    /// Возможные должности сотрудников
    /// </summary>
    public enum Positions
    {
        /// <summary>
        /// Директор
        /// </summary>
        Director,

        /// <summary>
        /// Администратор
        /// </summary>
        Administrator,

        /// <summary>
        /// Супервайзер
        /// </summary>
        Supervisor,

        /// <summary>
        /// Оператор 1С
        /// </summary>
        Operator_1C,

        /// <summary>
        /// Кладовщик
        /// </summary>
        Storekeeper,

        /// <summary>
        /// Охранник
        /// </summary>
        Security,

        /// <summary>
        /// Курьер
        /// </summary>
        Courier,

        /// <summary>
        /// Кассир
        /// </summary>
        Cashier,

        /// <summary>
        /// Уборщик
        /// </summary>
        Cleaner
    }
}