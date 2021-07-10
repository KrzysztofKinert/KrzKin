using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainSchedule.Models;

namespace TrainSchedule.Data
{
    public class DbInitializer
    {
        public static void Initialize(TrainScheduleContext context)
        {
            if (context.Connections.Any())
            {
                return;
            }

            var connections = new Connection[]
            {
                new Connection{Name="Matejko",Type="I",IsWiFi=true,IsBicycleCarriage=true}
            };

            context.Connections.AddRange(connections);
            context.SaveChanges();

            var stages = new Stage[]
            {
                new Stage{ConnectionID=1,Sequence=1,DepartureStation="Opole",ArrivalStation="Oława",DepartureDate= new DateTime(2021,6,7,8,0,0),ArrivalDate= new DateTime(2021,6,7,8,24,0),Distance=40.0},
                new Stage{ConnectionID=1,Sequence=2,DepartureStation="Brzeg",ArrivalStation="Oława",DepartureDate= new DateTime(2021,6,7,8,26,0),ArrivalDate= new DateTime(2021,6,7,8,35,0),Distance=15.0},
                new Stage{ConnectionID=1,Sequence=3,DepartureStation="Oława",ArrivalStation="Wrocław Główny",DepartureDate= new DateTime(2021,6,7,8,37,0),ArrivalDate= new DateTime(2021,6,7,8,57,0),Distance=27.0}
            };

            context.Stages.AddRange(stages);
            context.SaveChanges();

            var stations = new Station[]
            {
                new Station{Name="Opole Główne"},
                new Station{Name="Opole Zachodnie"},
                new Station{Name="Chróścina Opolska"},
                new Station{Name="Dąbrowa Niemodlinska"},
                new Station{Name="Lewin Brzeski"},
                new Station{Name="Przecza"},
                new Station{Name="Brzeg"},
                new Station{Name="Lipki"},
                new Station{Name="Oława"},
                new Station{Name="Lizawice"},
                new Station{Name="Zębice Wrocławskie"},
                new Station{Name="Święta Katarzyna"},
                new Station{Name="Wrocław Brochów"},
                new Station{Name="Wrocław Główny"}
            };

            context.Stations.AddRange(stations);
            context.SaveChanges();

        }

        
    }
}
