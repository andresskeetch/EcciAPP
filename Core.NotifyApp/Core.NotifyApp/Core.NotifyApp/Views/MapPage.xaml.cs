using Core.NotifyApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Position = Xamarin.Forms.Maps.Position;

namespace Core.NotifyApp.Views
{
	public partial class MapPage : ContentPage
	{
        GeolocatorService geolocatorService;

        public MapPage()
        {
            InitializeComponent();
            geolocatorService = new GeolocatorService();
            loadUbications();
        }

        public void loadUbications()
        {

            var position = new Position(
            4.6374173, -74.071207);

            List<Pin> pins = new List<Pin>();
            pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(4.6374173, -74.071207),
                Label = "Universidad ECCI Sede Principal",
                Address = "Cra. 19 #49-20, Bogotá, Cundinamarca"
            });
            pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(4.6375963, -74.071394),
                Label = "Universidad ECCI - Sede I",
                Address = "Cra. 19 #49-27, Bogotá, Cundinamarca"
            });

            pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(4.6377553, -74.071387),
                Label = "Universidad ECCI - Sede K",
                Address = "Cra. 19 #49-57, Bogotá, Cundinamarca"
            });

            pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(4.6380613, -74.07143),
                Label = "Universidad ECCI - Sede J",
                Address = "Cra. 19 #49-20, Bogotá, Cundinamarca"
            });

            pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(4.6368226, -74.0712884),
                Label = "Universidad ECCI - Sede G",
                Address = "Cra. 19 #48-32, Bogotá, Cundinamarca"
            });

            pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(4.6367373, -74.071642),
                Label = "Universidad ECCI - Sede G2",
                Address = "Cra. 19 #48-21, Bogotá, Cundinamarca"
            });

            pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(4.6386529, -74.0709796),
                Label = "Universidad ECCI - Sede J3",
                Address = "Cra. 19 #50-30, Bogotá, Cundinamarca"
            });

            pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(4.6383107, -74.0722191),
                Label = "Universidad ECCI - Sede J2",
                Address = "Cl. 50 #20-31, Bogotá, Cundinamarca"
            });

            pins.Add(new Pin
            {
                Type = PinType.Place,
                Position = new Position(4.6393971, -74.0712428),
                Label = "Universidad ECCI Sede P",
                Address = "Cl. 51 #19-12, Bogotá, Cundinamarca"
            });

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                position,
                Distance.FromKilometers(.0)));
            foreach (Pin Pim in pins)
            {
                MyMap.Pins.Add(Pim);
            }
        }
    }
}