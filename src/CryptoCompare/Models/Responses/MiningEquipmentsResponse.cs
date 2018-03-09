using System.Collections.Generic;

namespace CryptoCompare
{
    public class MiningEquipmentsResponse : BaseApiResponse
    {
        public IReadOnlyDictionary<string, MiningEquipment> MiningData { get; set; }
    }
}
