import Box from "@mui/material/Box";
import CircularProgress from "@mui/material/CircularProgress";
import Container from "@mui/material/Container";
import { React, useEffect, useState } from "react";
import TeamAddEdit from "./TeamAddEdit";
import TeamList from "./TeamList";

export default function TeamRoot() {
  const [teams, setTeams] = useState([]);
  const [isPending, setIsPending] = useState(true);

  useEffect(() => {
    fetch("api/teams")
      .then((response) => {
        if (!response.ok) {
          throw Error("SOMETHING WENT WRONG");
        }
        return response.json();
      })
      .then((data) => {
        setTeams(data.result);
        setIsPending(false);
        // setError(null);
      })
      .catch((error) => {
        if (error.name === "AbortError") {
          console.error("FETCH ABORTED");
        } else {
          setIsPending(false);
          // setError(error.message);
        }
      });
  }, []);

  const content = isPending ? <CircularProgress /> : <TeamList teams={teams} />;

  return (
    <Container maxWidth="sm" sx={{ marginTop: 2, marginBottom: 2 }}>
      <Box sx={{ textAlign: "center", marginBottom: 2 }}>
        <h1>Teams</h1>
        <p>What team would you like to manage?</p>
      </Box>
      <Box sx={{ textAlign: "center" }}>{content}</Box>
      <TeamAddEdit team={null} edit="false" />
    </Container>
  );
}
