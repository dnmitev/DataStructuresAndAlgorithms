// http://bgcoder.com/Contests/Practice/Index/133#9
namespace Occasions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    class Events
    {
        private const string End = "End";

        static void Main()
        {
            var result = new StringBuilder();
            var handler = new EventHandler();

            while (true)
            {
                var userLine = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                if (userLine[0] == End)
                {
                    break;
                }

                var data = userLine[0].Split(' ');

                switch (data[0])
                {
                    case "AddEvent":
                        {
                            var newEvent = new Event
                            {
                                Date = DateTime.Parse(data[1]),
                                Name = userLine[1],
                                Location = userLine.Length == 3 ? userLine[2] : null
                            };

                            handler.AddEvent(newEvent);
                            result.AppendLine("Event added");

                            break;
                        }
                    case "DeleteEvents":
                        {
                            var title = userLine[0].Substring(13);
                            var deletedCount = handler.DeleteEvent(title);

                            result.AppendLine(deletedCount > 0 ? string.Format("{0} events deleted", deletedCount) : "No events found");

                            break;
                        }
                    case "ListEvents":
                        {
                            var date = DateTime.Parse(data[1]);
                            var count = int.Parse(userLine[1]);

                            var events = handler.ListEvents(date, count);

                            if (events.FirstOrDefault() != null)
                            {
                                foreach (var e in events)
                                {
                                    result.AppendLine(e.ToString());
                                }
                            }
                            else
                            {
                                result.AppendLine("No events found");
                            }

                            break;
                        }
                    default:
                        break;
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }

    class Event : IComparable<Event>
    {
        public const string DateFormat = "yyyy-MM-ddTHH:mm:ss";

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
        public override string ToString()
        {
            string eventFormat = "{0:" + DateFormat + "} | {1}";
            if (Location != null)
            {
                eventFormat += " | {2}";
            }

            string eventAsString = String.Format(eventFormat, this.Date, this.Name, this.Location);

            return eventAsString;
        }

        public int CompareTo(Event other)
        {
            int compareResult = DateTime.Compare(this.Date, other.Date);
            if (compareResult == 0)
            {
                compareResult = string.Compare(this.Name, other.Name);
            }

            if (compareResult == 0)
            {
                compareResult = string.Compare(this.Location, other.Location);
            }

            return compareResult;
        }
    }

    class EventHandler
    {
        private OrderedMultiDictionary<DateTime, Event> eventsListByDate = new OrderedMultiDictionary<DateTime, Event>(true);
        private OrderedMultiDictionary<string, Event> eventsListByName = new OrderedMultiDictionary<string, Event>(true);

        public void AddEvent(Event ev)
        {
            var title = ev.Name.ToLower();
            eventsListByName.Add(title, ev);
            eventsListByDate.Add(ev.Date, ev);
        }

        public int DeleteEvent(string eventTitle)
        {
            string eventTitleLowerCase = eventTitle.ToLowerInvariant();
            var eventsToDelete = this.eventsListByName[eventTitleLowerCase];
            int deletedCount = eventsToDelete.Count;

            foreach (var e in eventsToDelete)
            {
                this.eventsListByDate.Remove(e.Date, e);
            }

            this.eventsListByName.Remove(eventTitleLowerCase);

            return deletedCount;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var matchedEvents =
                        from e in this.eventsListByDate.RangeFrom(date, true).Values
                        select e;
            var limitedMatchedEvents = matchedEvents.Take(count);
            return limitedMatchedEvents;
        }
    }
}