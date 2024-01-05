using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Entities.Event;

namespace Infrastructure.Persistence.Configurations.Events
{
    internal class EventAgentConfiguration : IEntityTypeConfiguration<EventAgent>
    {
        public void Configure(EntityTypeBuilder<EventAgent> builder)
        {
            //throw new NotImplementedException();
        }
    }
}
