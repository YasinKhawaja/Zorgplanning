import { Box, Button } from "@mui/material";
import React from "react";
import ReactExport from "react-export-excel";
import { getCountDaysInMonth } from "./planning-utils";

const ExcelFile = ReactExport.ExcelFile;
const ExcelSheet = ReactExport.ExcelFile.ExcelSheet;
const ExcelColumn = ReactExport.ExcelFile.ExcelColumn;

const nums = [];

export default function ExportExcel(props) {
  React.useEffect(() => {
    const daysCount = getCountDaysInMonth(
      props.planning.year,
      props.planning.month
    );
    for (let i = 1; i <= daysCount; i++) {
      nums.push(i);
    }
  }, []);

  return (
    props.planning && (
      <Box sx={{ marginBottom: "24px" }}>
        <ExcelFile
          element={
            <Button color="success" size="large" variant="contained">
              Export to Excel
            </Button>
          }
        >
          <ExcelSheet data={props.planning.team.employees} name="Planning">
            <ExcelColumn
              label="Nurse"
              value={(col) => `${col.firstName} ${col.lastName}`}
            />
            <ExcelColumn label="Regime" value={(col) => col.regime.hours} />
            {nums &&
              nums.map((day, i) => (
                <ExcelColumn
                  key={day}
                  label={day}
                  value={(col) =>
                    `${col.schedules[i].shift.start} - ${col.schedules[i].shift.end}`
                  }
                />
              ))}
          </ExcelSheet>
        </ExcelFile>
      </Box>
    )
  );
}
