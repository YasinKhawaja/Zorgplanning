import GroupsIcon from "@mui/icons-material/Groups";
import { Box, CircularProgress } from "@mui/material";
import React from "react";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import PageHeader from "../../components/presentations/PageHeader";
import TeamService from "../../services/TeamService";
import Teams from "./Teams";

const useStyles = () => ({
  progressWrap: { display: "flex", justifyContent: "center" },
});

export default function TeamsIndex() {
  const [teams, setTeams] = React.useState(null);
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

  const handleRefresh = () => {
    fetchTeams();
  };

  React.useEffect(() => {
    fetchTeams();
  }, [setTeams]);

  const classes = useStyles();

  const content = isPending ? (
    <Box sx={classes.progressWrap}>
      <CircularProgress />
    </Box>
  ) : (
    <Teams teams={teams} onRefresh={handleRefresh} />
  );

  return (
    <>
      <Header />
      <PageHeader
        icon={<GroupsIcon fontSize="large" />}
        title="Teams"
        subtitle="What team would you like to manage?"
      />
      <Main>{content}</Main>
    </>
  );
}
