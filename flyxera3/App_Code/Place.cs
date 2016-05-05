﻿using System;

namespace flyxera3
{
    public class Place
    {
        public double Latitude;
        public double Longitude;

        public Place(string latitude, string longitude)
        {
            Latitude = Convert.ToDouble(latitude);
            Longitude = Convert.ToDouble(longitude);
        }

        /// <summary>
        /// Returns the distance (in meters) between this and p. 
        /// </summary>
        /// The formulas are from http://www.movable-type.co.uk/scripts/latlong.html
        public double DistanceTo(Place p)
        {
            // The radius of the earth in meters.
            var R = 6371000;

            var φ1 = ToRadians(Latitude);
            var φ2 = ToRadians(p.Latitude);
            var Δφ = ToRadians(p.Latitude - Latitude);
            var Δλ = ToRadians(p.Longitude - Longitude);

            var a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) +
                    Math.Cos(φ1) * Math.Cos(φ2) *
                    Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c;
        }

        private double ToRadians(double θ)
        {
            return (Math.PI / 180) * θ;
        }
    }
}