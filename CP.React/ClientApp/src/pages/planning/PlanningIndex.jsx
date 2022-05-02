import {
  Box,
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
import PlanningWizard from "./PlanningWizard";

export default function PlanningIndex() {
  const [isMounted, setIsMounted] = React.useState(false);
  const [showTable, setShowTable] = React.useState(false);
  const [planning, setPlanning] = React.useState(null);

  React.useEffect(() => {
    setIsMounted(true);
  }, []);

  const handleGeneratePlanning = (values) => {
    fetch("https://localhost:44428/api/planning", {
      method: "POST",
      body: JSON.stringify(values),
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then(() => {
        fetch(
          `https://localhost:44428/api/planning?teamId=${values.teamId}&year=${values.year}&month=${values.month}`,
          { method: "GET" }
        )
          .then((response) => response.json())
          .then((data) => {
            const planning = data.result;
            setPlanning(planning);
            setShowTable(true);
          })
          .catch((error) => {
            console.log(error);
          });
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <React.Fragment>
      <Header />
      <Main>
        {showTable && planning ? (
          <>
            <Box sx={{ marginBottom: "24px" }}>
              <ExportExcel planning={planning} />
            </Box>
            <TableContainer component={Paper}>
              <Table sx={{ minWidth: 650 }} aria-label="simple table">
                <TableHead>
                  <TableRow>
                    <TableCell align="left">Nurse</TableCell>
                    <TableCell align="center">Regime</TableCell>
                    {planning.employees[0].schedules.map((s, i) => (
                      <TableCell key={i} align="center">
                        {i + 1}
                      </TableCell>
                    ))}
                  </TableRow>
                </TableHead>
                <TableBody>
                  {planning.employees.map((emp) => (
                    <TableRow
                      key={emp.id}
                      sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
                    >
                      <TableCell component="th" scope="row">
                        {emp.firstName}&nbsp;
                        {emp.lastName}
                      </TableCell>
                      <TableCell align="center">{emp.regime.hours}</TableCell>
                      {emp.schedules.map((s) => (
                        <TableCell align="center">{`${s.shift.start.substring(
                          0,
                          5
                        )}-${s.shift.end.substring(0, 5)}`}</TableCell>
                      ))}
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
          </>
        ) : (
          <PlanningWizard onGeneratePlanning={handleGeneratePlanning} />
        )}
      </Main>
    </React.Fragment>
  );
}
