import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import React from "react";
import { getWeekendsInMonth } from "./planning-utils";

export default function PlanningTable(props) {
  const { planning } = props;

  const weekends = getWeekendsInMonth(
    planning.year,
    planning.month,
    planning.days
  );

  const getStyles = (employee, schedule) => {
    var styles = {};

    if (schedule.shift.start === "00:00:00") {
      styles.color = "#FFFFFF !important";
    }

    if (
      weekends.includes(new Date(schedule.date).getDate()) &&
      schedule.shift.start === "00:00:00"
    ) {
      styles.backgroundColor = "#C0C0C0 !important";
      styles.color = "#C0C0C0 !important";
    } else if (
      weekends.includes(new Date(schedule.date).getDate()) &&
      schedule.shift.start !== "00:00:00"
    ) {
      styles.backgroundColor = "#C0C0C0 !important";
    }

    if (planning.holidays.includes(schedule.date)) {
      styles.color = "#FF00FF !important";
    }

    const absence = employee.absences.find(
      (absence) => absence.date === schedule.date
    );

    if (absence !== undefined) {
      switch (absence.type) {
        case "Leave":
          styles.color = "#00FF00 !important";
          break;
        case "Sickness":
          styles.color = "#FF0000 !important";
          break;
        case "WorkingTimeReduction":
          styles.color = "#0000FF !important";
          break;
        default:
          break;
      }
    }

    return styles;
  };

  const getTableCellContent = (employee, schedule) => {
    const absence = employee.absences.find(
      (absence) => absence.date === schedule.date
    );

    if (planning.holidays.includes(schedule.date)) {
      return <h3 style={{ marginBottom: "0px" }}>F</h3>;
    }

    if (absence !== undefined) {
      switch (absence.type) {
        case "Leave":
          return <h3 style={{ marginBottom: "0px" }}>V</h3>;
        case "Sickness":
          return <h3 style={{ marginBottom: "0px" }}>Z</h3>;
        case "WorkingTimeReduction":
          return <h3 style={{ marginBottom: "0px" }}>A</h3>;
        default:
          break;
      }
    }

    if (schedule.shift.start === "00:00:00") {
      return <></>;
    }

    const startTime = schedule.shift.start.substring(0, 5);
    const endTime = schedule.shift.end.substring(0, 5);

    return `${startTime}-${endTime}`;
  };

  return (
    <TableContainer>
      <Table
        className="table table-hover"
        sx={{ minWidth: 650 }}
        aria-label="simple table"
      >
        <TableHead>
          <TableRow>
            <TableCell align="left">Zorgkundige</TableCell>
            <TableCell align="center">Regime</TableCell>
            {Array.from(Array(planning.days).keys()).map((day) => (
              <TableCell
                key={day}
                align="center"
                sx={
                  weekends.includes(day + 1)
                    ? { backgroundColor: "#C0C0C0 !important" }
                    : null
                }
              >
                {day + 1}
              </TableCell>
            ))}
          </TableRow>
        </TableHead>
        <TableBody>
          {planning.team.employees.map((emp) => (
            <TableRow
              key={emp.id}
              sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
            >
              <TableCell
                component="th"
                scope="row"
                sx={{ whiteSpace: "nowrap" }}
              >
                {emp.firstName}&nbsp;{emp.lastName}&nbsp;
                {emp.isFixedNight ? "(vaste nacht)" : ""}
              </TableCell>
              <TableCell align="center">{emp.regime.hours}</TableCell>
              {emp.schedules.map((sch, i) => (
                <TableCell key={i} align="center" sx={getStyles(emp, sch)}>
                  {getTableCellContent(emp, sch)}
                </TableCell>
              ))}
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
