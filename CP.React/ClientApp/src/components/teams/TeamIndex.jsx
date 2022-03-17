import { Box } from "@mui/material";
import CircularProgress from "@mui/material/CircularProgress";
import Container from "@mui/material/Container";
import React from "react";
import TeamService from "../../services/TeamService";
import Title from "../presentations/Title";
import TeamCrud from "./TeamCrud";

export default function TeamIndex() {
  const [teams, setTeams] = React.useState([]);
  const [isPending, setIsPending] = React.useState(true);

  const fetchTeams = () => {
    TeamService.getAll()
      .then((response) => {
        setTeams(response.data.result);
        setIsPending(false);
      })
      .catch((error) => {
        console.error(error);
      });
  };

  React.useEffect(() => {
    fetchTeams();
  }, [setTeams]);

  const handleRefresh = () => {
    fetchTeams();
  };

  const content = isPending ? (
    <CircularProgress />
  ) : (
    <TeamCrud teams={teams} onRefresh={handleRefresh} />
  );

  return (
    <Container maxWidth="sm" sx={{ marginTop: 5, marginBottom: 5 }}>
      <Title primary="Teams" secondary="What team would you like to manage?" />
      <Box sx={{ textAlign: "center" }}>{content}</Box>
    </Container>
  );
}
