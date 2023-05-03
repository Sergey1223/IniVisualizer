using System;
using System.Collections.Generic;

namespace IniClient.Model
{
    internal class CarEntityModelList : IModelList<CarEntityModel>
    {
        internal int TotalCount { get; }

        public List<CarEntityModel> Data { get; }

        public CarEntityModelList() { }

        internal CarEntityModelList(int totalCount, List<List<string>> table)
        {
            TotalCount = totalCount;
            Data = new List<CarEntityModel>();

            foreach (List<string> row in table)
            {
                CarEntityModel model = new CarEntityModel()
                {
                    Id = Guid.Parse(row[0]),
                    Number = row[1],
                    XPosition = int.Parse(row[2]),
                    YPosition = int.Parse(row[3]),
                    FuelAmount = double.Parse(row[4]),
                    TyresWear = double.Parse(row[5]),
                    IsActive = bool.Parse(row[6])
                };

                Data.Add(model);
            }
        }
    }
}
