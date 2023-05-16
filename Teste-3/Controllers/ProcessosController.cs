using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Device.Location;

namespace Teste_3.Controllers
{
    public class ProcessosController : Controller
    {
        public ActionResult Geolocalizacao()
        {
            return View();
        }

        public ActionResult Resultado()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);

            // start the watcher
            watcher.Start();

            // wait for the watcher to get a location fix
            while (watcher.Status != GeoPositionStatus.Ready)
            {
                // wait for the watcher to get a fix
            }

            // get the current location
            GeoCoordinate currentLocation = watcher.Position.Location;

            // stop the watcher
            watcher.Stop();

            double databaseVariable1 = -23.465410;
            double databaseVariable2 = -46.573629;


            // create two GeoCoordinate objects
            GeoCoordinate pointA = new GeoCoordinate(currentLocation.Latitude, currentLocation.Longitude);
            GeoCoordinate pointB = new GeoCoordinate(databaseVariable1, databaseVariable2);

            // calculate the distance between the two points
            var distanceInMeters = pointA.GetDistanceTo(pointB);
           

            // print the distance in meters
            ViewData["distancia"] = distanceInMeters;


            if (distanceInMeters <= 1000)
            {
                //Console.WriteLine("DENTRO DO RAIO");
                ViewData["resultado"] = "DENTRO DO RAIO, CHECK-IN REALIZADO COM SUCESSO!";
                ViewData["coordenadas"] = pointA;
            }
            else
            {
                //Console.WriteLine("FORA DO RAIO");
                ViewData["resultado"] = "FORA DO RAIO, CHECK-IN INVÁLIDO!";
                ViewData["coordenadas"] = pointA;
            }

            return View();
        }


    }
}