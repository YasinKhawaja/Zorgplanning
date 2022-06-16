import { Route, Switch } from "react-router-dom";
import AbsencesIndex from "../pages/absences/AbsencesIndex";
import Dashboard from "../pages/dashboard/Dashboard";
import EmployeesIndex from "../pages/employees/EmployeesIndex";
import HolidaysIndex from "../pages/holidays/HolidaysIndex";
import PlanningIndex from "../pages/planning/PlanningIndex";
import TeamsIndex from "../pages/teams/TeamsIndex";

export default function Layout() {
  return (
    <Switch>
      <Route
        exact
        path="/"
        render={(props) => <Dashboard key={props.location.key} />}
      />
      <Route
        exact
        path="/holidays"
        render={(props) => <HolidaysIndex key={props.location.key} />}
      />
      <Route
        exact
        path="/teams"
        render={(props) => <TeamsIndex key={props.location.key} />}
      />
      <Route
        exact
        path="/teams/:teamId/employees"
        render={(props) => <EmployeesIndex key={props.location.key} />}
      />
      <Route
        exact
        path="/teams/:teamId/employees/:employeeId/calendar"
        render={(props) => <AbsencesIndex key={props.location.key} />}
      />
      <Route
        exact
        path="/planning"
        render={(props) => <PlanningIndex key={props.location.key} />}
      />
    </Switch>
  );
}
