import { Typography } from "@mui/material";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import HolidaysCalendar from "./HolidaysCalendar";

export default function HolidaysIndex() {
  return (
    <>
      <Header />
      <Main>
        <Typography variant="h4" borderBottom={1} borderColor="#DEE2E6">
          Feestdagen
        </Typography>
        <HolidaysCalendar />
      </Main>
    </>
  );
}
