using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behavious;

public class EventIds
{
	public static EventId Application = new EventId(1, "APPLICATION");
	public static EventId CommandExecuting = new EventId(2, "COMMAND EXECUTING");
	public static EventId CommandStart = new EventId(3, "COMMAND START");
	public static EventId CommandEnd = new EventId(4, "COMMAND END");
	public static EventId QueryExecuting = new EventId(5, "QUERY EXECUTING");
	public static EventId QueryStart = new EventId(6, "QUERY START");
	public static EventId QueryEnd = new EventId(7, "QUERY END");
	public static EventId ValidationStart = new EventId(8, "VALIDATION START");
	public static EventId ValidationExecuting = new EventId(9, "VALIDATION EXECUTING");
	public static EventId ValidationEnd = new EventId(10, "VALIDATION END");
	public static EventId DomainEvent = new EventId(11, "DOMAIN EVENT");
	public static EventId HttpRequest = new EventId(12, "HTTP REQUEST");
	public static EventId HttpResponse = new EventId(13, "HTTP RESPONSE");
	public static EventId FGM = new EventId(14, "FGM");
	public static EventId Sejam = new EventId(15, "SEJAM");
	public static EventId CacheSet = new EventId(16, "CACHE SET");
	public static EventId CacheGet = new EventId(17, "CACHE GET");
	public static EventId CacheRemove = new EventId(18, "CACHE REMOVE");
	public static EventId Encrypt = new EventId(19, "ENCRYPT");
	public static EventId Decrypt = new EventId(20, "DECRYPT");
	public static EventId Transaction = new EventId(21, "TRANSACTION");
	public static EventId Exception = new EventId(22, "EXCEPTION");
	public static EventId AS400 = new EventId(23, "AS400");
}
