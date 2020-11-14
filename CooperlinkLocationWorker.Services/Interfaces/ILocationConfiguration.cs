using CooperlinkLocationWorker.Domain.Enum;

namespace CooperlinkLocationWorker.Services.Interfaces
{
    public interface ILocationConfiguration
    {
        public double Radius { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public EDistanceType DistanceType { get;  }
    }
}
