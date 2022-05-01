using Bocasay.Core.Events;
using Bocasay.Data.Dto.User;
using Bocasay.Data.SqlServer.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Domain.Events.UserEvents
{
	public class UpdateUserEvent : Event
	{ 
		public UserDto UserDto { get; set; }
	}
}
