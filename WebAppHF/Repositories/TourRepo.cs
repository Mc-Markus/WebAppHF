using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public class TourRepo : ITourRepo
    {
        public Tour GetWalkByID(int Id)
        {
            using (HFContext context = new HFContext())
            {
                Tour tour = context.Tours.SingleOrDefault(t => t.ID == Id);
                return tour;
            }
        }

        public List<Tour> GetAll()
        {
            IEnumerable<Tour> Tours;
            using (HFContext context = new HFContext())
            {
                Tours = context.Tours.AsEnumerable();

                if (Tours == null)
                {
                    Console.WriteLine("empty");
                }
                return Tours.ToList();
            }
        }

        public List<List<OrderTourViewModel>> GetTourViewModels()
        {
            const string recordType = "tour";
            IEnumerable<Tour> tours;
            List<Tour> tourList;
            List<List<OrderTourViewModel>> OrderTours = new List<List<OrderTourViewModel>>();

            using (HFContext context = new HFContext())
            {
                tours = context.Tours.AsEnumerable();
                tours.OrderBy(t => t.Date)
                    .ThenBy(t => t.StartTime);
                tourList = tours.ToList();

                if (tours == null)
                {
                    return null;
                }

                DateTime day = tourList.Last().Date;
                DateTime time = tourList.Last().StartTime;

                foreach (var tour in tourList)
                {
                    if (day != tour.Date)
                    {
                        day = tour.Date;
                        List<OrderTourViewModel> DayList = new List<OrderTourViewModel>();
                        OrderTours.Add(DayList);

                        if (time != tour.StartTime)
                        {
                            time = tour.StartTime;

                            DayList.Add
                            (new OrderTourViewModel
                                (
                                    tour.Date,
                                    tour.StartTime,
                                    tour.Language + " Guide: " + tour.GuideName,
                                    tour.GuideName,
                                    new OrderItem(),
                                    new OrderItem()
                                )
                            );
                        }
                        else
                        {
                            DayList.Last().LanguageList.Add(tour.Language + " Guide: " + tour.GuideName);
                        }
                    }

                    else
                    {
                        if (time != tour.StartTime)
                        {
                            time = tour.StartTime;

                            OrderTours.Last().Add
                            (new OrderTourViewModel
                                (
                                    tour.Date,
                                    tour.StartTime,
                                    tour.Language + " Guide: " + tour.GuideName,
                                    tour.GuideName,
                                    new OrderItem(),
                                    new OrderItem()
                                )
                            );
                        }
                        else
                        {
                            OrderTours.Last().Last().LanguageList.Add(tour.Language + " Guide: " + tour.GuideName);
                        }
                    }
                }
                return OrderTours;


            }

        }
    }
}