export function getRandomColor() {
  var letters = "0123456789ABCDEF";
  var color = "#";
  for (var i = 0; i < 6; i++) {
    color += letters[Math.floor(Math.random() * 16)];
  }
  return color;
}

export function mapHolidaysToEvents(holidays) {
  var id = 0;
  return holidays.map((holiday) => {
    id += 1;
    return {
      id: id,
      title: holiday.name,
      start: holiday.date,
      allDay: true,
      color: getRandomColor(),
    };
  });
}
