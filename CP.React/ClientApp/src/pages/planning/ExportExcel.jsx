import { Box, Button } from "@mui/material";
import React from "react";
import ReactExport from "react-export-excel";
import { getMonthName } from "./planning-utils";

const ExcelFile = ReactExport.ExcelFile;
const ExcelSheet = ReactExport.ExcelFile.ExcelSheet;
const ExcelColumn = ReactExport.ExcelFile.ExcelColumn;

const useStyles = () => ({
  btnExportExcelDiv: { marginTop: "24px", marginBottom: "24px" },
});

export default function ExportExcel(props) {
  const { planning } = props;

  const classes = useStyles();

  const getFileName = () => {
    return (
      "Planning Team " +
      planning.team.name +
      " - " +
      getMonthName(planning.month) +
      " " +
      planning.year
    );
  };

  const getNurseName = (nurse) => {
    let nurseName = nurse.firstName + " " + nurse.lastName;
    if (nurse.isFixedNight) {
      nurseName += " (vaste nacht)";
    }
    return nurseName;
  };

  const getDayCellContent = (nurse, day) => {
    if (planning.holidays.includes(nurse.schedules[day].date)) {
      return "F";
    }

    const absence = nurse.absences.find(
      (absence) => absence.date === nurse.schedules[day].date
    );

    if (absence !== undefined) {
      switch (absence.type) {
        case "Leave":
          return "V";
        case "Sickness":
          return "Z";
        case "WorkingTimeReduction":
          return "A";
        default:
          break;
      }
    }

    if (nurse.schedules[day].shift.start === "00:00:00") {
      return "";
    }

    const startTime = nurse.schedules[day].shift.start.substring(0, 5);
    const endTime = nurse.schedules[day].shift.end.substring(0, 5);

    return startTime + "-" + endTime;
  };

  return (
    <Box sx={classes.btnExportExcelDiv}>
      <ExcelFile
        filename={getFileName()}
        element={
          <Button variant="contained" color="success" disableElevation>
            Exporteren naar Excel
          </Button>
        }
      >
        <ExcelSheet data={planning.team.employees} name="Planning">
          <ExcelColumn label="Zorgkundige" value={(col) => getNurseName(col)} />
          <ExcelColumn label="Regime" value={(col) => col.regime.hours} />
          {Array.from(Array(planning.days).keys()).map((day) => (
            <ExcelColumn
              key={day}
              label={day + 1}
              value={(col) => getDayCellContent(col, day)}
            />
          ))}
        </ExcelSheet>
      </ExcelFile>
    </Box>
  );
}
