import { Typography } from "@mui/material";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import Teams from "./Teams";

export default function TeamsIndex() {
  return (
    <>
      <Header />
      <Main>
        <Typography variant="h4" borderBottom={1} borderColor="#DEE2E6">
          Teams
        </Typography>
        <Teams />
      </Main>
    </>
  );
}
