import CalendarMonthIcon from "@mui/icons-material/CalendarMonth";
import { Box, CircularProgress } from "@mui/material";
import React from "react";
import * as Router from "react-router-dom";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import PageHeader from "../../components/presentations/PageHeader";
import EmployeeService from "../../services/EmployeeService";
import Calendar from "./Calendar";

export default function CalendarIndex() {
  const [employee, setEmployee] = React.useState(null);
  const [isPending, setIsPending] = React.useState(true);

  const { employeeId } = Router.useParams();

  React.useEffect(() => {
    EmployeeService.get(employeeId)
      .then((response) => {
        setEmployee(response.data.result);
        setIsPending(false);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  const content =
    !employee && isPending ? (
      <Box sx={{ display: "flex", justifyContent: "center" }}>
        <CircularProgress />
      </Box>
    ) : (
      <>
        <Calendar employee={employee} />
      </>
    );

  return (
    <>
      <Header />
      {employee && !isPending && (
        <PageHeader
          icon={<CalendarMonthIcon fontSize="large" />}
          title="Leave Planning"
          subtitle={`The leave planning of the nurse <b>${employee.firstName}</b>.`}
        />
      )}
      <Main>{content}</Main>
    </>
  );
}
