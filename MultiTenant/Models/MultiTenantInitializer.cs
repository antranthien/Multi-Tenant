using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace MultiTenant.Models
{
    public class MultiTenantInitializer : DropCreateDatabaseAlways<MultiTenantContext>
    {
        protected override void Seed(MultiTenantContext context)
        {
            var tenants = new List<Tenant>
            {
                new Tenant
                {
                    Name = "SVC",
                    DomainName = "www.codecamp.com",
                    Default = true
                },
                new Tenant
                {
                    Name = "ANGU",
                    DomainName = "angularu.com",
                    Default = false
                },
                new Tenant
                {
                    Name = "CSSC",
                    DomainName = "codestarsubmit.com",
                    Default = false
                }
            };

            //   context.Tenants.AddRange(tenants);

            //context.SaveChanges();
        }

        private async Task CreateSpeakers(MultiTenantContext context)
        {
            var speakerJson = await GetEmbeddedResourceAsString("MultiTenant.speaker.json");

            JArray jsonValSpeakers = JArray.Parse(speakerJson);

            dynamic speakerData = jsonValSpeakers;

            foreach(var speaker in speakerData)
            {
                context.Speakers.Add(new Speaker
                {
                    PictureId = speaker.id,
                    FirstName = speaker.firstName,
                    LastName = speaker.lastName,
                    AllowHtml = speaker.allowHtml,
                    Bio = speaker.bio,
                    Website = speaker.website
                });
            }
        }

        private async Task CreateSessions(MultiTenantContext context)
        {
            var sessionJson = await GetEmbeddedResourceAsString("MultiTenant.session.json");

            var tenants = await context.Tenants.ToListAsync();

            JArray jsonValSessions = JArray.Parse(sessionJson);

            dynamic sessionData = jsonValSessions;

            var sessionTenantDict = new Dictionary<int, string>();


            foreach(var session in sessionData)
            {
                sessionTenantDict.Add((int)session.id, (string)session.tenantName);


            }
        }
        private async Task<string> GetEmbeddedResourceAsString(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string result;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using(var streamReader = new StreamReader(stream))
                {
                    result = await streamReader.ReadToEndAsync();
                }
            }

            return result;
        }
    }
}