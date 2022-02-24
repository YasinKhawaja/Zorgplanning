import PeopleAltIcon from "@mui/icons-material/PeopleAlt";
import Container from "@mui/material/Container";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import React, { Component } from "react";

export class Teams extends Component {
  static displayName = Teams.name;

  constructor(props) {
    super(props);
    this.state = { teams: [], loading: true };
  }

  componentDidMount() {
    this.populateTeamsData();
  }

  render() {
    const { teams, loading } = this.state;

    let content = loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      this.renderTeamsList(teams)
    );

    return (
      <Container maxWidth="sm" sx={{ textAlign: "center" }}>
        <h1>Teams</h1>
        {content}
      </Container>
    );
  }

  renderTeamsList(teams) {
    return (
      <nav aria-label="main mailbox folders">
        {teams.map}
        <List>{teams.map((team) => this.renderTeamItem(team))}</List>
      </nav>
    );
  }

  renderTeamItem(team) {
    return (
      <React.Fragment>
        <ListItem disablePadding>
          <ListItemButton
            divider="true"
            component="a"
            href={`/teams/${team.id}`}
          >
            <ListItemIcon sx={{ minWidth: "40px" }}>
              <PeopleAltIcon color="primary" />
            </ListItemIcon>
            <ListItemText primary={team.name} />
          </ListItemButton>
        </ListItem>
        {/* <Divider variant="inset" component="li" /> */}
      </React.Fragment>
    );
  }

  async populateTeamsData() {
    const response = await fetch("api/teams");
    const data = await response.json();
    const result = data.result;
    this.setState({ teams: result, loading: false });
  }
}
