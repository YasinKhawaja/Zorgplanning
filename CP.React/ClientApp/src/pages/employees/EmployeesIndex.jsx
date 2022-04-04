import PeopleAltIcon from "@mui/icons-material/PeopleAlt";
import React from "react";
import { useParams } from "react-router-dom";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import PageHeader from "../../components/presentations/PageHeader";
import TeamService from "../../services/TeamService";
import Employees from "./Employees";

export default function EmployeesIndex() {
  const [team, setTeam] = React.useState(null);
  const [isPending, setIsPending] = React.useState(true);

  const { teamId } = useParams();
  React.useEffect(() => {
    TeamService.get(teamId)
      .then((response) => {
        setTeam(response.data.result);
        setIsPending(false);
      })
      .catch((error) => console.error(error));
  }, []);

  return (
    <>
      <Header />
      {!isPending && (
        <>
          <PageHeader
            icon={<PeopleAltIcon fontSize="large" />}
            title="Nurses"
            subtitle={`All nurses in team ${team.name}.`}
          />
          <Main>
            <Employees team={team} />
          </Main>
        </>
      )}
    </>
  );
}
