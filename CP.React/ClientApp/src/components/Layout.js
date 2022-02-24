import CssBaseline from "@mui/material/CssBaseline";
import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";
import { Home } from "./Home";
import { Main as Main } from "./Main";
import { NavMenu } from "./NavMenu";
import { Teams } from "./teams/Teams";

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div>
        <CssBaseline />
        <NavMenu />
        <Main>
          <Switch>
            <Route exact path="/">
              <Home></Home>
            </Route>
            <Route exact path="/teams">
              <Teams></Teams>
            </Route>
            {/* <Route exact path="/s/:id">
              <Teams></Teams>
            </Route> */}
          </Switch>
        </Main>
      </div>
    );
  }
}
