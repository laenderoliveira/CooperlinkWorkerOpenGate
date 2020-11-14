using CooperlinkLocationWorker.Domain.Enum;
using CooperlinkLocationWorker.Domain.Models;
using System;

namespace CooperlinkLocationWorker.Domain.Extensions
{
    public static class LocationExtension
    {
        public static double DistanceBetweenTwoPoints(Location location1, Location location2, EDistanceType type = EDistanceType.KILOMETERS)
        {
            //HAVERSINE
            double R = (type == EDistanceType.MILES) ? 3960 : 6371;

            double dLat = toRadian(location2.Latitude - location1.Latitude);
            double dLon = toRadian(location2.Longitude - location1.Longitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(toRadian(location1.Latitude)) * Math.Cos(toRadian(location2.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;

            return d;
        }

        public static bool LocationWithinRadius(this LocationInfo location1, Location location2, double radius, EDistanceType type = EDistanceType.KILOMETERS)
        {
            var position2 = new Location(location1.Latitude, location1.Longitude);

            var distance = DistanceBetweenTwoPoints(position2, location2, type);

            return distance <= radius;
        }

        public static bool AllowedOpenGate(this LocationInfo curretLocation, LocationInfo lastLocation, Location baseLocation, double radius, EDistanceType distanceType)
        {
            return (
                lastLocation.Ignition == EIgnition.ON &&
                curretLocation.Ignition == EIgnition.OFF &&
                lastLocation.LocationWithinRadius(baseLocation, radius, distanceType) &&
                curretLocation.LocationWithinRadius(baseLocation, radius, distanceType)
                );
        }

        private static double toRadian(double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}
