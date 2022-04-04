import React from "react";
import { Route, Switch } from "react-router-dom";
import CalendarIndex from "../pages/calendar/CalendarIndex";
import EmployeesIndex from "../pages/employees/EmployeesIndex";
import TeamsIndex from "../pages/teams/TeamsIndex";
import { Home } from "./Home";
import { NavMenu } from "./NavMenu";

export default function Layout() {
  return (
    <Switch>
      <Route exact path="/">
        <NavMenu />
        <Home />
      </Route>
      <Route exact path="/teams">
        <TeamsIndex />
      </Route>
      <Route exact path="/teams/:teamId/employees">
        <EmployeesIndex />
      </Route>
      <Route exact path="/teams/:teamId/employees/:employeeId/calendar">
        <CalendarIndex />
      </Route>
    </Switch>
  );
}
