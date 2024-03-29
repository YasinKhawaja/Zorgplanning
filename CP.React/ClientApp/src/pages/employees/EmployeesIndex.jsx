import { Typography } from "@mui/material";
import React from "react";
import { useParams } from "react-router-dom";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import TeamService from "../../services/TeamService";
import Employees from "./Employees";

export default function EmployeesIndex() {
  const [team, setTeam] = React.useState(null);

  const { teamId } = useParams();

  React.useEffect(() => {
    TeamService.get(teamId)
      .then((response) => {
        setTeam(response.data.result);
      })
      .catch((error) => console.error(error));
  }, []);

  return (
    <>
      <Header />
      {team && (
        <Main>
          <Typography variant="h4" borderBottom={1} borderColor="#DEE2E6">
            Zorgkundigen in {team.name}
          </Typography>
          <Employees team={team} />
        </Main>
      )}
    </>
  );
}
