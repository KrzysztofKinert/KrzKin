using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainSchedule.Models;

namespace TrainSchedule.Data
{
    public static class SelectResults
    {
        public static List<Result> FindResults(TrainScheduleContext context, Condition conditions)
        {
            var results = new List<Result>();

            var select = from stages in context.Stages
                         where stages.DepartureStation == conditions.FromStation
                         select stages.ConnectionID;
            List<int> IdsFrom = select.ToList();

            select = from stages in context.Stages
                     where stages.ArrivalStation == conditions.ToStation
                     select stages.ConnectionID;
            List<int> IdsTo = select.ToList();

            DateTime dateStart = conditions.Date;
            dateStart = dateStart.AddHours(conditions.Time.Hour - 1);
            dateStart = dateStart.AddMinutes(conditions.Time.Minute);
            DateTime dateEnd = dateStart.AddHours(11);

            if (conditions.IsDeparture == true)
            {
                select = from stages in context.Stages
                              where stages.DepartureDate >= dateStart
                                 && stages.DepartureDate <= dateEnd
                                 && stages.DepartureStation == conditions.FromStation
                              select stages.ConnectionID;
            }
            else
            {
                select = from stages in context.Stages
                              where stages.ArrivalDate >= dateStart
                                 && stages.ArrivalDate <= dateEnd
                                 && stages.ArrivalStation == conditions.ToStation
                              select stages.ConnectionID;
            }
            List<int> IdsDate = select.ToList();

            List<int> IdsType = new List<int>();
            if(conditions.IsExpress == true)
            {
                select = from connections in context.Connections
                         where connections.Type == "E"
                         select connections.ConnectionID;
                IdsType.AddRange(select.ToList());
            }
            if (conditions.IsIntercity == true)
            {
                select = from connections in context.Connections
                         where connections.Type == "I"
                         select connections.ConnectionID;
                IdsType.AddRange(select.ToList());
            }
            if (conditions.IsRegional == true)
            {
                select = from connections in context.Connections
                         where connections.Type == "R"
                         select connections.ConnectionID;
                IdsType.AddRange(select.ToList());
            }

            List<int> IdsWifi = new List<int>();
            if (conditions.IsWifi == true)
            {
                select = from connections in context.Connections
                         where connections.IsWiFi == true
                         select connections.ConnectionID;
                IdsWifi.AddRange(select.ToList());
            }
            else
            {
                select = from connections in context.Connections
                         select connections.ConnectionID;
                IdsWifi.AddRange(select.ToList());
            }

            List<int> IdsBicycleCarriage = new List<int>();
            if (conditions.IsBicycleCarriage == true)
            {
                select = from connections in context.Connections
                         where connections.IsBicycleCarriage == true
                         select connections.ConnectionID;
                IdsBicycleCarriage.AddRange(select.ToList());
            }
            else
            {
                select = from connections in context.Connections
                         select connections.ConnectionID;
                IdsBicycleCarriage.AddRange(select.ToList());
            }

            HashSet<int> intersection = new HashSet<int>(IdsFrom);
            intersection.IntersectWith(IdsTo);
            intersection.IntersectWith(IdsDate);
            intersection.IntersectWith(IdsType);
            intersection.IntersectWith(IdsWifi);
            intersection.IntersectWith(IdsBicycleCarriage);
            List<int> Ids = intersection.ToList();

            foreach (int id in Ids) results.Add(SelectResult(context, conditions, id));

            List<Result> sortedResults = new List<Result>();
            if(conditions.IsDeparture == true) sortedResults = results.OrderBy(r => r.Departure).ToList();
            else sortedResults = results.OrderBy(r => r.Arrival).ToList();

            return sortedResults;
        }
        public static Result SelectResult(TrainScheduleContext context, Condition conditions, int id)
        {
            Result result = new Result();

            var selectString = from connections in context.Connections
                               where connections.ConnectionID == id
                               select connections.Name;
            result.Name = selectString.First();

            result.ConnectionID = id;

            var selectDate = from stages in context.Stages
                             where stages.ConnectionID == id
                              && stages.DepartureStation == conditions.FromStation
                             select stages.DepartureDate;
            result.Departure = selectDate.First();

            selectDate = from stages in context.Stages
                         where stages.ConnectionID == id
                            && stages.ArrivalStation == conditions.ToStation
                         select stages.ArrivalDate;
            result.Arrival = selectDate.First();

            result.Stages = SelectStages(context, conditions, id);

            result.Distance = 0;
            foreach (Stage stage in result.Stages) result.Distance += stage.Distance;

            var selectService = from connections in context.Connections
                                where connections.ConnectionID == id
                                select connections.IsBicycleCarriage;
            result.IsBicycleCarriage = selectService.First();

            selectService = from connections in context.Connections
                            where connections.ConnectionID == id
                            select connections.IsWiFi;
            result.IsWiFi = selectService.First();

            var selectType = from connections in context.Connections
                             where connections.ConnectionID == id
                             select connections.Type;
            result.Type = selectType.First();

            result.Time = result.Arrival.Subtract(result.Departure);

            return result;
        }
        public static List<Stage> SelectStages(TrainScheduleContext context, Condition conditions, int ConnectionID)
        {
            var selectSequence = from stages in context.Stages
                                 where stages.DepartureStation == conditions.FromStation
                                    && stages.ConnectionID == ConnectionID
                                 select stages.Sequence;
            int minStage = selectSequence.First();

            selectSequence = from stages in context.Stages
                             where stages.ArrivalStation == conditions.ToStation
                                && stages.ConnectionID == ConnectionID
                             select stages.Sequence;
            int maxStage = selectSequence.First();

            var selectStages = from stages in context.Stages
                               where stages.Sequence >= minStage
                                && stages.Sequence <= maxStage
                                && stages.ConnectionID == ConnectionID
                               select stages;

            return selectStages.ToList();
        }
    }
}
