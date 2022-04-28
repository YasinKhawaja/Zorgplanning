import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import React from "react";
import Header from "../../components/presentations/Header";
import Main from "../../components/presentations/Main";
import ExportExcel from "./ExportExcel";
import { areAllKeysPopulated, getCountDaysInMonth } from "./planning-utils";
import PlanningWizard from "./PlanningWizard";

const dayNums = [];

function PlanningIndex() {
  const [isMounted, setIsMounted] = React.useState(false);
  const [planningValues, setPlanningValues] = React.useState({});
  const [showTable, setShowTable] = React.useState(false);

  React.useEffect(() => {
    setIsMounted(true);
  }, []);

  React.useEffect(() => {
    if (isMounted) {
      if (areAllKeysPopulated(planningValues)) {
        for (
          let i = 1;
          i <= getCountDaysInMonth(planningValues.year, planningValues.month);
          i++
        ) {
          dayNums.push(i);
        }
        setShowTable(true);
      }
    }
  }, [planningValues]);

  return (
    <React.Fragment>
      <Header />
      <Main>
        {showTable ? (
          <>
            <TableContainer component={Paper}>
              <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                  <TableRow>
                    <TableCell align="right">Nurse</TableCell>
                    <TableCell align="right">Regime</TableCell>
                    {dayNums.map((day) => (
                      <TableCell align="right">{day}</TableCell>
                    ))}
                  </TableRow>
                </TableHead>
                <TableBody>
                  {data.map((x) => (
                    <TableRow
                      key={x.employee.name}
                      sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                    >
                      <TableCell component="th" scope="row">
                        {x.employee.name}
                      </TableCell>
                      <TableCell align="right">{x.employee.regime}</TableCell>
                      {x.schedules.map((s) => (
                        <TableCell align="right">{`${s.start} - ${s.end}`}</TableCell>
                      ))}
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
            <ExportExcel data={data} />
          </>
        ) : (
          <PlanningWizard onChangePlanningValues={setPlanningValues} />
        )}
      </Main>
    </React.Fragment>
  );
}

const data = [
  {
    employee: { name: "Yasin1", regime: "38" },
    schedules: [
      { date: "1", start: "08:00", end: "12:00" },
      { date: "2", start: "08:00", end: "12:00" },
      { date: "3", start: "08:00", end: "12:00" },
      { date: "4", start: "08:00", end: "12:00" },
      { date: "5", start: "08:00", end: "12:00" },
      { date: "6", start: "08:00", end: "12:00" },
      { date: "7", start: "08:00", end: "12:00" },
      { date: "8", start: "08:00", end: "12:00" },
      { date: "9", start: "08:00", end: "12:00" },
      { date: "10", start: "08:00", end: "12:00" },
      { date: "11", start: "08:00", end: "12:00" },
      { date: "12", start: "08:00", end: "12:00" },
      { date: "13", start: "08:00", end: "12:00" },
      { date: "14", start: "08:00", end: "12:00" },
      { date: "15", start: "08:00", end: "12:00" },
      { date: "16", start: "08:00", end: "12:00" },
      { date: "17", start: "08:00", end: "12:00" },
      { date: "18", start: "08:00", end: "12:00" },
      { date: "19", start: "08:00", end: "12:00" },
      { date: "20", start: "08:00", end: "12:00" },
      { date: "21", start: "08:00", end: "12:00" },
      { date: "22", start: "08:00", end: "12:00" },
      { date: "23", start: "08:00", end: "12:00" },
      { date: "24", start: "08:00", end: "12:00" },
      { date: "25", start: "08:00", end: "12:00" },
      { date: "26", start: "08:00", end: "12:00" },
      { date: "27", start: "08:00", end: "12:00" },
      { date: "28", start: "08:00", end: "12:00" },
      { date: "29", start: "08:00", end: "12:00" },
      { date: "30", start: "08:00", end: "12:00" },
    ],
  },
  {
    employee: { name: "Yasin2", regime: "38" },
    schedules: [
      { date: "1", start: "08:00", end: "12:00" },
      { date: "2", start: "08:00", end: "12:00" },
      { date: "3", start: "08:00", end: "12:00" },
      { date: "4", start: "08:00", end: "12:00" },
      { date: "5", start: "08:00", end: "12:00" },
      { date: "6", start: "08:00", end: "12:00" },
      { date: "7", start: "08:00", end: "12:00" },
      { date: "8", start: "08:00", end: "12:00" },
      { date: "9", start: "08:00", end: "12:00" },
      { date: "10", start: "08:00", end: "12:00" },
      { date: "11", start: "08:00", end: "12:00" },
      { date: "12", start: "08:00", end: "12:00" },
      { date: "13", start: "08:00", end: "12:00" },
      { date: "14", start: "08:00", end: "12:00" },
      { date: "15", start: "08:00", end: "12:00" },
      { date: "16", start: "08:00", end: "12:00" },
      { date: "17", start: "08:00", end: "12:00" },
      { date: "18", start: "08:00", end: "12:00" },
      { date: "19", start: "08:00", end: "12:00" },
      { date: "20", start: "08:00", end: "12:00" },
      { date: "21", start: "08:00", end: "12:00" },
      { date: "22", start: "08:00", end: "12:00" },
      { date: "23", start: "08:00", end: "12:00" },
      { date: "24", start: "08:00", end: "12:00" },
      { date: "25", start: "08:00", end: "12:00" },
      { date: "26", start: "08:00", end: "12:00" },
      { date: "27", start: "08:00", end: "12:00" },
      { date: "28", start: "08:00", end: "12:00" },
      { date: "29", start: "08:00", end: "12:00" },
      { date: "30", start: "08:00", end: "12:00" },
    ],
  },
  {
    employee: { name: "Yasin3", regime: "38" },
    schedules: [
      { date: "1", start: "08:00", end: "12:00" },
      { date: "2", start: "08:00", end: "12:00" },
      { date: "3", start: "08:00", end: "12:00" },
      { date: "4", start: "08:00", end: "12:00" },
      { date: "5", start: "08:00", end: "12:00" },
      { date: "6", start: "08:00", end: "12:00" },
      { date: "7", start: "08:00", end: "12:00" },
      { date: "8", start: "08:00", end: "12:00" },
      { date: "9", start: "08:00", end: "12:00" },
      { date: "10", start: "08:00", end: "12:00" },
      { date: "11", start: "08:00", end: "12:00" },
      { date: "12", start: "08:00", end: "12:00" },
      { date: "13", start: "08:00", end: "12:00" },
      { date: "14", start: "08:00", end: "12:00" },
      { date: "15", start: "08:00", end: "12:00" },
      { date: "16", start: "08:00", end: "12:00" },
      { date: "17", start: "08:00", end: "12:00" },
      { date: "18", start: "08:00", end: "12:00" },
      { date: "19", start: "08:00", end: "12:00" },
      { date: "20", start: "08:00", end: "12:00" },
      { date: "21", start: "08:00", end: "12:00" },
      { date: "22", start: "08:00", end: "12:00" },
      { date: "23", start: "08:00", end: "12:00" },
      { date: "24", start: "08:00", end: "12:00" },
      { date: "25", start: "08:00", end: "12:00" },
      { date: "26", start: "08:00", end: "12:00" },
      { date: "27", start: "08:00", end: "12:00" },
      { date: "28", start: "08:00", end: "12:00" },
      { date: "29", start: "08:00", end: "12:00" },
      { date: "30", start: "08:00", end: "12:00" },
    ],
  },
  {
    employee: { name: "Yasin4", regime: "38" },
    schedules: [
      { date: "1", start: "08:00", end: "12:00" },
      { date: "2", start: "08:00", end: "12:00" },
      { date: "3", start: "08:00", end: "12:00" },
      { date: "4", start: "08:00", end: "12:00" },
      { date: "5", start: "08:00", end: "12:00" },
      { date: "6", start: "08:00", end: "12:00" },
      { date: "7", start: "08:00", end: "12:00" },
      { date: "8", start: "08:00", end: "12:00" },
      { date: "9", start: "08:00", end: "12:00" },
      { date: "10", start: "08:00", end: "12:00" },
      { date: "11", start: "08:00", end: "12:00" },
      { date: "12", start: "08:00", end: "12:00" },
      { date: "13", start: "08:00", end: "12:00" },
      { date: "14", start: "08:00", end: "12:00" },
      { date: "15", start: "08:00", end: "12:00" },
      { date: "16", start: "08:00", end: "12:00" },
      { date: "17", start: "08:00", end: "12:00" },
      { date: "18", start: "08:00", end: "12:00" },
      { date: "19", start: "08:00", end: "12:00" },
      { date: "20", start: "08:00", end: "12:00" },
      { date: "21", start: "08:00", end: "12:00" },
      { date: "22", start: "08:00", end: "12:00" },
      { date: "23", start: "08:00", end: "12:00" },
      { date: "24", start: "08:00", end: "12:00" },
      { date: "25", start: "08:00", end: "12:00" },
      { date: "26", start: "08:00", end: "12:00" },
      { date: "27", start: "08:00", end: "12:00" },
      { date: "28", start: "08:00", end: "12:00" },
      { date: "29", start: "08:00", end: "12:00" },
      { date: "30", start: "08:00", end: "12:00" },
    ],
  },
  {
    employee: { name: "Yasin5", regime: "38" },
    schedules: [
      { date: "1", start: "08:00", end: "12:00" },
      { date: "2", start: "08:00", end: "12:00" },
      { date: "3", start: "08:00", end: "12:00" },
      { date: "4", start: "08:00", end: "12:00" },
      { date: "5", start: "08:00", end: "12:00" },
      { date: "6", start: "08:00", end: "12:00" },
      { date: "7", start: "08:00", end: "12:00" },
      { date: "8", start: "08:00", end: "12:00" },
      { date: "9", start: "08:00", end: "12:00" },
      { date: "10", start: "08:00", end: "12:00" },
      { date: "11", start: "08:00", end: "12:00" },
      { date: "12", start: "08:00", end: "12:00" },
      { date: "13", start: "08:00", end: "12:00" },
      { date: "14", start: "08:00", end: "12:00" },
      { date: "15", start: "08:00", end: "12:00" },
      { date: "16", start: "08:00", end: "12:00" },
      { date: "17", start: "08:00", end: "12:00" },
      { date: "18", start: "08:00", end: "12:00" },
      { date: "19", start: "08:00", end: "12:00" },
      { date: "20", start: "08:00", end: "12:00" },
      { date: "21", start: "08:00", end: "12:00" },
      { date: "22", start: "08:00", end: "12:00" },
      { date: "23", start: "08:00", end: "12:00" },
      { date: "24", start: "08:00", end: "12:00" },
      { date: "25", start: "08:00", end: "12:00" },
      { date: "26", start: "08:00", end: "12:00" },
      { date: "27", start: "08:00", end: "12:00" },
      { date: "28", start: "08:00", end: "12:00" },
      { date: "29", start: "08:00", end: "12:00" },
      { date: "30", start: "08:00", end: "12:00" },
    ],
  },
];

export default PlanningIndex;
