import moment from "moment";

function mapTeamsForSelectInput(teams) {
  return teams.map((team) => {
    return { id: team.id, name: team.name };
  });
}

function getYearsForSelectInput(year) {
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

function getMonthsForSelectInput() {
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

export {
  mapTeamsForSelectInput,
  getYearsForSelectInput,
  getMonthsForSelectInput,
};
