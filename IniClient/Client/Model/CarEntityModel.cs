using System;

namespace IniClient.Model
{
    internal class CarEntityModel : IModel
    {
        internal Guid Id { get; set; }

        internal string Number { get; set; }

        internal int XPosition { get; set; }

        internal int YPosition { get; set; }

        internal double FuelAmount { get; set; }

        internal double TyresWear { get; set; }

        internal bool IsActive { get; set; }

        public CarEntityModel() { }
    }
}
