import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";
import AbsencesIndex from "../pages/absences/AbsencesIndex";
import EmployeesIndex from "../pages/employees/EmployeesIndex";
import TeamsIndex from "../pages/teams/TeamsIndex";
import { Home } from "./Home";
import { NavMenu } from "./NavMenu";

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
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
        <Route exact path="/absences">
          <AbsencesIndex />
        </Route>
      </Switch>
    );
  }
}
