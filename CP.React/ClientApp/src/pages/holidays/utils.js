export function mapHolidaysToEvents(holidays) {
  var id = 0;
  return holidays.map((holiday) => {
    id += 1;
    return {
      id: id,
      title: holiday.name,
      start: holiday.date,
      allDay: true,
      color: "#FF00FF",
    };
  });
}
