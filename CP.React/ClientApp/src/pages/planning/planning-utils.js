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
  for (let i = 1; i <= 12; i++) {
    months.push({
      id: i,
      name: moment()
        .month(i - 1)
        .format("MMMM"),
    });
  }
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
