function mapTeamsForSelectInput(teams) {
  return teams.map(function (team) {
    return { id: team.id, name: team.name };
  });
}

export { mapTeamsForSelectInput };
