using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Google.Apis.Requests;
using ConsoleApp1.Stag;

namespace ConsoleApp1.Export
{
    /// <summary>
    /// Naváže spojení s google kalendářem, vytvoří požadovaný kalendář a provede export událostí 
    /// </summary>
    public class Exporter
    {
        static string[] Scopes = { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents };
        static string ApplicationName = "Google Calendar API .NET Stag/IS exporter";
        static UserCredential credential;
        static string CalendarId = Stag.Uzivatel.CalendarId;

      
  
        /// <summary>
        /// Vyvolá metodu PridejUdalosti()
        /// </summary>
        public void SpustExport()
        {
            Task.Run(async () =>
            {
                await PridejUdalosti();
            }).GetAwaiter().GetResult();
        }

        public async Task PridejUdalosti()
        {
            using (var stream =
                  new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json"; 
                try {
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }
                catch (Exception e)
                {
                    Uzivatel.ChybovaHlaska = "Chyba behem exportu. " + e;
                }

            }

            // Create Google Calendar API service.        
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
                
            });



                // VYTVORENI NOVEHO KALENDARE
            Calendar calendar = new Calendar();
            calendar.Summary =Uzivatel.Kalendar;

            // VLOZENI NOVEHO KALENDARE
            try
            {
                Calendar createdCalendar = service.Calendars.Insert(calendar).Execute();
                Console.WriteLine(createdCalendar.Id);
                CalendarId = createdCalendar.Id;

            }
            catch (Exception e)
            {
                Console.WriteLine("Chybajzna " + e);
            }
       

             // Definování parametrl requestu.
             EventsResource.ListRequest request = service.Events.List(CalendarId);
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            await PrijdejHromadneUdalosti(service);
        }

        /// <summary>
        /// Metoda pro hromadny import udalosti do google kalendare
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        async static Task PrijdejHromadneUdalosti (CalendarService service)
        {
            var request2 = new BatchRequest(service);
            foreach (var zaznam in Uzivatel.ZaznamyProGoogleKalendar)
            {
                request2.Queue<Event>(service.Events.Insert(
                  new Event
                  {
                      Summary = zaznam.Titulek,
                      Location = zaznam.MistoUrl,
                      Description = zaznam.Popis,
                      Start = new EventDateTime() { DateTime = zaznam.Start },
                      End = new EventDateTime() { DateTime = zaznam.Konec }
                  }, CalendarId),
                  (content, error, i, message) =>
                  {
                      // Put your callback code here.
                      Uzivatel.ChybovaHlaska = "Chyba behem importu do google kalendáře.";
                  });

            }

            await request2.ExecuteAsync();
        }
    }
}
