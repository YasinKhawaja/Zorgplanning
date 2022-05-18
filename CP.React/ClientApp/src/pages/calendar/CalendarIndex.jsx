import { Grid, Skeleton, Typography } from "@mui/material";
import React from "react";
import * as Router from "react-router-dom";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import EmployeeService from "../../services/EmployeeService";
import Calendar from "./Calendar";

export default function CalendarIndex() {
  const [employee, setEmployee] = React.useState(null);

  const { employeeId } = Router.useParams();

  React.useEffect(() => {
    EmployeeService.get(employeeId)
      .then((response) => {
        setEmployee(response.data.result);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  return (
    <>
      <Header />
      <Main>
        {employee !== null ? (
          <>
            <Typography
              variant="h5"
              component="div"
              sx={{ marginBottom: "24px" }}
            >
              Verlofplanning van "{employee.firstName + " " + employee.lastName}
              "
            </Typography>
            <Calendar employee={employee} />
          </>
        ) : (
          <CalendarSkeleton />
        )}
      </Main>
    </>
  );
}

function CalendarSkeleton() {
  return (
    <Grid container spacing={2}>
      <Grid item xs={12}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={1}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={1}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={1}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={6}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={1}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={1}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      <Grid item xs={1}>
        <Skeleton animation="wave" variant="rectangular" height={35} />
      </Grid>
      {[...Array(6)].map((e, i) => (
        <React.Fragment key={i}>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
          <Grid item xs={1.714285714285714}>
            <Skeleton variant="rectangular" animation="wave" height={100} />
          </Grid>
        </React.Fragment>
      ))}
    </Grid>
  );
}
