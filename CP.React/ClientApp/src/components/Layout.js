import React from "react";
import { Redirect, Route, Switch } from "react-router-dom";
import CalendarIndex from "../pages/calendar/CalendarIndex";
import Dashboard from "../pages/dashboard/Dashboard";
import EmployeesIndex from "../pages/employees/EmployeesIndex";
import HolidaysIndex from "../pages/holidays/HolidaysIndex";
import PlanningIndex from "../pages/planning/PlanningIndex";
import TeamsIndex from "../pages/teams/TeamsIndex";

export default function Layout() {
  return (
    <Switch>
      <Redirect exact from="/" to="/dashboard" />
      <Route
        exact
        path="/dashboard"
        render={(props) => (
          <React.Fragment key={props.location.key}>
            {/* <AuthenticatedTemplate> */}
            <Dashboard />
            {/* </AuthenticatedTemplate> */}
          </React.Fragment>
        )}
      />
      <Route
        exact
        path="/holidays"
        render={(props) => (
          <React.Fragment key={props.location.key}>
            {/* <AuthenticatedTemplate> */}
            <HolidaysIndex />
            {/* </AuthenticatedTemplate> */}
          </React.Fragment>
        )}
      />
      <Route
        exact
        path="/teams"
        render={(props) => (
          <React.Fragment key={props.location.key}>
            {/* <AuthenticatedTemplate> */}
            <TeamsIndex />
            {/* </AuthenticatedTemplate> */}
          </React.Fragment>
        )}
      />
      <Route
        exact
        path="/teams/:teamId/employees"
        render={(props) => (
          <React.Fragment key={props.location.key}>
            {/* <AuthenticatedTemplate> */}
            <EmployeesIndex />
            {/* </AuthenticatedTemplate> */}
          </React.Fragment>
        )}
      />
      <Route
        exact
        path="/teams/:teamId/employees/:employeeId/calendar"
        render={(props) => (
          <React.Fragment key={props.location.key}>
            {/* <AuthenticatedTemplate> */}
            <CalendarIndex />
            {/* </AuthenticatedTemplate> */}
          </React.Fragment>
        )}
      />
      <Route
        exact
        path="/planning"
        render={(props) => <PlanningIndex key={props.location.key} />}
      />
    </Switch>
  );
}
