import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";
import EmployeesIndex from "../pages/Employees/EmployeesIndex";
import { Home } from "./Home";
import Main from "./Main";
import { NavMenu } from "./NavMenu";
import TeamIndex from "./teams/TeamIndex";

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <Main>
        <Switch>
          <Route exact path="/">
            <NavMenu />
            <Home></Home>
          </Route>
          <Route exact path="/teams">
            <TeamIndex />
          </Route>
          <Route exact path="/teams/:teamId/employees">
            <EmployeesIndex />
          </Route>
        </Switch>
      </Main>
    );
  }
}
