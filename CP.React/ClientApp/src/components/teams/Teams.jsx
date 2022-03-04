import PeopleAltIcon from "@mui/icons-material/PeopleAlt";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import CircularProgress from "@mui/material/CircularProgress";
import Container from "@mui/material/Container";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import React, { Component } from "react";
import TeamForm from "./TeamForm";

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

    let content = loading ? <CircularProgress /> : this.renderTeamsList(teams);

    return (
      <Container sx={{ marginTop: 1, marginBottom: 1 }}>
        <Box>
          <h1>Teams</h1>
          <p>What team would you like to manage?</p>
        </Box>
        <Box>{content}</Box>
        <Box sx={{ marginTop: 1 }}>
          <Button variant="contained" disableElevation>
            ADD
          </Button>
          <TeamForm />
        </Box>
      </Container>
    );
  }

  renderTeamsList(teams) {
    return (
      <List sx={{ border: 1, borderColor: "primary.main" }}>
        {teams.map((team) => this.renderTeamItem(team))}
      </List>
    );
  }

  renderTeamItem(team) {
    return (
      <ListItem key={team.id} disablePadding>
        <ListItemButton component="a" href={`/teams/${team.id}/employees`}>
          <ListItemIcon sx={{ minWidth: "40px" }}>
            <PeopleAltIcon color="primary" />
          </ListItemIcon>
          <ListItemText primary={team.name} />
        </ListItemButton>
      </ListItem>
    );
  }

  async populateTeamsData() {
    const response = await fetch("api/teams");
    const data = await response.json();
    const result = data.result;
    this.setState({ teams: result, loading: false });
  }
}
