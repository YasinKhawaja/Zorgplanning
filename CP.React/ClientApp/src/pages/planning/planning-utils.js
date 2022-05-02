import axios from "axios";
import { saveAs } from "file-saver";
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
