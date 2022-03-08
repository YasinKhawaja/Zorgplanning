import CssBaseline from "@mui/material/CssBaseline";
import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";
import EmployeesCrud from "./employees/EmployeesCrud";
import { Home } from "./Home";
import { Main } from "./Main";
import { NavMenu } from "./NavMenu";
import TeamRoot from "./teams/TeamRoot";

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <>
        <CssBaseline />
        <Main>
          <Switch>
            <Route exact path="/">
              <NavMenu />
              <Home></Home>
            </Route>
            <Route exact path="/teams">
              <TeamRoot />
            </Route>
            <Route exact path="/teams/:teamId/employees">
              <EmployeesCrud />
            </Route>
          </Switch>
        </Main>
      </>
    );
  }
}
