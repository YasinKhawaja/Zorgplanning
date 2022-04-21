import { AuthenticatedTemplate } from "@azure/msal-react";
import React from "react";
import { Route, Switch } from "react-router-dom";
import CalendarIndex from "../pages/calendar/CalendarIndex";
import EmployeesIndex from "../pages/employees/EmployeesIndex";
import HolidaysIndex from "../pages/holidays/HolidaysIndex";
import PlanningIndex from "../pages/planning/PlanningIndex";
import TeamsIndex from "../pages/teams/TeamsIndex";
import ProfileContent from "./authentication/msgraphapi/ProfileContent";
import Home from "./Home";
import NavMenu from "./NavMenu";
import Header from "../components/presentations/Header";

export default function Layout() {
  return (
    <Switch>
      <Route exact path="/">
        <NavMenu />
        <Home />
      </Route>
      <Route exact path="/my">
        <AuthenticatedTemplate>
          <ProfileContent />
        </AuthenticatedTemplate>
      </Route>
      <Route exact path="/holidays">
        <AuthenticatedTemplate>
          <HolidaysIndex />
        </AuthenticatedTemplate>
      </Route>
      <Route exact path="/teams">
        <AuthenticatedTemplate>
          <TeamsIndex />
        </AuthenticatedTemplate>
      </Route>
      <Route exact path="/teams/:teamId/employees">
        <AuthenticatedTemplate>
          <EmployeesIndex />
        </AuthenticatedTemplate>
      </Route>
      <Route exact path="/teams/:teamId/employees/:employeeId/calendar">
        <AuthenticatedTemplate>
          <CalendarIndex />
        </AuthenticatedTemplate>
      </Route>
      <Route
        exact
        path="/planning"
        render={(props) => (
          <PlanningIndex key={props.location.key} {...props} />
        )}
      />
    </Switch>
  );
}
