using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MeetupsApi.Data;

namespace MeetupsApi.Models
{
    public class MeetupModel
    {   
        
        public List<Meetups> GetAll()
        {
            Console.WriteLine("MeetupModel.GetAll : START");
            var context = new SantanderChalengeContext();
            Console.WriteLine("MeetupModel.GetAll : END");
            return context.Meetups.ToList();
        }

        public string Create(int userOrganizer, string title,int canceled)
        {
            Console.WriteLine("MeetupModel.Create : START");
            try
            {
                var context = new SantanderChalengeContext();
                var met = new Meetups();
                met.UserOrganizer=userOrganizer; 
                met.Title=title;
                met.Canceled=canceled;
                context.Meetups.Add(met);
                context.SaveChanges();
                Console.WriteLine("MeetupModel.Create : END");
                return "";
            }
            catch(Exception ex)
            {                
                Console.WriteLine("MeetupModel.Create : ERROR : "+ex.Message);
                return ex.Message;
            }
        }
        public string Cancel(int id )
        {
            Console.WriteLine("MeetupModel.Cancel : START");
            try
            {
                var context = new SantanderChalengeContext();
                var res = context.Meetups.SingleOrDefault(x=> x.Id == id);
                res.Canceled = 1;
                context.SaveChanges();
                Console.WriteLine("MeetupModel.Cancel : END");
                return "";
            }
            catch(Exception ex)
            {                
                Console.WriteLine("MeetupModel.Cancel : ERROR : "+ex.Message);
                return ex.Message;
            }
        }

        public string Update(int id , string title )
        {
            Console.WriteLine("MeetupModel.Update : START");
            try
            {
                var context = new SantanderChalengeContext();
                var res = context.Meetups.SingleOrDefault(x=> x.Id == id);
                res.Title = title;
                context.SaveChanges();
                Console.WriteLine("MeetupModel.Update : END");
                return "";
            }
            catch(Exception ex)
            {                
                Console.WriteLine("MeetupModel.Update : RROR : "+ex.Message);
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            Console.WriteLine("MeetupModel.Delete : START");
            try
            {
                var context = new SantanderChalengeContext();
                context.Remove(context.Meetups.Single(x=> x.Id == id)); 
                context.SaveChanges();
                Console.WriteLine("MeetupModel.Delete : END");
                return "";
            }
            catch(Exception ex)
            {
                Console.WriteLine("MeetupModel.Delete : ERROR : "+ex.Message);
                return ex.Message;
            }
        }
        
    }
}