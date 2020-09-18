using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Satellite_cs;

public class SatelliteCsTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        // string line0 = "ISS (ZARYA)    ";
        string line1 = "1 25544U 98067A   20258.18510567  .00000068  00000-0  93716-5 0  9995";
        string line2 = "2 25544  51.6438 268.0523 0000907  94.9123  25.5188 15.48946285245810";
        
        Sat_Io io = new Sat_Io();
        Satrec satrec = io.twoline2satrec(line1,line2);


        Gstime gmst = new Gstime();
        DateTime newDate = DateTime.Now;

        Sgp4 sgp4 = new Sgp4();
        // Pass minutes since epoc
        // PositionAndVelocity positionAndVelocity = sgp4.sgp4(satrec, 0);

        // Or you can use the DateTime object Date

        Propagate propagate = new Propagate();
        PositionAndVelocity positionAndVelocity = propagate.propagate(satrec, newDate);

        // Set the Observer at 122.03 West by 36.96 North, in RADIANS
        Geodetic observerGd = new Geodetic();
        Satellite_cs.Transform tf = new Satellite_cs.Transform();
        DopplerFactor df = new DopplerFactor();

        observerGd.longitude = tf.degreesToRadians(-122.0308);
        observerGd.latitude = tf.degreesToRadians(36.9613422);
        observerGd.height = 0.370;


       
        double gmstTime = gmst.gstime(newDate); // GMST definition 

        DateTime UTCdate = newDate.ToUniversalTime();

        // // You can get ECF, Geodetic, Look Angles, and Doppler Factor.
        Coordinates positionEcf = tf.eciToEcf(positionAndVelocity.position_ECI, gmstTime);
        Coordinates observerEcf = tf.geodeticToEcf(observerGd);
        Coordinates velocityEcf = tf.eciToEcf(positionAndVelocity.velocity_ECI, gmstTime);
        Geodetic positionGd = tf.eciToGeodetic(positionAndVelocity.position_ECI, gmstTime);
        LookAngles lookAngles = tf.ecfToLookAngles(observerGd, positionEcf);
        double dopplerFactor = df.dopplerFactor(observerEcf, positionEcf, velocityEcf);

        // The position_velocity result is a key-value pair of ECI coordinates.
        // These are the base results from which all other coordinates are derived.
        Coordinates positionEci = positionAndVelocity.position_ECI;
        Coordinates velocityEci = positionAndVelocity.velocity_ECI;

        double satelliteX = positionEci.x;
        double satelliteY = positionEci.y;
        double satelliteZ = positionEci.z;

         // Look Angles may be accessed by `azimuth`, `elevation`, `range_sat` properties.
        double azimuth = lookAngles.azimuth;
        double elevation = lookAngles.elevation;
        double rangeSat  = lookAngles.rangeSat;

        // Geodetic coords are accessed via `longitude`, `latitude`, `height`.
        double longitude = positionGd.longitude;
        double latitude  = positionGd.latitude;
        double height    = positionGd.height;

        //  Convert the RADIANS to DEGREES for pretty printing (appends "N", "S", "E", "W", etc).
        double longitudeStr = tf.degreesLong(longitude);
        double latitudeStr  = tf.degreesLat(latitude);

        Debug.Log("Long: " + longitudeStr);
        Debug.Log("Lat: " + latitudeStr);


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
