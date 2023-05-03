using IniServer.Repository.Fields;
using System;

namespace IniServer.Repository
{
    internal class CarEntityModel : IGenerableEntityModel<CarEntityModel>
    {
        private const string NUMBER_MINIMUM_VALUE = "A";
        private const string NUMBER_MAXIMUM_VALUE = "C";
        private const string NUMBER_PATTERN = "%%%%-%%%";
        private const int POSITION_MINIMUM_VALUE = 0;
        private const int POSITION_MAXIMUM_VALUE = 1000;
        private const float FUEL_MINIMUM_VALUE = 0;
        private const float FUEL_MAXIMUM_VALUE = 500;
        private const float TYRES_WEAR_MINIMUM_VALUE = 0;
        private const float TYRES_WEAR_MAXIMUM_VALUE = 500;

        [Column(0, false)]
        public Guid Id { get; set; }

        [Column(1, true)]
        public GenerableStringField Number { get; set; }

        [Column(2, true)]
        public GenerableIntegerField XPosition { get; set; }

        [Column(3, true)]
        public GenerableIntegerField YPosition { get; set; }

        [Column(4, true)]
        public GenerableFloatField FuelAmount { get; set; }

        [Column(5, true)]
        public GenerableFloatField TyresWear { get; set; }

        [Column(6, true)]
        public GenerableBooleanField IsActive { get; set; }

        public void GenerateFields(ref Random random)
        {
            Number = new GenerableStringField(NUMBER_MINIMUM_VALUE, NUMBER_MAXIMUM_VALUE, NUMBER_PATTERN, ref random);
            XPosition = new GenerableIntegerField(POSITION_MINIMUM_VALUE, POSITION_MAXIMUM_VALUE, ref random);
            YPosition = new GenerableIntegerField(POSITION_MINIMUM_VALUE, POSITION_MAXIMUM_VALUE, ref random);
            FuelAmount = new GenerableFloatField(FUEL_MINIMUM_VALUE, FUEL_MAXIMUM_VALUE, ref random);
            TyresWear = new GenerableFloatField(TYRES_WEAR_MINIMUM_VALUE, TYRES_WEAR_MAXIMUM_VALUE, ref random);
            IsActive = new GenerableBooleanField(false, true, ref random);
        }

        public void RegenerateFields(ref Random random)
        {
            XPosition.Generate(ref random);
            YPosition.Generate(ref random);
            FuelAmount.Generate(ref random);
            TyresWear.Generate(ref random);
            IsActive.Generate(ref random);
        }
    }
}
