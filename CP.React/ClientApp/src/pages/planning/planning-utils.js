import moment from "moment";

export function mapTeamsForSelectInput(teams) {
  return teams.map((team) => {
    return { id: team.id, name: team.name };
  });
}

export function getYearsForSelectInput(year) {
  const years = [];
  years.push({ id: year, name: String(year) });
  for (let i = 1; i <= 5; i++) {
    years.push({ id: year - i, name: String(year - i) });
    years.push({ id: year + i, name: String(year + i) });
  }
  years.sort((a, b) => {
    return a.id - b.id;
  });
  return years;
}

export function getMonthsForSelectInput() {
  const months = [];
  months.push({ id: 1, name: "Januari" });
  months.push({ id: 2, name: "Februari" });
  months.push({ id: 3, name: "Maart" });
  months.push({ id: 4, name: "April" });
  months.push({ id: 5, name: "Mei" });
  months.push({ id: 6, name: "Juni" });
  months.push({ id: 7, name: "Juli" });
  months.push({ id: 8, name: "Augustus" });
  months.push({ id: 9, name: "September" });
  months.push({ id: 10, name: "Oktober" });
  months.push({ id: 11, name: "November" });
  months.push({ id: 12, name: "December" });
  return months;
}

export function areAllKeysPopulated(obj) {
  return Object.keys(obj).every((key) => {
    return obj[key] !== "";
  });
}

export function getCountDaysInMonth(year, month) {
  return moment(`${year}-${month}`, "YYYY-MM").daysInMonth();
}

export function getOptionById(options, id) {
  return options.find((option) => option.id === id);
}

export function isDayNumberAWeekendDay(year, month, day) {
  const date = new Date(year, month, day);
  return date.getDay() === 0 || date.getDay() === 6;
}

export function getWeekendsInMonth(year, month, days) {
  const weekends = [];
  const startDate = moment(`${year}-${month}-01`);
  const endDate = moment(`${year}-${month}-${days}`);
  const daysInMonth = endDate.diff(startDate, "days");
  for (let i = 0; i < daysInMonth; i++) {
    const day = moment(startDate).add(i, "days");
    if (day.day() === 0 || day.day() === 6) {
      weekends.push(day.date());
    }
  }
  return weekends;
}

export function getMonthName(month) {
  switch (month) {
    case 1:
      return "Januari";
    case 2:
      return "Februari";
    case 3:
      return "Maart";
    case 4:
      return "April";
    case 5:
      return "Mei";
    case 6:
      return "Juni";
    case 7:
      return "Juli";
    case 8:
      return "Augustus";
    case 9:
      return "September";
    case 10:
      return "Oktober";
    case 11:
      return "November";
    case 12:
      return "December";
    default:
      return "";
  }
}
